import React from 'react'
import { FaArrowsAltH, FaArrowsAltV, FaCircle, FaRegCircle } from 'react-icons/fa'
import { getPersonalityDescriptions } from '../../../util/PersonalityDescriptions'

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

    const descriptions = getPersonalityDescriptions(personalityKey)

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
        //const curPersonalityTypeDescObj = descriptions

        let primaryName = ''
        let primaryDesc = ''
        let aspectName = ''
        let aspectDesc = ''

        const primaryVal = curPersonalityType['primary']
        const aspectVal = curPersonalityType['aspect']

        if (primaryVal <= 0.2) {
            primaryName = descriptions['primary']['left']['name']
            primaryDesc = descriptions['primary']['left']['description'];

            if (aspectVal <= 0.2) {
                aspectName = descriptions['leftAspect']['top']['name']
                aspectDesc = descriptions['leftAspect']['top']['description']
            } else if (aspectVal >= 0.2) {
                aspectName = descriptions['leftAspect']['bottom']['name']
                aspectDesc = descriptions['leftAspect']['bottom']['description']
            }
        } else if (primaryVal >= 0.2) {
            primaryName = descriptions['primary']['right']['name']
            primaryDesc = descriptions['primary']['right']['description']

            if (aspectVal <= 0.2) {
                aspectName = descriptions['rightAspect']['top']['name']
                aspectDesc = descriptions['rightAspect']['top']['description']
            } else if (aspectVal >= 0.2) {
                aspectName = descriptions['rightAspect']['bottom']['name']
                aspectDesc = descriptions['rightAspect']['bottom']['description']
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
                            <button type='button' onClick={() => onSetPersonality(-1.0, -1.0)} className={baseBtnClass + (primaryVal === -1.0 && aspectVal === -1.0 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['left']['name'] + ' (extreme) + ' + descriptions['leftAspect']['top']['name'] + ' (extreme)'}>
                                {
                                    primaryVal === -1.0 && aspectVal === -1.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-60'></div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(1.0, -1.0)} className={baseBtnClass + (primaryVal === 1.0 && aspectVal === -1.0 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['right']['name'] + ' (extreme) + ' + descriptions['rightAspect']['top']['name'] + ' (extreme)'}>
                                {
                                    primaryVal === 1.0 && aspectVal === -1.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                    </div>
                    <div className='row text-center'>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-1.0, -0.5)} className={baseBtnClass + (primaryVal === -1.0 && aspectVal === -0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['left']['name'] + ' (extreme) + ' + descriptions['leftAspect']['top']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === -1.0 && aspectVal === -0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-0.5, -0.5)} className={baseBtnClass + (primaryVal === -0.5 && aspectVal === -0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['left']['name'] + ' (moderate) + ' + descriptions['leftAspect']['top']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === -0.5 && aspectVal === -0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'></div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(0.5, -0.5)} className={baseBtnClass + (primaryVal === 0.5 && aspectVal === -0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['right']['name'] + ' (moderate) + ' + descriptions['rightAspect']['top']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === 0.5 && aspectVal === -0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(1.0, -0.5)} className={baseBtnClass + (primaryVal === 1.0 && aspectVal === -0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['right']['name'] + ' (extreme) + ' + descriptions['rightAspect']['top']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === 1.0 && aspectVal === -0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                    </div>
                    <div className='row text-center'>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-1.0, 0.0)} className={baseBtnClass + (primaryVal === -1.0 && aspectVal === 0.0 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['left']['name'] + ' (extreme)'}>
                                {
                                    primaryVal === -1.0 && aspectVal === 0.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-0.5, 0.0)} className={baseBtnClass + (primaryVal === -0.5 && aspectVal === 0.0 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['left']['name'] + ' (moderate)'}>
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
                            <button type='button' onClick={() => onSetPersonality(0.5, 0.0)} className={baseBtnClass + (primaryVal === 0.5 && aspectVal === 0.0 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['right']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === 0.5 && aspectVal === 0.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(1.0, 0.0)} className={baseBtnClass + (primaryVal === 1.0 && aspectVal === 0.0 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['right']['name'] + ' (extreme)'}>
                                {
                                    primaryVal === 1.0 && aspectVal === 0.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                    </div>
                    <div className='row text-center'>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-1.0, 0.5)} className={baseBtnClass + (primaryVal === -1.0 && aspectVal === 0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['left']['name'] + ' (extreme) + ' + descriptions['leftAspect']['bottom']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === -1.0 && aspectVal === 0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-0.5, 0.5)} className={baseBtnClass + (primaryVal === -0.5 && aspectVal === 0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['left']['name'] + ' (moderate) + ' + descriptions['leftAspect']['bottom']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === -0.5 && aspectVal === 0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'></div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(0.5, 0.5)} className={baseBtnClass + (primaryVal === 0.5 && aspectVal === 0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['right']['name'] + ' (moderate) + ' + descriptions['rightAspect']['bottom']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === 0.5 && aspectVal === 0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(1.0, 0.5)} className={baseBtnClass + (primaryVal === 1.0 && aspectVal === 0.5 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['right']['name'] + ' (extreme) + ' + descriptions['rightAspect']['bottom']['name'] + ' (moderate)'}>
                                {
                                    primaryVal === 1.0 && aspectVal === 0.5 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                    </div>
                    <div className='row text-center'>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(-1.0, 1.0)} className={baseBtnClass + (primaryVal === -1.0 && aspectVal === 1.0 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['left']['name'] + ' (extreme) + ' + descriptions['leftAspect']['bottom']['name'] + ' (extreme)'}>
                                {
                                    primaryVal === -1.0 && aspectVal === 1.0 ? btnActiveEl : btnInactiveEl
                                }
                            </button>
                        </div>
                        <div className='personality-w-60'></div>
                        <div className='personality-w-20'>
                            <button type='button' onClick={() => onSetPersonality(1.0, 1.0)} className={baseBtnClass + (primaryVal === 1.0 && aspectVal === 1.0 ? btnActiveClass : btnInactiveClass)} title={descriptions['primary']['right']['name'] + ' (extreme) + ' + descriptions['rightAspect']['bottom']['name'] + ' (extreme)'}>
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
                    <p>{characterName} is balanced between {descriptions['primary']['left']['name']} and {descriptions['primary']['right']['name']}</p>
                }

            </div>
        </>
    )
}

export default Personality