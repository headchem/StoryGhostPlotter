import React from 'react'
import { isNullOrEmpty } from '../../../../util/Helpers';
import SimpleSequence from './SimpleSequence'
import SequenceAdvice from '../Advice/SequenceAdvice'

const SimpleSequenceList = (
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
        textPropName,
        completionsPropName,
        completionURL,
        editCompletion
    }
) => {

    const simpleSequenceRows = sequences.map((sequence, idx) => {
        // only show this sequence if: it's the Opening Image, or the previous sequence either has a blurb or has a selected brainstorm
        const isOpeningImage = idx === 0
        const prevSequence = isOpeningImage ? sequences[0] : sequences[idx - 1]
        const prevNotEmpty = isNullOrEmpty(prevSequence[textPropName]) === false
        const prevSeqHasSelectedBrainstorm = !prevSequence[completionsPropName] ? false : prevSequence[completionsPropName].filter(brainstorm => brainstorm['isSelected'] === true).length > 0
        const showCurSequence = isOpeningImage || prevNotEmpty || prevSeqHasSelectedBrainstorm

        if (showCurSequence && sequences && sequences.length > 1) {
            return <div className='row pb-5' key={sequence['sequenceName']}>
                <div className='col-8'>
                    <SimpleSequence
                        userInfo={userInfo}
                        plotId={plotId}
                        targetSequence={sequence['sequenceName']}
                        logLineDescription={logLineDescription}
                        genres={genres}
                        problemTemplate={problemTemplate}
                        dramaticQuestion={dramaticQuestion}
                        keywords={keywords}
                        sequences={sequences}
                        characters={characters}
                        updateSequenceCompletions={updateSequenceCompletions}
                        textPropName={textPropName}
                        completionsPropName={completionsPropName}
                        completionURL={completionURL}
                        editCompletion={editCompletion}
                    />
                </div>
                <div className='col-4'>
                    <SequenceAdvice
                        sequenceName={sequence.sequenceName}
                        genres={genres}
                        problemTemplate={problemTemplate}
                        keywords={keywords}
                        heroCharacterArchetype={heroCharacterArchetype}
                        dramaticQuestion={dramaticQuestion}
                    />
                </div>
            </div>
        }
        return null
    }
    );

    return (
        <>
            {
                simpleSequenceRows
            }
        </>
    )
}

export default SimpleSequenceList