import React, { useEffect, useState } from 'react'
//import Popover from 'react-bootstrap/Popover';
import Accordion from 'react-bootstrap/Accordion';
//import OverlayTrigger from 'react-bootstrap/OverlayTrigger'
import Spinner from 'react-bootstrap/Spinner';
//import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Nav from 'react-bootstrap/Nav'
//import { useSearchParams } from "react-router-dom";
import ArchetypeDescription from './ArchetypeDescription'
import { FaGhost, FaMinusCircle, FaArrowsAltH } from 'react-icons/fa'
import { fetchWithTimeout } from '../../../util/FetchUtil'
import LimitedTextArea from './LimitedTextArea'
import { encode } from "../../../util/tokenizer/mod"; // FROM https://github.com/josephrocca/gpt-2-3-tokenizer


const Character = ({
    userInfo,
    onFocusChange,

    archetypeOptions,
    genres,
    problemTemplate,
    keywords,
    dramaticQuestion,

    character,
    characters,

    updateCharacterName,
    updateCharacterArchetype,
    updateCharacterDescription,
    updateAICharacterDescription,
    deleteCharacter,
    //allowed
}) => {

    const [isCompletionLoading, setIsCompletionLoading] = useState(false)
    //const [commonAdvice, setCommonAdvice] = useState('')


    const [descriptionTokenCount, setDescriptionTokenCount] = useState(0)

    const onGenerateCompletion = async () => {
        setIsCompletionLoading(true)
        fetchCompletion(character.archetype)
    }

    const onDeleteCharacter = () => {
        deleteCharacter(character.id)
    }

    const fetchCompletion = async (archetype) => {
        fetchWithTimeout('/api/Character/Generate?archetype=' + archetype, {
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
                // 'heroArchetype': heroArchetype,
                // 'enemyArchetype': enemyArchetype,
                // 'primalStakes': primalStakes,
                'dramaticQuestion': dramaticQuestion,
                //'sequences': sequences,
                'characters': characters
            })
        }).then(function (response) {
            if (response.ok) {
                return response.json();
            }
            return Promise.reject(response);
        }).then(function (data) {
            updateAICharacterDescription(character.id, data['completion'])
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server. Please wait a few minutes and try again.');
        }).finally(function () {
            setIsCompletionLoading(false)
        });
    }

    const updateTokenCount = () => {
        const tokens = encode(character.description)
        setDescriptionTokenCount(tokens.length)
    }

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        //if (sequence.isLocked === false) { // IMPORTANT: changing log line won't affect advice of older sequences that have already been locked
        const timeout = setTimeout(() => {
            updateTokenCount()
        }, 2000) //2000 - timeout to execute this function if timeout will be not cleared

        return () => clearTimeout(timeout) //clear timeout (delete function execution)
        //}

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [character]);

    const onCharacterNameChange = (event) => {
        updateCharacterName(character.id, event.target.value)
    }

    const onArchetypeChange = (event) => {
        updateCharacterArchetype(character.id, event.target.value)
    }

    return (
        <>
            <div className='row border-top mt-3 pt-3' onClick={onFocusChange}>

                <div className='col-md-7'>
                    <div className='row pb-3'>
                        <div className='col-md-7'>
                            <input type='text' className='fs-5 form-control' placeholder='Character Name' required onChange={onCharacterNameChange} defaultValue={character.name} />

                        </div>
                        <div className='col-md-4'>
                            <select required className='fs-5 form-select form-inline' defaultValue={character.archetype} onChange={onArchetypeChange} onFocus={() => onFocusChange('archetype')}>
                                <option key="blank" value="" disabled selected>Archetype</option>
                                {
                                    archetypeOptions.map(function (o) {
                                        return <option key={o.value} value={o.value}>{o.label}</option>
                                    })
                                }
                            </select>
                        </div>
                        <div className='col-md-1'>
                            {
                                character.id !== characters[0].id &&
                                <button onClick={onDeleteCharacter} className='btn btn-outline-danger float-end btn-no-border'><FaMinusCircle /></button>
                            }
                        </div>
                    </div>
                    <div className='row'>
                        {/* <Tabs defaultActiveKey="closeminded" className="mb-3">
                            <Tab eventKey="closeminded" title="Closeminded-Imaginative">
                                <p>grid goes here for Closeminded-Imaginative</p>
                            </Tab>
                            <Tab eventKey="disciplined" title="Disciplines-Spontaneous">
                                <p>grid goes here for Disciplines-Spontaneous</p>
                            </Tab>
                            <Tab eventKey="introvert" title="Introvert-Extrovert">
                                <p>grid goes here for Introvert-Extrovert</p>
                            </Tab>
                            <Tab eventKey="cold" title="Cold-Empathetic">
                                <p>grid goes here for Cold-Empathetic</p>
                            </Tab>
                            <Tab eventKey="unflappable" title="Unflappable-Anxious">
                                <p>grid goes here for Unflappable-Anxious</p>
                            </Tab>
                        </Tabs> */}


                        <Tab.Container id="left-tabs-example" defaultActiveKey="closeminded">
                            <Row>
                                <Col sm={4}>
                                    <Nav variant="pills" className="flex-column">
                                        <Nav.Item>
                                            <Nav.Link eventKey="closeminded">Closeminded-Imaginative</Nav.Link>
                                        </Nav.Item>
                                        <Nav.Item>
                                            <Nav.Link eventKey="disciplined">Disciplined-Spontaneous</Nav.Link>
                                        </Nav.Item>
                                        <Nav.Item>
                                            <Nav.Link eventKey="introvert">Introvert-Extrovert</Nav.Link>
                                        </Nav.Item>
                                        <Nav.Item>
                                            <Nav.Link eventKey="cold">Cold-Empathetic</Nav.Link>
                                        </Nav.Item>
                                        <Nav.Item>
                                            <Nav.Link eventKey="unflappable">Unflappable-Anxious</Nav.Link>
                                        </Nav.Item>
                                    </Nav>
                                </Col>
                                <Col sm={8}>
                                    <Tab.Content>
                                        <Tab.Pane eventKey="closeminded">
                                            <div className='row'>
                                                <div className='col-md-12'>
                                                    <table className='big5-table w-100 text-center'>
                                                        <th colspan='5'>Closedminded <FaArrowsAltH /> Imaginative</th>
                                                        <tr className='big5-aspect-label rotate-90'>
                                                            <td rowspan='6' className='rotate-180'>Fuddy-duddy <FaArrowsAltH /> Idea-averse</td>
                                                        </tr>
                                                        <tr className='big5-aspect-label rotate-270'>
                                                            <td rowspan='6'>Artsy <FaArrowsAltH /> Brainstormer</td>
                                                        </tr>
                                                        <tr>
                                                            <td>X</td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td>X</td>
                                                        </tr>
                                                        <tr>
                                                            <td>X</td>
                                                            <td>X</td>
                                                            <td></td>
                                                            <td>X</td>
                                                            <td>X</td>
                                                        </tr>
                                                        <tr>
                                                            <td>X</td>
                                                            <td>X</td>
                                                            <td>X</td>
                                                            <td>X</td>
                                                            <td>X</td>
                                                        </tr>
                                                        <tr>
                                                            <td>X</td>
                                                            <td>X</td>
                                                            <td></td>
                                                            <td>X</td>
                                                            <td>X</td>
                                                        </tr>
                                                        <tr>
                                                            <td>X</td>
                                                            <td></td>
                                                            <td></td>
                                                            <td></td>
                                                            <td>X</td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>
                                            <div className='row'>
                                                <div className='col-md-12'>
                                                    <p>Archetype description goes here.</p>
                                                    <p>Big 5: Moderate Unflappable: Resilient, Controlled, Stress-free, Calm, Unemotional, Hardy, Secure, Self-satisfied</p>
                                                    <p>Big 5 Aspect: Full Impervious: Emotionally stable, Impervious, Maintain composure, Not easily annoyed</p>
                                                </div>
                                            </div>
                                        </Tab.Pane>
                                        <Tab.Pane eventKey="disciplined">
                                            <p>grid goes here for Disciplined-Spontaneous</p>
                                        </Tab.Pane>
                                        <Tab.Pane eventKey="introvert">
                                            <p>grid goes here for Introvert-Extrovert</p>
                                        </Tab.Pane>
                                        <Tab.Pane eventKey="cold">
                                            <p>grid goes here for Cold-Empathetic</p>
                                        </Tab.Pane>
                                        <Tab.Pane eventKey="unflappable">
                                            <p>grid goes here for Unflappable-Anxious</p>
                                        </Tab.Pane>
                                    </Tab.Content>
                                </Col>
                            </Row>
                        </Tab.Container>

                        {/* <div className='col-md-5'>
                            <label htmlFor="customRange1" className="form-label">A <FaArrowsAltH/> B</label>
                            <input type="range" className="form-range" id="customRange1" min="-2" max="2" step="1" defaultValue={0} />
                        </div>
                        <div className='col-md-7'>
                            <p>Big 5 desc goes here .Big 5 desc goes here .Big 5 desc goes here .Big 5 desc goes here .Big 5 desc goes here .Big 5 desc goes here .</p>
                        </div> */}
                    </div>
                    <div className='row'>
                        <div className='col-md-12'>
                            <LimitedTextArea
                                className="form-control"
                                value={character.description}
                                setValue={(newValue) => updateCharacterDescription(character.id, newValue)}
                                rows={2}
                                limit={200}
                                curTokenCount={descriptionTokenCount}
                                showCount={true}
                            />
                        </div>


                    </div>
                </div>
                <div className='col-md-5'>
                    {
                        <>
                            <Accordion defaultActiveKey={['1']} alwaysOpen>
                                <Accordion.Item eventKey="0">
                                    <Accordion.Header>Brainstorm with AI</Accordion.Header>
                                    <Accordion.Body>
                                        {
                                            <div className='row'>
                                                {
                                                    userInfo && userInfo.userRoles.includes('customer') &&
                                                    <>
                                                        {
                                                            character.aiText && character.aiText.length > 0 &&
                                                            <p>{character.aiText}</p>
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
                                                        <p>Sign up for our premium plan to ask the AI to brainstorm ideas for this sequence.</p>
                                                    </>
                                                }

                                            </div>
                                        }
                                    </Accordion.Body>
                                </Accordion.Item>
                                <Accordion.Item eventKey="1">
                                    <Accordion.Header>Advice</Accordion.Header>
                                    <Accordion.Body>
                                        <ArchetypeDescription archetype={character.archetype} />
                                    </Accordion.Body>
                                </Accordion.Item>
                            </Accordion>
                        </>
                    }
                </div>


            </div>
        </>
    )
}

export default Character