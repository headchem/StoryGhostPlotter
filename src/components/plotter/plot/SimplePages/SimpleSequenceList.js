import React from 'react'
import Accordion from 'react-bootstrap/Accordion';
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

        // if we're on expanded summaries, check that all previous blurbs have a value before showing current expanded summary
        const curBlurbHasSelectedBrainstorm = !sequence['blurbCompletions'] ? false : sequence['blurbCompletions'].filter(brainstorm => brainstorm['isSelected'] === true).length > 0
        const curBlurbHasValue = curBlurbHasSelectedBrainstorm || (sequence && sequence['blurb'] && sequence['blurb'] !== '')

        const showCurSequence = (textPropName === 'text' && curBlurbHasValue === true && (prevSeqHasSelectedBrainstorm === true || isOpeningImage || prevNotEmpty)) || (textPropName === 'blurb' && (isOpeningImage || prevNotEmpty || prevSeqHasSelectedBrainstorm))

        if (showCurSequence && sequences && sequences.length > 1) {
            return <div className='row pb-5' key={sequence['sequenceName']}>
                <h3 className='float-start'>{sequence['sequenceName']}</h3>
                <div className='col-md-4 order-md-2'>

                    <div className="d-md-none pb-3">
                        <Accordion defaultActiveKey={[]} alwaysOpen>

                            <Accordion.Item eventKey="0">
                                <Accordion.Header>Advice for {sequence.sequenceName}</Accordion.Header>
                                <Accordion.Body>
                                    <SequenceAdvice
                                        showAdviceHeader={false}
                                        sequenceName={sequence.sequenceName}
                                        genres={genres}
                                        problemTemplate={problemTemplate}
                                        keywords={keywords}
                                        heroCharacterArchetype={heroCharacterArchetype}
                                        dramaticQuestion={dramaticQuestion}
                                    />
                                </Accordion.Body>
                            </Accordion.Item>
                        </Accordion>
                    </div>

                    <div className="d-none d-md-block">
                        <SequenceAdvice
                            showAdviceHeader={true}
                            sequenceName={sequence.sequenceName}
                            genres={genres}
                            problemTemplate={problemTemplate}
                            keywords={keywords}
                            heroCharacterArchetype={heroCharacterArchetype}
                            dramaticQuestion={dramaticQuestion}
                        />
                    </div>
                </div>
                <div className='col-md-8 order-md-1'>
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