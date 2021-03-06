import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { fetchWithTimeout } from '../../../../util/FetchUtil'
import AICompletions from './AICompletions'


const CharacterBrainstorm = (
    {
        userInfo,
        plotId,
        character,
        updateCharacterDescription,
        updateAICharacterCompletion,
        tokensRemaining
    }
) => {

    const navigate = useNavigate()
    const [isCompletionLoading, setIsCompletionLoading] = useState(false)
    const [temperature, setTemperature] = useState(0.9)

    const fetchCompletion = async () => {
        setIsCompletionLoading(true)

        fetchWithTimeout('/api/Character/Generate?plotId=' + plotId + '&temperature=' + temperature, {
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
                updateAICharacterCompletion(character.id, [data])
            } else {
                const newCompletionList = [...character['aiCompletions'], data] // set newCompletionList to all existing character.AICompletions plus add the new one
                updateAICharacterCompletion(character.id, newCompletionList)
            }
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server or you have run out of tokens');
        }).finally(function () {
            setIsCompletionLoading(false)
        });
    }

    const onCopyBrainstorm = (idxToSelect) => {
        const selectedCompletion = character['aiCompletions'][idxToSelect]['completion']
        updateCharacterDescription(character.id, selectedCompletion)
    }

    const onSelectBrainstormChange = (idxToSelect, isSelected) => {
        // first set all completions isSelected to false
        const newCompletions = character['aiCompletions'].map(
            (completion) => { return { ...completion, isSelected: false } }
        )

        // second set just the newly selected completion to true
        const newCompletionsWithSelected = newCompletions.map(
            (completion, idx) => idx === idxToSelect ? { ...completion, isSelected: isSelected } : completion
        )

        updateAICharacterCompletion(character.id, newCompletionsWithSelected)
    }

    const onDeleteBrainstorm = (idxToDelete) => {
        const newBrainstormList = character['aiCompletions'].filter((obj, objIdx) => objIdx !== idxToDelete)
        updateAICharacterCompletion(character.id, newBrainstormList)
    }

    return (
        <>
            {
                //userInfo && userInfo.userRoles.includes('customer') &&
                <AICompletions
                    userInfo={userInfo}
                    isLoading={isCompletionLoading}
                    onGenerateCompletion={fetchCompletion}
                    completions={character['aiCompletions']}
                    onCopyBrainstorm={onCopyBrainstorm}
                    onSelectBrainstormChange={onSelectBrainstormChange}
                    showSelectBrainstorm={false}
                    onDeleteBrainstorm={onDeleteBrainstorm}
                    temperature={temperature}
                    setTemperature={setTemperature}
                    showTemperature={true}
                    tokensRemaining={tokensRemaining}
                />
            }
        </>
    )
}

export default CharacterBrainstorm