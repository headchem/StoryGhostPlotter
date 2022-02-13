

const GenreDescription = ({ genreDescObj }) => {

    const keywordsList = genreDescObj.keywords.map((word) =>
        <li key={word}>{word}</li>
    );

    return (
        <div>
            {
                genreDescObj &&
                <>
                    <h2>{genreDescObj.name}</h2>
                    <p>{genreDescObj.description}</p>
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

export default GenreDescription
