

const ArchetypeDescription = ({ archetypeDescObj }) => {

    const examplesList = archetypeDescObj.examples.map((example) =>
        <li>{example}</li>
    );

    const talentsList = archetypeDescObj.talents.map((talent) =>
        <li>{talent}</li>
    );

    const weaknessesList = archetypeDescObj.weaknesses.map((weakness) =>
        <li>{weakness}</li>
    );

    const addictionsList = archetypeDescObj.addictions.map((addiction) =>
        <li>{addiction}</li>
    );

    const greatestFearsList = archetypeDescObj.greatestFears.map((fear) =>
        <li>{fear}</li>
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
                </>
            }
        </div>
    )
}

export default ArchetypeDescription