import React from 'react'
import SimpleCharacter from './SimpleCharacter'

const Page3 = (
    {
        logLineDescription,
        characters,

        userInfo,
        plotId,
        updateCharacterName,
        // updateCharacterIsHero,
        // updateCharacterArchetype,
        updateCharacterDescription,
        //updateAICharacterCompletion,
        // updateCharacterPersonality,
        setCharacters,
    }
) => {

    const newCharacter = () => {
        console.log('TODO: create new character')
    }

    return (
        <>
            <div className="card-group">
                <div className="card">

                    <div className="card-body">
                        {
                            characters && characters.length > 0 &&
                            <>
                                {
                                    characters
                                        .map((character) => (
                                            <SimpleCharacter
                                                key={character.id}
                                                userInfo={userInfo}
                                                plotId={plotId}
                                                logLineDescription={logLineDescription}
                                                //archetypeOptions={archetypeOptions}
                                                //character={character}
                                                curCharacterId={character.id}
                                                characters={characters}
                                                //onFocusChange={() => onFocusChange('character')}
                                                updateCharacterName={updateCharacterName}
                                                // updateCharacterIsHero={updateCharacterIsHero}
                                                // updateCharacterArchetype={updateCharacterArchetype}
                                                updateCharacterDescription={updateCharacterDescription}
                                                //updateAICharacterCompletion={updateAICharacterCompletion}
                                                //updateCharacterPersonality={updateCharacterPersonality}
                                                setCharacters={setCharacters}
                                            />
                                        ))
                                }
                            </>

                        }

                        <button onClick={newCharacter} className='btn btn-primary'>New Character</button>
                    </div>

                </div>
            </div>
        </>
    )
}

export default Page3