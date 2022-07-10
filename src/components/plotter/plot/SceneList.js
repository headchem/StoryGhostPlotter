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
    sequences,
    tokensRemaining,
    AILogLineDescriptions,
    updateScenes,
}) => {

    const addScene = () => {
        console.log('add scene')

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
            <p>Scene List goes here for current Sequence</p>
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
                            sequences={sequences}
                            tokensRemaining={tokensRemaining}
                            AILogLineDescriptions={AILogLineDescriptions}
                        />

                    ))
            }

            <button className='btn btn-primary' onClick={addScene}>Add Scene</button>
        </>
    )
}

export default SceneList