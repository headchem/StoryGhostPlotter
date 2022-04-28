import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { FaGhost } from 'react-icons/fa'
import Spinner from 'react-bootstrap/Spinner';

import { fetchWithTimeout } from '../../../util/FetchUtil'

const LogLineBrainstormAll = (
    {
        userInfo,
        genres,
        setKeywords,
        setLogLineDescription,
        setTitle,
        setProblemTemplate,
        setDramaticQuestion
    }
) => {

    const navigate = useNavigate()

    const [isLoading, setIsLoading] = useState(false)

    const onGenerate = async () => {
        setIsLoading(true)
        fetchAll()
    }

    const fetchAll = async () => {
        fetchWithTimeout('/api/LogLine/GenerateAll', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'seed': 123,
                'genres': genres
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
            console.log(data)
            setKeywords(data['keywords'] ?? [])
            setLogLineDescription(data['logLineDescription'])
            setTitle(data['title'])
            setProblemTemplate(data['problemTemplate'])
            setDramaticQuestion(data['dramaticQuestion'])
        }).catch(function (error) {
            console.warn(error);
        }).finally(function () {
            setIsLoading(false)
        });
    }

    return (
        <div className='row'>
            <div className="alert alert-warning" role="alert">
                <p>Based on the genres above, ask the AI to fill out the keywords, log line, title, problem template, and dramatic question.</p>
                
                <button disabled={isLoading} type="button" className="btn btn-warning" onClick={onGenerate}>
                    {
                        isLoading === true &&
                        <Spinner size="sm" as="span" animation="border" variant="secondary" />
                    }
                    {
                        isLoading === false &&
                        <FaGhost />
                    }
                    <span> Delete and Regenerate All Log Line Inputs</span>
                </button>

            </div>
        </div>
    )
}

export default LogLineBrainstormAll