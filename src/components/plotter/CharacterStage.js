import React, { useState } from 'react'
import { FaLock, FaLockOpen, FaPencilAlt, FaCaretRight } from 'react-icons/fa'

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

    const [summaryGenerateVisible, setSummaryGenerateVisible] = useState(true)
    const [summaryLockVisible, setSummaryLockVisible] = useState(true)
    const [summaryLocked, setSummaryLocked] = useState(false)
    const [fullLocked, setFullLocked] = useState(false)

    const [isSummaryLoading, setIsSummaryLoading] = useState(false)
    const [isFullLoading, setIsFullLoading] = useState(false)

    const fetchCompletion = async (completionType) => {

        fetch('/api/Generate', {
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
            if (response.ok) {
                return response.json();
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
        setFull('')
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
        <div className='row stage' onClick={onFocusChange}>
            <div className='col-4'>
                {
                    isSummaryLoading === false &&
                    <>
                        <div className='gen-controls'>
                            {
                                isComplete === false &&
                                <>
                                    {
                                        summaryGenerateVisible === true && summaryLocked === false &&
                                        <button onClick={onGenerateSummary} className='btn btn-primary generate m-3'><FaPencilAlt /> Generate</button>
                                    }
                                </>
                            }
                            {
                                summary !== '' &&
                                <>
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
                                </>
                            }
                        </div>
                        {
                            summary !== '' &&
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
                <FaCaretRight className='gen-text-arrow' />
            </div>
            <div className='col-7'>
                {
                    isFullLoading === false &&
                    <>
                        {
                            summaryLocked === true &&
                            <>
                                <div className='gen-controls'>
                                    {
                                        fullLocked === false && isComplete === false &&
                                        <button onClick={onGenerateFull} className='btn btn-primary generate m-3'><FaPencilAlt /> Generate</button>
                                    }
                                    {
                                        full !== '' &&
                                        <>
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
                                        </>
                                    }
                                </div>
                                {
                                    full !== '' &&
                                    <p>{full}</p>
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
