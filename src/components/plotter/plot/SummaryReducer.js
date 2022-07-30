import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { fetchWithTimeout } from '../../../util/FetchUtil'

const SummaryReducer = ({
    userInfo,
    plotId,
    characters,
    longText,
    tokensRemaining
}) => {
    const navigate = useNavigate()

    const [isCompletionLoading, setIsCompletionLoading] = useState(false)
    const [completions, setCompletions] = useState([])


    const generateSummary = async () => {

        const characterNames = characters.map(c => c.name)

        setIsCompletionLoading(true)

        fetchWithTimeout('/api/Sequence/GenerateSummaryReducer', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                plotId: plotId,
                characterNames: characterNames,
                full: longText
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
            setCompletions(data)
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server or you have run out of tokens');
        }).finally(function () {
            setIsCompletionLoading(false)
        });
    }

    const completionsList = completions.map((c, i) =>
        <li title={i === 0 ? 'low temp' : 'high temp'} key={i}>{c.completion}</li>
    )

    return (
        <div className='row w-100'>
            <div className='col'>
                {
                    isCompletionLoading === true &&
                    <p>loading...</p>
                }
                {
                    isCompletionLoading === false && longText && longText !== '' &&
                    <button className="btn btn-secondary" onClick={generateSummary}>generate summary</button>
                }

                <ul>
                    {completionsList}
                </ul>
            </div>
        </div>
    )
}

export default SummaryReducer