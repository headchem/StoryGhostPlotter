import React from 'react'
import Scene from './Scene'
import { v4 as uuid } from 'uuid'

const SceneList = ({
    userInfo,
    plotId,
    mode,
    sequenceType,
    genres,
    problemTemplate,
    keywords,
    characters,
    heroCharacterArchetype,
    dramaticQuestion,
    logLineDescription,
    sequence,
    tokensRemaining,
    AILogLineDescriptions,
    updateScenes,
    updateScene,
    deleteScene,

    emotionsOptions,
    emotions,
}) => {

    const getNewScene = () => {
        const newScene = {
            'id': uuid(),
            'summary': '',
            'full': '',
            'summaryCompletions': [],
            'fullCompletions': []
        }

        return newScene
    }

    const addScene = () => {

        const newScene = getNewScene()

        if (!sequence.scenes) {
            updateScenes(sequence.sequenceName, [newScene])
        } else {
            updateScenes(sequence.sequenceName, [...sequence.scenes, newScene])
        }
    }

    // from: https://stackoverflow.com/a/38181008
    const insert = (arr, index, newItem) => [
        // part of the array before the specified index
        ...arr.slice(0, index),
        // inserted item
        newItem,
        // part of the array after the specified index
        ...arr.slice(index)
    ]

    const insertScene = (idx) => {
        const newScene = getNewScene()

        if (!sequence.scenes) {
            updateScenes(sequence.sequenceName, [newScene])
        } else { // insert in the middle
            const newSceneList = insert(sequence.scenes, idx, newScene)
            updateScenes(sequence.sequenceName, newSceneList)
        }
    }

    return (
        <>
            <div className='row'>
                <div className='col'>
                    <button className='btn btn-primary mb-3' onClick={() => insertScene(0)}>Add Scene</button>
                </div>
            </div>
            <div className='row'>
                <div className='col'>
                    {
                        sequence && sequence.scenes &&
                            sequence.scenes.map((scene, idx) => (
                            <Scene key={idx + sequenceType + scene.id}
                                userInfo={userInfo}
                                plotId={plotId}
                                mode={mode}
                                sequenceType={sequenceType}
                                genres={genres}
                                problemTemplate={problemTemplate}
                                keywords={keywords}
                                characters={characters}
                                heroCharacterArchetype={heroCharacterArchetype}
                                dramaticQuestion={dramaticQuestion}
                                logLineDescription={logLineDescription}
                                sequence={sequence}
                                scene={scene}
                                tokensRemaining={tokensRemaining}
                                AILogLineDescriptions={AILogLineDescriptions}
                                updateScene={updateScene}
                                deleteScene={deleteScene}
                                sceneIdx={idx + 1}
                                insertScene={insertScene}

                                emotionsOptions={emotionsOptions}
                                emotions={emotions}
                            />

                        ))
                    }
                </div>
            </div>
            {
                sequence && !sequence.scenes &&
                <div className='row'>
                    <div className='col'>
                        <button className='btn btn-primary mb-3' onClick={addScene}>Add Scene</button>
                    </div>
                </div>
            }

        </>
    )
}

export default SceneList