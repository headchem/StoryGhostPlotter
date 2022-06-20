import React from 'react'
import SimpleSequenceList from './SimpleSequenceList'

const Page6 = (
    {
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
            {
                <SimpleSequenceList
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