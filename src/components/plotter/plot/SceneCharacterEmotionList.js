import React, { useState } from 'react'
import { v4 as uuid } from 'uuid';

import SceneCharacterEmotion from './SceneCharacterEmotion'
import { FaPlusCircle } from 'react-icons/fa'
import EmotionsChart from './EmotionsChart'


const SceneCharacterEmotionList = ({
    emotionsOptions,
    characters,
    sequence,
    scene,
    mode,
    updateScene,
    emotions,
    emotionsMap,
}) => {

    const uniqueComponentId = uuid()

    const [showEmotionsChart, setShowEmotionsChart] = useState(false)
    const [chartType, setChartType] = useState('line')

    const handleChartTypeChange = e => {
        const target = e.target;
        if (target.checked) {
            setChartType('area');
        } else {
            setChartType('line');
        }
    };

    const onInsertCharacterEmotion = () => {
        const newCharacterEmotion = {
            id: uuid(),
            characterId: null,
            emotion: ''
        }

        const newCharacterEmotions = !scene.characterEmotions ? [newCharacterEmotion] : [...scene.characterEmotions, newCharacterEmotion] // set all to existing, plus add the new one

        updateScene(sequence.sequenceName, scene.id, 'characterEmotions', newCharacterEmotions)
    }

    const deleteCharacterEmotion = (id) => {
        const curCharacterEmotionIndex = scene.characterEmotions.indexOf(scene.characterEmotions.filter((characterEmotion) => characterEmotion.id === id)[0])

        let newCharacterEmotions = [...scene.characterEmotions]
        newCharacterEmotions.splice(curCharacterEmotionIndex, 1);

        updateScene(sequence.sequenceName, scene.id, 'characterEmotions', newCharacterEmotions)
    }

    const updateSelectedCharacter = (characterEmotionId, selectedCharacterId) => {
        if (selectedCharacterId === '') {
            selectedCharacterId = null
        }

        const newCharacterEmotions = scene.characterEmotions.map(
            (characterEmotion) => characterEmotion.id === characterEmotionId ? { ...characterEmotion, characterId: selectedCharacterId } : characterEmotion
        )

        updateScene(sequence.sequenceName, scene.id, 'characterEmotions', newCharacterEmotions)
    }

    const updateSelectedEmotion = (characterEmotionId, selectedEmotion) => {
        const newCharacterEmotions = scene.characterEmotions.map(
            (characterEmotion) => characterEmotion.id === characterEmotionId ? { ...characterEmotion, emotion: selectedEmotion } : characterEmotion
        )

        updateScene(sequence.sequenceName, scene.id, 'characterEmotions', newCharacterEmotions)
    }



    const dataKeys = [
        'joyToSadness',
        'trustToDisgust',
        'fearToAnger',
        'surpriseToAnticipation',

        'anxietyToConfidence',
        'boredomToFascination',
        'frustrationToEuphoria',
        'dispiritedToEncouraged',
        'terrorToEnchantment',
        'humiliationToPride',

        'pleasureToDispleasure',
        'arousalToNonarousal',
        'dominanceToSubmissiveness',

        'innerFocusToOutwardTarget',
    ]

    const data = !scene.characterEmotions ? [] : scene.characterEmotions.map((emo, i) => {
        const emoName = emo.emotion

        if (!emoName || emoName === '') return {name: ''}

        const emoObj = emotionsMap[emoName]

        return {
            name: emoName,

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
    }).filter(x => x['name'] !== '')

    return (
        <>
            {
                scene.characterEmotions && scene.characterEmotions
                    .map((characterEmotion) => (
                        <div className='row mt-3 mb-3' key={characterEmotion.id}>
                            <SceneCharacterEmotion
                                characterEmotion={characterEmotion}
                                emotionsOptions={emotionsOptions}
                                mode={mode}
                                deleteCharacterEmotion={deleteCharacterEmotion}
                                updateSelectedCharacter={updateSelectedCharacter}
                                updateSelectedEmotion={updateSelectedEmotion}
                                characters={characters}
                            />
                        </div>
                    ))
            }
            <div className='row mt-3 mb-5'>
                <div className='col'>
                    <button
                        type='button'
                        className='btn btn-outline-primary btn-block'
                        onClick={onInsertCharacterEmotion}
                    ><FaPlusCircle /> New Character-Emotion</button>
                </div>
            </div>

            <div className='row'>
                <div className='col'>
                    {
                        showEmotionsChart === false &&
                        <button className='btn btn-link' onClick={() => setShowEmotionsChart(true)}>show emotions chart</button>
                    }
                    {
                        showEmotionsChart === true &&
                        <button className='btn btn-link' onClick={() => setShowEmotionsChart(false)}>hide emotions chart</button>
                    }
                </div>
            </div>

            {
                showEmotionsChart === true &&
                <div className='row'>
                    <div className='col'>
                        <div className="form-check form-switch fs-5 mb-4 mt-4">
                            <input className="form-check-input" type="checkbox" id={uniqueComponentId + 'ChartFlexSwitchCheckChecked'} onChange={handleChartTypeChange} checked={chartType === 'area'} />
                            <label className="form-check-label" htmlFor={uniqueComponentId + 'ChartFlexSwitchCheckChecked'}>Area</label>
                        </div>
                        <EmotionsChart
                            keys={dataKeys}
                            data={data}
                            chartType={chartType}
                        />
                    </div>
                </div>
            }

        </>
    )
}

export default SceneCharacterEmotionList