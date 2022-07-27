import React, { useState, useEffect } from 'react'
import { v4 as uuid } from 'uuid';
import { toast } from 'react-toastify';
import Spinner from 'react-bootstrap/Spinner';

import { useSearchParams, useNavigate, createSearchParams } from "react-router-dom";
import { useUniqueId } from '../../../util/GenerateUniqueId'
import { allSequencesHaveValues } from '../../../util/SequenceTextCheck'

import DisplaySimple from './DisplaySimple'
import DisplayAdvanced from './DisplayAdvanced'

const PlotHome = (
    {
        userInfo,
        mode
    }
) => {

    const toastSaveId = 'save-status'

    const notify = (msg, type) => {
        toast(msg, {
            toastId: toastSaveId,
            type: type,
            autoClose: false
        });

        toast.update(toastSaveId, {
            render: msg,
            type: type,
            autoClose: false
        });
    }

    const [displayMode, setDisplayMode] = useState('simple') // options are "simple" and "advanced"

    const [logLineDescription, setLogLineDescription] = useState('')
    const [AILogLineDescriptions, setAILogLineDescriptions] = useState(null)
    const [title, setTitle] = useState('')
    const [AITitles, setAITitles] = useState(null)
    const [genres, setGenres] = useState('')
    const [problemTemplate, setProblemTemplate] = useState('')
    const [keywords, setKeywords] = useState([])
    const [dramaticQuestion, setDramaticQuestion] = useState('')
    const [sequences, setSequences] = useState(null)
    const [characters, setCharacters] = useState(null)
    const [isPublic, setIsPublic] = useState(false)
    const [isPublicCheckboxId] = useState(useUniqueId('isPublicCheckbox'))
    const [isNotFound, setIsNotFound] = useState(false)
    const [lastSaveSuccess, setLastSaveSuccess] = useState(null)
    const [tokensRemaining, setTokensRemaining] = useState(9999999999)

    const [searchParams] = useSearchParams()
    const navigate = useNavigate()

    const onIsPublicChange = () => {
        setIsPublic(!isPublic)
    }

    const populatePlot = (data) => {
        setLogLineDescription(data['logLineDescription'])
        setAILogLineDescriptions(data['aiLogLineDescriptions'])
        setTitle(data['title'])
        setAITitles(data['aiTitles'])
        setGenres(data['genres'])
        setProblemTemplate(data['problemTemplate'])
        setKeywords(data['keywords'] ?? [])
        setDramaticQuestion(data['dramaticQuestion'])
        setSequences(data['sequences'])

        // set default protagonist if array is blank
        // if (!data['characters'] || data['characters'].length === 0) {
        //     data['characters'] = [{
        //         id: uuid(),
        //         name: '',
        //         archetype: '',
        //         description: ''
        //     }]
        // }

        setCharacters(data['characters'])
        setIsPublic(data['isPublic'])
    }

    const populateLogLineOptions = (data) => {
        // convert list of string tuples from the webservice into the format expected by React-Select
        const mapToSelectOptions = (arr) => {
            return arr.map(function (x) {
                return { value: x['item1'], label: x['item2'] }
            })
        }

        const mappedGenreOptions = mapToSelectOptions(data['genres'])
        const mappedProblemTemplateOptions = mapToSelectOptions(data['problemTemplates'])
        const mappedArchetypeOptions = mapToSelectOptions(data['archetypes'])
        const mappedDramaticQuestionsOptions = mapToSelectOptions(data['dramaticQuestions'])

        setGenreOptions(mappedGenreOptions)
        setProblemTemplateOptions(mappedProblemTemplateOptions)
        setArchetypeOptions(mappedArchetypeOptions)
        setDramaticQuestionOptions(mappedDramaticQuestionsOptions)
    }

    // on page load, this is called, which waits for both LogLineOptions and GetPlot to complete before setting any values (LogLineOptions must populate dropdowns before we can set values)
    useEffect(() => {
        // clean up controller. FROM: https://stackoverflow.com/a/63144665 avoids the error "To fix, cancel all subscriptions and asynchronous tasks in a useEffect cleanup function."
        // eslint-disable-next-line no-unused-vars
        let isSubscribed = true;

        setPlotLoading(true)

        const plotId = searchParams.get("id")

        // if plotId is empty, this is most likely due to auth redirect stripping the query vars. In this case, redirect back to the main plot home page
        if (!plotId || plotId === '') {
            navigate('/plots')
        } else {
            Promise.all([
                fetch('/api/LogLine/LogLineOptions'),
                fetch('/api/GetPlot?id=' + plotId)
            ]).then(function (responses) {
                if (responses[1].status === 401 || responses[1].status === 403) {
                    navigate('/plots')
                } else {

                    if (responses[1].ok === false) {
                        setIsNotFound(true)
                    } else {
                        // Get a JSON object from each of the responses
                        return Promise.all(responses.map(function (response) {
                            return response.json();
                        }));
                    }
                }
            }).then(function (data) {
                const logLineOptionsData = data[0]
                populateLogLineOptions(logLineOptionsData)

                const plotData = data[1]

                // this is required to kickstart a newly created plot
                if (!plotData.sequences || plotData.sequences.length === 0) {

                    plotData.sequences = [
                        {
                            sequenceName: 'Opening Image',
                            text: ''
                        }
                    ]
                }

                populatePlot(plotData)

            }).catch(function (error) {
                console.log(error);
            }).finally(function () {
                setPlotLoading(false)
            });
        }
        return () => (isSubscribed = false)
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    const updateLogLineDescriptionCompletions = (completions) => {
        setAILogLineDescriptions(completions)
    }

    const updateBlurb = (sequenceName, text) => {
        setSequences(
            sequences.map(
                (sequence) => sequence.sequenceName === sequenceName ? { ...sequence, blurb: text } : sequence
            )
        )
    }

    const updateExpandedSummary = (sequenceName, text) => {
        setSequences(
            sequences.map(
                (sequence) => sequence.sequenceName === sequenceName ? { ...sequence, text: text } : sequence
            )
        )
    }

    // const updateFull = (sequenceName, text) => {
    //     setSequences(
    //         sequences.map(
    //             (sequence) => sequence.sequenceName === sequenceName ? { ...sequence, full: text } : sequence
    //         )
    //     )
    // }

    const updateBlurbCompletions = (sequenceName, completions) => {
        setSequences(
            sequences.map(
                (sequence) => sequence.sequenceName === sequenceName ? { ...sequence, blurbCompletions: completions } : sequence
            )
        )
    }

    const editCompletion = (completionId, sequences, sequenceName, completionPropName, newCompletionText) => {

        const getNewCompletions = (sequence) => {
            const newCompletions = sequence[completionPropName].map(
                (completion) => completion['id'] === completionId ? { ...completion, completion: newCompletionText } : completion
            )

            return newCompletions
        }

        const getNewSequence = (sequence) => {
            if (completionPropName === 'blurbCompletions') {
                return { ...sequence, blurbCompletions: getNewCompletions(sequence) }
            } else if (completionPropName === 'completions') {
                return { ...sequence, completions: getNewCompletions(sequence) }
            } else if (completionPropName === 'fullCompletions') {
                return { ...sequence, fullCompletions: getNewCompletions(sequence) }
            }
        }

        const newSequences = sequences.map(
            (sequence) => sequence.sequenceName === sequenceName ? getNewSequence(sequence) : sequence
        )

        setSequences(newSequences)
    }

    const updateExpandedSummaryCompletions = (sequenceName, completions) => {
        setSequences(
            sequences.map(
                (sequence) => sequence.sequenceName === sequenceName ? { ...sequence, completions: completions } : sequence
            )
        )
    }

    const updateScenes = (sequenceName, scenes) => {
        setSequences(
            sequences.map(
                (sequence) => sequence.sequenceName === sequenceName ? { ...sequence, scenes: scenes } : sequence
            )
        )
    }

    const updateScene = (sequenceName, sceneId, propName, newValue) => {
        const sequence = sequences.filter(s => s.sequenceName === sequenceName)[0]

        let newScenes = null

        if (propName === 'summary') {
            newScenes = sequence.scenes.map((scene) => scene.id === sceneId ? { ...scene, 'summary': newValue } : scene)
        } else if (propName === 'full') {
            newScenes = sequence.scenes.map((scene) => scene.id === sceneId ? { ...scene, 'full': newValue } : scene)
        }

        setSequences(
            sequences.map(
                (sequence) => sequence.sequenceName === sequenceName ? { ...sequence, scenes: newScenes } : sequence
            )
        )
    }

    const deleteScene = (sequenceName, sceneId) => {

        const sequence = sequences.filter(s => s.sequenceName === sequenceName)[0]

        let newScenes = [...sequence.scenes]// sequence.scenes.map((scene) => scene.id === sceneId ? { ...scene, 'summary': newValue } : scene)

        const curSceneIndex = newScenes.indexOf(newScenes.filter((scene) => scene.id === sceneId)[0])

        newScenes.splice(curSceneIndex, 1);

        setSequences(
            sequences.map(
                (sequence) => sequence.sequenceName === sequenceName ? { ...sequence, scenes: newScenes } : sequence
            )
        )
    }

    const updateCharacterName = (id, newCharacterName) => {
        const updatedCharacters = characters.map(
            (character) => character.id === id ? { ...character, name: newCharacterName } : character
        )

        setCharacters(updatedCharacters)
    }

    const updateCharacterIsHero = (id, isHero) => {
        if (isHero === false) { // set all characters to false
            setCharacters(
                characters.map(
                    (character) => character.id === id ? { ...character, isHero: false } : { ...character, isHero: false }
                )
            )
        } else {
            // first set all characters to false
            const newCharacters = characters.map(
                (character) => character.id === id ? { ...character, isHero: false } : { ...character, isHero: false }
            )

            // second set just the new character to the protagonist
            setCharacters(
                newCharacters.map(
                    (character) => character.id === id ? { ...character, isHero: isHero } : character
                )
            )
        }
    }

    const heroCharacters = !characters ? null : characters.filter(c => c.isHero === true)
    const heroCharacter = !heroCharacters ? null : (heroCharacters.length === 1 ? heroCharacters[0] : null)
    const heroCharacterArchetype = !heroCharacter ? '' : heroCharacter.archetype;

    const updateCharacterDescription = (id, description) => {
        setCharacters(
            characters.map(
                (character) => character.id === id ? { ...character, description: description } : character
            )
        )
    }

    const updateAICharacterCompletion = (id, completionList) => {
        setCharacters(
            characters.map(
                (character) => character.id === id ? { ...character, aiCompletions: completionList } : character
            )
        )
    }

    const updateCharacterArchetype = (id, archetype) => {
        setCharacters(
            characters.map(
                (character) => character.id === id ? { ...character, archetype: archetype } : character
            )
        )
    }

    const updateCharacterPersonality = (id, personalityKey, primary, aspect) => {
        const curCharacter = characters.filter((character) => character.id === id)[0]

        //if ('personality' in curCharacter === false) {
        if (!curCharacter['personality']) {
            curCharacter['personality'] = {
                'closemindedToImaginative': { 'primary': 0.0, 'aspect': 0.0 },
                'disciplinedToSpontaneous': { 'primary': 0.0, 'aspect': 0.0 },
                'introvertToExtrovert': { 'primary': 0.0, 'aspect': 0.0 },
                'coldToEmpathetic': { 'primary': 0.0, 'aspect': 0.0 },
                'unflappableToAnxious': { 'primary': 0.0, 'aspect': 0.0 },
            }
        }

        const newPersonality = Object.assign({}, curCharacter['personality']);

        newPersonality[personalityKey]['primary'] = primary
        newPersonality[personalityKey]['aspect'] = aspect

        const newCharacters = characters.map(
            (character) => character.id === id ? { ...character, personality: newPersonality } : character
        )

        setCharacters(newCharacters)
    }


    // IMPORTANT! When updating properties in sequences, you MUST update all of the properties in a single call to setSequences. If you do then one after the other, some changes will get overridden because the update is asynchronous and it starts from the same unaltered state as the baseline before making the property change. That baseline probably hasn't been updated if you call setSequences(firstChange) then setSequences(secondChange) one after the other
    const insertSequence = (curSequenceName, newSequenceName) => {

        const newSequence = {
            sequenceName: newSequenceName, //getNewSequenceName(sequences),
            text: '',
        }

        const curSequenceIndex = sequences.indexOf(sequences.filter((sequence) => sequence.sequenceName === curSequenceName)[0])

        if (curSequenceIndex === sequences.length - 1) {
            setSequences([...sequences, newSequence]) // set sequences to all the existing sequences, plus add the new one
        } else {
            let newSequences = [...sequences]
            newSequences.splice(curSequenceIndex + 1, 0, newSequence);

            setSequences(
                newSequences
            )
        }
    }

    const deleteSequence = (curSequenceName) => {
        const curSequenceIndex = sequences.indexOf(sequences.filter((sequence) => sequence.sequenceName === curSequenceName)[0])

        let newSequences = [...sequences]
        newSequences.splice(curSequenceIndex, 1);

        setSequences(
            newSequences
        )
    }



    const insertCharacter = () => {

        const newCharacter = {
            id: uuid(),
            name: 'UNNAMED',
            description: '',
            'personality': {
                'closemindedToImaginative': { 'primary': 0.0, 'aspect': 0.0 },
                'disciplinedToSpontaneous': { 'primary': 0.0, 'aspect': 0.0 },
                'introvertToExtrovert': { 'primary': 0.0, 'aspect': 0.0 },
                'coldToEmpathetic': { 'primary': 0.0, 'aspect': 0.0 },
                'unflappableToAnxious': { 'primary': 0.0, 'aspect': 0.0 },
            }
        }

        setCharacters([...characters, newCharacter]) // set characters to all the existing characters, plus add the new one

    }

    const deleteCharacter = (id) => {
        const curCharacterIndex = characters.indexOf(characters.filter((character) => character.id === id)[0])

        let newCharacters = [...characters]
        newCharacters.splice(curCharacterIndex, 1);

        setCharacters(
            newCharacters
        )
    }


    const [plotLoading, setPlotLoading] = useState(false)

    const [genreOptions, setGenreOptions] = useState([])
    const [problemTemplateOptions, setProblemTemplateOptions] = useState([])
    const [archetypeOptions, setArchetypeOptions] = useState([])
    const [dramaticQuestionOptions, setDramaticQuestionOptions] = useState([])


    const [curFocusElName, setCurFocusElName] = useState('')
    const [lastFocusedSequenceName, setLastFocusedSequenceName] = useState('')



    const [logLineIncomplete, setLogLineIncomplete] = useState(true)

    const onFocusChange = (elName) => {
        setCurFocusElName(elName)
    }

    const isNullOrEmpty = (val) => {
        if (val === undefined) return true
        if (val === null) return true
        if (val === '') return true
        if (val.length === 0) return true

        return false
    }

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        const checkLogLineIsComplete = async () => {
            // if any of the Log Line fields are still incomplete, call setLogLineIncomplete(true)

            if (isNullOrEmpty(logLineDescription) || isNullOrEmpty(title) || isNullOrEmpty(genres) || isNullOrEmpty(problemTemplate) || isNullOrEmpty(keywords) || isNullOrEmpty(dramaticQuestion)) {
                setLogLineIncomplete(true)
                return
            }

            setLogLineIncomplete(false)
        }

        checkLogLineIsComplete()

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [title, genres, AITitles, problemTemplate, keywords, logLineDescription, dramaticQuestion]);

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        const timeout = setTimeout(async () => {
            savePlot()
        }, 2000) //ms timeout to execute this function if timeout will be not cleared

        return () => clearTimeout(timeout) //clear timeout (delete function execution)

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [title, genres, AITitles, problemTemplate, keywords, logLineDescription, AILogLineDescriptions, dramaticQuestion, sequences, characters, isPublic]);

    const updateTokensRemaining = () => {
        fetch('/api/GetTokensRemaining', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => response.json())
            .then(data => {
                setTokensRemaining(data)
            })
            .catch(error => {
                console.error(error)
            })
    }

    const savePlot = () => {
        if (isNotFound === true) return;

        if (title === '') {
            //console.log('title was empty string, skip auto-save');
            return;
        }

        updateTokensRemaining();

        const plotId = searchParams.get("id")

        fetch('/api/SaveLogLine?id=' + plotId, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'logLineDescription': logLineDescription,
                'AILogLineDescriptions': AILogLineDescriptions,
                'AITitles': AITitles,
                'title': title,
                'genres': genres,
                'problemTemplate': problemTemplate,
                'keywords': keywords,
                'dramaticQuestion': dramaticQuestion,
                'sequences': sequences,
                'characters': characters,
                'isPublic': isPublic
            })
        })
            .then((response) => {
                if (response.status === 401 || response.status === 403) {
                    navigate('/plots')
                } else {

                    if (response.ok) {
                        // Do something
                        if (response.status === 204) {
                            setLastSaveSuccess(Date.now())
                            notify('Last saved: ' + (new Date().toLocaleTimeString()), toast.TYPE.DEFAULT)
                        } else {
                            notify('Unable to save!', toast.TYPE.ERROR)
                            console.error('error saving: ' + response.status);
                        }
                    } else {
                        notify('Unable to save!', toast.TYPE.ERROR)
                        console.error('error saving: ' + response.status);
                    }
                }
            })
            .catch(error => {
                console.error(error)
                notify('Unable to save!', toast.TYPE.ERROR)
            }).finally(function () {

            });
    }

    const onGenresChange = (inputValue) => {
        setGenres(inputValue.map(el => el.value))
        //setGenre(event.target.value)
    }

    const onProblemTemplateChange = (event) => {
        setProblemTemplate(event.target.value)
    }

    const onKeywordsChange = (inputValue) => {
        setKeywords(inputValue.map(el => el.value))
    }

    const onDramaticQuestionChange = (event) => {
        setDramaticQuestion(event.target.value)
    }

    const onTitleChange = (event) => {
        setTitle(event.target.value)
    }

    const onLogLineDescriptionChange = (val) => {
        setLogLineDescription(val)
    }

    const goToViewPlot = () => {
        const plotId = searchParams.get("id")

        const params = { id: plotId, a: userInfo.userId };
        navigate('/view?' + createSearchParams(params))
    }

    const heroCharacterCheck = !characters ? [] : characters.filter(c => c.isHero === true)
    const hideBlurbs = (!characters || characters.length === 0 || characters.filter(c => c.name === '').length > 0 || heroCharacterCheck.length === 0 || (heroCharacterCheck.length > 0 && heroCharacter.archetype === ''))
    const blurbsIncomplete = hideBlurbs || allSequencesHaveValues(sequences, 'Cooldown', 'blurb', 'blurbCompletions') === false
    const expandedSummariesIncomplete = blurbsIncomplete || allSequencesHaveValues(sequences, 'Cooldown', 'text', 'completions') === false

    const handleDisplayModeChange = e => {
        const target = e.target;
        if (target.checked) {
            setDisplayMode('advanced');
        } else {
            setDisplayMode('simple');
        }
    };


    return (
        <>
            {
                plotLoading === true && <Spinner animation="border" variant="secondary" />
            }
            {
                isNotFound === true &&
                <>
                    <p>Plot not found! This plot either doesn't exist, the author has not made it public, or your network connection is down.</p>
                </>
            }
            {
                plotLoading === false && isNotFound === false &&
                <>
                    <div className='row'>
                        <div className='col-12'>
                            <div className="form-check form-switch">
                                <input className="form-check-input" type="checkbox" id="flexSwitchCheckChecked" onChange={handleDisplayModeChange} checked={displayMode === 'advanced'} />
                                <label className="form-check-label" htmlFor="flexSwitchCheckChecked">Advanced Mode</label>
                            </div>
                        </div>
                    </div>

                    {
                        displayMode === 'simple' &&
                        <DisplaySimple
                            userInfo={userInfo}
                            plotId={searchParams.get("id")}
                            mode={mode}
                            genreOptions={genreOptions}
                            genres={genres}
                            onGenresChange={onGenresChange}
                            onFocusChange={onFocusChange}
                            setKeywords={setKeywords}
                            setLogLineDescription={setLogLineDescription}
                            setTitle={setTitle}
                            setProblemTemplate={setProblemTemplate}
                            setDramaticQuestion={setDramaticQuestion}
                            keywords={keywords}
                            onKeywordsChange={onKeywordsChange}
                            logLineIncomplete={logLineIncomplete}
                            logLineDescription={logLineDescription}
                            onLogLineDescriptionChange={onLogLineDescriptionChange}
                            onTitleChange={onTitleChange}
                            title={title}
                            problemTemplate={problemTemplate}
                            onProblemTemplateChange={onProblemTemplateChange}
                            problemTemplateOptions={problemTemplateOptions}
                            dramaticQuestion={dramaticQuestion}
                            onDramaticQuestionChange={onDramaticQuestionChange}
                            dramaticQuestionOptions={dramaticQuestionOptions}
                            updateLogLineDescriptionCompletions={updateLogLineDescriptionCompletions}
                            AILogLineDescriptions={AILogLineDescriptions}
                            AITitles={AITitles}
                            setAITitles={setAITitles}
                            curFocusElName={curFocusElName}
                            tokensRemaining={tokensRemaining}

                            hideBlurbs={hideBlurbs}
                            blurbsIncomplete={blurbsIncomplete}
                            expandedSummariesIncomplete={expandedSummariesIncomplete}

                            setCharacters={setCharacters}

                            characters={characters}
                            archetypeOptions={archetypeOptions}
                            updateCharacterName={updateCharacterName}
                            updateCharacterIsHero={updateCharacterIsHero}
                            updateCharacterArchetype={updateCharacterArchetype}
                            updateCharacterDescription={updateCharacterDescription}
                            updateAICharacterCompletion={updateAICharacterCompletion}
                            updateCharacterPersonality={updateCharacterPersonality}
                            insertCharacter={insertCharacter}
                            deleteCharacter={deleteCharacter}

                            sequences={sequences}
                            setLastFocusedSequenceName={setLastFocusedSequenceName}
                            lastFocusedSequenceName={lastFocusedSequenceName}
                            updateBlurb={updateBlurb}
                            updateExpandedSummary={updateExpandedSummary}

                            insertSequence={insertSequence}
                            deleteSequence={deleteSequence}
                            heroCharacterArchetype={heroCharacterArchetype}
                            updateBlurbCompletions={updateBlurbCompletions}
                            updateExpandedSummaryCompletions={updateExpandedSummaryCompletions}

                            setSequences={setSequences}

                            goToViewPlot={goToViewPlot}
                            isPublicCheckboxId={isPublicCheckboxId}
                            onIsPublicChange={onIsPublicChange}
                            isPublic={isPublic}
                            lastSaveSuccess={lastSaveSuccess}

                            editCompletion={editCompletion}

                            updateScenes={updateScenes}
                            updateScene={updateScene}
                            deleteScene={deleteScene}
                        />
                    }
                    {
                        displayMode === 'advanced' &&
                        <DisplayAdvanced
                            userInfo={userInfo}
                            plotId={searchParams.get("id")}
                            mode={mode}
                            genreOptions={genreOptions}
                            genres={genres}
                            onGenresChange={onGenresChange}
                            onFocusChange={onFocusChange}
                            setKeywords={setKeywords}
                            setLogLineDescription={setLogLineDescription}
                            setTitle={setTitle}
                            setProblemTemplate={setProblemTemplate}
                            setDramaticQuestion={setDramaticQuestion}
                            keywords={keywords}
                            onKeywordsChange={onKeywordsChange}
                            logLineIncomplete={logLineIncomplete}
                            logLineDescription={logLineDescription}
                            onLogLineDescriptionChange={onLogLineDescriptionChange}
                            onTitleChange={onTitleChange}
                            title={title}
                            problemTemplate={problemTemplate}
                            onProblemTemplateChange={onProblemTemplateChange}
                            problemTemplateOptions={problemTemplateOptions}
                            dramaticQuestion={dramaticQuestion}
                            onDramaticQuestionChange={onDramaticQuestionChange}
                            dramaticQuestionOptions={dramaticQuestionOptions}
                            updateLogLineDescriptionCompletions={updateLogLineDescriptionCompletions}
                            AILogLineDescriptions={AILogLineDescriptions}
                            AITitles={AITitles}
                            setAITitles={setAITitles}
                            curFocusElName={curFocusElName}
                            tokensRemaining={tokensRemaining}

                            hideBlurbs={hideBlurbs}
                            blurbsIncomplete={blurbsIncomplete}
                            expandedSummariesIncomplete={expandedSummariesIncomplete}

                            setCharacters={setCharacters}

                            characters={characters}
                            archetypeOptions={archetypeOptions}
                            updateCharacterName={updateCharacterName}
                            updateCharacterIsHero={updateCharacterIsHero}
                            updateCharacterArchetype={updateCharacterArchetype}
                            updateCharacterDescription={updateCharacterDescription}
                            updateAICharacterCompletion={updateAICharacterCompletion}
                            updateCharacterPersonality={updateCharacterPersonality}
                            insertCharacter={insertCharacter}
                            deleteCharacter={deleteCharacter}

                            sequences={sequences}
                            setLastFocusedSequenceName={setLastFocusedSequenceName}
                            lastFocusedSequenceName={lastFocusedSequenceName}
                            updateBlurb={updateBlurb}
                            updateExpandedSummary={updateExpandedSummary}

                            insertSequence={insertSequence}
                            deleteSequence={deleteSequence}
                            heroCharacterArchetype={heroCharacterArchetype}
                            updateBlurbCompletions={updateBlurbCompletions}
                            updateExpandedSummaryCompletions={updateExpandedSummaryCompletions}

                            setSequences={setSequences}

                            goToViewPlot={goToViewPlot}
                            isPublicCheckboxId={isPublicCheckboxId}
                            onIsPublicChange={onIsPublicChange}
                            isPublic={isPublic}
                            lastSaveSuccess={lastSaveSuccess}

                            editCompletion={editCompletion}

                            updateScenes={updateScenes}
                            updateScene={updateScene}
                            deleteScene={deleteScene}
                        />
                    }

                </>
            }
        </>
    )
}

export default PlotHome