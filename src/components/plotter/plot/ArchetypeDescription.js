import React, { useEffect, useState } from 'react'
import { useNavigate } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';

const ArchetypeDescription = ({ archetype }) => {

    const navigate = useNavigate()
    const [archetypeDescObj, setArchetypeDescObj] = useState('')
    const [isLoading, setIsLoading] = useState(false)

    useEffect(() => {
        fetchArchetype()
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [archetype]);

    const fetchArchetype = async () => {
        if (!archetype) return;

        setIsLoading(true)

        const url = '/api/LogLine/ArchetypeDescription?archetype=' + archetype

        fetch(url)
            .then(function (response) {
                if (response.status === 401 || response.status === 403) {
                    navigate('/plots')
                } else {
                    if (response.ok) {
                        return response.json();
                    }
                }
                return Promise.reject(response);
            }).then(function (data) {
                setArchetypeDescObj(data)
            }).catch(function (error) {
                console.warn(error);
            }).finally(function () {
                setIsLoading(false)
            });
    }

    return (
        <div>
            {
                isLoading === true &&
                <Spinner size="sm" as="span" animation="border" variant="secondary" />
            }
            {
                isLoading === false && archetypeDescObj &&
                <>
                    <h2>{archetypeDescObj.name}</h2>
                    <p title="archetype motto"><em>"{archetypeDescObj.motto}"</em></p>
                    <p>{archetypeDescObj.description}</p>
                    <p><strong>Shadow side: </strong>{archetypeDescObj.shadowSide}</p>
                    <p><strong>Motivated by: </strong>{archetypeDescObj.sourceOfMotivation}</p>
                    <figure className="list-to-comma-str">
                        <figcaption>Examples</figcaption>
                        <ul>
                            {
                                archetypeDescObj.examples.map((example) =>
                                    <li key={example}>{example}</li>
                                )
                            }
                        </ul>
                    </figure>

                    <figure className="list-to-comma-str">
                        <figcaption>Talents</figcaption>
                        <ul>
                            {
                                archetypeDescObj.talents.map((talent) =>
                                    <li key={talent}>{talent}</li>
                                )
                            }
                        </ul>
                    </figure>

                    <figure className="list-to-comma-str">
                        <figcaption>Weaknesses</figcaption>
                        <ul>
                            {
                                archetypeDescObj.weaknesses.map((weakness) =>
                                    <li key={weakness}>{weakness}</li>
                                )
                            }
                        </ul>
                    </figure>

                    <figure className="list-to-comma-str">
                        <figcaption>Greatest fears</figcaption>
                        <ul>
                            {
                                archetypeDescObj.greatestFears.map((fear) =>
                                    <li key={fear}>{fear}</li>
                                )
                            }
                        </ul>
                    </figure>

                    <p><strong>Addictive quality: </strong>{archetypeDescObj.addictiveQuality}</p>
                    <figure className="list-to-comma-str">
                        <figcaption>Addictions</figcaption>
                        <ul>
                            {
                                archetypeDescObj.addictions.map((addiction) =>
                                    <li key={addiction}>{addiction}</li>
                                )
                            }
                        </ul>
                    </figure>
                    <p><strong>Pre-problem desires: </strong>{archetypeDescObj.orphanDesires}</p>
                    <p><strong>Initial (unsuccessful) response to problem: </strong>{archetypeDescObj.wandererResponse}</p>
                    <p><strong>Mature (successful) response to problem: </strong>{archetypeDescObj.warriorResponse}</p>
                </>
            }
        </div >
    )
}

export default ArchetypeDescription