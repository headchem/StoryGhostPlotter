

const LogLinePrompt = ({ logLineIncomplete, logLinePromptIsLoading, logLinePrompt, onFocusChange }) => {

    return (
        <div>
            {
                logLineIncomplete === true &&
                <>
                    <p>Fill out all fields above to generate a synopsis prompt.</p>
                </>
            }
            {
                logLineIncomplete === false &&
                <>
                    {
                        logLinePromptIsLoading === true &&
                        <>
                            <p>Loading prompt...</p>
                        </>
                    }
                    {
                        logLinePromptIsLoading === false && logLinePrompt !== '' &&
                        <div onClick={onFocusChange}>
                            <p>{logLinePrompt}</p>
                        </div>
                    }
                </>
            }
        </div>
    )
}

export default LogLinePrompt
