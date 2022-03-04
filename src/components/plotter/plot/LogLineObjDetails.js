import React, { useState, useEffect } from 'react'
import { FaGhost, FaCog } from 'react-icons/fa'
import Accordion from 'react-bootstrap/Accordion';
import Spinner from 'react-bootstrap/Spinner';
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import Carousel from 'react-bootstrap/Carousel'
import GenresDescription from './GenresDescription'
import ProblemTemplateDescription from './ProblemTemplateDescription'
import DramaticQuestionDescription from './DramaticQuestionDescription'
import { fetchWithTimeout } from '../../../util/FetchUtil'
//import 'react-bootstrap-range-slider/dist/react-bootstrap-range-slider.css';
//import RangeSlider from 'react-bootstrap-range-slider';

const LogLineObjDetails = (
    {
        userInfo,
        //AILogLineTitle,
        AILogLineDescriptions,
        //onAILogLineTitleChange,
        onAILogLineDescriptionsChange,
        curFocusElName,
        genres,
        problemTemplate,
        dramaticQuestion,
        keywords,
        sequences,
        characters
    }
) => {

    const [isCompletionLoading, setIsCompletionLoading] = useState(false)
    const [descIsLoading, setDescIsLoading] = useState(false)
    const [genresDescObjs, setGenresDescObjs] = useState(null)
    const [problemTemplateDescObj, setProblemTemplateDescObj] = useState(null)
    const [dramaticQuestionDescObj, setDramaticQuestionDescObj] = useState(null)
    //const [keywordSliderValue, setKeywordSliderValue] = useState(5);

    const onGenerateCompletion = async () => {
        setIsCompletionLoading(true)
        fetchCompletion()
    }

    const fetchCompletion = async () => {
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
                'dramaticQuestion': dramaticQuestion,
                'sequences': sequences,
                'characters': characters
            })
        }).then(function (response) {
            if (response.ok) {
                return response.json();
            }
            return Promise.reject(response);
        }).then(function (data) {
            //const lastItem = [...data].pop()
            // clone existing AILogLineDescriptions and append the new data item returned

            if (AILogLineDescriptions) {
                onAILogLineDescriptionsChange([...AILogLineDescriptions, data])
            } else {
                onAILogLineDescriptionsChange([data])
            }

        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server. Please wait a few minutes and try again.');
        }).finally(function () {
            setIsCompletionLoading(false)
        });
    }

    const onDeleteBrainstorm = (idxToDelete) => {
        onAILogLineDescriptionsChange(AILogLineDescriptions.filter((obj, objIdx) => objIdx !== idxToDelete))
    }

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        loadDescObj(curFocusElName)

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [curFocusElName, genres, problemTemplate, dramaticQuestion]);

    const isNullOrEmpty = (val) => {
        if (val === undefined) return true
        if (val === null) return true
        if (val === '') return true
        if (val.length === 0) return true

        return false
    }

    const loadDescObj = async (elName) => {
        let url = ''

        if (elName === 'genres' && !isNullOrEmpty(genres)) {
            url = '/api/LogLine/GenresDescription?genres=' + genres.join(',')
        } else if (elName === 'problem template' && !isNullOrEmpty(problemTemplate)) {
            url = '/api/LogLine/ProblemTemplateDescription?problemTemplate=' + problemTemplate
        } else if (elName === 'dramatic question' && !isNullOrEmpty(dramaticQuestion)) {
            url = '/api/LogLine/DramaticQuestionDescription?dramaticQuestion=' + dramaticQuestion
        }

        if (url !== '') {
            setDescIsLoading(true)

            fetch(url)
                .then(function (response) {
                    if (response.ok) {
                        return response.json();
                    }
                    return Promise.reject(response);
                }).then(function (data) {

                    if (elName === 'genres') {
                        setGenresDescObjs(data)
                    } else if (elName === 'problem template') {
                        setProblemTemplateDescObj(data)
                    } else if (elName === 'dramatic question') {
                        setDramaticQuestionDescObj(data)
                    }
                }).catch(function (error) {
                    console.warn(error);
                }).finally(function () {
                    setDescIsLoading(false)
                });
        }
    }

    return (
        <div>
            {
                descIsLoading === true && <Spinner animation="border" variant="secondary" />
            }
            {
                descIsLoading === false && <>
                    {
                        (curFocusElName === 'logLineDescription' || curFocusElName === 'keywords') &&
                        <>
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

                                                        <Carousel variant="dark" interval={null} indicators={true} defaultActiveIndex={AILogLineDescriptions.length-1}>
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

                                                        <button disabled={isCompletionLoading} title='This will replace the existing brainstorm' type="button" className="btn btn-info mt-2" onClick={onGenerateCompletion}>
                                                            {
                                                                isCompletionLoading === true &&
                                                                <Spinner size="sm" as="span" animation="border" variant="secondary" />
                                                            }
                                                            {
                                                                isCompletionLoading === false &&
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
                                            Write 1-3 sentences that tease the plot. Try to interweave two iteresting ideas, and add a dash of irony.
                                        </p>
                                    </Accordion.Body>
                                </Accordion.Item>
                            </Accordion>
                        </>
                    }
                    {
                        curFocusElName === 'title' &&
                        <p id="titleHelp">A few short words that capture something symbolic about the story. Don't worry about getting the perfect title right now - treat it like a draft and come back to it later.</p>
                    }
                    {
                        curFocusElName === 'genres' && genresDescObjs !== null && <GenresDescription genresDescObjs={genresDescObjs} />
                    }
                    {
                        curFocusElName === 'problem template' && problemTemplateDescObj && <ProblemTemplateDescription problemTemplateDescObj={problemTemplateDescObj} />
                    }
                    {
                        curFocusElName === 'dramatic question' && dramaticQuestionDescObj && <DramaticQuestionDescription dramaticQuestionDescObj={dramaticQuestionDescObj} />
                    }
                    {/* {
                        curFocusElName === 'keywords' &&
                        <>
                            <p>Enter 3-5 core concepts this story relies upon. For example:</p>
                            <ul>
                                <li>magic ring</li>
                                <li>spaceship</li>
                                <li>deception</li>
                                <li>The Chosen One</li>
                                <li>shame</li>
                            </ul>
                        </>
                    } */}
                </>
            }
        </div>
    )
}

export default LogLineObjDetails