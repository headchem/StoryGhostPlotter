import React, { useEffect, useState, useMemo } from 'react'
import Accordion from 'react-bootstrap/Accordion';
import { FaMinusCircle } from 'react-icons/fa'
import LimitedTextArea from './LimitedTextArea'
import NextSequencesButtonGroup from './NextSequencesButtonGroup'
import { getTokenCount } from "../../../util/Tokenizer";
import SequenceAdvice from './SequenceAdvice'
import SequenceBrainstorm from './SequenceBrainstorm'

const Sequence = ({
    userInfo,

    genres,
    problemTemplate,
    keywords,
    characters,
    dramaticQuestion,
    logLineDescription,

    sequence,
    sequences,

    updateEventsText,
    insertSequence,
    deleteSequence,
    updateSequenceCompletions,
    allowed
}) => {

    const textLimits = {
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

    const [sequenceEventsTokenCount, setSequenceEventsTokenCount] = useState(0)

    const [showConfirmDelete, setShowConfirmDelete] = useState(false)

    const onInsertSequence = (nextSequenceName) => {
        //console.log('insert new sequence: ' + sequence.sequenceName + ': ' + nextSequenceName)
        insertSequence(sequence.sequenceName, nextSequenceName)
    }

    const onDeleteSequence = () => {
        deleteSequence(sequence.sequenceName)
    }

    const updateTokenCount = async () => {
        const seqText = sequence.text ? sequence.text : ''

        const eventsTokenCount = await getTokenCount(seqText)
        setSequenceEventsTokenCount(eventsTokenCount)
    }

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        //if (sequence.isLocked === false) { // IMPORTANT: changing log line won't affect advice of older sequences that have already been locked
        const timeout = setTimeout(() => {
            //getAdvice()
            updateTokenCount()
        }, 2000) //2000 - timeout to execute this function if timeout will be not cleared

        return () => clearTimeout(timeout) //clear timeout (delete function execution)
        //}

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [sequence, characters]);

    const NextSequencesButtonGroupMemo = useMemo(() => ( // useMemo prevents the buttons from flickering on keypress
        <NextSequencesButtonGroup
            allowed={allowed}
            onInsertSequence={onInsertSequence}
        />
        // eslint-disable-next-line react-hooks/exhaustive-deps
    ), [allowed]);


    // return true is any of the previous texts are empty. We need all previous texts to be filled out in order to generate a correctly formatted completion prompt.
    // const brainstormDisabled = () => {
    //     const existingSequenceNamesArr = sequences.map((seq) => seq.sequenceName)
    //     const curSeqIndex = existingSequenceNamesArr.indexOf(sequence.sequenceName)
    //     const prevSeqsArr = sequences.slice(0, curSeqIndex) // +1 to include self
    //     const prevTexts = prevSeqsArr.map((seq) => seq.text)

    //     const isBlank = (str) => (!str || str.trim().length === 0);

    //     return prevTexts.some(isBlank)
    // }

    return (
        <>
            <div className='row border-top mt-3 pt-3'>
                <div className='col-md-7'>
                    {/* <div className='col-md-7'> */}
                    <h4 className="float-start">{sequence.sequenceName}</h4>
                    {
                        sequence.sequenceName !== 'Opening Image' &&
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

                    <div className="float-start w-100 pt-3">
                        <label title="concrete events and interactions visible to the audience" htmlFor={sequence.sequenceName + '_events_textarea'} className="form-label w-100 d-none">Visible Events</label>
                        <LimitedTextArea
                            id={sequence.sequenceName + '_events_textarea'}
                            className="form-control"
                            value={sequence.text}
                            setValue={(newValue) => updateEventsText(sequence.sequenceName, newValue)}
                            rows={textLimits[sequence.sequenceName]['rows']}
                            limit={textLimits[sequence.sequenceName]['max']}
                            curTokenCount={sequenceEventsTokenCount}
                            showCount={true}
                        />
                    </div>

                </div>
                <div className='col-md-5'>

                    <Accordion defaultActiveKey={[]} alwaysOpen>

                        <Accordion.Item eventKey="0">
                            <Accordion.Header>Advice</Accordion.Header>
                            <Accordion.Body>
                                <SequenceAdvice
                                    userInfo={userInfo}
                                    sequenceName={sequence.sequenceName}
                                    genres={genres}
                                    problemTemplate={problemTemplate}
                                    keywords={keywords}
                                    characters={characters}
                                    dramaticQuestion={dramaticQuestion}
                                    //sequence={sequence}
                                    sequences={sequences}
                                />
                            </Accordion.Body>
                        </Accordion.Item>
                        <Accordion.Item eventKey="1">
                            <Accordion.Header>Brainstorm with AI</Accordion.Header>
                            <Accordion.Body>
                                {
                                    <div className='row'>
                                        <div className='col'>
                                            <p>Based on the log line, characters, and previous events, ask the AI to brainstorm for {sequence.sequenceName}.</p>
                                            {
                                                userInfo && userInfo.userRoles.includes('customer') &&

                                                <SequenceBrainstorm
                                                    userInfo={userInfo}
                                                    logLineDescription={logLineDescription}
                                                    genres={genres}
                                                    problemTemplate={problemTemplate}
                                                    dramaticQuestion={dramaticQuestion}
                                                    keywords={keywords}
                                                    sequences={sequences}
                                                    characters={characters}
                                                    completions={!sequence['completions'] ? [] : sequence['completions']}
                                                    targetSequence={sequence.sequenceName}
                                                    updateSequenceCompletions={updateSequenceCompletions}
                                                />
                                            }
                                            {
                                                (!userInfo || !userInfo.userRoles.includes('customer')) &&
                                                <>
                                                    <p>Sign up for our premium plan to ask the AI to brainstorm ideas.</p>
                                                </>
                                            }
                                        </div>
                                    </div>
                                }
                            </Accordion.Body>
                        </Accordion.Item>

                    </Accordion>


                </div>
            </div>
            <div className='row pb-3 pt-3'>
                {
                    NextSequencesButtonGroupMemo
                }
            </div>
        </>
    )
}

export default Sequence