import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { fetchWithTimeout } from '../../../../util/FetchUtil'
import { allSequencesHaveValues } from '../../../../util/SequenceTextCheck'
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
        updateText,
        updateSequenceCompletions,
        completionURL,
        textPropName,
        completionPropName,
        tokensRemaining,
        AILogLineDescriptions
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

        fetchWithTimeout('/api/Sequence/' + completionURL + '?targetSequence=' + targetSequence + '&temperature=' + temperature + '&numCompletions=1', {
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
                AILogLineDescriptions: AILogLineDescriptions
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
                updateSequenceCompletions(targetSequence, data)
            } else {
                const newCompletionList = [...completions, data[0]]
                updateSequenceCompletions(targetSequence, newCompletionList)
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
        updateText(targetSequence, selectedCompletion)
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

        updateSequenceCompletions(targetSequence, newCompletionsWithSelected)
    }

    const onDeleteBrainstorm = (idxToDelete) => {
        const newBrainstormList = completions.filter((obj, objIdx) => objIdx !== idxToDelete)

        updateSequenceCompletions(targetSequence, newBrainstormList)
    }

    // return true if any of the previous texts are empty. We need all previous texts to be filled out in order to generate a correctly formatted completion prompt.
    const brainstormDisabled = () => {
        return allSequencesHaveValues(sequences, targetSequence, textPropName, completionPropName) === false
    }

    return (
        <>
            {
                availableModels.indexOf(targetSequence) > -1 &&
                <>
                    {
                        brainstormDisabled() === true &&
                        <div className="alert alert-warning" role="alert">
                            <p>All previous sequences must have some text before you can ask the AI to brainstorm on this sequence.</p>
                        </div>
                    }
                    {
                        brainstormDisabled() === false &&
                        <>
                            <p>Select the brainstorm that best adheres to the advice for this sequence.</p>
                            <AICompletions
                                userInfo={userInfo}
                                isLoading={isCompletionLoading}
                                onGenerateCompletion={fetchCompletion}
                                completions={completions}
                                onCopyBrainstorm={onCopyBrainstorm}
                                onSelectBrainstormChange={onSelectBrainstormChange}
                                showSelectBrainstorm={true}
                                onDeleteBrainstorm={onDeleteBrainstorm}
                                showTemperature={true}
                                temperature={temperature}
                                setTemperature={setTemperature}
                                tokensRemaining={tokensRemaining}
                            />
                        </>
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