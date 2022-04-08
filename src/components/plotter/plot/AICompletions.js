import React from 'react'
import { FaGhost, FaCog } from 'react-icons/fa'
import Spinner from 'react-bootstrap/Spinner';
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import Carousel from 'react-bootstrap/Carousel'

const AICompletions = (
    {
        userInfo,
        isLoading,
        completions,
        onDeleteBrainstorm,
        onGenerateCompletion,
    }
) => {

    const startingPage = !completions ? 0 : completions.length - 1

    return (
        <>
            {
                userInfo && userInfo.userRoles.includes('customer') &&
                <>
                    <p className="text-muted">The AI sometimes returns characters, locations, and events from existing stories. Add some twists of your own to ensure uniqueness.</p>
                    <hr />

                    <Carousel variant="dark" interval={null} indicators={true} defaultActiveIndex={startingPage}>
                        {
                            completions && completions.length > 0 && completions.map((completion, idx) =>
                                <Carousel.Item key={'carousel-' + idx}>
                                    {
                                        <Tabs defaultActiveKey="finetune" className="mb-3">
                                            <Tab eventKey="finetune" title="Brainstorms">
                                                <p style={{whiteSpace: "pre-wrap", maxHeight: "500px", overflowY: "auto"}}>{completion}</p>
                                            </Tab>
                                            <Tab eventKey="manage" title={<FaCog />}>
                                                <button className="btn btn-danger mt-2 mb-4" onClick={() => onDeleteBrainstorm(idx)}>delete this brainstorm</button>
                                            </Tab>
                                        </Tabs>
                                    }
                                </Carousel.Item>
                            )
                        }
                    </Carousel>

                    <button disabled={isLoading} title='This will replace the existing brainstorm' type="button" className="btn btn-info mt-2" onClick={onGenerateCompletion}>
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