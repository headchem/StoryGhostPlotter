import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { fetchWithTimeout } from '../../../util/FetchUtil'
import AICompletions from './AICompletions'


const CharacterBrainstorm = (
    {
        userInfo,
        plotId,
        character,
        updateAICharacterCompletion,
        tokensRemaining
    }
) => {

    const navigate = useNavigate()
    const [isCompletionLoading, setIsCompletionLoading] = useState(false)
    //const [completionText, setCompletionText] = useState(false)

    const fetchCompletion = async () => {
        setIsCompletionLoading(true)

        fetchWithTimeout('/api/Character/Generate?plotId=' + plotId, {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(character)
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
            if (!character['aiCompletions']) {
                updateAICharacterCompletion(character.id, [data['completion']])
            } else {
                const newCompletionList = [...character['aiCompletions'], data['completion']] // set newCompletionList to all existing character.AICompletions plus add the new one
                updateAICharacterCompletion(character.id, newCompletionList)
            }
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server or you have run out of tokens');
        }).finally(function () {
            setIsCompletionLoading(false)
        });
    }

    const onDeleteBrainstorm = (idxToDelete) => {
        const newBrainstormList = character['aiCompletions'].filter((obj, objIdx) => objIdx !== idxToDelete)
        updateAICharacterCompletion(character.id, newBrainstormList)
    }

    return (
        <AICompletions
            userInfo={userInfo}
            isLoading={isCompletionLoading}
            onGenerateCompletion={fetchCompletion}
            completions={character['aiCompletions']}
            onDeleteBrainstorm={onDeleteBrainstorm}
            showTemperature={false}
            tokensRemaining={tokensRemaining}
        />
    )
}

export default CharacterBrainstorm