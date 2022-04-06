import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { fetchWithTimeout } from '../../../util/FetchUtil'
import AICompletions from './AICompletions'


const SequenceBrainstorm = (
    {
        userInfo,
        logLineDescription,
        genres,
        problemTemplate,
        dramaticQuestion,
        keywords,
        sequences,
        characters,
        updateSequenceCompletions,
        completions,
        part
    }
) => {

    const navigate = useNavigate()
    const [isCompletionLoading, setIsCompletionLoading] = useState(false)
    //const [completionText, setCompletionText] = useState(false)

    const fetchCompletion = async () => {
        setIsCompletionLoading(true)

        //console.log('fetch completion with all the inputs')

        fetchWithTimeout('/api/Sequence/Generate?part=' + part, {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                logLineDescription:logLineDescription,
                genres: genres,
                problemTemplate: problemTemplate,
                dramaticQuestion: dramaticQuestion,
                keywords: keywords,
                sequences: sequences,
                characters: characters,
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
            console.log('save this data:')
            console.log(data)
            if (!completions || completions.length === 0) {
                updateSequenceCompletions([data['completion']])
            } else {
                const newCompletionList = [...completions, data['completion']]
                updateSequenceCompletions(newCompletionList)
            }
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server. Please wait a few minutes and try again.');
        }).finally(function () {
            setIsCompletionLoading(false)
        });
    }

    const onDeleteBrainstorm = (idxToDelete) => {
        const newBrainstormList = completions.filter((obj, objIdx) => objIdx !== idxToDelete)
        updateSequenceCompletions(newBrainstormList)

        console.log('delete brainstorm: ' + idxToDelete)
    }

    return (
        <AICompletions
            userInfo={userInfo}
            isLoading={isCompletionLoading}
            onGenerateCompletion={fetchCompletion}
            completions={completions}
            onDeleteBrainstorm={onDeleteBrainstorm}
        />
    )
}

export default SequenceBrainstorm