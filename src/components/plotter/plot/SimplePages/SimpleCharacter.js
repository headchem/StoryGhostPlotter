import React from 'react'
import LimitedTextArea from '../LimitedTextArea'
import { FaSyncAlt } from 'react-icons/fa'
import { getPersonalitySummary } from '../../../../util/PersonalityDescriptions'


const SimpleCharacter = (
    {
        userInfo,
        plotId,
        character,
        updateCharacterName,
        updateCharacterIsHero,
        updateCharacterArchetype,
        updateCharacterDescription,
        updateAICharacterCompletion,
        updateCharacterPersonality,
    }
) => {

    const onCharacterNameChange = (event) => {
        updateCharacterName(character.id, event.target.value)
    }

    const personalitySummary = getPersonalitySummary(character['personality'])

    const characterArchetypeCapitalized = !character.archetype ? 'Archetype not set' : character.archetype[0].toUpperCase() + character.archetype.slice(1)

    const rerollCharacter = () => {
        console.log('reroll current character: ' + character.id)
    }

    return (
        <div className='row'>
            <div className='col-12'>
                <p>{characterArchetypeCapitalized}-type {character.name} is {personalitySummary}.</p>
                <input type='text' className='fs-5 form-control' placeholder='Character Name' required onChange={onCharacterNameChange} defaultValue={character.name} />
                <LimitedTextArea
                    id={character.id + '_desc'}
                    className="form-control"
                    value={character.description}
                    setValue={(newValue) => updateCharacterDescription(character.id, newValue)}
                    rows={5}
                    limit={400}
                    //curTokenCount={descriptionTokenCount}
                    showCount={true}
                />
                <button className='btn btn-secondary' onClick={rerollCharacter}><FaSyncAlt /> Reroll</button>
            </div>
        </div>
    )
}

export default SimpleCharacter