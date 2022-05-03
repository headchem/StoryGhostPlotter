import { v4 as uuid } from 'uuid';
import { FaPlusCircle } from 'react-icons/fa'

import Character from './Character'

const CharacterList = ({
    characters,
    userInfo,
    archetypeOptions,
    onFocusChange,
    updateCharacterName,
    updateCharacterIsHero,
    updateCharacterArchetype,
    updateCharacterDescription,
    updateAICharacterCompletion,
    updateCharacterPersonality,
    insertCharacter,
    deleteCharacter,
}) => {


    const onInsertCharacter = () => {
        const unique_id = uuid();
        insertCharacter(unique_id)
    }


    return (
        <>
            {
                characters && characters.length > 0 &&
                <>
                    {
                        characters
                            .map((character) => (
                                <Character
                                    key={character.id}
                                    userInfo={userInfo}
                                    archetypeOptions={archetypeOptions}
                                    character={character}
                                    characters={characters}
                                    onFocusChange={() => onFocusChange('character')}
                                    updateCharacterName={updateCharacterName}
                                    updateCharacterIsHero={updateCharacterIsHero}
                                    updateCharacterArchetype={updateCharacterArchetype}
                                    updateCharacterDescription={updateCharacterDescription}
                                    updateAICharacterCompletion={updateAICharacterCompletion}
                                    updateCharacterPersonality={updateCharacterPersonality}
                                    deleteCharacter={deleteCharacter}
                                />
                            ))
                    }
                </>

            }

            <div className='row pb-3 pt-3'>
                <div className='col'>
                    <button
                        type='button'
                        className='btn btn-outline-primary btn-block'
                        onClick={onInsertCharacter}
                    ><FaPlusCircle /> New Character</button>
                </div>
            </div>
        </>
    )
}

export default CharacterList