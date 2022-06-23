import React from 'react'
import SimpleSequenceList from './SimpleSequenceList'

const Page6 = (
    {
        userInfo,
        plotId,
        logLineDescription,
        genres,
        problemTemplate,
        dramaticQuestion,
        keywords,
        sequences,
        characters,
        updateSequenceCompletions,
        heroCharacterArchetype,
        editCompletion
    }
) => {

    return (
        <>
            <div className="row">
                <div className='col-12'>
                    <p>Expand the previous sequence events into a full paragraph with more detail and emotion.</p>
                </div>
            </div>

            {
                <SimpleSequenceList
                    userInfo={userInfo}
                    plotId={plotId}
                    logLineDescription={logLineDescription}
                    genres={genres}
                    problemTemplate={problemTemplate}
                    dramaticQuestion={dramaticQuestion}
                    keywords={keywords}
                    sequences={sequences}
                    characters={characters}
                    updateSequenceCompletions={updateSequenceCompletions}
                    heroCharacterArchetype={heroCharacterArchetype}
                    textPropName={'text'}
                    completionsPropName={'completions'}
                    completionURL={'GenerateExpandedSummary'}
                    editCompletion={editCompletion}
                />
            }
        </>
    )
}

export default Page6