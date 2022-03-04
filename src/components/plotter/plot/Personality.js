import React from 'react'
import { FaArrowsAltH, FaArrowsAltV, FaCircle, FaRegCircle } from 'react-icons/fa'


const Personality = ({
    userInfo,
    personalityKey,
    primaryLeft,
    primaryRight,
    primaryLeftAspectTop,
    primaryLeftAspectBottom,
    primaryRightAspectTop,
    primaryRightAspectBottom,
    character,
    onChange
}) => {

    const descriptions = {
        'closemindedToImaginative': {
            'primary': {
                'left': {
                    'name': 'closeminded',
                    'description': 'Preserver, Conservative, Practical, Prefers not to be exposed to alternative moral systems, narrow interests, inartistic, does not question "why?", accepts status quo, down-to-earth'
                },
                'right': {
                    'name': 'imaginative',
                    'description': 'Explorer, Curious, Visionary, Enjoys seeing unfamiliar things/strange people, curious, imaginative, untraditional'
                }
            },
            'leftAspect': {
                'top': {
                    'name': 'a fuddy-duddy',
                    'description': 'Lack of Artistry, Disdain, Dislikes poetry, Seldom lost in thought, Seldom daydream, Art is pointless'
                },
                'bottom': {
                    'name': 'idea averse',
                    'description': 'Mentally resistant to new ideas, Ignorance, Difficulty understanding abstract ideas, Avoids philosophical discussions, Avoid challenging reading material, Slow learner'
                }
            },
            'rightAspect': {
                'top': {
                    'name': 'artsy',
                    'description': 'Openess, Artistry, Reflection, Enjoy beauty in nature, Deepy moved by music, Notices beauty in unexpected places, Needs creative outlet'
                },
                'bottom': {
                    'name': 'a brainstormer',
                    'description': 'Intellect, Ingenuity, Quick to understand things, Can handle a lot of information, Solves complex problems, Has rich vocabulary, Thinks quickly, Formulates clear ideas'
                }
            }
        },
        'disciplinedToSpontaneous': {
            'primary': {
                'left': {
                    'name': 'disciplined',
                    'description': 'Focused, Organized, Ambitious, Hardworking, Neat, Persevering, Punctual, Self-disciplined'
                },
                'right': {
                    'name': 'spontaneous',
                    'description': 'Flexible, Spontaneous, Multi-tasker, Spur-of-the-moment action, Unreliable, Hedonistic, Careless, Lax'
                }
            },
            'leftAspect': {
                'top': {
                    'name': 'industrious',
                    'description': 'Industrious, Tries hard, Carry out plans, Work quickly, Finish what they start'
                },
                'bottom': {
                    'name': 'orderly',
                    'description': 'Orderly, Neat, Perfectionism, Punctuality, Polices others'
                }
            },
            'rightAspect': {
                'top': {
                    'name': 'head in the clouds',
                    'description': 'Unfocused, screws things up, Wastes time, Unmotivated, Mind wanders, Postpones decisions'
                },
                'bottom': {
                    'name': 'sloppy',
                    'description': 'Messy, Not bothered by disorder, Imprecise, Late, Dislikes routine'
                }
            }
        },
        'introvertToExtrovert': {
            'primary': {
                'left': {
                    'name': 'introvert',
                    'description': 'Introvert, Private, Reserved, Sober, Aloof, Unenthusiastic'
                },
                'right': {
                    'name': 'extrovert',
                    'description': 'Extrovert, Social, Enthusiastic, Partier, Optimistic, Fun-loving, Affectionate'
                }
            },
            'leftAspect': {
                'top': {
                    'name': 'glum',
                    'description': 'Apathetic, Glum, Loner, Hard to get to know, Keep others at a distance, Reveal little about self, Not caught up in excitement'
                },
                'bottom': {
                    'name': 'submissive',
                    'description': 'Passive, Submissive, Follower, Holds back opinions, Can\'t influence others, Unconvincing'
                }
            },
            'rightAspect': {
                'top': {
                    'name': 'gung-ho',
                    'description': 'Enthusiasm, Makes friends, Sociability, Warms up to others, Laughs a lot'
                },
                'bottom': {
                    'name': 'bossy',
                    'description': 'Assertiveness, Dominance, Leadership, Takes charge, Coerces others, Captivates and convinces others, Thinks highly of own leadership'
                }
            }
        },
        'coldToEmpathetic': {
            'primary': {
                'left': {
                    'name': 'cold',
                    'description': 'Challenger, Competitive, Fighter, Asserts own rights, Irritable, Manipulative, Uncooperative, Rude'
                },
                'right': {
                    'name': 'empathetic',
                    'description': 'Adapter, Team player, Helper, Agreeable, Good-natured, Forgiving, Gullible'
                }
            },
            'leftAspect': {
                'top': {
                    'name': 'unfeeling',
                    'description': 'Disinterest in others problems, Unfeeling, No time for others, Does not have a soft side'
                },
                'bottom': {
                    'name': 'rude',
                    'description': 'Rude, Rebellious, Selfish, Feel superior to others, Likes a good fight, Take advantage of others'
                }
            },
            'rightAspect': {
                'top': {
                    'name': 'compassionate',
                    'description': 'Compassion, Empathy, Concern about others well-being, Sympathy, Do things for others'
                },
                'bottom': {
                    'name': 'polite',
                    'description': 'Polite, Respect authority, Avoid being pushy, Rarely pressure others'
                }
            }
        },
        'unflappableToAnxious': {
            'primary': {
                'left': {
                    'name': 'unflappable',
                    'description': 'Resilient, Controlled, Stress-free, Calm, Unemotional, Hardy, Secure, Self-satisfied'
                },
                'right': {
                    'name': 'anxious',
                    'description': 'Reactive, Tense, Anxious, Alert, Worrying, Insecure, Hypochondriacal, Feels inadequate'
                }
            },
            'leftAspect': {
                'top': {
                    'name': 'impervious',
                    'description': 'Emotionally stable, Impervious, Maintain composure, Not easily annoyed'
                },
                'bottom': {
                    'name': 'relaxed',
                    'description': 'Attentive to current moment, Relaxed, self-assured, Unsuseptible, self-secure, Not easily embarrassed'
                }
            },
            'rightAspect': {
                'top': {
                    'name': 'volatile',
                    'description': 'Volatile, Irritable, Angry, Agitated, Frequent mood swings'
                },
                'bottom': {
                    'name': 'vulnerable',
                    'description': 'Withdrawn, Anxious, Depressed, Vulnerable, Frequent doubts, Feel threatened easily, Easily discouraged, overwhelmed by events, Afraid of everything'
                }
            }
        }
    }

    const getDescs = () => {

        if (!character['personality']) {
            return {
                'primaryName': '',
                'primaryDesc': '',
                'primaryAmt': '',
                'aspectName': '',
                'aspectDesc': '',
                'aspectAmt': ''
            }
        }

        const curPersonalityType = character['personality'][personalityKey]
        const curPersonalityTypeDescObj = descriptions[personalityKey]

        let primaryName = ''
        let primaryDesc = ''
        let aspectName = ''
        let aspectDesc = ''

        const primaryVal = curPersonalityType['primary']
        const aspectVal = curPersonalityType['aspect']

        if (primaryVal <= 0.2) {
            primaryName = curPersonalityTypeDescObj['primary']['left']['name']
            primaryDesc = curPersonalityTypeDescObj['primary']['left']['description'];

            if (aspectVal <= 0.2) {
                aspectName = curPersonalityTypeDescObj['leftAspect']['top']['name']
                aspectDesc = curPersonalityTypeDescObj['leftAspect']['top']['description']
            } else if (aspectVal >= 0.2) {
                aspectName = curPersonalityTypeDescObj['leftAspect']['bottom']['name']
                aspectDesc = curPersonalityTypeDescObj['leftAspect']['bottom']['description']
            }
        } else if (primaryVal >= 0.2) {
            primaryName = curPersonalityTypeDescObj['primary']['right']['name']
            primaryDesc = curPersonalityTypeDescObj['primary']['right']['description']

            if (aspectVal <= 0.2) {
                aspectName = curPersonalityTypeDescObj['rightAspect']['top']['name']
                aspectDesc = curPersonalityTypeDescObj['rightAspect']['top']['description']
            } else if (aspectVal >= 0.2) {
                aspectName = curPersonalityTypeDescObj['rightAspect']['bottom']['name']
                aspectDesc = curPersonalityTypeDescObj['rightAspect']['bottom']['description']
            }
        }

        const primaryAmountStr = Math.abs(primaryVal) >= 0.66 ? 'extreme' : (Math.abs(primaryVal) >= 0.33 ? 'moderate' : 'neutral')
        const aspectAmountStr = Math.abs(aspectVal) >= 0.66 ? 'extreme' : (Math.abs(aspectVal) >= 0.33 ? 'moderate' : 'neutral')

        return {
            'primaryName': primaryName,
            'primaryDesc': primaryDesc,
            'primaryAmt': primaryAmountStr,
            'aspectName': aspectName,
            'aspectDesc': aspectDesc,
            'aspectAmt': aspectAmountStr
        }
    }

    const curDescs = getDescs()

    const primaryName = curDescs['primaryName']
    const primaryDesc = curDescs['primaryDesc']
    const primaryAmountStr = curDescs['primaryAmt']
    const aspectName = curDescs['aspectName']
    const aspectDesc = curDescs['aspectDesc']
    const aspectAmountStr = curDescs['aspectAmt']

    const onSetPersonality = (primary, aspect) => {
        onChange(character.id, personalityKey, primary, aspect)
    }

    let primaryVal = 0.0
    let aspectVal = 0.0

    if (character['personality'] && character['personality'][personalityKey]) {
        primaryVal = character['personality'][personalityKey]['primary']
        aspectVal = character['personality'][personalityKey]['aspect']
    }

    const baseBtnClass = 'btn btn-circle btn-lg'
    const btnActiveClass = ' btn-primary'
    const btnInactiveClass = ' btn-outline-secondary'

    const btnActiveEl = <FaCircle />
    const btnInactiveEl = <FaRegCircle />

    const characterName = character.name === '' ? 'Character name not set' : character.name

    return (
        <>
            <div className='row'>
                <div className='col-12 text-center'>
                    <h5>{primaryLeft} <FaArrowsAltH /> {primaryRight}</h5>
                </div>
            </div>
            <div className='row'>
                <div className='col-1 vertical-col'>
                    <div className='row h-100'>
                        <p className='my-auto vertical-text'>{primaryLeftAspectTop} <FaArrowsAltV /> {primaryLeftAspectBottom}</p>
                    </div>
                </div>
                <div className='col-10 my-auto button-grid'>
                    <div className='row text-center'>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-1.0, -1.0)} className={baseBtnClass + (primaryVal === -1.0 && aspectVal === -1.0 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['left']['name'] + ' (extreme) + ' + descriptions[personalityKey]['leftAspect']['top']['name'] + ' (extreme)'}>
                                {
                                    primaryVal === -1.0 && aspectVal === -1.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-60'></div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(1.0, -1.0)} className={baseBtnClass + (primaryVal === 1.0 && aspectVal === -1.0 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['right']['name'] + ' (extreme) + ' + descriptions[personalityKey]['rightAspect']['top']['name'] + ' (extreme)'}>
                                {
                                    primaryVal === 1.0 && aspectVal === -1.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                    </div>
                    <div className='row text-center'>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-1.0, -0.5)} className={baseBtnClass + (primaryVal === -1.0 && aspectVal === -0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['left']['name'] + ' (extreme) + ' + descriptions[personalityKey]['leftAspect']['top']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === -1.0 && aspectVal === -0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-0.5, -0.5)} className={baseBtnClass + (primaryVal === -0.5 && aspectVal === -0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['left']['name'] + ' (moderate) + ' + descriptions[personalityKey]['leftAspect']['top']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === -0.5 && aspectVal === -0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'></div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(0.5, -0.5)} className={baseBtnClass + (primaryVal === 0.5 && aspectVal === -0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['right']['name'] + ' (moderate) + ' + descriptions[personalityKey]['rightAspect']['top']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === 0.5 && aspectVal === -0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(1.0, -0.5)} className={baseBtnClass + (primaryVal === 1.0 && aspectVal === -0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['right']['name'] + ' (extreme) + ' + descriptions[personalityKey]['rightAspect']['top']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === 1.0 && aspectVal === -0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                    </div>
                    <div className='row text-center'>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-1.0, 0.0)} className={baseBtnClass + (primaryVal === -1.0 && aspectVal === 0.0 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['left']['name'] + ' (extreme)'}>
                                {
                                    primaryVal === -1.0 && aspectVal === 0.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-0.5, 0.0)} className={baseBtnClass + (primaryVal === -0.5 && aspectVal === 0.0 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['left']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === -0.5 && aspectVal === 0.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(0.0, 0.0)} className={baseBtnClass + (primaryVal === 0.0 && aspectVal === 0.0 ? btnActiveClass : btnInactiveClass)} title={'neutral'}>
                                {
                                    primaryVal === 0.0 && aspectVal === 0.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(0.5, 0.0)} className={baseBtnClass + (primaryVal === 0.5 && aspectVal === 0.0 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['right']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === 0.5 && aspectVal === 0.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(1.0, 0.0)} className={baseBtnClass + (primaryVal === 1.0 && aspectVal === 0.0 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['right']['name'] + ' (extreme)'}>
                                {
                                    primaryVal === 1.0 && aspectVal === 0.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                    </div>
                    <div className='row text-center'>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-1.0, 0.5)} className={baseBtnClass + (primaryVal === -1.0 && aspectVal === 0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['left']['name'] + ' (extreme) + ' + descriptions[personalityKey]['leftAspect']['bottom']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === -1.0 && aspectVal === 0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-0.5, 0.5)} className={baseBtnClass + (primaryVal === -0.5 && aspectVal === 0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['left']['name'] + ' (moderate) + ' + descriptions[personalityKey]['leftAspect']['bottom']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === -0.5 && aspectVal === 0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'></div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(0.5, 0.5)} className={baseBtnClass + (primaryVal === 0.5 && aspectVal === 0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['right']['name'] + ' (moderate) + ' + descriptions[personalityKey]['rightAspect']['bottom']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === 0.5 && aspectVal === 0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(1.0, 0.5)} className={baseBtnClass + (primaryVal === 1.0 && aspectVal === 0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['right']['name'] + ' (extreme) + ' + descriptions[personalityKey]['rightAspect']['bottom']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === 1.0 && aspectVal === 0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                    </div>
                    <div className='row text-center'>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-1.0, 1.0)} className={baseBtnClass + (primaryVal === -1.0 && aspectVal === 1.0 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['left']['name'] + ' (extreme) + ' + descriptions[personalityKey]['leftAspect']['bottom']['name'] + ' (extreme)'}>
                                {
                                    primaryVal === -1.0 && aspectVal === 1.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-60'></div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(1.0, 1.0)} className={baseBtnClass + (primaryVal === 1.0 && aspectVal === 1.0 ? btnActiveClass : btnInactiveClass)} title={descriptions[personalityKey]['primary']['right']['name'] + ' (extreme) + ' + descriptions[personalityKey]['rightAspect']['bottom']['name'] + ' (extreme)'}>
                                {
                                    primaryVal === 1.0 && aspectVal === 1.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                    </div>
                </div>

                <div className='col-1 vertical-col'>
                    <div className='row h-100'>
                        <p className='my-auto vertical-text'>{primaryRightAspectTop} <FaArrowsAltV /> {primaryRightAspectBottom}</p>
                    </div>
                </div>

            </div>
            <div className='row'>
                {
                    primaryAmountStr !== 'neutral' && primaryName !== '' &&
                    <p><span className='fw-bold'>{characterName} is {primaryName} ({primaryAmountStr}).</span> For example: {primaryDesc}</p>
                }
                {
                    aspectAmountStr !== 'neutral' && aspectName !== '' &&
                    <p><span className='fw-bold'>{characterName} is {aspectName} ({aspectAmountStr}).</span> For example: {aspectDesc}</p>
                }
                {
                    primaryAmountStr === 'neutral' && aspectAmountStr === 'neutral' &&
                    <p>{characterName} is balanced between {descriptions[personalityKey]['primary']['left']['name']} and {descriptions[personalityKey]['primary']['right']['name']}</p>
                }

            </div>

            {/* <div className='row'>
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
            </div> */}
        </>
    )
}

export default Personality