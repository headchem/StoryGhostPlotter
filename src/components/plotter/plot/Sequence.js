import React, { useEffect, useState, useRef, useMemo } from 'react'
import { useNavigate } from "react-router-dom";
//import Popover from 'react-bootstrap/Popover';
import Accordion from 'react-bootstrap/Accordion';
//import OverlayTrigger from 'react-bootstrap/OverlayTrigger'
import Spinner from 'react-bootstrap/Spinner';
//import { useSearchParams } from "react-router-dom";
import { FaGhost, FaMinusCircle } from 'react-icons/fa'
import { fetchWithTimeout } from '../../../util/FetchUtil'
import LimitedTextArea from './LimitedTextArea'
import NextSequencesButtonGroup from './NextSequencesButtonGroup'
import { encode } from "../../../util/tokenizer/mod"; // FROM https://github.com/josephrocca/gpt-2-3-tokenizer


const Sequence = ({
    userInfo,
    onFocusChange,
    curFocusElName,

    genres,
    problemTemplate,
    keywords,
    characters,
    dramaticQuestion,

    sequence,
    sequences,

    updateContextText,
    updateEventsText,
    updateAIText,
    insertSequence,
    deleteSequence,
    allowed
}) => {

    const navigate = useNavigate()

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

    const [isCompletionLoading, setIsCompletionLoading] = useState(false)

    const [contextCommonAdvice, setContextCommonAdvice] = useState('')
    const [contextGenresAdvice, setContextGenresAdvice] = useState('')
    const [contextProblemTemplateAdvice, setContextProblemTemplateAdvice] = useState('')
    const [contextDramaticQuestionAdvice, setContextDramaticQuestionAdvice] = useState('')
    const [contextHeroArchetypeAdvice, setContextHeroArchetypeAdvice] = useState('')

    const [eventsCommonAdvice, setEventsCommonAdvice] = useState('')
    const [eventsGenresAdvice, setEventsGenresAdvice] = useState('')
    const [eventsProblemTemplateAdvice, setEventsProblemTemplateAdvice] = useState('')
    const [eventsDramaticQuestionAdvice, setEventsDramaticQuestionAdvice] = useState('')
    const [eventsHeroArchetypeAdvice, setEventsHeroArchetypeAdvice] = useState('')

    const [contextAdviceIsEmpty, setContextAdviceIsEmpty] = useState(true)
    const [eventsAdviceIsEmpty, setEventsAdviceIsEmpty] = useState(true)

    const [isAdviceLoading, setIsAdviceLoading] = useState(false)
    const [sequenceEventsTokenCount, setSequenceEventsTokenCount] = useState(0)
    const [sequenceContextTokenCount, setSequenceContextTokenCount] = useState(0)

    const [showConfirmDelete, setShowConfirmDelete] = useState(false)

    const onGenerateCompletion = async () => {
        setIsCompletionLoading(true)
        fetchCompletion(sequence.sequenceName)
    }

    const getAdvice = async () => {
        setIsAdviceLoading(true)
        fetchAdvice()
    }

    const onInsertSequence = (nextSequenceName) => {
        //console.log('insert new sequence: ' + sequence.sequenceName + ': ' + nextSequenceName)
        insertSequence(sequence.sequenceName, nextSequenceName)
    }

    const onDeleteSequence = () => {
        deleteSequence(sequence.sequenceName)
    }

    const fetchCompletion = async (sequenceName) => {
        fetchWithTimeout('/api/Sequence/Generate?sequenceName=' + sequenceName, {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'seed': 123,
                'genres': genres,
                'problemTemplate': problemTemplate,
                'keywords': keywords,
                'dramaticQuestion': dramaticQuestion,
                'sequences': sequences,
                'characters': characters
            })
        }).then(function (response) {
            if (response.status === 401 || response.status === 403) {
                navigate('/plots')
            } else {
                if (response.ok) {
                    return response.json();
                }
            }
            return Promise.reject(response);
        }).then(function (data) {
            updateAIText(sequence.sequenceName, data['completion'])
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server. Please wait a few minutes and try again.');
        }).finally(function () {
            setIsCompletionLoading(false)
        });
    }

    const updateTokenCount = () => {
        const seqText = sequence.text ? sequence.text : ''
        const contextText = sequence.context ? sequence.context : ''

        const eventsTokens = encode(seqText)
        const contextTokens = encode(contextText)
        setSequenceEventsTokenCount(eventsTokens.length)
        setSequenceContextTokenCount(contextTokens.length)
    }

    const fetchAdvice = async () => {
        let heroCharacter = characters.filter((character) => character.isHero === true);
        heroCharacter = heroCharacter.length > 0 ? heroCharacter[0] : null;

        fetch('/api/Sequence/Advice?sequenceName=' + sequence.sequenceName, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'genres': genres,
                'problemTemplate': problemTemplate,
                'keywords': keywords,
                'heroArchetype': (heroCharacter ? heroCharacter.archetype : ''),
                'dramaticQuestion': dramaticQuestion,
                'text': sequence.text,
                'context': sequence.context
            })
        }).then(function (response) {
            if (response.status === 401 || response.status === 403) {
                navigate('/plots')
            } else {
                if (response.ok) {
                    return response.json();
                }
            }
            return Promise.reject(response);
        }).then(function (data) {
            const eventsAdvice = data['events']
            const contextAdvice = data['context']

            const combinedContext = contextAdvice['common'] + contextAdvice['genres'] + contextAdvice['problemTemplate'] + contextAdvice['dramaticQuestion'] + contextAdvice['heroArchetype']
            const combinedContextTrimmed = combinedContext.replace(/\s/g, '').trim()

            setContextAdviceIsEmpty(combinedContextTrimmed.length === 0)


            setContextCommonAdvice(contextAdvice['common'])
            setContextGenresAdvice(contextAdvice['genres'])
            setContextProblemTemplateAdvice(contextAdvice['problemTemplate'])
            setContextDramaticQuestionAdvice(contextAdvice['dramaticQuestion'])
            setContextHeroArchetypeAdvice(contextAdvice['heroArchetype'])

            const combinedEvents = eventsAdvice['common'] + eventsAdvice['genres'] + eventsAdvice['problemTemplate'] + eventsAdvice['dramaticQuestion'] + eventsAdvice['heroArchetype']
            const combinedEventsTrimmed = combinedEvents.replace(/\s/g, '').trim()

            setEventsAdviceIsEmpty(combinedEventsTrimmed.length === 0)

            setEventsCommonAdvice(eventsAdvice['common'])
            setEventsGenresAdvice(eventsAdvice['genres'])
            setEventsProblemTemplateAdvice(eventsAdvice['problemTemplate'])
            setEventsDramaticQuestionAdvice(eventsAdvice['dramaticQuestion'])
            setEventsHeroArchetypeAdvice(eventsAdvice['heroArchetype'])
        }).catch(function (error) {
            console.warn(error);
        }).finally(function () {
            setIsAdviceLoading(false)
        });

    }

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        //if (sequence.isLocked === false) { // IMPORTANT: changing log line won't affect advice of older sequences that have already been locked
        const timeout = setTimeout(() => {
            getAdvice()
            updateTokenCount()
        }, 2000) //2000 - timeout to execute this function if timeout will be not cleared

        return () => clearTimeout(timeout) //clear timeout (delete function execution)
        //}

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [sequence, characters]);

    const isFirstAdviceRun = useRef(true)

    // BOTH of the useEffect below are to kick off getAdvice, once for LogLine changes, and another for new sequences being added

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {

        // run advice immediately, then debounce all subsequent requests
        if (isFirstAdviceRun.current) {
            isFirstAdviceRun.current = false
            getAdvice()
            return
        }

        const timeout = setTimeout(() => {
            getAdvice()
        }, 2000) //2000 - timeout to execute this function if timeout will be not cleared

        return () => clearTimeout(timeout) //clear timeout (delete function execution)

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [genres, problemTemplate, dramaticQuestion]);

    const NextSequencesButtonGroupMemo = useMemo(() => ( // useMemo prevents the buttons from flickering on keypress
        <NextSequencesButtonGroup
            allowed={allowed}
            onInsertSequence={onInsertSequence}
        />
        // eslint-disable-next-line react-hooks/exhaustive-deps
    ), [allowed]);


    // return true is any of the previous texts are empty. We need all previous texts to be filled out in order to generate a correctly formatted completion prompt.
    const brainstormDisabled = () => {
        const existingSequenceNamesArr = sequences.map((seq) => seq.sequenceName)
        const curSeqIndex = existingSequenceNamesArr.indexOf(sequence.sequenceName)
        const prevSeqsArr = sequences.slice(0, curSeqIndex) // +1 to include self
        const prevTexts = prevSeqsArr.map((seq) => seq.text)

        const isBlank = (str) => (!str || str.trim().length === 0);

        return prevTexts.some(isBlank)
    }

    return (
        <>
            <div className='row border-top mt-3 pt-3'>
                <div className='col-md-7'>
                    <h4>{sequence.sequenceName}</h4>

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

                    <div className='d-none' onFocus={() => onFocusChange('sequence_context')}>
                        <label title="hidden information, character backstories, or worldbuilding that drives the visible events" htmlFor={sequence.sequenceName + '_context_textarea'} className="form-label w-100">Background context <span className="text-muted">(optional)</span></label>
                        <LimitedTextArea
                            id={sequence.sequenceName + '_context_textarea'}
                            className="form-control"
                            value={sequence.context}
                            setValue={(newValue) => updateContextText(sequence.sequenceName, newValue)}
                            rows={3}
                            limit={400}
                            curTokenCount={sequenceContextTokenCount}
                            showCount={true}
                        />
                    </div>
                    <div onFocus={() => onFocusChange('sequence_events')}>
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
                    {
                        <>

                            <Accordion defaultActiveKey={['1']} alwaysOpen>
                                <Accordion.Item eventKey="0">
                                    <Accordion.Header>Brainstorm with AI</Accordion.Header>
                                    <Accordion.Body>
                                        {
                                            <div className='row'>
                                                {
                                                    userInfo && userInfo.userRoles.includes('customer') &&
                                                    <>
                                                        {
                                                            sequence.aiText && sequence.aiText.length > 0 &&
                                                            <p>{sequence.aiText}</p>
                                                        }

                                                        {
                                                            brainstormDisabled() === true &&
                                                            <p>Complete all previous texts to use the brainstorm feature.</p>
                                                        }
                                                        {
                                                            brainstormDisabled() === false &&
                                                            <button disabled={isCompletionLoading} title='This will add a new brainstorm - existing brainstorms will remain' type="button" className="generate btn btn-info mt-2 text-right" onClick={onGenerateCompletion}>
                                                                {
                                                                    isCompletionLoading === true &&
                                                                    <Spinner size="sm" as="span" animation="border" variant="secondary" />
                                                                }
                                                                {
                                                                    isCompletionLoading === false &&
                                                                    <FaGhost />
                                                                }
                                                                <span> Brainstorm with AI</span>
                                                            </button>
                                                        }
                                                    </>
                                                }
                                                {
                                                    (!userInfo || !userInfo.userRoles.includes('customer')) &&
                                                    <>
                                                        <p>Sign up for our premium plan to ask the AI to brainstorm ideas for this sequence.</p>
                                                    </>
                                                }

                                            </div>
                                        }
                                    </Accordion.Body>
                                </Accordion.Item>
                                <Accordion.Item eventKey="1">
                                    <Accordion.Header>Advice</Accordion.Header>
                                    <Accordion.Body>
                                        {
                                            contextAdviceIsEmpty === false &&
                                            <>
                                                <h5 title="Info hidden from the reader, or character backstories that inform the visible events">Background Context</h5>
                                                <p className={`${isAdviceLoading ? 'text-loading' : ''}`}>
                                                    <span title="common advice">{contextCommonAdvice} </span>
                                                    <span title="genres advice">{contextGenresAdvice} </span>
                                                    <span title="problem template advice">{contextProblemTemplateAdvice} </span>
                                                    <span title="dramatic question advice">{contextDramaticQuestionAdvice}</span>
                                                    <span title="hero archetype advice">{contextHeroArchetypeAdvice} </span>
                                                </p>
                                            </>
                                        }
                                        {
                                            contextAdviceIsEmpty === false && eventsAdviceIsEmpty === false &&
                                            <hr title="given the context above, therefore the events below transpired..." />
                                        }
                                        {
                                            eventsAdviceIsEmpty === false &&
                                            <>
                                                <h5 title="string events together with 'therefore' instead of 'and then'">Events</h5>
                                                <p className={`${isAdviceLoading ? 'text-loading' : ''}`}>
                                                    <span title="common advice">{eventsCommonAdvice} </span>
                                                    <span title="genres advice">{eventsGenresAdvice} </span>
                                                    <span title="problem template advice">{eventsProblemTemplateAdvice} </span>
                                                    <span title="dramatic question advice">{eventsDramaticQuestionAdvice}</span>
                                                    <span title="hero archetype advice">{eventsHeroArchetypeAdvice} </span>
                                                </p>
                                            </>
                                        }




                                    </Accordion.Body>
                                </Accordion.Item>
                            </Accordion>


                        </>
                    }
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