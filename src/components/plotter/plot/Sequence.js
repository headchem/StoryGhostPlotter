import React, { useEffect, useState, useRef } from 'react'
import { FaLock, FaLockOpen, FaGhost } from 'react-icons/fa'
import { fetchWithTimeout } from '../../../util/FetchUtil'
import LimitedTextArea from './LimitedTextArea'

const Sequence = ({

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
    moveToNextSequence,
    moveToPrevSequence,
}) => {

    const textLimits = {
        'Opening Image': {
            'charMax': 150,
            'rows': 2
        },
        'Setup': {
            'charMax': 500,
            'rows': 8
        },
        'Theme Stated': {
            'charMax': 300,
            'rows': 5
        },
        'Setup (Continued)': {
            'charMax': 500,
            'rows': 7
        },
        'Catalyst': {
            'charMax': 300,
            'rows': 5
        },
        'Debate': {
            'charMax': 650,
            'rows': 10
        },
        'B Story': {
            'charMax': 300,
            'rows': 4
        },
        'Debate (Continued)': {
            'charMax': 300,
            'rows': 5
        },
        'Break Into Two': {
            'charMax': 250,
            'rows': 3
        },
        'Fun And Games': {
            'charMax': 1000,
            'rows': 18
        },
        'First Pinch Point': {
            'charMax': 150,
            'rows': 2
        },
        'Midpoint': {
            'charMax': 500,
            'rows': 7
        },
        'Bad Guys Close In': {
            'charMax': 1200,
            'rows': 20
        },
        'Second Pinch Point': {
            'charMax': 150,
            'rows': 2
        },
        'All Hope Is Lost': {
            'charMax': 500,
            'rows': 5
        },
        'Dark Night Of The Soul': {
            'charMax': 750,
            'rows': 8
        },
        'Break Into Three': {
            'charMax': 300,
            'rows': 4
        },
        'Climax': {
            'charMax': 1200,
            'rows': 20
        },
        'Cooldown': {
            'charMax': 350,
            'rows': 5
        }
    }

    const [isCompletionLoading, setIsCompletionLoading] = useState(false)
    const [sequenceAdvice, setSequenceAdvice] = useState('')
    const [isAdviceLoading, setIsAdviceLoading] = useState(false)
    const isFirstAdviceRun = useRef(true)

    const onGenerateCompletion = async () => {
        setIsCompletionLoading(true)
        fetchCompletion(sequence.sequenceName)
    }

    const getAdvice = async () => {
        setIsAdviceLoading(true)
        fetchAdvice(sequence.sequenceName)
    }

    // const onGenreChange = (inputValue, { action, prevInputValue }) => { // optional method signature if we ever need the previous value from the dropdown
    const onSequenceChange = (event) => {
        var selectElement = event.target;
        var value = selectElement.value;

        updateSequenceName(sequence.sequenceName, value)
        console.log('current sequence: ');
        console.log(sequence);
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
            setSequenceAdvice(data['advice'])
        }).catch(function (error) {
            console.warn(error);
        }).finally(function () {
            setIsAdviceLoading(false)
        });

    }

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        if (sequence.isLocked === false) {

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
        }

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [sequence, genre, problemTemplate, heroArchetype, enemyArchetype, primalStakes, dramaticQuestion], 500);

    return (

        <div className='row border-top m-3 p-3' onClick={onFocusChange}>
            <div className='col-3'>
                {
                    sequence.isLocked === false &&
                    <select className='sequence-name form-select' placeholder='Sequence' defaultValue={sequence.sequenceName} onChange={onSequenceChange}>
                        {
                            sequence.allowed.map(function (o) {
                                return <option key={o} value={o}>{o}</option>
                            })
                        }
                    </select>
                }
                {
                    sequence.isLocked === true &&
                    <p className='sequence-name'>{sequence.sequenceName}</p>
                }

                {
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
                }

            </div>
            <div className='col-4'>
                <LimitedTextArea
                    className="form-control"
                    value={sequence.text}
                    setValue={(newValue) => updateSequenceText(sequence.sequenceName, newValue)}
                    rows={textLimits[sequence.sequenceName]['rows']}
                    limit={textLimits[sequence.sequenceName]['charMax']}
                    showCount={!sequence.isLocked}
                />
                {
                    sequence.isLocked === false &&
                    <>
                        {
                            isCompletionLoading === false &&

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
            <div className='col-5'>
                {
                    sequence.isLocked === false &&
                    <>
                        <p className={`${isAdviceLoading ? 'text-loading' : ''}`}>{sequenceAdvice}</p>
                    </>
                }
            </div>
        </div>
    )
}

export default Sequence