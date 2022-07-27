import React from 'react'
import Scene from './Scene'
import { v4 as uuid } from 'uuid'

const SceneList = ({
    userInfo,
    plotId,
    sequenceType,
    genres,
    problemTemplate,
    keywords,
    characters,
    heroCharacterArchetype,
    dramaticQuestion,
    logLineDescription,
    sequence,
    scenes,
    tokensRemaining,
    AILogLineDescriptions,
    updateScenes,
    updateScene,
    deleteScene,
}) => {

    const addScene = () => {

        const newScene = {
            'id': uuid(),
            'summary': '',
            'full': '',
            'summaryCompletions': [],
            'fullCompletions': []
        }

        if (!sequence.scenes) {
            updateScenes(sequence.sequenceName, [newScene])
        } else {
            updateScenes(sequence.sequenceName, [...sequence.scenes, newScene])
        }
    }

    return (
        <>
            <div className='row'>
                <div className='col'>
                    {
                        sequence && sequence.scenes && sequence.scenes
                            .map((scene) => (
                                <Scene key={sequenceType + scene.id}
                                    userInfo={userInfo}
                                    plotId={plotId}
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
                                />

                            ))
                    }
                </div>
            </div>
            <div className='row'>
                <div className='col'>

                    <button className='btn btn-primary' onClick={addScene}>Add Scene</button>
                </div>
            </div>
        </>
    )
}

export default SceneList