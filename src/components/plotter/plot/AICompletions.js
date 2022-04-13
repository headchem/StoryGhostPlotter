import React, { useState, useEffect } from 'react'
import { FaGhost, FaTrash } from 'react-icons/fa'
import Spinner from 'react-bootstrap/Spinner';
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import DeleteTab from './DeleteTab'

const AICompletions = (
    {
        userInfo,
        isLoading,
        completions,
        onDeleteBrainstorm,
        onGenerateCompletion,
    }
) => {
    const [currentTab, setCurrentTab] = useState("tab-0");

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        const lastTab = !completions ? 0 : completions.length - 1
        setCurrentTab('tab-' + lastTab)
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [completions]);

    return (
        <>
            {
                userInfo && userInfo.userRoles.includes('customer') &&
                <>
                    <p className="text-muted">The AI sometimes returns characters, locations, and events from existing stories. Add some twists of your own to ensure uniqueness.</p>
                    <hr />

                    <Tabs
                        className="mb-3"
                        defaultActiveKey="tab-0"
                        activeKey={currentTab}
                        onSelect={(key) => setCurrentTab(key)}
                    >
                        {
                            completions && completions.length > 0 && completions.map((completion, idx) =>
                                <Tab key={`tab-` + idx} eventKey={`tab-` + idx} title={<>{idx} <DeleteTab idx={idx} onDeleteBrainstorm={onDeleteBrainstorm} /></>}>
                                    <p style={{ whiteSpace: "pre-wrap", maxHeight: "500px", overflowY: "auto" }}>{completion}</p>
                                </Tab>
                            )
                        }
                    </Tabs>

                    <button disabled={isLoading} type="button" className="btn btn-info mt-2" onClick={onGenerateCompletion}>
                        {
                            isLoading === true &&
                            <Spinner size="sm" as="span" animation="border" variant="secondary" />
                        }
                        {
                            isLoading === false &&
                            <FaGhost />
                        }
                        <span> New AI Brainstorm</span>
                    </button>
                </>
            }
            {
                (!userInfo || !userInfo.userRoles.includes('customer')) &&
                <>
                    <p>Sign up for our premium plan to ask the AI to brainstorm ideas.</p>
                </>
            }

        </>
    )
}

export default AICompletions