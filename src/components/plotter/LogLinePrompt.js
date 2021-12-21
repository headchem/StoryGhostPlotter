

const LogLinePrompt = ({ logLinePromptIsLoading, logLinePrompt }) => {

    return (
        <div>
            {
                logLinePromptIsLoading === true && <>
                    <p>Loading...</p>
                </>
            }
            {
                logLinePromptIsLoading === false && logLinePrompt !== '' && <>
                    <p>Prompt we'll send to the AI:</p>
                    <p>{logLinePrompt}</p>
                </>
            }
        </div>
    )
}

export default LogLinePrompt
