import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { FaGhost } from 'react-icons/fa'
import Spinner from 'react-bootstrap/Spinner';
import SignUpMessage from './SignUpMessage'

import { fetchWithTimeout } from '../../../util/FetchUtil'

const TitleBrainstorm = (
    {
        userInfo,
        plotId,
        AITitles,
        logLineDescription,
        genres,
        setAITitles,
        tokensRemaining
    }
) => {

    const navigate = useNavigate()

    const [isTitlesCompletionLoading, setIsTitlesCompletionLoading] = useState(false)

    const onGenerateTitlesCompletion = async () => {
        setIsTitlesCompletionLoading(true)
        fetchTitlesCompletion()
    }

    const fetchTitlesCompletion = async () => {
        fetchWithTimeout('/api/Titles/Generate', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'seed': 123,
                'id': plotId, 
                'genres': genres,
                'logLineDescription': logLineDescription
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
            setAITitles(data)
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server or you have run out of tokens');
        }).finally(function () {
            setIsTitlesCompletionLoading(false)
        });
    }

    const aiTitlesListItems = (AITitles ?? []).map((t, idx) =>
        <li key={idx}>{t}</li>
    )

    return (
        <>
            <p id="titleHelp">A few short words that capture something symbolic about the story. Don't worry about getting the perfect title right now - treat it like a draft and come back to it later.</p>
            {
                userInfo && userInfo.userRoles.includes('customer') &&
                <>
                    {
                        tokensRemaining <= 0 &&
                        <>
                            <p>You have run out of tokens.</p>
                        </>
                    }
                    {
                        tokensRemaining > 0 &&
                        <>
                            <ul>
                                {
                                    aiTitlesListItems
                                }
                            </ul>
                            <p className='text-muted'>Sometimes the generated titles have already been used by other authors or movies, so we recommend searching for the title before using it.</p>
                            <button disabled={isTitlesCompletionLoading} type="button" className="btn btn-info mt-2" onClick={onGenerateTitlesCompletion}>
                                {
                                    isTitlesCompletionLoading === true &&
                                    <Spinner size="sm" as="span" animation="border" variant="secondary" />
                                }
                                {
                                    isTitlesCompletionLoading === false &&
                                    <FaGhost />
                                }
                                <span> New AI Brainstorm</span>
                            </button>
                        </>
                    }
                </>
            }
            {
                (!userInfo || !userInfo.userRoles.includes('customer')) &&
                <SignUpMessage />
            }
        </>
    )
}

export default TitleBrainstorm