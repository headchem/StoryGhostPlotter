import React from 'react'
import { FaGhost } from 'react-icons/fa'
import Spinner from 'react-bootstrap/Spinner';
//import Tabs from 'react-bootstrap/Tabs'
//import Tab from 'react-bootstrap/Tab'
import DeleteCompletion from './DeleteCompletion'
import SelectCompletion from './SelectCompletion'
import SignUpMessage from '../SignUpMessage'
import ToxicMessage from './ToxicMessage'

const AICompletions = (
    {
        userInfo,
        isLoading,
        completions,
        onDeleteBrainstorm,
        onSelectBrainstorm,
        onGenerateCompletion,
        showTemperature,
        temperature,
        setTemperature,
        tokensRemaining
    }
) => {
    //const [currentTab, setCurrentTab] = useState("tab-0");

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    // useEffect(() => {
    //     //const lastTab = !completions ? 0 : completions.length - 1
    //     //setCurrentTab('tab-' + lastTab)
    //     // eslint-disable-next-line react-hooks/exhaustive-deps
    // }, [completions]);

    const limit = 10 // maximum number of brainstorms before the Brainstorm button is disabled and replaced with a message asking user to delete brainstorms

    return (
        <>
            {
                userInfo && userInfo.userRoles.includes('customer') &&
                <>
                    <p className="text-muted">Tokens remaining: {tokensRemaining}. The AI sometimes returns characters, locations, and events from existing stories. Add some twists of your own to ensure uniqueness.</p>
                    <hr />

                    {
                        completions && completions.length > 0 && completions.map((completion, idx) =>
                            <div key={`completion-` + idx} className="card mb-2">
                                <div className="card-body">
                                    <p className="card-text">{completion['completion']}</p>
                                    <SelectCompletion idx={idx} onSelectBrainstorm={onSelectBrainstorm} />
                                    <DeleteCompletion idx={idx} onDeleteBrainstorm={onDeleteBrainstorm} />
                                    {
                                        completion['completionIsToxic']
                                        &&
                                        <ToxicMessage />
                                    }
                                </div>
                            </div>
                        )
                    }

                    {/* {
                        false &&
                        <Tabs
                            className="mb-3"
                            defaultActiveKey="tab-0"
                            activeKey={currentTab}
                            onSelect={(key) => setCurrentTab(key)}
                        >
                            {
                                completions && completions.length > 0 && completions.map((completion, idx) =>
                                    <Tab key={`tab-` + idx} eventKey={`tab-` + idx} title={<>{idx} <DeleteCompletion idx={idx} onDeleteBrainstorm={onDeleteBrainstorm} /></>}>
                                        {
                                            completion['completionIsToxic']
                                            &&
                                            <ToxicMessage />
                                        }
                                        <p style={{ whiteSpace: "pre-wrap", maxHeight: "500px", overflowY: "auto" }}>{completion['completion']}</p>
                                    </Tab>
                                )
                            }
                        </Tabs>
                    } */}


                    {
                        showTemperature === true &&
                        <div className='row'>
                            <label className='form-label'>tame &lt;-&gt; wild <span>(temperature: {temperature})</span>
                                <input className='form-range' type="range" min="0.5" max="1.3" step={0.05} defaultValue={temperature} onChange={(e) => setTemperature(e.target.value)} />
                            </label>

                        </div>
                    }

                    {
                        tokensRemaining <= 0 &&
                        <>
                            <p>You have run out of tokens.</p>
                        </>
                    }
                    {
                        tokensRemaining > 0 &&
                        <>
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

                </>
            }
            {
                (!userInfo || !userInfo.userRoles.includes('customer')) &&
                <SignUpMessage />
            }

        </>
    )
}

export default AICompletions