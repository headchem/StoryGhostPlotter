

const ProblemTemplateDescription = ({ problemTemplateDescObj }) => {

    return (
        <div>
            {
                problemTemplateDescObj && <>
                    Problem Template desc obj goes here
                    <p>name: {problemTemplateDescObj.name}</p>
                    <p>desc: {problemTemplateDescObj.description}</p>
                </>
            }
        </div>
    )
}

export default ProblemTemplateDescription
