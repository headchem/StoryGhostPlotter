

const PrimalStakesDescription = ({ primalStakesDescObj }) => {

    const keywordsList = primalStakesDescObj.keywords.map((word) =>
        <li key={word}>{word}</li>
    );

    return (
        <div>
            {
                primalStakesDescObj &&
                <>
                    <h2>{primalStakesDescObj.name}</h2>
                    <p>{primalStakesDescObj.description}</p>
                    <figure className="list-to-comma-str">
                        <figcaption>Keywords</figcaption>
                        <ul>
                            {
                                keywordsList
                            }
                        </ul>
                    </figure>
                </>
            }
        </div>
    )
}

export default PrimalStakesDescription
