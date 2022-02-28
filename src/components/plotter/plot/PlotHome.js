import React, { useState, useEffect } from 'react'
import { v4 as uuid } from 'uuid';
import Spinner from 'react-bootstrap/Spinner';
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import Select from 'react-select';

import { useSearchParams, useNavigate, createSearchParams } from "react-router-dom";
import { useUniqueId } from '../../../util/GenerateUniqueId'

import LimitedTextArea from './LimitedTextArea'
import LogLineSelect from './LogLineSelect'
import LogLineObjDetails from './LogLineObjDetails'

import SequenceList from './SequenceList'
import CharacterList from './CharacterList'
import { encode } from "../../../util/tokenizer/mod"; // FROM https://github.com/josephrocca/gpt-2-3-tokenizer

const PlotHome = (
    {
        userInfo,
    }
) => {

    const [logLineDescription, setLogLineDescription] = useState('')
    const [AILogLineDescription, setAILogLineDescription] = useState('')
    //const [AILogLineTitle, setAILogLineTitle] = useState('')
    const [title, setTitle] = useState('')
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

    const [logLineDescriptionTokenCount, setLogLineDescriptionTokenCount] = useState(0)

    const [searchParams] = useSearchParams()
    const navigate = useNavigate()

    const onIsPublicChange = () => {
        setIsPublic(!isPublic)
    }

    const populatePlot = (data) => {
        setLogLineDescription(data['logLineDescription'])
        setAILogLineDescription(data['aiLogLineDescription'])
        //setAILogLineTitle(data['aiLogLineTitle'])
        setTitle(data['title'])
        setGenres(data['genres'])
        setProblemTemplate(data['problemTemplate'])
        setKeywords(data['keywords'] ?? [])
        setDramaticQuestion(data['dramaticQuestion'])
        setSequences(data['sequences'])

        // set default protagonist if arr is blank
        if (!data['characters'] || data['characters'].length === 0) {
            data['characters'] = [{
                id: uuid(),
                name: '',
                archetype: '',
                description: ''
            }]
        }

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

        Promise.all([
            fetch('/api/LogLine/LogLineOptions'),
            fetch('/api/GetPlot?id=' + plotId)
        ]).then(function (responses) {
            if (responses[1].ok === false) {
                setIsNotFound(true)
            } else {
                // Get a JSON object from each of the responses
                return Promise.all(responses.map(function (response) {
                    return response.json();
                }));
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

        return () => (isSubscribed = false)
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    const updateSequenceText = (sequenceName, text) => {
        setSequences(
            sequences.map(
                (sequence) => sequence.sequenceName === sequenceName ? { ...sequence, text: text } : sequence
            )
        )
    }

    const updateAISequenceText = (sequenceName, text) => {
        setSequences(
            sequences.map(
                (sequence) => sequence.sequenceName === sequenceName ? { ...sequence, aiText: text } : sequence
            )
        )
    }

    const updateCharacterName = (id, newCharacterName) => {
        setCharacters(
            characters.map(
                (character) => character.id === id ? { ...character, name: newCharacterName } : character
            )
        )
    }

    const updateCharacterDescription = (id, description) => {
        setCharacters(
            characters.map(
                (character) => character.id === id ? { ...character, description: description } : character
            )
        )
    }

    const updateAICharacterDescription = (id, description) => {
        setCharacters(
            characters.map(
                (character) => character.id === id ? { ...character, aiText: description } : character
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
            name: '',
            description: ''
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

        //console.log('LOG LINE UPDATE')

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
    }, [title, genres, problemTemplate, keywords, logLineDescription, dramaticQuestion]);

    const [totalTokens, setTotalTokens] = useState(0)

    const updateTotalTokens = () => {
        if (!sequences || sequences.length === 0) return
        const allText = sequences.map(s => s.text).join(" ") + characters.map(s => s.description).join(" ") + logLineDescription
        //console.log(allText)
        const numTokens = encode(allText).length
        setTotalTokens(numTokens)
    }

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        const timeout = setTimeout(() => {
            savePlot()

            const logLineTokens = encode(logLineDescription)
            setLogLineDescriptionTokenCount(logLineTokens.length)
            updateTotalTokens()

        }, 2000) //ms timeout to execute this function if timeout will be not cleared

        return () => clearTimeout(timeout) //clear timeout (delete function execution)

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [title, genres, problemTemplate, keywords, logLineDescription, AILogLineDescription, dramaticQuestion, sequences, characters, isPublic]);

    const savePlot = () => {
        if (isNotFound === true) return;

        if (title === '') {
            console.log('title was empty string, skip auto-save');
            return;
        }

        const plotId = searchParams.get("id")
        //console.log(`auto save logline for plotId: ${plotId}, title: ${title}, genres: ${genres}, problemTemplate: ${problemTemplate}, keywords: ${keywords}, heroArchetype: ${heroArchetype}, primalStakes: ${primalStakes}, enemyArchetype: ${enemyArchetype}, dramaticQuestion: ${dramaticQuestion}`);

        fetch('/api/SaveLogLine?id=' + plotId, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'logLineDescription': logLineDescription,
                'AILogLineDescription': AILogLineDescription,
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
                if (response.ok) {
                    // Do something
                    if (response.status === 204) {
                        setLastSaveSuccess(Date.now())
                    } else {
                        console.error('error saving: ' + response.status);
                    }
                } else {
                    console.error('error saving: ' + response.status);
                }
            })
            .catch(error => {
                console.error(error)
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

    // const onAILogLineTitleChange = (val) => {
    //     setAILogLineTitle(val)
    // }

    const onAILogLineDescriptionChange = (val) => {
        setAILogLineDescription(val)
    }

    const goToViewPlot = () => {
        const plotId = searchParams.get("id")

        const params = { id: plotId, a: userInfo.userId };
        navigate('/view?' + createSearchParams(params))
    }

    return (
        <>
            {
                plotLoading === true && <Spinner animation="border" variant="secondary" />
            }
            {
                isNotFound === true &&
                <>
                    <p>This plot either doesn't exist, or the author has not made it public.</p>
                </>
            }
            {
                plotLoading === false && isNotFound === false &&
                <>

                    <div className='row pb-5'>
                        <div className='col-md-7 logline'>
                            <div className='row pb-3'>
                                <div className='col-md-3'>
                                    <label htmlFor="genres" className="form-label">Genres</label>
                                </div>
                                <div className='col-md-9'>
                                    <div style={{ width: '100%' }}>
                                        <Select
                                            defaultValue={genreOptions.filter(o => genres.indexOf(o.value) > -1)}
                                            isMulti
                                            name="genres"
                                            options={genreOptions}
                                            className="genres-multi-select"
                                            classNamePrefix="select"
                                            onChange={onGenresChange}
                                            onFocus={() => onFocusChange('genres')}
                                        />
                                    </div>
                                </div>
                            </div>

                            <div className='row pb-3'>
                                <div className='col-md-3'>
                                    <label for="title" className="form-label">Title</label>
                                </div>
                                <div className='col-md-9'>
                                    <input type='text' className='fs-5 form-control' placeholder='Plot Title' required onChange={onTitleChange} defaultValue={title} onFocus={() => onFocusChange('title')} aria-describedby="titleHelp" id="title" />
                                </div>
                            </div>

                            <div className='row pb-3'>
                                <div className='col-md-3'>
                                    <label for="logLineDesc" className="form-label">Log Line</label>
                                </div>
                                <div className='col-md-9'>
                                    <LimitedTextArea
                                        id='logLineDesc'
                                        className="form-control"
                                        value={logLineDescription}
                                        setValue={(newValue) => onLogLineDescriptionChange(newValue)}
                                        rows={4}
                                        limit={700}
                                        curTokenCount={logLineDescriptionTokenCount}
                                        showCount={true}
                                        onFocus={() => onFocusChange('logLineDescription')}
                                    />
                                </div>
                            </div>

                            <div className='row pb-3'>
                                <div className='col-md-3'>
                                    <label for="problemTemplate" className="form-label">Problem Template</label>
                                </div>
                                <div className='col-md-9'>
                                    <select id='problemTemplate' required className='fs-5 form-select' defaultValue={problemTemplate} onChange={onProblemTemplateChange} onFocus={() => onFocusChange('problem template')}>
                                        <option key="blank" value="" disabled selected>Problem Template</option>
                                        {
                                            problemTemplateOptions.map(function (o) {
                                                return <option key={o.value} value={o.value}>{o.label}</option>
                                            })
                                        }
                                    </select>
                                </div>
                            </div>

                            <div className='row pb-3'>
                                <div className='col-md-3'>
                                    <label for="dramaticQuestion" className="form-label" title='also called the "theme"'>Dramatic Question</label>
                                </div>
                                <div className='col-md-9'>
                                    <select id='dramaticQuestion' required className='fs-5 form-select dramaticQuestionSelect' defaultValue={dramaticQuestion} onChange={onDramaticQuestionChange} onFocus={() => onFocusChange('dramatic question')}>
                                        <option key="blank" value="" disabled selected>Dramatic Question</option>
                                        {
                                            dramaticQuestionOptions.map(function (o) {
                                                return <option key={o.value} value={o.value}>{o.label}</option>
                                            })
                                        }
                                    </select>
                                </div>
                            </div>

                            <div className='row pb-3'>
                                <div className='col-md-3'>
                                    <label for="keywords" className="form-label">Keywords</label>
                                </div>
                                <div className='col-md-9'>
                                    <div style={{ width: '100%' }}>
                                        <LogLineSelect
                                            placeholder='Keywords'
                                            isMultiSelect={true}
                                            onFocusChange={() => onFocusChange('keywords')}
                                            value={keywords}
                                            onChange={onKeywordsChange}
                                        />
                                    </div>
                                </div>
                            </div>



                        </div>
                        <div className='col-md-5'>
                            <LogLineObjDetails
                                userInfo={userInfo}
                                onAILogLineDescriptionChange={onAILogLineDescriptionChange}
                                // onAILogLineTitleChange={onAILogLineTitleChange}
                                // AILogLineTitle={AILogLineTitle}
                                AILogLineDescription={AILogLineDescription}
                                curFocusElName={curFocusElName}
                                genres={genres}
                                problemTemplate={problemTemplate}
                                dramaticQuestion={dramaticQuestion}
                                keywords={keywords}
                                sequences={sequences}
                                characters={characters}
                            />
                        </div>
                    </div>

                    {
                        logLineIncomplete === true &&
                        <p>All fields above must be completed.</p>
                    }
                    {
                        logLineIncomplete === false &&
                        <>
                            <Tabs defaultActiveKey="characters" className="mb-3" onFocus={() => onFocusChange('tabs')}>
                                <Tab eventKey="characters" title="Characters">
                                    <CharacterList
                                        characters={characters}
                                        userInfo={userInfo}
                                        archetypeOptions={archetypeOptions}
                                        onFocusChange={onFocusChange}
                                        updateCharacterName={updateCharacterName}
                                        updateCharacterArchetype={updateCharacterArchetype}
                                        updateCharacterDescription={updateCharacterDescription}
                                        updateAICharacterDescription={updateAICharacterDescription}
                                        insertCharacter={insertCharacter}
                                        deleteCharacter={deleteCharacter}
                                        genres={genres}
                                        problemTemplate={problemTemplate}
                                        keywords={keywords}
                                        dramaticQuestion={dramaticQuestion}
                                    />
                                </Tab>
                                <Tab eventKey="sequences" title="Sequence of Events">
                                    <SequenceList
                                        sequences={sequences}
                                        userInfo={userInfo}
                                        onFocusChange={onFocusChange}
                                        updateSequenceText={updateSequenceText}
                                        updateAISequenceText={updateAISequenceText}
                                        insertSequence={insertSequence}
                                        deleteSequence={deleteSequence}
                                        genres={genres}
                                        problemTemplate={problemTemplate}
                                        keywords={keywords}
                                        characters={characters}
                                        dramaticQuestion={dramaticQuestion}
                                    />
                                </Tab>
                            </Tabs>

                        </>
                    }
                    <div className='row mb-4 pt-5 border-top'>
                        <div className='col-8'>
                            <button className='btn btn-primary' onClick={goToViewPlot}>View and Share</button>
                        </div>
                        <div className="col-2 form-check" title="check this box to make your plot public">
                            <label className="form-check-label" htmlFor={isPublicCheckboxId}>
                                Is Public
                            </label>
                            <input id={isPublicCheckboxId} className='form-check-input' type='checkbox' onChange={onIsPublicChange} checked={isPublic} />

                        </div>
                        <div className='col-2'>
                            <p className='text-muted text-end'>
                                {
                                    lastSaveSuccess === null &&
                                    <span>not yet saved in this session</span>
                                }
                                {
                                    lastSaveSuccess !== null &&
                                    <span>last saved: {new Date(lastSaveSuccess).toLocaleTimeString()}</span>
                                }
                                {
                                    <>
                                        <br />
                                        <span>{totalTokens}/{2048 - 320} tokens</span>
                                    </>
                                }
                            </p>
                        </div>
                    </div>
                </>
            }
        </>
    )
}

export default PlotHome