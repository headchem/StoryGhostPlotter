import React, { useState, useEffect } from 'react'
import { FaGhost } from 'react-icons/fa'
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
        showTemperature,
        temperature,
        setTemperature
    }
) => {
    const [currentTab, setCurrentTab] = useState("tab-0");

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        const lastTab = !completions ? 0 : completions.length - 1
        setCurrentTab('tab-' + lastTab)
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [completions]);

    const limit = 10 // maximum number of brainstorms before the Brainstorm button is disabled and replaced with a message asking user to delete brainstorms

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

                    {
                        showTemperature === true &&
                        <div className='row'>
                            <label className='form-label'>tame &lt;-&gt; wild <span>(temperature: {temperature})</span>
                                <input className='form-range' type="range" min="0.5" max="1.0" step={0.05} defaultValue={temperature} onChange={(e) => setTemperature(e.target.value)} />
                            </label>

                        </div>
                    }
                    {
                        completions && completions.length >= limit &&
                        <div className='row'>
                            <div className='col alert alert-primary'>
                                <p>You have reached the maximum of {limit} brainstorms. Please delete some brainstorms before generating more.</p>
                            </div>
                        </div>

                    }
                    {
                        (!completions || completions.length < limit) &&
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
                    }

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