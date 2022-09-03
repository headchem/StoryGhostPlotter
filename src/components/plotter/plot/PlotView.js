import React, { useState, useEffect } from 'react'
import { useSearchParams, Link } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import { getText } from '../../../util/Helpers'
import EmotionsChart from './EmotionsChart'

const PlotView = (
    {
        userInfo,
    }
) => {

    const [title, setTitle] = useState('')
    const [sequences, setSequences] = useState(null)
    const [characters, setCharacters] = useState(null)
    const [isPublic, setIsPublic] = useState(false)
    const [isNotFound, setIsNotFound] = useState(false)
    const [plotLoading, setPlotLoading] = useState(false)
    const [authorUserId, setAuthorUserId] = useState('')
    const [emotions, setEmotions] = useState(null)
    const [selectedCharacter, setSelectedCharacter] = useState('')

    const [searchParams] = useSearchParams()

    const populatePlot = (data) => {
        setTitle(data['title'])
        setSequences(data['sequences'])
        setIsPublic(data['isPublic'])
        setAuthorUserId(data['userId'])
        setCharacters(data['characters'])
    }

    const uniqueCharacterNames = !characters ? [] : [...new Set(characters.map(c => c.name))]

    const emotionsMap = !emotions ? {} : Object.assign({}, ...emotions.filter(emo => emo.id !== '').map((x) => ({ [x.id]: x }))); // convert array of emotions into a dictionary


    const allSceneEmotionData = !sequences ? [] : sequences.filter(seq => seq.sequenceName !== 'B Story').map(seq => {
        let allSceneEmotions = []

        seq.scenes.forEach(scene => {
            const sceneData = !scene.characterEmotions ? [] : scene.characterEmotions.map((emo, i) => {
                const emoName = emo.emotion

                if (!emoName || emoName === '') return { name: '' }

                const emoObj = emotionsMap[emoName]
                const characterName = !emo.characterId ? 'none' : characters.filter(c => c.id === emo.characterId)[0]['name'] // TODO: make a dictionary lookup for efficiency

                return {
                    name: emoName + ' (' + characterName + ')',
                    characterName: characterName,

                    joyToSadness: emoObj['joyToSadness'],
                    trustToDisgust: emoObj['trustToDisgust'],
                    fearToAnger: emoObj['fearToAnger'],
                    surpriseToAnticipation: emoObj['surpriseToAnticipation'],

                    anxietyToConfidence: emoObj['anxietyToConfidence'],
                    boredomToFascination: emoObj['boredomToFascination'],
                    frustrationToEuphoria: emoObj['frustrationToEuphoria'],
                    dispiritedToEncouraged: emoObj['dispiritedToEncouraged'],
                    terrorToEnchantment: emoObj['terrorToEnchantment'],
                    humiliationToPride: emoObj['humiliationToPride'],

                    pleasureToDispleasure: emoObj['pleasureToDispleasure'],
                    arousalToNonarousal: emoObj['arousalToNonarousal'],
                    dominanceToSubmissiveness: emoObj['dominanceToSubmissiveness'],

                    innerFocusToOutwardTarget: emoObj['innerFocusToOutwardTarget'],
                }
            })

            sceneData.forEach(el => allSceneEmotions.push(el))
        })

        return [].concat.apply([], allSceneEmotions)
    }).flat()


    const allSequenceEmotionDataBySeq = !sequences ? [] : sequences.filter(seq => seq.sequenceName !== 'B Story').map(seq => {
        const result = {
            name: seq.sequenceName,
            characterEmotions: {}
        }

        characters.forEach(character => result.characterEmotions[character.name] = {
            joyToSadness: 0,
            trustToDisgust: 0,
            fearToAnger: 0,
            surpriseToAnticipation: 0,

            anxietyToConfidence: 0,
            boredomToFascination: 0,
            frustrationToEuphoria: 0,
            dispiritedToEncouraged: 0,
            terrorToEnchantment: 0,
            humiliationToPride: 0,

            pleasureToDispleasure: 0,
            arousalToNonarousal: 0,
            dominanceToSubmissiveness: 0,

            innerFocusToOutwardTarget: 0,
        })

        seq.scenes.forEach(scene => {
            characters.forEach(character => {
                if (scene.characterEmotions && scene.characterEmotions.length > 0) {
                    const curCharacter = result.characterEmotions[character.name]

                    scene.characterEmotions.forEach(emo => {
                        const emoName = emo.emotion
                        const characterName = !emo.characterId ? 'none' : characters.filter(c => c.id === emo.characterId)[0]['name'] // TODO: make a dictionary lookup for efficiency

                        if (emoName && emoName !== '' && characterName === character.name) {
                            const emoObj = emotionsMap[emoName]

                            curCharacter.joyToSadness += emoObj['joyToSadness'] / seq.scenes.length
                            curCharacter.trustToDisgust += emoObj['trustToDisgust'] / seq.scenes.length
                            curCharacter.fearToAnger += emoObj['fearToAnger'] / seq.scenes.length
                            curCharacter.surpriseToAnticipation += emoObj['surpriseToAnticipation'] / seq.scenes.length

                            curCharacter.anxietyToConfidence += emoObj['anxietyToConfidence'] / seq.scenes.length
                            curCharacter.boredomToFascination += emoObj['boredomToFascination'] / seq.scenes.length
                            curCharacter.frustrationToEuphoria += emoObj['frustrationToEuphoria'] / seq.scenes.length
                            curCharacter.dispiritedToEncouraged += emoObj['dispiritedToEncouraged'] / seq.scenes.length
                            curCharacter.terrorToEnchantment += emoObj['terrorToEnchantment'] / seq.scenes.length
                            curCharacter.humiliationToPride += emoObj['humiliationToPride'] / seq.scenes.length

                            curCharacter.pleasureToDispleasure += emoObj['pleasureToDispleasure'] / seq.scenes.length
                            curCharacter.arousalToNonarousal += emoObj['arousalToNonarousal'] / seq.scenes.length
                            curCharacter.dominanceToSubmissiveness += emoObj['dominanceToSubmissiveness'] / seq.scenes.length

                            curCharacter.innerFocusToOutwardTarget += emoObj['innerFocusToOutwardTarget'] / seq.scenes.length
                        }
                    })
                }

            })

        })

        return result
    })

    const allSequenceEmotionData = allSequenceEmotionDataBySeq.map(seq => {

        const result = {
            name: seq.name,
            characterName: 'Ensemble',

            joyToSadness: 0,
            trustToDisgust: 0,
            fearToAnger: 0,
            surpriseToAnticipation: 0,

            anxietyToConfidence: 0,
            boredomToFascination: 0,
            frustrationToEuphoria: 0,
            dispiritedToEncouraged: 0,
            terrorToEnchantment: 0,
            humiliationToPride: 0,

            pleasureToDispleasure: 0,
            arousalToNonarousal: 0,
            dominanceToSubmissiveness: 0,

            innerFocusToOutwardTarget: 0,
        }

        characters.forEach(character => {
            const curCharacter = seq.characterEmotions[character.name]

            result.joyToSadness += curCharacter.joyToSadness
            result.trustToDisgust += curCharacter.trustToDisgust
            result.fearToAnger += curCharacter.fearToAnger
            result.surpriseToAnticipation += curCharacter.surpriseToAnticipation

            result.anxietyToConfidence += curCharacter.anxietyToConfidence
            result.boredomToFascination += curCharacter.boredomToFascination
            result.frustrationToEuphoria += curCharacter.frustrationToEuphoria
            result.dispiritedToEncouraged += curCharacter.dispiritedToEncouraged
            result.terrorToEnchantment += curCharacter.terrorToEnchantment
            result.humiliationToPride += curCharacter.humiliationToPride

            result.pleasureToDispleasure += curCharacter.pleasureToDispleasure
            result.arousalToNonarousal += curCharacter.arousalToNonarousal
            result.dominanceToSubmissiveness += curCharacter.dominanceToSubmissiveness

            result.innerFocusToOutwardTarget += curCharacter.innerFocusToOutwardTarget
        })

        return result
    })

    const getCharacterSequenceEmotions = (characterName) => {
        const characterEmotions = allSequenceEmotionDataBySeq.map(seq => {
            const result = seq.characterEmotions[characterName]
            result['name'] = seq.name
            result['characterName'] = characterName

            return result
        })

        return characterEmotions
    }

    const selectedCharacterSequenceEmotions = selectedCharacter === '' ? allSequenceEmotionData : allSequenceEmotionDataBySeq.map(seq => {
        const result = seq.characterEmotions[selectedCharacter]
        result['name'] = seq.name
        result['characterName'] = selectedCharacter

        return result
    })

    // on page load, this is called, which waits for both LogLineOptions and GetPlot to complete before setting any values (LogLineOptions must populate dropdowns before we can set values)
    useEffect(() => {
        // clean up controller. FROM: https://stackoverflow.com/a/63144665 avoids the error "To fix, cancel all subscriptions and asynchronous tasks in a useEffect cleanup function."
        // eslint-disable-next-line no-unused-vars
        let isSubscribed = true;

        setPlotLoading(true)

        const plotId = searchParams.get("id")
        const authorId = searchParams.get("a")

        Promise.all([
            fetch('/api/GetPlot?id=' + plotId + '&a=' + authorId),
            fetch('/api/Emotions')
            // other fetches could go here
        ]).then(function (responses) {
            if (responses[0].ok === false) {
                setIsNotFound(true)
            } else {
                // Get a JSON object from each of the responses
                return Promise.all(responses.map(function (response) {
                    return response.json();
                }));
            }
        }).then(function (data) {
            const plotData = data[0]
            const emotionsData = data[1]

            populatePlot(plotData)
            setEmotions(emotionsData)

        }).catch(function (error) {
            // if there's an error, log it
            console.log(error);
        }).finally(function () {
            setPlotLoading(false)
        });

        return () => (isSubscribed = false)
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    return (
        <>
            {
                plotLoading === true && <Spinner animation="border" variant="secondary" />
            }
            {
                isNotFound === true &&
                <>
                    <p>Plot not found! This plot either doesn't exist, the author has not made it public, or your network connection is down. If you are the author, ensure you are logged in.</p>
                </>
            }
            {
                plotLoading === false && isNotFound === false &&
                <div className='row mb-4'>
                    {
                        userInfo && userInfo.userId === authorUserId &&
                        <Link className="nav-link" to={'/plot?id=' + searchParams.get("id")}>Edit your plot</Link>
                    }
                    {
                        userInfo && userInfo.userId === authorUserId && isPublic === false &&
                        <>
                            <p>Only you, the author, can see this because you have not set this plot to be public.</p>
                        </>
                    }
                    <h1 className='pb-4'>{title}</h1>
                    {
                        sequences &&
                        <>
                            <Tabs defaultActiveKey="blurbs" className="mb-3">
                                <Tab eventKey="blurbs" title="Blurbs">
                                    {
                                        sequences.map((sequence) => (
                                            <span key={sequence.sequenceName}>
                                                <p className='fs-5' title={sequence.sequenceName}>{getText(sequence, 'blurb', 'blurbCompletions')}</p>
                                            </span>
                                        ))
                                    }
                                </Tab>
                                <Tab eventKey="expandedSummaries" title="Expanded Summaries">
                                    {
                                        sequences.map((sequence) => (
                                            <span key={sequence.sequenceName}>
                                                <p className='fs-5' title={sequence.sequenceName}>{getText(sequence, 'text', 'completions')}</p>
                                            </span>
                                        ))
                                    }
                                </Tab>
                                {
                                    userInfo && userInfo.userRoles.includes('admin') &&

                                    <Tab eventKey="scenes" title="Scenes">
                                        {
                                            sequences.map((sequence) => (
                                                <span key={sequence.sequenceName}>
                                                    {
                                                        <>
                                                            {
                                                                sequence.scenes && sequence.scenes.length > 0 && sequence.scenes.map((scene) => (
                                                                    <span key={scene.id}>
                                                                        <p className='fs-5' title={sequence.sequenceName}>{getText(scene, 'summary', 'fullsummaryCompletions')}</p>
                                                                    </span>
                                                                ))
                                                            }
                                                        </>
                                                    }
                                                    <p className='fs-5' title={sequence.sequenceName}>{getText(sequence, 'full', 'fullCompletions')}</p>
                                                </span>
                                            ))
                                        }
                                    </Tab>
                                }
                                {
                                    userInfo && userInfo.userRoles.includes('admin') &&
                                    <Tab eventKey="emotions" title="Emotions">
                                        <div className='row'>
                                            <div className='col'>
                                                <h1>All Scenes</h1>
                                                <EmotionsChart
                                                    data={allSceneEmotionData}
                                                />
                                            </div>
                                        </div>
                                        <div className='row mt-5'>
                                            <div className='col'>
                                                <h1>By Sequence</h1>
                                                <select required className='fs-5 form-select form-inline' value={selectedCharacter} onChange={(e) => setSelectedCharacter(e.target.value)}>
                                                    <option key="blank" value="">All</option>
                                                    {
                                                        uniqueCharacterNames.map(function (name) {
                                                            return <option key={name} value={name}>{name}</option>
                                                        })
                                                    }
                                                </select>
                                                <EmotionsChart
                                                    data={selectedCharacterSequenceEmotions}
                                                    showCharacterDropdown={false}
                                                />
                                            </div>
                                        </div>
                                    </Tab>
                                }
                                <Tab eventKey="all" title="All">
                                    {
                                        sequences.map((sequence) => (
                                            <div className='row border-bottom' key={sequence.sequenceName}>
                                                {
                                                    <>
                                                        <div className='col'>
                                                            <div className='sticky-md-top'>
                                                                <p className='fs-5' title={sequence.sequenceName}>{getText(sequence, 'blurb', 'blurbCompletions')}</p>
                                                            </div>
                                                        </div>
                                                        <div className='col'>
                                                            <div className='sticky-md-top'>
                                                                <p className='fs-5' title={sequence.sequenceName}>{getText(sequence, 'text', 'completions')}</p>

                                                            </div>
                                                        </div>
                                                        {
                                                            userInfo && userInfo.userRoles.includes('admin') &&
                                                            <>
                                                                <div className='col'>
                                                                    <div className='sticky-md-top'>
                                                                        {
                                                                            sequence.scenes && sequence.scenes.length > 0 && sequence.scenes.map((scene) => (
                                                                                <span key={scene.id}>
                                                                                    <p className='fs-5' title={sequence.sequenceName}>{getText(scene, 'summary', 'fullsummaryCompletions')}</p>
                                                                                </span>
                                                                            ))
                                                                        }
                                                                    </div>
                                                                </div>

                                                                <div className='col'>
                                                                    <div className='sticky-md-top'>
                                                                        {
                                                                            sequence.scenes && sequence.scenes.length > 0 && sequence.scenes.map((scene) => (
                                                                                <span key={scene.id}>
                                                                                    <p className='fs-5' style={{ 'whiteSpace': 'pre-line' }} title={sequence.sequenceName}>{scene.full}</p>
                                                                                </span>
                                                                            ))
                                                                        }
                                                                    </div>
                                                                </div>
                                                            </>
                                                        }
                                                    </>
                                                }
                                                <p className='fs-5' title={sequence.sequenceName}>{getText(sequence, 'full', 'fullCompletions')}</p>
                                            </div>
                                        ))
                                    }
                                </Tab>
                            </Tabs>

                        </>
                    }
                </div>
            }
        </>
    )
}

export default PlotView