import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { fetchWithTimeout } from '../../../../util/FetchUtil'
import AICompletions from './AICompletions'

const LogLineDescriptionBrainstorm = (
    {
        userInfo,
        plotId,
        genres,
        keywords,
        completions,
        updateLogLineDescription,
        updateLogLineDescriptionCompletions,
        tokensRemaining
    }
) => {

    const navigate = useNavigate()

    const [temperature, setTemperature] = useState(0.9)
    const [isCompletionLoading, setIsCompletionLoading] = useState(false)

    const fetchCompletion = async () => {
        setIsCompletionLoading(true)

        fetchWithTimeout('/api/LogLineDescription/Generate?temperature=' + temperature + '&keywordsImpact=4', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: plotId,
                //logLineDescription: logLineDescription,
                genres: genres,
                //problemTemplate: problemTemplate,
                //dramaticQuestion: dramaticQuestion,
                keywords: keywords,
                //sequences: sequences,
                //characters: characters,
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
            if (!completions || completions.length === 0) {
                updateLogLineDescriptionCompletions([data])
            } else {
                const newCompletionList = [...completions, data]
                updateLogLineDescriptionCompletions(newCompletionList)
            }
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server or you have run out of tokens');
        }).finally(function () {
            setIsCompletionLoading(false)
        });
    }

    const onCopyBrainstorm = (idxToSelect) => {
        const selectedCompletion = completions[idxToSelect]['completion']
        updateLogLineDescription(selectedCompletion)
    }

    const onSelectBrainstormChange = (idxToSelect, isSelected) => {
        // first set all completions isSelected to false
        const newCompletions = completions.map(
            (completion) => { return { ...completion, isSelected: false } }
        )

        // second set just the newly selected completion to true
        const newCompletionsWithSelected = newCompletions.map(
            (completion, idx) => idx === idxToSelect ? { ...completion, isSelected: isSelected } : completion
        )

        updateLogLineDescriptionCompletions(newCompletionsWithSelected)
    }

    const onDeleteBrainstorm = (idxToDelete) => {
        const newBrainstormList = completions.filter((obj, objIdx) => objIdx !== idxToDelete)

        updateLogLineDescriptionCompletions(newBrainstormList)
    }

    return (
        <>

            {
                <>
                    <p>Select the brainstorm that best adheres to the advice for this sequence.</p>
                    <AICompletions
                        userInfo={userInfo}
                        isLoading={isCompletionLoading}
                        onGenerateCompletion={fetchCompletion}
                        completions={completions}
                        onCopyBrainstorm={onCopyBrainstorm}
                        onSelectBrainstormChange={onSelectBrainstormChange}
                        showSelectBrainstorm={false}
                        onDeleteBrainstorm={onDeleteBrainstorm}
                        showTemperature={true}
                        temperature={temperature}
                        setTemperature={setTemperature}
                        tokensRemaining={tokensRemaining}
                    />
                </>
            }
        </>

    )
}

export default LogLineDescriptionBrainstorm