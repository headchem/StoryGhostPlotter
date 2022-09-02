import React from 'react'
import { v4 as uuid } from 'uuid';

import SceneCharacterEmotion from './SceneCharacterEmotion'
import { FaPlusCircle } from 'react-icons/fa'


const SceneCharacterEmotionList = ({
    emotionsOptions,
    characters,
    sequence,
    scene,
    mode,
    updateScene,
}) => {

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
        </>
    )
}

export default SceneCharacterEmotionList