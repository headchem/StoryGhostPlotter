import React, { useState } from 'react'
import SimpleCharacter from './SimpleCharacter'
import Spinner from 'react-bootstrap/Spinner';
import { fetchWithTimeout } from '../../../../util/FetchUtil'
import { useNavigate } from "react-router-dom";

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

    const [isLoading, setIsLoading] = useState(false)

    const navigate = useNavigate()

    const generateAllCharacters = () => {
        setIsLoading(true)

        fetchWithTimeout('/api/Character/GenerateAll', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'seed': 123,
                'id': plotId,
                'logLineDescription': logLineDescription,
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
            setCharacters(data)
        }).catch(function (error) {
            console.warn(error);
        }).finally(function () {
            setIsLoading(false)
        });
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

                        {
                            isLoading === true &&
                            <Spinner size="sm" as="span" animation="border" variant="secondary" />
                        }
                        {
                            isLoading === false && (!characters || characters.length === 0) &&
                            <button onClick={generateAllCharacters} className='btn btn-primary'>Generate Characters</button>
                        }

                    </div>

                </div>
            </div>
        </>
    )
}

export default Page3