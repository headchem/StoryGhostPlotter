

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
                </>
            }
        </div>
    )
}

export default ProblemTemplateDescription
