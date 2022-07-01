import React from 'react'
import SimpleCharacter from './SimpleCharacter'
import SimpleCharacterGenerateAll from './SimpleCharacterGenerateAll'

const Page3 = (
    {
        logLineDescription,
        characters,
        userInfo,
        plotId,
        updateCharacterName,
        updateCharacterDescription,
        setCharacters,
    }
) => {

    return (
        <>
            <div className="card-group">
                <div className="card">

                    <div className="card-body">

                        <SimpleCharacterGenerateAll
                            logLineDescription={logLineDescription}
                            characters={characters}
                            userInfo={userInfo}
                            plotId={plotId}
                            setCharacters={setCharacters}
                        />

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
                                                archetype={character['archetype']}
                                                curCharacterId={character.id}
                                                characters={characters}
                                                updateCharacterName={updateCharacterName}
                                                updateCharacterDescription={updateCharacterDescription}
                                                setCharacters={setCharacters}
                                            />
                                        ))
                                }
                            </>

                        }

                        <SimpleCharacterGenerateAll
                            logLineDescription={logLineDescription}
                            characters={characters}
                            userInfo={userInfo}
                            plotId={plotId}
                            setCharacters={setCharacters}
                        />
                    </div>

                </div>
            </div>
        </>
    )
}

export default Page3