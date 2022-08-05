import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { fetchWithTimeout } from '../../../util/FetchUtil'

const SceneSummarizer = ({
    userInfo,
    plotId,
    characters,
    scene,
    tokensRemaining
}) => {
    const navigate = useNavigate()

    const [isCompletionLoading, setIsCompletionLoading] = useState(false)
    const [completions, setCompletions] = useState([])


    const generateSummary = async () => {
        //console.log(scene.full)

        const characterNames = characters.map(c => c.name)
        //console.log(characterNames)

        setIsCompletionLoading(true)

        fetchWithTimeout('/api/Scene/GenerateSceneSummary', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                plotId: plotId,
                characterNames: characterNames,
                full: scene.full
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

    const getSummaryLabel = (idx) => {
        if (idx === 0) return 'zero temp'
        if (idx === 1) return 'low temp'
        if (idx === 2) return 'high temp'
    }

    const completionsList = completions.map((c, i) =>
        <li title={getSummaryLabel(i)} key={i}>{c.completion}</li>
    )

    return (
        <div className='row w-100'>
            <div className='col'>
                {
                    isCompletionLoading === true &&
                    <p>loading...</p>
                }
                {
                    isCompletionLoading === false && scene && scene.full && scene.full !== '' &&
                    <button className="btn btn-secondary" onClick={generateSummary} title="Ask the AI to generate a summary of the full scene screenplay">generate summary</button>
                }

                <ul>
                    {completionsList}
                </ul>
            </div>
        </div>
    )
}

export default SceneSummarizer