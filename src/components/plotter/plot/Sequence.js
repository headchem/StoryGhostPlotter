import React, { useEffect, useState, useMemo } from 'react'
import Accordion from 'react-bootstrap/Accordion';
import { FaMinusCircle } from 'react-icons/fa'
import LimitedTextArea from './LimitedTextArea'
import NextSequencesButtonGroup from './NextSequencesButtonGroup'
//import { getTokenCount } from "../../../util/Tokenizer";
import SequenceAdvice from './SequenceAdvice'
import SequenceBrainstorm from './Brainstorm/SequenceBrainstorm'
import SignUpMessage from './SignUpMessage'

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
    tokensRemaining
}) => {

    const blurbLimits = {
        'Opening Image': {
            'max': 200,
            'rows': 2
        },
        'Setup': {
            'max': 400,
            'rows': 4
        },
        'Theme Stated': {
            'max': 200,
            'rows': 2
        },
        'Setup (Continued)': {
            'max': 200,
            'rows': 2
        },
        'Catalyst': {
            'max': 200,
            'rows': 2
        },
        'Debate': {
            'max': 350,
            'rows': 3
        },
        'B Story': {
            'max': 150,
            'rows': 2
        },
        'Debate (Continued)': {
            'max': 100,
            'rows': 1
        },
        'Break Into Two': {
            'max': 250,
            'rows': 2
        },
        'Fun And Games': {
            'max': 400,
            'rows': 5
        },
        'First Pinch Point': {
            'max': 100,
            'rows': 2
        },
        'Midpoint': {
            'max': 200,
            'rows': 2
        },
        'Bad Guys Close In': {
            'max': 400,
            'rows': 4
        },
        'Second Pinch Point': {
            'max': 150,
            'rows': 2
        },
        'All Hope Is Lost': {
            'max': 300,
            'rows': 3
        },
        'Dark Night Of The Soul': {
            'max': 350,
            'rows': 4
        },
        'Break Into Three': {
            'max': 200,
            'rows': 2
        },
        'Climax': {
            'max': 400,
            'rows': 4
        },
        'Cooldown': {
            'max': 200,
            'rows': 2
        }
    }

    const expandedSummaryLimits = {
        'Opening Image': {
            'max': 400,
            'rows': 4
        },
        'Setup': {
            'max': 900,
            'rows': 9
        },
        'Theme Stated': {
            'max': 500,
            'rows': 6
        },
        'Setup (Continued)': {
            'max': 500,
            'rows': 7
        },
        'Catalyst': {
            'max': 500,
            'rows': 7
        },
        'Debate': {
            'max': 800,
            'rows': 11
        },
        'B Story': {
            'max': 400,
            'rows': 5
        },
        'Debate (Continued)': {
            'max': 300,
            'rows': 5
        },
        'Break Into Two': {
            'max': 650,
            'rows': 8
        },
        'Fun And Games': {
            'max': 1700,
            'rows': 22
        },
        'First Pinch Point': {
            'max': 150,
            'rows': 2
        },
        'Midpoint': {
            'max': 500,
            'rows': 6
        },
        'Bad Guys Close In': {
            'max': 1000,
            'rows': 14
        },
        'Second Pinch Point': {
            'max': 350,
            'rows': 5
        },
        'All Hope Is Lost': {
            'max': 500,
            'rows': 7
        },
        'Dark Night Of The Soul': {
            'max': 750,
            'rows': 10
        },
        'Break Into Three': {
            'max': 600,
            'rows': 8
        },
        'Climax': {
            'max': 1100,
            'rows': 14
        },
        'Cooldown': {
            'max': 600,
            'rows': 8
        }
    }

    const fullLimits = {
        'Opening Image': {
            'max': 4000,
            'rows': 4
        },
        'Setup': {
            'max': 9000,
            'rows': 9
        },
        'Theme Stated': {
            'max': 5000,
            'rows': 6
        },
        'Setup (Continued)': {
            'max': 5000,
            'rows': 7
        },
        'Catalyst': {
            'max': 5000,
            'rows': 7
        },
        'Debate': {
            'max': 8000,
            'rows': 11
        },
        'B Story': {
            'max': 4000,
            'rows': 5
        },
        'Debate (Continued)': {
            'max': 3000,
            'rows': 5
        },
        'Break Into Two': {
            'max': 6500,
            'rows': 8
        },
        'Fun And Games': {
            'max': 17000,
            'rows': 22
        },
        'First Pinch Point': {
            'max': 1500,
            'rows': 2
        },
        'Midpoint': {
            'max': 5000,
            'rows': 6
        },
        'Bad Guys Close In': {
            'max': 10000,
            'rows': 14
        },
        'Second Pinch Point': {
            'max': 3500,
            'rows': 5
        },
        'All Hope Is Lost': {
            'max': 5000,
            'rows': 7
        },
        'Dark Night Of The Soul': {
            'max': 7500,
            'rows': 10
        },
        'Break Into Three': {
            'max': 6000,
            'rows': 8
        },
        'Climax': {
            'max': 11000,
            'rows': 14
        },
        'Cooldown': {
            'max': 6000,
            'rows': 8
        }
    }

    // const [blurbTokenCount, setBlurbTokenCount] = useState(0)
    // const [expandedSummaryTokenCount, setExpandedSummaryTokenCount] = useState(0)
    // const [fullTokenCount, setFullTokenCount] = useState(0)

    const [showConfirmDelete, setShowConfirmDelete] = useState(false)

    const onInsertSequence = (nextSequenceName) => {
        //console.log('insert new sequence: ' + sequence.sequenceName + ': ' + nextSequenceName)
        insertSequence(sequence.sequenceName, nextSequenceName)
    }

    const onDeleteSequence = () => {
        deleteSequence(sequence.sequenceName)
    }

    // const updateBlurbTokenCount = async () => {
    //     const text = sequence.blurb ? sequence.blurb : ''

    //     const tokenCount = await getTokenCount(text)
    //     setBlurbTokenCount(tokenCount)
    // }

    // const updateExpandedSummaryTokenCount = async () => {
    //     const text = sequence.text ? sequence.text : ''

    //     const tokenCount = await getTokenCount(text)
    //     setExpandedSummaryTokenCount(tokenCount)
    // }

    // const updateFullTokenCount = async () => {
    //     const text = sequence.full ? sequence.full : ''

    //     const tokenCount = await getTokenCount(text)
    //     setFullTokenCount(tokenCount)
    // }

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
                                <label title="short logic blurb describing the absolute minimum required to explain the story" htmlFor={sequence.sequenceName + '_blurb_textarea'} className="form-label w-100 d-none">Visible Events</label>
                                {
                                    sequence.text && sequence.text !== '' &&
                                    <p>{sequence.text}</p>
                                }
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
                            </div>
                        }

                        {
                            sequenceType === 'expandedSummary' && sequence.blurb && sequence.blurb !== '' &&
                            <div className="float-start w-100 pt-3">
                                <label title="concrete events and interactions visible to the audience" htmlFor={sequence.sequenceName + '_expanded_summary_textarea'} className="form-label w-100 d-none">Visible Events</label>
                                {
                                    sequence.blurb && sequence.blurb !== '' &&
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
                            sequenceType === 'full' && sequence.text && sequence.text !== '' &&
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
                                                    userInfo && userInfo.userRoles.includes('customer') &&
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
                        {
                            sequenceType === 'expandedSummary' &&
                            <Accordion.Item eventKey="1">
                                <Accordion.Header>Brainstorm Expanded Summary with AI</Accordion.Header>
                                <Accordion.Body>
                                    {
                                        <div className='row'>
                                            <div className='col'>
                                                {
                                                    userInfo && userInfo.userRoles.includes('customer') &&
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