

const ArchetypeDescription = ({ archetypeDescObj }) => {

    const examplesList = archetypeDescObj.examples.map((example) =>
        <li key={example}>{example}</li>
    );

    const talentsList = archetypeDescObj.talents.map((talent) =>
        <li key={talent}>{talent}</li>
    );

    const weaknessesList = archetypeDescObj.weaknesses.map((weakness) =>
        <li key={weakness}>{weakness}</li>
    );

    const addictionsList = archetypeDescObj.addictions.map((addiction) =>
        <li key={addiction}>{addiction}</li>
    );

    const greatestFearsList = archetypeDescObj.greatestFears.map((fear) =>
        <li key={fear}>{fear}</li>
    );

    return (
        <div>
            {
                archetypeDescObj &&
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
                                examplesList
                            }
                        </ul>
                    </figure>

                    <figure className="list-to-comma-str">
                        <figcaption>Talents</figcaption>
                        <ul>
                            {
                                talentsList
                            }
                        </ul>
                    </figure>

                    <figure className="list-to-comma-str">
                        <figcaption>Weaknesses</figcaption>
                        <ul>
                            {
                                weaknessesList
                            }
                        </ul>
                    </figure>

                    <figure className="list-to-comma-str">
                        <figcaption>Greatest fears</figcaption>
                        <ul>
                            {
                                greatestFearsList
                            }
                        </ul>
                    </figure>

                    <p><strong>Addictive quality: </strong>{archetypeDescObj.addictiveQuality}</p>
                    <figure className="list-to-comma-str">
                        <figcaption>Addictions</figcaption>
                        <ul>
                            {
                                addictionsList
                            }
                        </ul>
                    </figure>
                    <p><strong>Pre-problem desires: </strong>{archetypeDescObj.orphanDesires}</p>
                    <p><strong>Initial (unsuccessful) response to problem: </strong>{archetypeDescObj.wandererResponse}</p>
                    <p><strong>Mature (successful) response to problem: </strong>{archetypeDescObj.warriorResponse}</p>
                </>
            }
        </div>
    )
}

export default ArchetypeDescription