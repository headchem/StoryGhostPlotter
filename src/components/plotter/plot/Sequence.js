import React, { useEffect, useState, useMemo } from 'react'
import Accordion from 'react-bootstrap/Accordion';
import { FaMinusCircle } from 'react-icons/fa'
import LimitedTextArea from './LimitedTextArea'
import NextSequencesButtonGroup from './NextSequencesButtonGroup'
import SequenceAdvice from './Advice/SequenceAdvice'
import SequenceBrainstorm from './Brainstorm/SequenceBrainstorm'
import SignUpMessage from './SignUpMessage'
import { blurbLimits, expandedSummaryLimits, fullLimits } from '../../../util/SequenceTextCheck';

const Sequence = ({
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

    updateBlurb,
    updateExpandedSummary,
    updateFull,
    insertSequence,
    deleteSequence,
    updateBlurbCompletions,
    updateExpandedSummaryCompletions,
    updateFullCompletions,
    allowed,
    tokensRemaining,
    AILogLineDescriptions
}) => {

    // const [blurbTokenCount, setBlurbTokenCount] = useState(0)
    // const [expandedSummaryTokenCount, setExpandedSummaryTokenCount] = useState(0)
    // const [fullTokenCount, setFullTokenCount] = useState(0)

    const [showConfirmDelete, setShowConfirmDelete] = useState(false)

    const onInsertSequence = (nextSequenceName) => {
        insertSequence(sequence.sequenceName, nextSequenceName)
    }

    const onDeleteSequence = () => {
        deleteSequence(sequence.sequenceName)
    }

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        const timeout = setTimeout(() => {
            // removing, too noisy, use simpler character counts as the limit
            //updateBlurbTokenCount()
            //updateExpandedSummaryTokenCount()
            //updateFullTokenCount()
        }, 2000) //2000 - timeout to execute this function if timeout will be not cleared

        return () => clearTimeout(timeout) //clear timeout (delete function execution)

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [sequence]);

    const NextSequencesButtonGroupMemo = useMemo(() => ( // useMemo prevents the buttons from flickering on keypress
        <NextSequencesButtonGroup
            allowed={allowed}
            onInsertSequence={onInsertSequence}
        />
        // eslint-disable-next-line react-hooks/exhaustive-deps
    ), [allowed]);

    const selectedBlurbBrainstorm = sequence && sequence['blurbCompletions'] ? sequence['blurbCompletions'].filter(brainstorm => brainstorm['isSelected'] === true) : null
    const selectedExpandedBrainstorm = sequence && sequence['completions'] ? sequence['completions'].filter(brainstorm => brainstorm['isSelected'] === true) : null

    const blurbHasValue = (selectedBlurbBrainstorm && selectedBlurbBrainstorm.length > 0) || (sequence && sequence.blurb && sequence.blurb !== '')
    const expandedSummaryHasValue = (selectedExpandedBrainstorm && selectedExpandedBrainstorm.length > 0) || (sequence && sequence.text && sequence.text !== '')

    return (
        <>
            <div className='row border-top mt-3 pt-3'>
                <div className='col-md-7'>
                    <div className="d-inline-block sticky-md-top w-100">
                        <h4 className="float-start">{sequence.sequenceName}</h4>
                        {
                            sequence.sequenceName !== 'Opening Image' && sequenceType === 'blurb' &&
                            <div className='float-end'>
                                {
                                    showConfirmDelete === false &&
                                    <>
                                        <button onClick={() => setShowConfirmDelete(true)} className='btn btn-outline-danger btn-no-border' title='Delete this sequence. You will be prompted to confirm.'><FaMinusCircle /></button>
                                    </>
                                }
                                {
                                    showConfirmDelete === true &&
                                    <>
                                        <button onClick={onDeleteSequence} className="btn btn-danger">Delete</button>
                                        <button className='btn btn-link' onClick={() => setShowConfirmDelete(false)}>cancel delete</button>
                                    </>
                                }
                            </div>
                        }

                        {
                            sequenceType === 'blurb' &&
                            <div className="float-start w-100 pt-3">

                                {userInfo && userInfo.userRoles.includes('admin') && sequence.text && sequence.text !== '' &&
                                    <p><span className='text-muted'>Expanded Summary (admin only): </span> {sequence.text}</p>
                                }
                                {
                                    selectedBlurbBrainstorm && selectedBlurbBrainstorm.length > 0 &&
                                    <p>{selectedBlurbBrainstorm[0]['completion']}</p>
                                }
                                {
                                    (!selectedBlurbBrainstorm || selectedBlurbBrainstorm.length === 0) &&
                                    <>
                                        <label title="short logic blurb describing the absolute minimum required to explain the story" htmlFor={sequence.sequenceName + '_blurb_textarea'} className="form-label w-100 d-none">Visible Events</label>
                                        <LimitedTextArea
                                            id={sequence.sequenceName + '_blurb_textarea'}
                                            className="form-control"
                                            value={sequence.blurb}
                                            setValue={(newValue) => updateBlurb(sequence.sequenceName, newValue)}
                                            rows={blurbLimits[sequence.sequenceName]['rows']}
                                            limit={blurbLimits[sequence.sequenceName]['max']}
                                            //curTokenCount={blurbTokenCount}
                                            showCount={true}
                                        />
                                    </>
                                }
                            </div>
                        }

                        {
                            (sequenceType === 'expandedSummary' && blurbHasValue) &&
                            <div className="float-start w-100 pt-3">
                                <label title="concrete events and interactions visible to the audience" htmlFor={sequence.sequenceName + '_expanded_summary_textarea'} className="form-label w-100 d-none">Visible Events</label>
                                {
                                    selectedBlurbBrainstorm && selectedBlurbBrainstorm.length > 0 &&
                                    <p>{selectedBlurbBrainstorm[0]['completion']}</p>
                                }
                                {
                                    (!selectedBlurbBrainstorm || selectedBlurbBrainstorm.length === 0) && sequence.blurb && sequence.blurb !== '' &&
                                    <p>{sequence.blurb}</p>
                                }
                                <LimitedTextArea
                                    id={sequence.sequenceName + '_expanded_summary_textarea'}
                                    className="form-control"
                                    value={sequence.text}
                                    setValue={(newValue) => updateExpandedSummary(sequence.sequenceName, newValue)}
                                    rows={expandedSummaryLimits[sequence.sequenceName]['rows']}
                                    limit={expandedSummaryLimits[sequence.sequenceName]['max']}
                                    //curTokenCount={expandedSummaryTokenCount}
                                    showCount={true}
                                />
                            </div>
                        }

                        {
                            (sequenceType === 'expandedSummary' && !blurbHasValue) &&
                            <div className="float-start w-100 pt-3">
                                <p>The corresponding Blurb for this sequence does not have a value. Enter a blurb in the previous tab before returning here to expand upon it.</p>
                            </div>
                        }

                        {
                            sequenceType === 'full' && expandedSummaryHasValue &&
                            <div className="float-start w-100 pt-3">
                                <label title="full screenplay for this sequence" htmlFor={sequence.sequenceName + '_full_textarea'} className="form-label w-100 d-none">Visible Events</label>
                                {
                                    sequence.blurb && sequence.blurb !== '' &&
                                    <p>{sequence.blurb}</p>
                                }
                                {
                                    sequence.text && sequence.text !== '' &&
                                    <p>{sequence.text}</p>
                                }
                                <LimitedTextArea
                                    id={sequence.sequenceName + '_full_textarea'}
                                    className="form-control"
                                    value={sequence.full}
                                    setValue={(newValue) => updateFull(sequence.sequenceName, newValue)}
                                    rows={fullLimits[sequence.sequenceName]['rows']}
                                    limit={fullLimits[sequence.sequenceName]['max']}
                                    //curTokenCount={fullTokenCount}
                                    showCount={true}
                                />
                            </div>
                        }

                        {
                            (sequenceType === 'full' && !expandedSummaryHasValue) &&
                            <div className="float-start w-100 pt-3">
                                <p>The corresponding Expanded Summary for this sequence does not have a value. Enter an expanded summary in the previous tab before returning here to complete it in full.</p>
                            </div>
                        }
                    </div>

                </div>
                <div className='col-md-5'>

                    <Accordion defaultActiveKey={['1']} alwaysOpen>

                        <Accordion.Item eventKey="0">
                            <Accordion.Header>Advice</Accordion.Header>
                            <Accordion.Body>
                                <SequenceAdvice
                                    userInfo={userInfo}
                                    sequenceName={sequence.sequenceName}
                                    genres={genres}
                                    problemTemplate={problemTemplate}
                                    keywords={keywords}
                                    heroCharacterArchetype={heroCharacterArchetype}
                                    dramaticQuestion={dramaticQuestion}
                                />
                            </Accordion.Body>
                        </Accordion.Item>
                        {
                            sequenceType === 'blurb' &&
                            <Accordion.Item eventKey="1">
                                <Accordion.Header>Brainstorm Blurb with AI</Accordion.Header>
                                <Accordion.Body>
                                    {
                                        <div className='row'>
                                            <div className='col'>
                                                {
                                                    //userInfo && userInfo.userRoles.includes('customer') &&
                                                    <>
                                                        <p>Based on the log line, characters, and previous events, ask the AI to brainstorm a blurb for {sequence.sequenceName}.</p>
                                                        <SequenceBrainstorm
                                                            userInfo={userInfo}
                                                            plotId={plotId}
                                                            logLineDescription={logLineDescription}
                                                            genres={genres}
                                                            problemTemplate={problemTemplate}
                                                            dramaticQuestion={dramaticQuestion}
                                                            keywords={keywords}
                                                            sequences={sequences}
                                                            characters={characters}
                                                            completions={!sequence['blurbCompletions'] ? [] : sequence['blurbCompletions']}
                                                            targetSequence={sequence.sequenceName}
                                                            updateText={updateBlurb}
                                                            updateSequenceCompletions={updateBlurbCompletions}
                                                            completionURL={'GenerateBlurb'}
                                                            textPropName='blurb'
                                                            completionPropName={'blurbCompletions'}
                                                            tokensRemaining={tokensRemaining}
                                                            AILogLineDescriptions={AILogLineDescriptions}
                                                        />
                                                    </>
                                                }
                                                {/* {
                                                    (!userInfo || !userInfo.userRoles.includes('customer')) &&
                                                    <>
                                                        <SignUpMessage />
                                                    </>
                                                } */}
                                            </div>
                                        </div>
                                    }
                                </Accordion.Body>
                            </Accordion.Item>
                        }
                        {
                            sequenceType === 'expandedSummary' &&
                            <Accordion.Item eventKey="1">
                                <Accordion.Header>Brainstorm Expanded Summary with AI</Accordion.Header>
                                <Accordion.Body>
                                    {
                                        <div className='row'>
                                            <div className='col'>
                                                {
                                                    //userInfo && userInfo.userRoles.includes('customer') &&
                                                    <>
                                                        <p>Based on the log line, characters, and previous events, ask the AI to brainstorm an expanded summary for {sequence.sequenceName}.</p>
                                                        <SequenceBrainstorm
                                                            userInfo={userInfo}
                                                            plotId={plotId}
                                                            logLineDescription={logLineDescription}
                                                            genres={genres}
                                                            problemTemplate={problemTemplate}
                                                            dramaticQuestion={dramaticQuestion}
                                                            keywords={keywords}
                                                            sequences={sequences}
                                                            characters={characters}
                                                            completions={!sequence['completions'] ? [] : sequence['completions']}
                                                            targetSequence={sequence.sequenceName}
                                                            updateText={updateExpandedSummary}
                                                            updateSequenceCompletions={updateExpandedSummaryCompletions}
                                                            completionURL={'GenerateExpandedSummary'}
                                                            textPropName='text'
                                                            completionPropName={'completions'}
                                                            tokensRemaining={tokensRemaining}
                                                        />
                                                    </>
                                                }
                                                {/* {
                                                    (!userInfo || !userInfo.userRoles.includes('customer')) &&
                                                    <>
                                                        <SignUpMessage />
                                                    </>
                                                } */}
                                            </div>
                                        </div>
                                    }
                                </Accordion.Body>
                            </Accordion.Item>
                        }
                        {
                            sequenceType === 'full' &&
                            <Accordion.Item eventKey="1">
                                <Accordion.Header>Brainstorm Full with AI</Accordion.Header>
                                <Accordion.Body>
                                    {
                                        <div className='row'>
                                            <div className='col'>
                                                {
                                                    userInfo && userInfo.userRoles.includes('customer') &&
                                                    <>
                                                        <p>Based on the log line, characters, and previous events, ask the AI to brainstorm a full screenplay for {sequence.sequenceName}.</p>
                                                        <SequenceBrainstorm
                                                            userInfo={userInfo}
                                                            plotId={plotId}
                                                            logLineDescription={logLineDescription}
                                                            genres={genres}
                                                            problemTemplate={problemTemplate}
                                                            dramaticQuestion={dramaticQuestion}
                                                            keywords={keywords}
                                                            sequences={sequences}
                                                            characters={characters}
                                                            completions={!sequence['fullCompletions'] ? [] : sequence['fullCompletions']}
                                                            targetSequence={sequence.sequenceName}
                                                            updateText={updateFull}
                                                            updateSequenceCompletions={updateFullCompletions}
                                                            completionURL={'GenerateFull'}
                                                            textPropName='full'
                                                            completionPropName={'fullCompletions'}
                                                            tokensRemaining={tokensRemaining}
                                                        />
                                                    </>
                                                }
                                                {
                                                    (!userInfo || !userInfo.userRoles.includes('customer')) &&
                                                    <>
                                                        <SignUpMessage />
                                                    </>
                                                }
                                            </div>
                                        </div>
                                    }
                                </Accordion.Body>
                            </Accordion.Item>
                        }
                    </Accordion>
                </div>
            </div>
            {
                sequenceType === 'blurb' &&

                <div className='row pb-3 pt-3'>
                    {
                        NextSequencesButtonGroupMemo
                    }
                </div>
            }
        </>
    )
}

export default Sequence