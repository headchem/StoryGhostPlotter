import { v4 as uuid } from 'uuid';
import { FaPlusCircle } from 'react-icons/fa'

import Character from './Character'

const CharacterList = ({
    characters,
    userInfo,
    archetypeOptions,
    onFocusChange,
    updateCharacterName,
    updateCharacterArchetype,
    updateCharacterDescription,
    updateAICharacterDescription,
    insertCharacter,
    deleteCharacter,
    genre,
    problemTemplate,
    keywords,
    dramaticQuestion
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
                                    updateCharacterArchetype={updateCharacterArchetype}
                                    updateCharacterDescription={updateCharacterDescription}
                                    updateAICharacterDescription={updateAICharacterDescription}

                                    deleteCharacter={deleteCharacter}

                                    genre={genre}
                                    problemTemplate={problemTemplate}
                                    keywords={keywords}
                                    dramaticQuestion={dramaticQuestion}
                                />
                            ))
                    }
                </>

            }

            <div className='row pb-3 pt-3'>
                <button
                    type='button'
                    className='btn btn-outline-primary'
                    onClick={onInsertCharacter}
                ><FaPlusCircle /> New Character</button>
            </div>
        </>
    )
}

export default CharacterList
