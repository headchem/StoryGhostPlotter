import React from 'react'
import SimpleCharacter from './SimpleCharacter'

const Page4 = (
    {
        characters,

        userInfo,
        plotId,
        updateCharacterName,
        updateCharacterIsHero,
        updateCharacterArchetype,
        updateCharacterDescription,
        updateAICharacterCompletion,
        updateCharacterPersonality,
    }
) => {

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
                                                //archetypeOptions={archetypeOptions}
                                                character={character}
                                                //characters={characters}
                                                //onFocusChange={() => onFocusChange('character')}
                                                updateCharacterName={updateCharacterName}
                                                updateCharacterIsHero={updateCharacterIsHero}
                                                updateCharacterArchetype={updateCharacterArchetype}
                                                updateCharacterDescription={updateCharacterDescription}
                                                updateAICharacterCompletion={updateAICharacterCompletion}
                                                updateCharacterPersonality={updateCharacterPersonality}
                                            //deleteCharacter={deleteCharacter}
                                            //tokensRemaining={tokensRemaining}
                                            />
                                        ))
                                }
                            </>

                        }

                        <button className='btn btn-primary'>New Character</button>
                    </div>

                </div>
            </div>
        </>
    )
}

export default Page4