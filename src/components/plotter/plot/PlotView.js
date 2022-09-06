import React, { useState, useEffect } from 'react'
import { useSearchParams, Link } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import { getText } from '../../../util/Helpers'
import EmotionsChart from './EmotionsChart'
import { AreaChart, Area, XAxis, YAxis, CartesianGrid, Legend, ResponsiveContainer } from 'recharts';
import { interpolateTurbo } from '../../../util/ChartUtil'

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

    const setEmoDelta = (emoObj, result, axis, leftName, rightName) => {
        if (emoObj[axis] < 0) {
            result['min' + leftName] = Math.min(result['min' + leftName], emoObj[axis])
            result['max' + leftName] = Math.max(result['max' + leftName], emoObj[axis])
            result['delta' + leftName] = Math.max(result['delta' + leftName], (Math.abs(result['min' + leftName]) - Math.abs(result['max' + leftName])))
        } else if (emoObj[axis] > 0) {
            result['min' + rightName] = Math.min(result['min' + rightName], emoObj[axis])
            result['max' + rightName] = Math.max(result['max' + rightName], emoObj[axis])
            result['delta' + rightName] = Math.max(result['delta' + rightName], (result['max' + rightName] - result['min' + rightName]))
        }
    }

    // return an object containing the min/max of each emotion axis seen in all character emotions in the scene
    const getMinMaxDeltaPerScene = (scene) => {
        let result = {
            minJoy: 0,
            maxJoy: 0,
            deltaJoy: 0,
            minSadness: 0,
            maxSadness: 0,
            deltaSadness: 0,

            minTust: 0,
            maxTrust: 0,
            deltaTrust: 0,
            minDisgust: 0,
            maxDisgust: 0,
            deltaDisgust: 0,

            minFear: 0,
            maxFear: 0,
            deltaFear: 0,
            minAnger: 0,
            maxAnger: 0,
            deltaAnger: 0,

            minSurprise: 0,
            maxSurprise: 0,
            deltaSurprise: 0,
            minAnticipation: 0,
            maxAnticipation: 0,
            deltaAnticipation: 0,

            minAnxiety: 0,
            maxAnxiety: 0,
            deltaAnxiety: 0,
            minConfidence: 0,
            maxConfidence: 0,
            deltaConfidence: 0,

            minBoredom: 0,
            maxBoredom: 0,
            deltaBoredom: 0,
            minFascination: 0,
            maxFascination: 0,
            deltaFascination: 0,

            minFrustration: 0,
            maxFrustration: 0,
            deltaFrustration: 0,
            minEuphoria: 0,
            maxEuphoria: 0,
            deltaEuphoria: 0,

            minDispirited: 0,
            maxDispirited: 0,
            deltaDispirited: 0,
            minEncouraged: 0,
            maxEncouraged: 0,
            deltaEncouraged: 0,

            minTerror: 0,
            maxTerror: 0,
            deltaTerror: 0,
            minEnchantment: 0,
            maxEnchantment: 0,
            deltaEnchantment: 0,

            minHumiliation: 0,
            maxHumiliation: 0,
            deltaHumiliation: 0,
            minPride: 0,
            maxPride: 0,
            deltaPride: 0,

            minPleasure: 0,
            maxPleasure: 0,
            deltaPleasure: 0,
            minDispleasure: 0,
            maxDispleasure: 0,
            deltaDispleasure: 0,

            minArousal: 0,
            maxArousal: 0,
            deltaArousal: 0,
            minNonarousal: 0,
            maxNonarousal: 0,
            deltaNonarousal: 0,

            minDominance: 0,
            maxDominance: 0,
            deltaDominance: 0,
            minSubmissiveness: 0,
            maxSubmissiveness: 0,
            deltaSubmissiveness: 0,

            minInnerFocus: 0,
            maxInnerFocus: 0,
            deltaInnerFocus: 0,
            minOutwardTarget: 0,
            maxOutwardTarget: 0,
            deltaOutwardTarget: 0,
        }

        if (!scene || !scene.characterEmotions) return result

        scene.characterEmotions.forEach(emo => {
            const emoName = emo.emotion
            const emoObj = emotionsMap[emoName]

            setEmoDelta(emoObj, result, 'joyToSadness', 'Joy', 'Sadness')
            setEmoDelta(emoObj, result, 'trustToDisgust', 'Trust', 'Disgust')
            setEmoDelta(emoObj, result, 'fearToAnger', 'Fear', 'Anger')
            setEmoDelta(emoObj, result, 'surpriseToAnticipation', 'Surprise', 'Anticipation')

            setEmoDelta(emoObj, result, 'anxietyToConfidence', 'Anxiety', 'Confidence')
            setEmoDelta(emoObj, result, 'boredomToFascination', 'Boredom', 'Fascination')
            setEmoDelta(emoObj, result, 'frustrationToEuphoria', 'Frustration', 'Euphoria')
            setEmoDelta(emoObj, result, 'dispiritedToEncouraged', 'Dispirited', 'Encouraged')
            setEmoDelta(emoObj, result, 'terrorToEnchantment', 'Terror', 'Enchantment')
            setEmoDelta(emoObj, result, 'humiliationToPride', 'Humiliation', 'Pride')

            setEmoDelta(emoObj, result, 'pleasureToDispleasure', 'Pleasure', 'Displeasure')
            setEmoDelta(emoObj, result, 'arousalToNonarousal', 'Arousal', 'Nonarousal')
            setEmoDelta(emoObj, result, 'dominanceToSubmissiveness', 'Dominance', 'Submissiveness')

            setEmoDelta(emoObj, result, 'innerFocusToOutwardTarget', 'InnerFocus', 'OutwardTarget')
        })

        return result
    }

    const minMaxDataBySequence = !sequences ? [] : sequences.filter(seq => seq.sequenceName !== 'B Story').map(seq => {
        let result = []

        seq.scenes.forEach(scene => {
            const sceneMinMax = getMinMaxDeltaPerScene(scene)
            result.push(sceneMinMax)
        })

        return result
    })

    const minMaxDeltaData = minMaxDataBySequence.flat().map(sceneDeltas => {
        const result = {
            'deltaJoy': sceneDeltas['deltaJoy'],
            'deltaSadness': sceneDeltas['deltaSadness'],
            'deltaTrust': sceneDeltas['deltaTrust'],
            'deltaDisgust': sceneDeltas['deltaDisgust'],
            'deltaFear': sceneDeltas['deltaFear'],
            'deltaAnger': sceneDeltas['deltaAnger'],
            'deltaSurprise': sceneDeltas['deltaSurprise'],
            'deltaAnticipation': sceneDeltas['deltaAnticipation'],

            'deltaPleasure': sceneDeltas['deltaPleasure'],
            'deltaDispleasure': sceneDeltas['deltaDispleasure'],
            'deltaArousal': sceneDeltas['deltaArousal'],
            'deltaNonarousal': sceneDeltas['deltaNonarousal'],
            'deltaDominance': sceneDeltas['deltaDominance'],
            'deltaSubmissiveness': sceneDeltas['deltaSubmissiveness'],

            // 'minJoy': sceneDeltas['minJoy'] * -1,
            // 'maxSadness': sceneDeltas['maxSadness'],
            // 'minTrust': sceneDeltas['minTrust'] * -1,
            // 'maxDisgust': sceneDeltas['maxDisgust'],
            // 'minFear': sceneDeltas['minFear'] * -1,
            // 'maxAnger': sceneDeltas['maxAnger'],
            // 'minSurprise': sceneDeltas['minSurprise'] * -1,
            // 'maxAnticipation': sceneDeltas['maxAnticipation'],

            // 'minArousal': sceneDeltas['minArousal'] * -1,

        }

        return result
    })

    //console.log(minMaxDataBySequence)
    //console.log(minMaxDeltaData)

    const minMaxDeltaDataKeys = (!minMaxDeltaData || minMaxDeltaData.length === 0) ? [] : Object.keys(minMaxDeltaData[0]).filter(o => o !== 'name')
    const colorMapArea = !minMaxDeltaDataKeys ? {} : Object.assign({}, ...minMaxDeltaDataKeys.map((key, i) => ({ [key]: interpolateTurbo((i + 1) / (minMaxDeltaDataKeys.length + 2)) })));

    const getEmptyCharacterEmotion = () => {
        return {
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
    }


    const allSequenceEmotionDataBySeq = !sequences ? [] : sequences.filter(seq => seq.sequenceName !== 'B Story').map(seq => {
        const result = {
            name: seq.sequenceName,
            sceneCount: seq.scenes.length,
            characterEmotions: {}
        }

        characters.forEach(character => result.characterEmotions[character.name] = getEmptyCharacterEmotion())

        result.characterEmotions['none'] = getEmptyCharacterEmotion()

        seq.scenes.forEach(scene => {

            const uniqueCharacterIdsInScene = 1 //[...new Set(scene.characterEmotions.map(ce => ce.characterId))].length
            const sceneEmotionsCount = scene.characterEmotions ? scene.characterEmotions.length : 1

            if (scene.characterEmotions) {
                scene.characterEmotions.forEach(emo => {

                    const emoName = emo.emotion
                    const characterName = !emo.characterId ? 'none' : characters.filter(c => c.id === emo.characterId)[0]['name'] // TODO: make a dictionary lookup for efficiency

                    const curCharacter = result.characterEmotions[characterName]

                    if (emoName && emoName !== '') {
                        const emoObj = emotionsMap[emoName]
                        const sceneCount = seq.scenes.length

                        // if a scene has many emotions, they each contribute a standardized amount via " / sceneEmotionsCount"
                        // if a sequence has many scenes, they each contribute a standardized amount via " / sceneCount"

                        curCharacter.joyToSadness += ((emoObj['joyToSadness'] / sceneEmotionsCount) / sceneCount) / uniqueCharacterIdsInScene
                        curCharacter.trustToDisgust += ((emoObj['trustToDisgust'] / sceneEmotionsCount) / sceneCount) / uniqueCharacterIdsInScene
                        curCharacter.fearToAnger += ((emoObj['fearToAnger'] / sceneEmotionsCount) / sceneCount) / uniqueCharacterIdsInScene
                        curCharacter.surpriseToAnticipation += ((emoObj['surpriseToAnticipation'] / sceneEmotionsCount) / sceneCount) / uniqueCharacterIdsInScene

                        curCharacter.anxietyToConfidence += ((emoObj['anxietyToConfidence'] / sceneEmotionsCount) / sceneCount) / uniqueCharacterIdsInScene
                        curCharacter.boredomToFascination += ((emoObj['boredomToFascination'] / sceneEmotionsCount) / sceneCount) / uniqueCharacterIdsInScene
                        curCharacter.frustrationToEuphoria += ((emoObj['frustrationToEuphoria'] / sceneEmotionsCount) / sceneCount) / uniqueCharacterIdsInScene
                        curCharacter.dispiritedToEncouraged += ((emoObj['dispiritedToEncouraged'] / sceneEmotionsCount) / sceneCount) / uniqueCharacterIdsInScene
                        curCharacter.terrorToEnchantment += ((emoObj['terrorToEnchantment'] / sceneEmotionsCount) / sceneCount) / uniqueCharacterIdsInScene
                        curCharacter.humiliationToPride += ((emoObj['humiliationToPride'] / sceneEmotionsCount) / sceneCount) / uniqueCharacterIdsInScene

                        curCharacter.pleasureToDispleasure += ((emoObj['pleasureToDispleasure'] / sceneEmotionsCount) / sceneCount) / uniqueCharacterIdsInScene
                        curCharacter.arousalToNonarousal += ((emoObj['arousalToNonarousal'] / sceneEmotionsCount) / sceneCount) / uniqueCharacterIdsInScene
                        curCharacter.dominanceToSubmissiveness += ((emoObj['dominanceToSubmissiveness'] / sceneEmotionsCount) / sceneCount) / uniqueCharacterIdsInScene

                        curCharacter.innerFocusToOutwardTarget += ((emoObj['innerFocusToOutwardTarget'] / sceneEmotionsCount) / sceneCount) / uniqueCharacterIdsInScene
                    }
                })
            }
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

            const denominator = 1//seq.sceneCount

            const curCharacter = seq.characterEmotions[character.name]

            result.joyToSadness += curCharacter.joyToSadness / denominator
            result.trustToDisgust += curCharacter.trustToDisgust / denominator
            result.fearToAnger += curCharacter.fearToAnger / denominator
            result.surpriseToAnticipation += curCharacter.surpriseToAnticipation / denominator

            result.anxietyToConfidence += curCharacter.anxietyToConfidence / denominator
            result.boredomToFascination += curCharacter.boredomToFascination / denominator
            result.frustrationToEuphoria += curCharacter.frustrationToEuphoria / denominator
            result.dispiritedToEncouraged += curCharacter.dispiritedToEncouraged / denominator
            result.terrorToEnchantment += curCharacter.terrorToEnchantment / denominator
            result.humiliationToPride += curCharacter.humiliationToPride / denominator

            result.pleasureToDispleasure += curCharacter.pleasureToDispleasure / denominator
            result.arousalToNonarousal += curCharacter.arousalToNonarousal / denominator
            result.dominanceToSubmissiveness += curCharacter.dominanceToSubmissiveness / denominator

            result.innerFocusToOutwardTarget += curCharacter.innerFocusToOutwardTarget / denominator
        })

        return result
    })

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
                    <p>Please refresh your browser! Your login probably expired. Otherwise, either this plot either doesn't exist, the author has not made it public, or your network connection is down.</p>
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
                                                    showCharacterDropdown={true}
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

                                        <div className='row mt-5'>
                                            <div className='col'>
                                                <h1>Deltas By Scene</h1>

                                                <div style={{ height: '400px' }}>
                                                    <ResponsiveContainer width="100%" height="100%">
                                                        <AreaChart
                                                            width={500}
                                                            height={400}
                                                            data={minMaxDeltaData}
                                                            margin={{
                                                                top: 10,
                                                                right: 30,
                                                                left: 0,
                                                                bottom: 0,
                                                            }}
                                                        >
                                                            <CartesianGrid strokeDasharray="3 3" />
                                                            <XAxis dataKey="name" />
                                                            <YAxis />
                                                            {/* <Tooltip /> */}
                                                            <Legend />
                                                            {
                                                                minMaxDeltaDataKeys.map((key) => <Area key={key} type="linear" dataKey={key} stackId="1" stroke={colorMapArea[key]} fill={colorMapArea[key]} activeDot={{ r: 8 }} />)
                                                            }
                                                        </AreaChart>
                                                    </ResponsiveContainer>
                                                </div>
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