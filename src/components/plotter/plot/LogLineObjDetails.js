import React, { useState, useEffect } from 'react'
import { FaGhost } from 'react-icons/fa'
import Accordion from 'react-bootstrap/Accordion';
import Spinner from 'react-bootstrap/Spinner';
import GenreDescription from './GenreDescription'
import ProblemTemplateDescription from './ProblemTemplateDescription'
import DramaticQuestionDescription from './DramaticQuestionDescription'
import { fetchWithTimeout } from '../../../util/FetchUtil'

const LogLineObjDetails = (
    {
        userInfo,
        AILogLineDescription,
        onAILogLineDescriptionChange,
        curFocusElName,
        genre,
        problemTemplate,
        dramaticQuestion,
        keywords,
        sequences,
        characters
    }
) => {

    const [isCompletionLoading, setIsCompletionLoading] = useState(false)
    const [descIsLoading, setDescIsLoading] = useState(false)
    const [genreDescObj, setGenreDescObj] = useState(null)
    const [problemTemplateDescObj, setProblemTemplateDescObj] = useState(null)
    const [dramaticQuestionDescObj, setDramaticQuestionDescObj] = useState(null)

    const onGenerateCompletion = async () => {
        setIsCompletionLoading(true)
        fetchCompletion()
    }

    const fetchCompletion = async () => {
        fetchWithTimeout('/api/LogLineDescription/Generate', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'seed': 123,
                'genre': genre,
                'problemTemplate': problemTemplate,
                'keywords': keywords,
                // 'heroArchetype': heroArchetype,
                // 'enemyArchetype': enemyArchetype,
                // 'primalStakes': primalStakes,
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
            onAILogLineDescriptionChange(data['completion'])
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server. Please wait a few minutes and try again.');
        }).finally(function () {
            setIsCompletionLoading(false)
        });
    }

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        loadDescObj(curFocusElName)

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [curFocusElName, genre, problemTemplate, dramaticQuestion]);

    const isNullOrEmpty = (val) => {
        if (val === undefined) return true
        if (val === null) return true
        if (val === '') return true
        if (val.length === 0) return true

        return false
    }

    const loadDescObj = async (elName) => {
        let url = ''

        if (elName === 'genre' && !isNullOrEmpty(genre)) {
            url = '/api/LogLine/GenreDescription?genre=' + genre
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

                    if (elName === 'genre') {
                        setGenreDescObj(data)
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

    // onAILogLineDescriptionChange('the ai value here')

    return (
        <div>
            {
                descIsLoading === true && <Spinner animation="border" variant="secondary" />
            }
            {
                descIsLoading === false && <>
                    {
                        curFocusElName === 'logLineDescription' &&
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
                                                        {
                                                            AILogLineDescription && AILogLineDescription.length > 0 &&
                                                            <p>{AILogLineDescription}</p>
                                                        }

                                                        <button disabled={isCompletionLoading} title='This will replace the existing brainstorm' type="button" className="generate btn btn-info mt-2 text-right" onClick={onGenerateCompletion}>
                                                            {
                                                                isCompletionLoading === true &&
                                                                <Spinner size="sm" as="span" animation="border" variant="secondary" />
                                                            }
                                                            {
                                                                isCompletionLoading === false &&
                                                                <FaGhost />
                                                            }
                                                            <span> Brainstorm with AI</span>
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
                                            Write a 2-sentence teaser to get people interested in the story.
                                        </p>
                                    </Accordion.Body>
                                </Accordion.Item>
                            </Accordion>
                        </>
                    }
                    {
                        curFocusElName === 'title' &&
                        <p>A few short words that capture something symbolic about the story. Don't worry about getting the perfect title right now - treat it like a draft and come back to it later.</p>
                    }
                    {
                        curFocusElName === 'genre' && genreDescObj !== null && <GenreDescription genreDescObj={genreDescObj} />
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
                            <p>Enter 3-5 core concepts this story relies upon. For example:</p>
                            <ul>
                                <li>magic ring</li>
                                <li>spaceship</li>
                                <li>deception</li>
                                <li>The Chosen One</li>
                                <li>shame</li>
                            </ul>
                        </>
                    }
                </>
            }
        </div>
    )
}

export default LogLineObjDetails