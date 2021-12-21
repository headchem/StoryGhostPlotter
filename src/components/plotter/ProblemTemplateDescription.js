

const ProblemTemplateDescription = ({ logLine }) => {

    return (
        <div>
            {
                logLine.problemTemplateDescObj && <>
                    Problem Template desc obj goes here
                    <p>name: {logLine.problemTemplateDescObj.name}</p>
                    <p>desc: {logLine.problemTemplateDescObj.description}</p>
                </>
            }
        </div>
    )
}

export default ProblemTemplateDescription
