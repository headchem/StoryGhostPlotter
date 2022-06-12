import React, { useState } from 'react'
import Accordion from 'react-bootstrap/Accordion';
import Tab from 'react-bootstrap/Tab'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import Nav from 'react-bootstrap/Nav'
import ArchetypeDescription from './ArchetypeDescription'
import CharacterAnalysis from './CharacterAnalysis'
import Personality from './Personality'
import CharacterBrainstorm from './Brainstorm/CharacterBrainstorm'
import { FaMinusCircle, FaTrash } from 'react-icons/fa'
import LimitedTextArea from './LimitedTextArea'
import { getPersonalitySummary } from '../../../util/PersonalityDescriptions'

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

    const [showConfirmDelete, setShowConfirmDelete] = useState(false)

    const onDeleteCharacter = () => {
        deleteCharacter(character.id)
    }

    const onCharacterNameChange = (event) => {
        updateCharacterName(character.id, event.target.value)
    }

    const onArchetypeChange = (event) => {
        updateCharacterArchetype(character.id, event.target.value)
    }

    const personalitySummary = getPersonalitySummary(character['personality'])

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
                                //curTokenCount={descriptionTokenCount}
                                showCount={true}
                            />
                        </div>


                    </div>
                </div>
                <div className='col-md-5'>
                    {
                        <>
                            <Accordion defaultActiveKey={['0', '2']} alwaysOpen>
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
                                            updateCharacterDescription={updateCharacterDescription}
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