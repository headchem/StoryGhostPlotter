import React, { useState, useEffect } from 'react'
import LimitedTextArea from '../LimitedTextArea'
import Spinner from 'react-bootstrap/Spinner';
import { isNullOrEmpty } from '../../../../util/Helpers';
import { FaSyncAlt, FaStar } from 'react-icons/fa'
import { getPersonalitySummary } from '../../../../util/PersonalityDescriptions'
import { useNavigate } from "react-router-dom";
import { fetchWithTimeout, fetchData } from '../../../../util/FetchUtil'

const SimpleCharacter = (
    {
        userInfo,
        plotId,
        logLineDescription,
        //character,
        curCharacterId,
        characters,
        updateCharacterName,
        //updateCharacterIsHero,
        //updateCharacterArchetype,
        updateCharacterDescription,
        //updateAICharacterCompletion,
        //updateCharacterPersonality,
        setCharacters
    }
) => {

    const character = characters.filter(c => c.id === curCharacterId)[0]

    const navigate = useNavigate()

    const [isLoading, setIsLoading] = useState(false)
    const [isArchetypeLoading, setIsArchetypeLoading] = useState(false)
    const [archetypeDescObj, setAchetypeDescObj] = useState('')

    const onCharacterNameChange = (event) => {
        updateCharacterName(curCharacterId, event.target.value)
    }

    const personalitySummary = getPersonalitySummary(character['personality'])

    const characterArchetypeCapitalized = !character.archetype ? 'Archetype not set' : character.archetype[0].toUpperCase() + character.archetype.slice(1)

    useEffect(() => {
        fetchArchetype()
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [characters]);

    const fetchArchetype = async () => {

        if (isNullOrEmpty(character.archetype)) return

        const url = '/api/LogLine/ArchetypeDescription?archetype=' + character.archetype

        fetchData(url, setIsArchetypeLoading, setAchetypeDescObj, navigate)
    }

    const rerollCharacter = async () => {
        console.log('reroll current character: ' + curCharacterId)

        setIsLoading(true)

        fetchWithTimeout('/api/Character/GenerateRandom?curCharacterId=' + curCharacterId, {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'seed': 123,
                'id': plotId,
                'logLineDescription': logLineDescription,
                'characters': characters
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

            const randChar = data['item1']
            const randCharCompletion = data['item2']

            console.log('randChar:')
            console.log(randChar)
            console.log('randCharCompletion:')
            console.log(randCharCompletion)

            let newAICompletions = null

            if (!character['aiCompletions']) {
                newAICompletions = [randCharCompletion]
            } else {
                newAICompletions = [...character['aiCompletions'], randCharCompletion] // set newCompletionList to all existing character.AICompletions plus add the new one
            }

            const newCharacters = characters.map(
                (c) => c.id === curCharacterId ? {
                    ...character,
                    personality: randChar['personality'],
                    name: randChar['name'],
                    isHero: randChar['isHero'],
                    archetype: randChar['archetype'],
                    description: randChar['description'],
                    aiCompletions: newAICompletions
                } : c
            )

            console.log('setCharacters:')
            console.log(newCharacters)

            setCharacters(newCharacters)
        }).catch(function (error) {
            console.warn(error);
        }).finally(function () {
            setIsLoading(false)
        });
    }

    return (
        <div className='row mb-5'>
            <div className='col-8'>
                <input type='text' className='fs-5 form-control mb-3' placeholder='Character Name' required onChange={onCharacterNameChange} value={character.name} />
                <LimitedTextArea
                    id={curCharacterId + '_desc'}
                    className="form-control"
                    value={character.description}
                    setValue={(newValue) => updateCharacterDescription(curCharacterId, newValue)}
                    rows={5}
                    limit={400}
                    //curTokenCount={descriptionTokenCount}
                    showCount={true}
                />
                {
                    isLoading === false &&
                    <button className='btn btn-primary float-end mt-3' onClick={rerollCharacter}><FaSyncAlt /> Reroll</button>
                }

                {
                    isLoading === true &&
                    <button className='btn btn-primary float-end mt-3' disabled><Spinner size="sm" as="span" animation="border" variant="secondary" /> Reroll</button>
                }
            </div>
            <div className='col-4'>
                {
                    character['isHero'] === true &&
                    <p><FaStar /> {character['name']} is the protagonist.</p>
                }
                <p>{characterArchetypeCapitalized}-type {character.name} is {personalitySummary}.</p>

                {
                    isArchetypeLoading &&
                    <Spinner size="sm" as="span" animation="border" variant="secondary" />
                }
                {
                    isArchetypeLoading === false &&
                    <p>
                        {archetypeDescObj['description']}
                    </p>
                }
            </div>
        </div>
    )
}

export default SimpleCharacter