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
        completions,
        targetSequence,
        updateSequenceCompletions
    }
) => {

    const availableModels = [
        'Opening Image',
        'Setup',
        'Theme Stated',
        'Catalyst',
        'Debate',
        'B Story',
        'Break Into Two',
        'Fun And Games'
    ]

    const navigate = useNavigate()
    const [isCompletionLoading, setIsCompletionLoading] = useState(false)
    //const [completionText, setCompletionText] = useState(false)

    const fetchCompletion = async () => {
        setIsCompletionLoading(true)

        //console.log('fetch completion with all the inputs')

        fetchWithTimeout('/api/Sequence/Generate?targetSequence=' + targetSequence, {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                logLineDescription: logLineDescription,
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
                updateSequenceCompletions(targetSequence, [data['completion']])
            } else {
                const newCompletionList = [...completions, data['completion']]
                updateSequenceCompletions(targetSequence, newCompletionList)
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

        updateSequenceCompletions(targetSequence, newBrainstormList)
    }

    return (
        <>
            {
                availableModels.indexOf(targetSequence) > -1 &&
                <AICompletions
                    userInfo={userInfo}
                    isLoading={isCompletionLoading}
                    onGenerateCompletion={fetchCompletion}
                    completions={completions}
                    onDeleteBrainstorm={onDeleteBrainstorm}
                />
            }
            {
                availableModels.indexOf(targetSequence) === -1 &&
                <p>AI model unavailable for this sequence.</p>
            }
        </>

    )
}

export default SequenceBrainstorm