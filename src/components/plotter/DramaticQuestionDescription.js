

const DramaticQuestionDescription = ({ logLine }) => {

    return (
        <div>
            {
                logLine.dramaticQuestionDescObj && <>
                    Dramatic question desc obj goes here
                    <p>name: {logLine.dramaticQuestionDescObj.name}</p>
                    <p>desc: {logLine.dramaticQuestionDescObj.description}</p>
                </>
            }
        </div>
    )
}

export default DramaticQuestionDescription
