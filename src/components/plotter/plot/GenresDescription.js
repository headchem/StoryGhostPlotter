

const GenresDescription = ({ genresDescObjs }) => {

    // const keywordsList = genresDescObj.keywords.map((word) =>
    //     <li key={word}>{word}</li>
    // );

    return (
        <div>
            {
                genresDescObjs.map((genreObj) => (
                    <div key={genreObj.name}>
                        <h2>{genreObj.name}</h2>
                        <p>{genreObj.description}</p>
                        {/* <figure className="list-to-comma-str">
                            <figcaption>Keywords</figcaption>
                            <ul>
                                {
                                    genreObj.keywords.map((word) =>
                                        <li key={word}>{word}</li>
                                    )
                                }
                            </ul>
                        </figure> */}
                    </div>
                ))
            }
        </div >
    )
}

export default GenresDescription
