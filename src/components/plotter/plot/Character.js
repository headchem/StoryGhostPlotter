import React, { useEffect, useState } from 'react'
//import Popover from 'react-bootstrap/Popover';
import Accordion from 'react-bootstrap/Accordion';
//import OverlayTrigger from 'react-bootstrap/OverlayTrigger'
//import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Nav from 'react-bootstrap/Nav'
//import { useSearchParams } from "react-router-dom";
import ArchetypeDescription from './ArchetypeDescription'
import CharacterAnalysis from './CharacterAnalysis'
import Personality from './Personality'
import CharacterBrainstorm from './CharacterBrainstorm'
import { FaMinusCircle, FaTrash } from 'react-icons/fa'
import LimitedTextArea from './LimitedTextArea'
import { getTokenCount } from "../../../util/Tokenizer";

const Character = ({
    userInfo,
    plotId,
    onFocusChange,

    archetypeOptions,


    character,
    characters,

    updateCharacterName,
    updateCharacterIsHero,
    updateCharacterArchetype,
    updateCharacterDescription,
    updateAICharacterCompletion,
    deleteCharacter,
    updateCharacterPersonality,
    tokensRemaining
}) => {

    const [descriptionTokenCount, setDescriptionTokenCount] = useState(0)

    const [showConfirmDelete, setShowConfirmDelete] = useState(false)

    const onDeleteCharacter = () => {
        deleteCharacter(character.id)
    }

    const updateTokenCount = async () => {
        //console.log('updating token count for character: ' + character.name)
        const tokenCount = await getTokenCount(character.description)
        setDescriptionTokenCount(tokenCount)
    }

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        //console.log('character changed for: ' + character.name)
        const timeout = setTimeout(() => {
            updateTokenCount()
        }, 2000) //2000 - timeout to execute this function if timeout will be not cleared

        return () => clearTimeout(timeout) //clear timeout (delete function execution)
        
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
            'a closeminded fuddy duddy', 'generally closeminded', 'closeminded and mentally resistant',
            'moderate',
            'imaginative and artsy', 'generally imaginative', 'an imaginative brainstormer');

        let disciplined_to_spontaneous_desc = getOneWordDesc(neutral_point, disciplined_to_spontaneous, disciplined_to_spontaneous_aspect,
            'disciplined and industrious', 'generally disciplined', 'disciplined and orderly',
            'dynamic',
            'spontaneous with their head in the clouds', 'generally spontaneous', 'spontaneous and sloppy');

        let introvert_to_extrovert_desc = getOneWordDesc(neutral_point, introvert_to_extrovert, introvert_to_extrovert_aspect,
            'introverted and glum', 'generally introverted', 'introverted and submissive',
            'ambivert',
            'extroverted and gung-ho', 'generally extroverted', 'extroverted and bossy');

        let cold_to_empathetic_desc = getOneWordDesc(neutral_point, cold_to_empathetic, cold_to_empathetic_aspect,
            'cold and unfeeling', 'generally cold', 'cold and rude',
            'negotiator',
            'empathetic and compassionate', 'generally empathetic', 'empathetic and polite');

        let unflappable_to_anxious_desc = getOneWordDesc(neutral_point, unflappable_to_anxious, unflappable_to_anxious_aspect,
            'unflappable and emotionally impervious', 'generally unflappable', 'unflappable and relaxed',
            'responsive to stress',
            'anxious and volatile', 'generally anxious', 'anxious and vulnerable');

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

    const personalitySummary = personalityStrs.slice(0, 5).join(', ')

    const characterArchetypeCapitalized = !character.archetype ? 'Archetype not set' : character.archetype[0].toUpperCase() + character.archetype.slice(1)

    return (
        <>
            <div className='row border-top mt-3 pt-3' onClick={onFocusChange}>

                <div className='col-md-7'>
                    <div className='row pb-3'>
                        <div className='col-md-5'>
                            <input type='text' className='fs-5 form-control' placeholder='Character Name' required onChange={onCharacterNameChange} defaultValue={character.name} />

                        </div>
                        <div className='col-md-3'>
                            <select required className='fs-5 form-select form-inline' value={!character.archetype ? '' : character.archetype} onChange={onArchetypeChange} onFocus={() => onFocusChange('archetype')}>
                                <option key="blank" value="" disabled>Archetype</option>
                                {
                                    archetypeOptions.map(function (o) {
                                        return <option key={o.value} value={o.value}>{o.label}</option>
                                    })
                                }
                            </select>
                        </div>
                        <div className='col-md-3 pt-2 fs-5'>
                            <div className='form-check' title="you may only designate one character as the protagonist">
                                <input className='form-check-input' id={character.id + '_is_protagonist'} type="checkbox" checked={character.isHero} value={character.isHero} onChange={(e) => updateCharacterIsHero(character.id, e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={character.id + '_is_protagonist'}>Is Protagonist?</label>
                            </div>
                        </div>
                        <div className='col-md-1'>
                            {
                                character.id !== characters[0].id &&
                                <>
                                    {
                                        showConfirmDelete === false &&
                                        <>
                                            <button onClick={() => setShowConfirmDelete(true)} className='btn btn-outline-danger float-end btn-no-border' title='Delete this character. You will wil br prompted to confirm'><FaMinusCircle /></button>
                                        </>
                                    }
                                    {
                                        showConfirmDelete === true &&
                                        <>
                                            <button className='btn btn-link p-0' onClick={() => setShowConfirmDelete(false)}>cancel</button>
                                            <button onClick={onDeleteCharacter} className="btn btn-danger"><FaTrash /></button>
                                        </>
                                    }
                                </>
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

                    <div className='row mt-3'>
                        <div className='col-12'>
                            <p>{characterArchetypeCapitalized}-type {character.name} is {personalitySummary}.</p>
                        </div>
                    </div>

                    <div className='row'>
                        <div className='col-md-12'>
                            <label htmlFor={character.id + '_desc'} className="form-label" title="1-3 sentences of backstory context that explains and exemplifies their personality.">Character notes</label>
                            <LimitedTextArea
                                id={character.id + '_desc'}
                                className="form-control"
                                value={character.description}
                                setValue={(newValue) => updateCharacterDescription(character.id, newValue)}
                                rows={5}
                                limit={400}
                                curTokenCount={descriptionTokenCount}
                                showCount={true}
                            />
                        </div>


                    </div>
                </div>
                <div className='col-md-5'>
                    {
                        <>
                            <Accordion defaultActiveKey={['0', '1']} alwaysOpen>
                                <Accordion.Item eventKey="0">
                                    <Accordion.Header>Character Analysis</Accordion.Header>
                                    <Accordion.Body>
                                        {
                                            <div className='row'>
                                                <CharacterAnalysis
                                                    character={character}
                                                    characters={characters}
                                                />
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
                                <Accordion.Item eventKey="2">
                                    <Accordion.Header>Brainstorm with AI</Accordion.Header>
                                    <Accordion.Body>
                                        <CharacterBrainstorm
                                            userInfo={userInfo}
                                            plotId={plotId}
                                            character={character}
                                            updateAICharacterCompletion={updateAICharacterCompletion}
                                            tokensRemaining={tokensRemaining}
                                        />
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