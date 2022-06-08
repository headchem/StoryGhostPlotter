import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { FaGhost } from 'react-icons/fa'
import Spinner from 'react-bootstrap/Spinner';
import { fetchWithTimeout } from '../../../../util/FetchUtil'

const KeywordsBrainstorm = (
    {
        userInfo,
        genres
    }
) => {

    const navigate = useNavigate()

    const [isKeywordsLoading, setIsKeywordsLoading] = useState(false)
    const [aiKeywords, setAIKeywords] = useState([])

    const onGenerateKeywords = async () => {
        setIsKeywordsLoading(true)
        fetchKeywords()
    }

    const fetchKeywords = async () => {
        fetchWithTimeout('/api/Keywords?genres=' + genres.join(',') + '&numKeywords=7', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
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
            setAIKeywords(data)
        }).catch(function (error) {
            console.warn(error);
        }).finally(function () {
            setIsKeywordsLoading(false)
        });
    }

    const aiKeywordsListItems = (aiKeywords ?? []).map((keyword, idx) =>
        <li key={idx}>{keyword}</li>
    )

    return (

        <>
            <p>Genre-appropriate ({genres.join(', ')}) keywords and concepts this story focuses on.</p>

            <ul>
                {
                    aiKeywordsListItems
                }
            </ul>
            <button disabled={isKeywordsLoading} title='Generate ' type="button" className="btn btn-info mt-2" onClick={onGenerateKeywords}>
                {
                    isKeywordsLoading === true &&
                    <Spinner size="sm" as="span" animation="border" variant="secondary" />
                }
                {
                    isKeywordsLoading === false &&
                    <FaGhost />
                }
                <span> New Keywords Brainstorm</span>
            </button>
        </>

    )
}

export default KeywordsBrainstorm