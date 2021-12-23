

const DramaticQuestionDescription = ({ dramaticQuestionDescObj }) => {

    return (
        <div>
            {
                dramaticQuestionDescObj &&
                <>
                    <h2>{dramaticQuestionDescObj.name}</h2>
                    <p><strong>{dramaticQuestionDescObj.description}</strong></p>
                    <p>As the Hero moves through the 4 stages of character growth (orphan, wanderer, warrior, martyr), different aspects of the theme are presented.</p>
                    <ol>
                        <li>Contrary: <strong>{dramaticQuestionDescObj.contrary}</strong> - <em>better than the Contradiction, but still not Positive</em></li>
                        <li>Contradiction: <strong>{dramaticQuestionDescObj.contradiction}</strong> - <em>opposite of the Positive</em></li>
                        <li>Negation: <strong>{dramaticQuestionDescObj.negation}</strong> - <em>darkest depths, extreme perversion of the Positive</em></li>
                        <li>Positive: <strong>{dramaticQuestionDescObj.positive}</strong> - <em>primary value at stake</em></li>
                    </ol>
                </>
            }
        </div>
    )
}

export default DramaticQuestionDescription
