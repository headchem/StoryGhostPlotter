

const ProblemTemplateDescription = ({ problemTemplateDescObj }) => {

    const keywordsList = problemTemplateDescObj.keywords.map((word) =>
        <li key={word}>{word}</li>
    );

    return (
        <div>
            {
                problemTemplateDescObj && <>
                    <h2>{problemTemplateDescObj.name}</h2>
                    <p>{problemTemplateDescObj.description}</p>
                    <figure className="list-to-comma-str">
                        <figcaption>Keywords</figcaption>
                        <ul>
                            {
                                keywordsList
                            }
                        </ul>
                    </figure>
                    <p>Hero's initial attitude is <strong>{problemTemplateDescObj.wandererAdjectives.heroAdjective}</strong> while the enemy is <strong>{problemTemplateDescObj.wandererAdjectives.enemyAdjective}</strong>.</p>
                    <p>Hero progresses to <strong>{problemTemplateDescObj.warriorAdjectives.heroAdjective}</strong> while the enemy becomes <strong>{problemTemplateDescObj.warriorAdjectives.enemyAdjective}</strong>.</p>
                    <p>At the end, Hero is <strong>{problemTemplateDescObj.martyrAdjectives.heroAdjective}</strong> while the enemy reverts to <strong>{problemTemplateDescObj.martyrAdjectives.enemyAdjective}</strong>.</p>
                </>
            }
        </div>
    )
}

export default ProblemTemplateDescription
