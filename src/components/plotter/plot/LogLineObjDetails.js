import React, { useState, useEffect } from 'react'
import { useNavigate } from "react-router-dom";
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
        logLineDescription,
        AILogLineDescriptions,
        AITitles,
        //onAILogLineTitleChange,
        onAILogLineDescriptionsChange,
        curFocusElName,
        genres,
        problemTemplate,
        dramaticQuestion,
        keywords,
        sequences,
        characters,
        setAITitles
    }
) => {

    const navigate = useNavigate()

    const [isKeywordsLoading, setIsKeywordsLoading] = useState(false)
    const [isLogLineDescriptionCompletionLoading, setIsLogLineDescriptionCompletionLoading] = useState(false)
    const [isTitlesCompletionLoading, setIsTitlesCompletionLoading] = useState(false)
    const [descIsLoading, setDescIsLoading] = useState(false)
    const [genresDescObjs, setGenresDescObjs] = useState(null)
    const [problemTemplateDescObj, setProblemTemplateDescObj] = useState(null)
    const [dramaticQuestionDescObj, setDramaticQuestionDescObj] = useState(null)
    const [aiKeywords, setAIKeywords] = useState([])

    const onGenerateLogLineCompletion = async () => {
        setIsLogLineDescriptionCompletionLoading(true)
        fetchLogLineDescriptionCompletion()
    }

    const onGenerateTitlesCompletion = async () => {
        setIsTitlesCompletionLoading(true)
        fetchTitlesCompletion()
    }

    const onGenerateKeywords = async () => {
        setIsKeywordsLoading(true)
        fetchKeywords()
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
                'dramaticQuestion': dramaticQuestion,
                'sequences': sequences,
                'characters': characters
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
            setIsLogLineDescriptionCompletionLoading(false)
        });
    }

    const fetchTitlesCompletion = async () => {
        fetchWithTimeout('/api/Titles/Generate', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'seed': 123,
                'genres': genres,
                'logLineDescription': logLineDescription,
                'problemTemplate': problemTemplate,
                'keywords': keywords,
                'dramaticQuestion': dramaticQuestion,
                'sequences': sequences,
                'characters': characters
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
            setAITitles(data)
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server. Please wait a few minutes and try again.');
        }).finally(function () {
            setIsTitlesCompletionLoading(false)
        });
    }

    const fetchKeywords = async () => {
        fetchWithTimeout('/api/Keywords?genres=' + genres.join(',') + '&numKeywords=7', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
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
            console.log(data)
            setAIKeywords(data)
        }).catch(function (error) {
            console.warn(error);
        }).finally(function () {
            setIsKeywordsLoading(false)
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
                    if (response.status === 401 || response.status === 403) {
                        navigate('/plots')
                    } else {
                        if (response.ok) {
                            return response.json();
                        }
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

    const startingPage = !AILogLineDescriptions ? 0 : AILogLineDescriptions.length - 1

    const aiTitlesListItems = (AITitles ?? []).map((t, idx) =>
        <li key={idx}>{t}</li>
    )

    const aiKeywordsListItems = (aiKeywords ?? []).map((keyword, idx) =>
        <li key={idx}>{keyword}</li>
    )

    return (
        <div>
            {
                descIsLoading === true && <Spinner animation="border" variant="secondary" />
            }
            {
                descIsLoading === false && <>
                    {
                        (curFocusElName === 'logLineDescription') &&
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
                        </>
                    }
                    {
                        curFocusElName === 'title' &&
                        <>
                            <p id="titleHelp">A few short words that capture something symbolic about the story. Don't worry about getting the perfect title right now - treat it like a draft and come back to it later.</p>
                            <ul>
                                {
                                    aiTitlesListItems
                                }
                            </ul>
                            <p className='text-muted'>Sometimes the generated titles have already been used by other authors or movies, so we recommend searching for the title before using it.</p>
                            <button disabled={isTitlesCompletionLoading} type="button" className="btn btn-info mt-2" onClick={onGenerateTitlesCompletion}>
                                {
                                    isTitlesCompletionLoading === true &&
                                    <Spinner size="sm" as="span" animation="border" variant="secondary" />
                                }
                                {
                                    isTitlesCompletionLoading === false &&
                                    <FaGhost />
                                }
                                <span> New AI Brainstorm</span>
                            </button>
                        </>
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
                    {
                        curFocusElName === 'keywords' &&
                        <>
                            <p>Genre-appropriate ({genres.join(', ')}) keywords and concepts this story focuses on.</p>

                            <ul>
                                {
                                    aiKeywordsListItems
                                }
                            </ul>
                            <button disabled={isKeywordsLoading} title='Generate ' type="button" className="btn btn-info mt-2" onClick={onGenerateKeywords}>
                                {
                                    isKeywordsLoading === true &&
                                    <Spinner size="sm" as="span" animation="border" variant="secondary" />
                                }
                                {
                                    isKeywordsLoading === false &&
                                    <FaGhost />
                                }
                                <span> New Keywords Brainstorm</span>
                            </button>
                        </>
                    }
                </>
            }
        </div>
    )
}

export default LogLineObjDetails