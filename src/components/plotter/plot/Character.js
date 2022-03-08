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
import Personality from './Personality'
import { FaGhost, FaMinusCircle } from 'react-icons/fa'
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
    updateCharacterIsHero,
    updateCharacterArchetype,
    updateCharacterDescription,
    updateAICharacterDescription,
    deleteCharacter,
    updateCharacterPersonality,
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

    const getPersonalityDescription = (closeminded_to_imaginative, closeminded_to_imaginative_aspect, disciplined_to_spontaneous, disciplined_to_spontaneous_aspect, introvert_to_extrovert, introvert_to_extrovert_aspect, cold_to_empathetic, cold_to_empathetic_aspect, unflappable_to_anxious, unflappable_to_anxious_aspect) => {

        const getOneWordDesc = (neutral_point, bigFiveAmount, aspectAmount, bigFiveNegAspectNeg, bigFiveNegAspectNeutral, bigFiveNegAspectPos, bigFiveTrueNeutral, bigFivePosAspectNeg, bigFivePosAspectNeutral, bigFivePosAspectPos) => {
            if (bigFiveAmount < neutral_point * -1) {
                if (aspectAmount < neutral_point * -1) {
                    return bigFiveNegAspectNeg;
                } else if (aspectAmount > neutral_point) {
                    return bigFiveNegAspectPos;
                } else {
                    return bigFiveNegAspectNeutral;
                }
            } else if (bigFiveAmount > neutral_point) {
                if (aspectAmount < neutral_point * -1) {
                    return bigFivePosAspectNeg;
                } else if (aspectAmount > neutral_point) {
                    return bigFivePosAspectPos;
                } else {
                    return bigFivePosAspectNeutral;
                }
            } else {
                return bigFiveTrueNeutral;
            }
        }

        var neutral_point = 0.2;

        let closeminded_to_imaginative_desc = getOneWordDesc(neutral_point, closeminded_to_imaginative, closeminded_to_imaginative_aspect,
            'fuddy duddy', 'generally closeminded', 'mentally resistant',
            'moderate',
            'artsy', 'generally imaginative', 'brainstormer');

        let disciplined_to_spontaneous_desc = getOneWordDesc(neutral_point, disciplined_to_spontaneous, disciplined_to_spontaneous_aspect,
            'industrious', 'generally disciplined', 'orderly',
            'dynamic',
            'head in the clouds', 'generally spontaneous', 'sloppy');

        let introvert_to_extrovert_desc = getOneWordDesc(neutral_point, introvert_to_extrovert, introvert_to_extrovert_aspect,
            'glum', 'generally introverted', 'submissive',
            'ambivert',
            'gung-ho', 'generally extroverted', 'bossy');

        let cold_to_empathetic_desc = getOneWordDesc(neutral_point, cold_to_empathetic, cold_to_empathetic_aspect,
            'unfeeling', 'generally cold', 'rude',
            'negotiator',
            'compassionate', 'generally empathetic', 'polite');

        let unflappable_to_anxious_desc = getOneWordDesc(neutral_point, unflappable_to_anxious, unflappable_to_anxious_aspect,
            'emotionally impervious', 'generally unflappable', 'relaxed',
            'responsive to stress',
            'volatile', 'generally anxious', 'vulnerable');

        return [closeminded_to_imaginative_desc, disciplined_to_spontaneous_desc, introvert_to_extrovert_desc, cold_to_empathetic_desc, unflappable_to_anxious_desc];
    }

    const characterPersonality = character['personality']

    const closemindedToImaginativePrimary = !characterPersonality ? 0.0 : characterPersonality['closemindedToImaginative']['primary']
    const closemindedToImaginativeAspect = !characterPersonality ? 0.0 : characterPersonality['closemindedToImaginative']['aspect']

    const disciplinedToSpontaneousPrimary = !characterPersonality ? 0.0 : characterPersonality['disciplinedToSpontaneous']['primary']
    const disciplinedToSpontaneousAspect = !characterPersonality ? 0.0 : characterPersonality['disciplinedToSpontaneous']['aspect']

    const introvertToExtrovertPrimary = !characterPersonality ? 0.0 : characterPersonality['introvertToExtrovert']['primary']
    const introvertToExtrovertAspect = !characterPersonality ? 0.0 : characterPersonality['introvertToExtrovert']['aspect']

    const coldToEmpatheticPrimary = !characterPersonality ? 0.0 : characterPersonality['coldToEmpathetic']['primary']
    const coldToEmpatheticAspect = !characterPersonality ? 0.0 : characterPersonality['coldToEmpathetic']['aspect']

    const unflappableToAnxiousPrimary = !characterPersonality ? 0.0 : characterPersonality['unflappableToAnxious']['primary']
    const unflappableToAnxiousAspect = !characterPersonality ? 0.0 : characterPersonality['unflappableToAnxious']['aspect']

    const personalityStrs = getPersonalityDescription(
        closemindedToImaginativePrimary,
        closemindedToImaginativeAspect,
        disciplinedToSpontaneousPrimary,
        disciplinedToSpontaneousAspect,
        introvertToExtrovertPrimary,
        introvertToExtrovertAspect,
        coldToEmpatheticPrimary,
        coldToEmpatheticAspect,
        unflappableToAnxiousPrimary,
        unflappableToAnxiousAspect,
    )

    const personalitySummary = personalityStrs.slice(0, 4).join(', ') + ' and ' + personalityStrs[4]

    const characterArchetypeCapitalized = !character.archetype ? 'Archetype not set' : character.archetype[0].toUpperCase() + character.archetype.slice(1)

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
                                <button onClick={onDeleteCharacter} className='btn btn-outline-danger float-end btn-no-border' title='delete character'><FaMinusCircle /></button>
                            }
                        </div>
                    </div>

                    <Accordion defaultActiveKey={['0']} alwaysOpen>

                        <Accordion.Item eventKey="0">
                            <Accordion.Header>Personality</Accordion.Header>
                            <Accordion.Body>
                                <div className='row'>
                                    <Tab.Container id="left-tabs-example" defaultActiveKey="closeminded">
                                        <Row>
                                            <Col sm={5}>
                                                <Nav variant="pills" className="flex-column">
                                                    <Nav.Item>
                                                        <Nav.Link eventKey="closeminded">Closeminded - Imaginative</Nav.Link>
                                                    </Nav.Item>
                                                    <Nav.Item>
                                                        <Nav.Link eventKey="disciplined">Disciplined - Spontaneous</Nav.Link>
                                                    </Nav.Item>
                                                    <Nav.Item>
                                                        <Nav.Link eventKey="introvert">Introvert - Extrovert</Nav.Link>
                                                    </Nav.Item>
                                                    <Nav.Item>
                                                        <Nav.Link eventKey="cold">Cold - Empathetic</Nav.Link>
                                                    </Nav.Item>
                                                    <Nav.Item>
                                                        <Nav.Link eventKey="unflappable">Unflappable - Anxious</Nav.Link>
                                                    </Nav.Item>
                                                </Nav>
                                            </Col>
                                            <Col sm={7}>
                                                <Tab.Content>
                                                    <Tab.Pane eventKey="closeminded">
                                                        <Personality
                                                            personalityKey='closemindedToImaginative'
                                                            primaryLeft='closeminded'
                                                            primaryRight='imaginative'
                                                            primaryLeftAspectTop='fuddy-duddy'
                                                            primaryLeftAspectBottom='idea-averse'
                                                            primaryRightAspectTop='artsy'
                                                            primaryRightAspectBottom='brainstormer'
                                                            character={character}
                                                            onChange={updateCharacterPersonality}
                                                        />
                                                    </Tab.Pane>
                                                    <Tab.Pane eventKey="disciplined">
                                                        <Personality
                                                            personalityKey='disciplinedToSpontaneous'
                                                            primaryLeft='disciplined'
                                                            primaryRight='spontaneous'
                                                            primaryLeftAspectTop='industrious'
                                                            primaryLeftAspectBottom='orderly'
                                                            primaryRightAspectTop='head in the clouds'
                                                            primaryRightAspectBottom='sloppy'
                                                            character={character}
                                                            onChange={updateCharacterPersonality}
                                                        />
                                                    </Tab.Pane>
                                                    <Tab.Pane eventKey="introvert">
                                                        <Personality
                                                            personalityKey='introvertToExtrovert'
                                                            primaryLeft='introvert'
                                                            primaryRight='extrovert'
                                                            primaryLeftAspectTop='glum'
                                                            primaryLeftAspectBottom='submissive'
                                                            primaryRightAspectTop='gung-ho'
                                                            primaryRightAspectBottom='bossy'
                                                            character={character}
                                                            onChange={updateCharacterPersonality}
                                                        />
                                                    </Tab.Pane>
                                                    <Tab.Pane eventKey="cold">
                                                        <Personality
                                                            personalityKey='coldToEmpathetic'
                                                            primaryLeft='cold'
                                                            primaryRight='empathetic'
                                                            primaryLeftAspectTop='unfeeling'
                                                            primaryLeftAspectBottom='rude'
                                                            primaryRightAspectTop='compassionate'
                                                            primaryRightAspectBottom='polite'
                                                            character={character}
                                                            onChange={updateCharacterPersonality}
                                                        />
                                                    </Tab.Pane>
                                                    <Tab.Pane eventKey="unflappable">
                                                        <Personality
                                                            personalityKey='unflappableToAnxious'
                                                            primaryLeft='unflappable'
                                                            primaryRight='anxious'
                                                            primaryLeftAspectTop='impervious'
                                                            primaryLeftAspectBottom='relaxed'
                                                            primaryRightAspectTop='volatile'
                                                            primaryRightAspectBottom='vulnerable'
                                                            character={character}
                                                            onChange={updateCharacterPersonality}
                                                        />
                                                    </Tab.Pane>
                                                </Tab.Content>
                                            </Col>
                                        </Row>
                                    </Tab.Container>
                                </div>
                            </Accordion.Body>
                        </Accordion.Item>
                    </Accordion>

                    <div title="you may only designate one character as the protagonist">
                        <label htmlFor={character.id + '_is_protagonist'}>Is Protagonist?</label>
                        <input id={character.id + '_is_protagonist'} type="checkbox" checked={character.isHero} value={character.isHero} onChange={(e) => updateCharacterIsHero(character.id, e.currentTarget.checked)} />
                    </div>

                    <div className='row mt-3'>
                        <div className='col-12'>
                            <p><span className='fw-bold'>{characterArchetypeCapitalized}</span> {character.name} has a personality of <span className='fw-bold'>{personalitySummary}.</span></p>
                        </div>
                    </div>

                    <div className='row'>
                        <div className='col-md-12'>
                            <label htmlFor={character.id + '_desc'} className="form-label">Character notes (optional)</label>
                            <LimitedTextArea
                                id={character.id + '_desc'}
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