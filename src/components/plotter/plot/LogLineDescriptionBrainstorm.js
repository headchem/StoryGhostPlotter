import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { FaGhost, FaCog } from 'react-icons/fa'
import Accordion from 'react-bootstrap/Accordion';
import Spinner from 'react-bootstrap/Spinner';
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import Carousel from 'react-bootstrap/Carousel'
import { fetchWithTimeout } from '../../../util/FetchUtil'

const LogLineDescriptionBrainstorm = (
    {
        userInfo,
        AILogLineDescriptions,
        onAILogLineDescriptionsChange,
        genres,
        problemTemplate,
        dramaticQuestion,
        keywords
    }
) => {

    const navigate = useNavigate()

    const [isLogLineDescriptionCompletionLoading, setIsLogLineDescriptionCompletionLoading] = useState(false)

    const onGenerateLogLineCompletion = async () => {
        setIsLogLineDescriptionCompletionLoading(true)
        fetchLogLineDescriptionCompletion()
    }

    const fetchLogLineDescriptionCompletion = async () => {
        fetchWithTimeout('/api/LogLineDescription/Generate?keywordsImpact=4', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'seed': 123,
                'genres': genres,
                'problemTemplate': problemTemplate,
                'keywords': keywords,
                'dramaticQuestion': dramaticQuestion
            })
        }).then(function (response) {
            if (response.status === 401 || response.status === 403) {
                navigate('/plots')
            } else {
                if (response.ok) {
                    return response.json();
                }
            }
            return Promise.reject(response);
        }).then(function (data) {
            if (AILogLineDescriptions) {
                onAILogLineDescriptionsChange([...AILogLineDescriptions, data])
            } else {
                onAILogLineDescriptionsChange([data])
            }

        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server. Please wait a few minutes and try again.');
        }).finally(function () {
            setIsLogLineDescriptionCompletionLoading(false)
        });
    }

    const onDeleteBrainstorm = (idxToDelete) => {
        onAILogLineDescriptionsChange(AILogLineDescriptions.filter((obj, objIdx) => objIdx !== idxToDelete))
    }

    const startingPage = !AILogLineDescriptions ? 0 : AILogLineDescriptions.length - 1

    return (

        <Accordion defaultActiveKey={['0', '1']} alwaysOpen>
            <Accordion.Item eventKey="0">
                <Accordion.Header>Brainstorm with AI</Accordion.Header>
                <Accordion.Body>
                    {
                        <div className='row'>
                            {
                                userInfo && userInfo.userRoles.includes('customer') &&
                                <>
                                    <p className="text-muted">The AI sometimes returns characters, locations, and events from existing stories. Add some twists of your own to ensure uniqueness.</p>
                                    <hr />

                                    <Carousel variant="dark" interval={null} indicators={true} defaultActiveIndex={startingPage}>
                                        {
                                            AILogLineDescriptions && AILogLineDescriptions.length > 0 && AILogLineDescriptions.map((obj, idx) =>
                                                <Carousel.Item key={'carousel-' + idx}>
                                                    {
                                                        <Tabs defaultActiveKey="finetune" className="mb-3">
                                                            <Tab eventKey="finetune" title="Original (genres)">
                                                                <p>{obj['finetuned']['completion']}</p>
                                                            </Tab>
                                                            {
                                                                obj['keywords'] &&
                                                                <Tab eventKey="keywords" title="With keywords">
                                                                    <p>{obj['keywords']['completion']}</p>
                                                                </Tab>
                                                            }
                                                            <Tab eventKey="manage" title={<FaCog />}>
                                                                <button className="btn btn-danger mt-2 mb-4" onClick={() => onDeleteBrainstorm(idx)}>delete this brainstorm</button>
                                                            </Tab>
                                                        </Tabs>
                                                    }
                                                </Carousel.Item>
                                            )
                                        }
                                    </Carousel>

                                    <button disabled={isLogLineDescriptionCompletionLoading} type="button" className="btn btn-info mt-2" onClick={onGenerateLogLineCompletion}>
                                        {
                                            isLogLineDescriptionCompletionLoading === true &&
                                            <Spinner size="sm" as="span" animation="border" variant="secondary" />
                                        }
                                        {
                                            isLogLineDescriptionCompletionLoading === false &&
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

                        </div>
                    }
                </Accordion.Body>
            </Accordion.Item>
            <Accordion.Item eventKey="1">
                <Accordion.Header>Advice</Accordion.Header>
                <Accordion.Body>
                    <p>
                        Write 1-3 sentences that tease the hero's transformation via the plot events. Try to interweave two iteresting ideas. Add irony where the primary conflict also happens to intersect with the hero's biggest character flaws. For example:
                    </p>
                    <p>
                        When [FLAWED HERO], is [CHALLENGED BY PIVOTAL EVENT], they must [DO ACTION]. But when [UNEXPECTED TWIST], they must [OVERCOME PERSONAL FLAW], or [LOSE PRIMAL STAKES].
                    </p>
                </Accordion.Body>
            </Accordion.Item>
        </Accordion>
    )
}

export default LogLineDescriptionBrainstorm