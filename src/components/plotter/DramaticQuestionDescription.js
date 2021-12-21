

const DramaticQuestionDescription = ({ dramaticQuestionDescObj }) => {

    return (
        <div>
            {
                dramaticQuestionDescObj && <>
                    Dramatic question desc obj goes here
                    <p>name: {dramaticQuestionDescObj.name}</p>
                    <p>desc: {dramaticQuestionDescObj.description}</p>
                </>
            }
        </div>
    )
}

export default DramaticQuestionDescription
