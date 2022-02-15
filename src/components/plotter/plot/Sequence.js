import React, { useEffect, useState, useRef } from 'react'
//import { useSearchParams } from "react-router-dom";
import { FaLock, FaLockOpen, FaGhost } from 'react-icons/fa'
import { fetchWithTimeout } from '../../../util/FetchUtil'
import LimitedTextArea from './LimitedTextArea'
import { encode } from "../../../util/tokenizer/mod"; // FROM https://github.com/josephrocca/gpt-2-3-tokenizer


const Sequence = ({
    userInfo,
    onFocusChange,

    genre,
    problemTemplate,
    keywords,
    heroArchetype,
    enemyArchetype,
    primalStakes,
    dramaticQuestion,

    sequence,
    sequences,

    updateSequenceText,
    updateSequenceName,
    //moveToNextSequence,
    //moveToPrevSequence,
    insertSequence,
    deleteSequence,
    allowed
}) => {

    //const [searchParams] = useSearchParams()

    const textLimits = {
        'Opening Image': {
            'max': 300,
            'rows': 3
        },
        'Setup': {
            'max': 500,
            'rows': 7
        },
        'Theme Stated': {
            'max': 300,
            'rows': 5
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
            'max': 500,
            'rows': 7
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
            'max': 400,
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
    const [commonAdvice, setCommonAdvice] = useState('')
    const [genreAdvice, setGenreAdvice] = useState('')
    const [problemTemplateAdvice, setProblemTemplateAdvice] = useState('')
    const [heroArchetypeAdvice, setHeroArchetypeAdvice] = useState('')
    const [enemyArchetypeAdvice, setEnemyArchetypeAdvice] = useState('')
    const [primalStakesAdvice, setPrimalStakesAdvice] = useState('')
    const [dramaticQuestionAdvice, setDramaticQuestionAdvice] = useState('')
    const [isAdviceLoading, setIsAdviceLoading] = useState(false)
    const [sequenceTokenCount, setSequenceTokenCount] = useState(0)

    const onGenerateCompletion = async () => {
        setIsCompletionLoading(true)
        fetchCompletion(sequence.sequenceName)
    }

    const getAdvice = async () => {
        setIsAdviceLoading(true)
        fetchAdvice(sequence.sequenceName)
    }

    // const onSequenceChange = (event) => {
    //     var value = event.target.value;
    //     setNextSequenceName(value)
    //     //updateSequenceName(sequence.sequenceName, value)
    //     //console.log('current sequence: ');
    //     //console.log(sequence);
    // }

    const onInsertSequence = (nextSequenceName) => {
        console.log('insert new sequence: ' + sequence.sequenceName + ': ' + nextSequenceName)
        insertSequence(sequence.sequenceName, nextSequenceName)
    }

    const onDeleteSequence = () => {
        deleteSequence(sequence.sequenceName)
    }

    const fetchCompletion = async (completionType) => {
        fetchWithTimeout('/api/Sequence/Generate', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'completionType': completionType,
                'seed': 123,
                'genre': genre,
                'problemTemplate': problemTemplate,
                'keywords': keywords,
                'heroArchetype': heroArchetype,
                'enemyArchetype': enemyArchetype,
                'primalStakes': primalStakes,
                'dramaticQuestion': dramaticQuestion,

                'sequences': sequences
            })
        }).then(function (response) {
            if (response.ok) {
                return response.json();
            }
            return Promise.reject(response);
        }).then(function (data) {
            updateSequenceText(sequence.sequenceName, data['completion'])
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server. Please wait a few minutes and try again.');
        }).finally(function () {
            setIsCompletionLoading(false)
        });
    }

    const updateTokenCount = () => {
        const tokens = encode(sequence.text)
        setSequenceTokenCount(tokens.length)
    }

    const fetchAdvice = async (completionType) => {
        fetch('/api/Sequence/Advice?sequenceName=' + sequence.sequenceName, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'completionType': completionType,
                'genre': genre,
                'problemTemplate': problemTemplate,
                'keywords': keywords,
                'heroArchetype': heroArchetype,
                'enemyArchetype': enemyArchetype,
                'primalStakes': primalStakes,
                'dramaticQuestion': dramaticQuestion,
                'text': sequence.text
            })
        }).then(function (response) {
            if (response.ok) {
                return response.json();
            }
            return Promise.reject(response);
        }).then(function (data) {
            setCommonAdvice(data['common'])
            setGenreAdvice(data['genre'])
            setProblemTemplateAdvice(data['problemTemplate'])
            setHeroArchetypeAdvice(data['heroArchetype'])
            setEnemyArchetypeAdvice(data['enemyArchetype'])
            setPrimalStakesAdvice(data['primalStakes'])
            setDramaticQuestionAdvice(data['dramaticQuestion'])
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
    }, [sequence]);

    const isFirstAdviceRun = useRef(true)

    // BOTH of the useEffect below are to kick off getAdvice, once for LogLine changes, and another for new sequences being added

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {

        // run advice immediately, then debounce all subsequent requests
        if (isFirstAdviceRun.current) {
            isFirstAdviceRun.current = false
            //getAdvice()
            return
        }

        const timeout = setTimeout(() => {
            getAdvice()
        }, 2000) //2000 - timeout to execute this function if timeout will be not cleared

        return () => clearTimeout(timeout) //clear timeout (delete function execution)

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [genre, problemTemplate, heroArchetype, enemyArchetype, primalStakes, dramaticQuestion]);


    // load advice on first load of a new Sequence component
    useEffect(() => {
        getAdvice()
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [])

    const optionalSequences = ['Theme Stated', 'Setup (Continued)', 'Debate (Continued)', 'B Story', 'First Pinch Point', 'Second Pinch Point']

    return (

        <div className='row border-top m-3 p-3' onClick={onFocusChange}>
            <div className='col-md-2'>
                {/* {
                    sequence.isLocked === false &&
                    <select className='sequence-name form-select' placeholder='Sequence' defaultValue={sequence.sequenceName} onChange={onSequenceChange}>
                        {
                            sequence.allowed.map(function (o) {
                                return <option key={o} value={o}>{o}</option>
                            })
                        }
                    </select>
                } */}
                {/* {
                    sequence.isLocked === true &&
                    <p className='sequence-name'>{sequence.sequenceName}</p>
                } */}
                <p className='sequence-name'>{sequence.sequenceName}</p>

                {/* {
                    sequence.isReadOnly === false &&
                    <>
                        {
                            sequence.isLocked === false &&
                            <button className='lock btn btn-secondary mt-2 text-right' onClick={() => moveToNextSequence(sequence.sequenceName)}>
                                <>
                                    <FaLockOpen /> Lock
                                </>
                            </button>
                        }
                        {
                            sequence.isLocked === true &&
                            <button className='lock btn btn-secondary mt-2 text-right' onClick={() => moveToPrevSequence(sequence.sequenceName)}>
                                <>
                                    <FaLock /> Unlock
                                </>
                            </button>
                        }
                    </>
                } */}

                {
                    allowed.length > 0 &&
                    <>
                        {
                            allowed.map(function (nextAllowed) {
                                return <button className={optionalSequences.indexOf(nextAllowed) > -1 ? 'btn btn-secondary' : 'btn btn-primary'} onClick={() => onInsertSequence(nextAllowed)}>Insert {nextAllowed}</button>
                            })
                        }
                    </>
                }

                <button onClick={onDeleteSequence} className='btn btn-danger'>delete current</button>

            </div>
            <div className='col-md-6'>
                <LimitedTextArea
                    className="form-control"
                    value={sequence.text}
                    setValue={(newValue) => updateSequenceText(sequence.sequenceName, newValue)}
                    rows={textLimits[sequence.sequenceName]['rows']}
                    limit={textLimits[sequence.sequenceName]['max']}
                    curTokenCount={sequenceTokenCount}
                    // showCount={!sequence.isLocked}
                    showCount={true}
                />
                {
                    //sequence.isLocked === false &&
                    <>
                        {
                            isCompletionLoading === false && userInfo && userInfo.userRoles.includes('customer') &&

                            <button type="button" className="generate btn btn-primary mt-2 text-right" onClick={onGenerateCompletion}>
                                <FaGhost /> Generate with AI
                            </button>
                        }
                        {
                            isCompletionLoading === true &&
                            <p className="text-right">loading...</p>
                        }
                    </>
                }

            </div>
            <div className='col-md-4'>
                {
                    //sequence.isLocked === false &&
                    <>
                        <p className={`${isAdviceLoading ? 'text-loading' : ''}`}>
                            <span title="common advice">{commonAdvice}</span>
                            <span title="genre advice">{genreAdvice}</span>
                            <span title="problem template advice">{problemTemplateAdvice}</span>
                            <span title="hero archetype advice">{heroArchetypeAdvice}</span>
                            <span title="enemy archetype advice">{enemyArchetypeAdvice}</span>
                            <span title="primal stakes advice">{primalStakesAdvice}</span>
                            <span title="dramatic question advice">{dramaticQuestionAdvice}</span>
                        </p>
                    </>
                }
            </div>
        </div>
    )
}

export default Sequence