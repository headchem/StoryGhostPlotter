import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { FaLock, FaLockOpen, FaCaretRight, FaGhost } from 'react-icons/fa'
import { fetchWithTimeout } from '../../../util/FetchUtil'
import LimitedTextArea from './LimitedTextArea'

const CharacterStage = ({
    stage,
    summary,
    setSummary,
    full,
    setFull,
    setNextAvailable,
    setNextUnavailable,
    isComplete,
    setPrevComplete,
    setPrevIncomplete,
    onFocusChange,

    genre,
    problemTemplate,
    keywords,
    heroArchetype,
    enemyArchetype,
    primalStakes,
    dramaticQuestion,

    orphanSummary,
    orphanFull,
    wandererSummary,
    wandererFull,
    warriorSummary,
    warriorFull,
    martyrSummary,
    martyrFull,
}) => {

    const navigate = useNavigate()

    const [summaryGenerateVisible, setSummaryGenerateVisible] = useState(true)
    const [summaryLockVisible, setSummaryLockVisible] = useState(true)
    const [summaryLocked, setSummaryLocked] = useState(false)
    const [fullLocked, setFullLocked] = useState(false)

    const [isSummaryLoading, setIsSummaryLoading] = useState(false)
    const [isFullLoading, setIsFullLoading] = useState(false)

    const fetchCompletion = async (completionType) => {

        fetchWithTimeout('/api/Generate', {
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

                'orphanSummary': orphanSummary,
                'orphanFull': orphanFull,
                'wandererSummary': wandererSummary,
                'wandererFull': wandererFull,
                'warriorSummary': warriorSummary,
                'warriorFull': warriorFull,
                'martyrSummary': martyrSummary,
                'martyrFull': martyrFull
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
            if (completionType.indexOf('Summary') > -1) {
                setSummary(data['completion'])
            } else {
                setFull(data['completion'])
            }

        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server. Please wait a few minutes and try again.');
        }).finally(function () {
            if (completionType.indexOf('Summary') > -1) {
                setIsSummaryLoading(false)
            } else {
                setIsFullLoading(false)
            }
        });


    }

    const onGenerateSummary = async () => {
        setIsSummaryLoading(true)
        fetchCompletion(stage + 'Summary')
    }

    const onGenerateFull = async () => {
        setIsFullLoading(true)
        fetchCompletion(stage + 'Full')
    }

    const onToggleSummaryLock = () => {
        const newSummaryLockedState = !summaryLocked

        setSummaryLocked(newSummaryLockedState)

        if (newSummaryLockedState === true) {
            setPrevComplete()
        } else {
            setPrevIncomplete()
        }
    }

    const onToggleFullLock = () => {
        const newFullLockedState = !fullLocked

        setFullLocked(newFullLockedState)

        if (newFullLockedState === true) {
            setNextAvailable()
            setSummaryGenerateVisible(false)
            setSummaryLockVisible(false)
        } else {
            setNextUnavailable()
            setSummaryGenerateVisible(true)
            setSummaryLockVisible(true)
        }
    }

    return (
        <div className='row border-top' onClick={onFocusChange}>
            <div className='col-4'>
                {
                    isSummaryLoading === false &&
                    <>
                        <div className='gen-controls bg-light'>
                            {
                                isComplete === false &&
                                <>
                                    {
                                        summaryGenerateVisible === true && summaryLocked === false &&
                                        <>
                                            <button onClick={onGenerateSummary} type="button" className="btn btn-primary m-3" >
                                                <FaGhost /> Generate with AI
                                            </button>
                                        </>
                                    }
                                </>
                            }
                            {

                                isComplete === false &&
                                <>
                                    {
                                        summaryLockVisible === true &&
                                        <button onClick={onToggleSummaryLock} className='btn btn-secondary lock m-3'>
                                            {
                                                summaryLocked === true &&
                                                <>
                                                    <FaLock /> Unlock
                                                </>
                                            }
                                            {
                                                summaryLocked === false &&
                                                <>
                                                    <FaLockOpen /> Lock
                                                </>
                                            }
                                        </button>
                                    }
                                </>

                            }
                        </div>

                        {
                            summaryLocked === false &&
                            <LimitedTextArea className="form-control" value={summary} setValue={setSummary} rows={5} limit={500} />
                            // <textarea className="form-control" value={summary} onChange={e => setSummary(e.target.value)} rows={5}></textarea>
                        }
                        {
                            summaryLocked === true &&
                            <p>{summary}</p>
                        }

                    </>
                }

                {
                    isSummaryLoading === true &&
                    <p>loading...</p>
                }
            </div>
            <div className='col-1'>
                <FaCaretRight className='gen-text-arrow text-muted' />
            </div>
            <div className='col-7'>
                {
                    isFullLoading === false &&
                    <>
                        {
                            summaryLocked === true &&
                            <>
                                <div className='gen-controls bg-light'>
                                    {
                                        fullLocked === false && isComplete === false &&
                                        <>
                                            <button type="button" className="btn btn-primary m-3" onClick={onGenerateFull}>
                                                <FaGhost /> Generate with AI
                                            </button>
                                        </>
                                    }

                                    {
                                        isComplete === false &&
                                        <button onClick={onToggleFullLock} className='btn btn-secondary lock m-3' >
                                            {
                                                fullLocked === true &&
                                                <>
                                                    <FaLock /> Unlock
                                                </>
                                            }
                                            {
                                                fullLocked === false &&
                                                <>
                                                    <FaLockOpen /> Lock
                                                </>
                                            }
                                        </button>
                                    }

                                </div>

                                {
                                    fullLocked === false &&
                                    // <textarea className="form-control" value={full} onChange={e => setFull(e.target.value)} rows={10}></textarea>
                                    <LimitedTextArea className="form-control" value={full} setValue={setFull} rows={10} limit={2000} />
                                }
                                {
                                    fullLocked === true &&
                                    <p style={{ whiteSpace: "pre-wrap" }}>{full}</p>
                                }

                            </>
                        }
                    </>
                }

                {
                    isFullLoading === true &&
                    <p>loading...</p>
                }
            </div>
        </div>
    )
}

export default CharacterStage
