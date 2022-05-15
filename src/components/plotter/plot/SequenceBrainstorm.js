import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { fetchWithTimeout } from '../../../util/FetchUtil'
import AICompletions from './AICompletions'


const SequenceBrainstorm = (
    {
        userInfo,
        plotId,
        logLineDescription,
        genres,
        problemTemplate,
        dramaticQuestion,
        keywords,
        sequences,
        characters,
        completions,
        targetSequence,
        updateSequenceCompletions,
        tokensRemaining
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
        'Fun And Games',
        'Midpoint',
        'Bad Guys Close In',
        'All Hope Is Lost',
        'Dark Night Of The Soul',
        'Break Into Three',
        'Climax',
        'Cooldown'
    ]

    const navigate = useNavigate()

    const [temperature, setTemperature] = useState(0.9)
    const [isCompletionLoading, setIsCompletionLoading] = useState(false)

    const fetchCompletion = async () => {
        setIsCompletionLoading(true)

        fetchWithTimeout('/api/Sequence/Generate?targetSequence=' + targetSequence + '&temperature=' + temperature, {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: plotId,
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
            console.warn('usually this means the model is still loading on the server or you have run out of tokens');
        }).finally(function () {
            setIsCompletionLoading(false)
        });
    }

    const onDeleteBrainstorm = (idxToDelete) => {
        const newBrainstormList = completions.filter((obj, objIdx) => objIdx !== idxToDelete)

        updateSequenceCompletions(targetSequence, newBrainstormList)
    }

    // return true is any of the previous texts are empty. We need all previous texts to be filled out in order to generate a correctly formatted completion prompt.
    const brainstormDisabled = () => {
        const existingSequenceNamesArr = sequences.map((seq) => seq.sequenceName)
        const curSeqIndex = existingSequenceNamesArr.indexOf(targetSequence)
        const prevSeqsArr = sequences.slice(0, curSeqIndex) // +1 to include self
        const prevTexts = prevSeqsArr.map((seq) => seq.text)

        const isBlank = (str) => (!str || str.trim().length === 0);

        return prevTexts.some(isBlank)
    }

    return (
        <>
            {
                availableModels.indexOf(targetSequence) > -1 &&
                <>
                    {
                        brainstormDisabled() === true &&
                        <div class="alert alert-warning" role="alert">
                            <p>All previous sequences must have some text before you can ask the AI to brainstorm on this sequence.</p>
                        </div>
                    }
                    {
                        brainstormDisabled() === false &&
                        <AICompletions
                            userInfo={userInfo}
                            isLoading={isCompletionLoading}
                            onGenerateCompletion={fetchCompletion}
                            completions={completions}
                            onDeleteBrainstorm={onDeleteBrainstorm}
                            showTemperature={true}
                            temperature={temperature}
                            setTemperature={setTemperature}
                            tokensRemaining={tokensRemaining}
                        />
                    }
                </>
            }
            {
                availableModels.indexOf(targetSequence) === -1 &&
                <p>AI model unavailable for this sequence.</p>
            }
        </>

    )
}

export default SequenceBrainstorm