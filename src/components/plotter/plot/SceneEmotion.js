import React from 'react'


const SceneEmotion = ({
    sequence,
    scene,
    emotion,
    updateScene,
    startOrEnd
}) => {

    const getPropName = () => {
        return startOrEnd + 'Emotion'
    }

    const onEmotionChange = (event) => {
        const newEmotion = { 'emotion': event.target.value, 'intensity': emotion['intensity'] }
        updateScene(sequence.sequenceName, scene.id, getPropName(), newEmotion)
    }

    const onIntensityChange = (event) => {
        const newEmotion = { 'emotion': emotion['emotion'], 'intensity': event.target.value }
        updateScene(sequence.sequenceName, scene.id, getPropName(), newEmotion)
    }

    const emotionList = [
        { 'intense': 'ecstacy', 'moderate': 'joy', 'mild': 'serenity' },
        { 'intense': 'love', 'moderate': 'caring', 'mild': 'peaceful' },
        { 'intense': 'admiration', 'moderate': 'trust', 'mild': 'acceptance' },
        { 'intense': 'submission', 'moderate': 'deference', 'mild': 'docile' },
        { 'intense': 'terror', 'moderate': 'fear', 'mild': 'apprehension' },
        { 'intense': 'awe', 'moderate': 'inspiration', 'mild': 'impressed' },
        { 'intense': 'amazement', 'moderate': 'surprise', 'mild': 'distraction' },
        { 'intense': 'disapproval', 'moderate': 'criticism', 'mild': 'dislike' },
        { 'intense': 'grief', 'moderate': 'sadness', 'mild': 'pensiveness' },
        { 'intense': 'remorse', 'moderate': 'guilt', 'mild': 'regret' },
        { 'intense': 'loathing', 'moderate': 'disgust', 'mild': 'boredom' },
        { 'intense': 'contempt', 'moderate': 'condescension', 'mild': 'distaste' },
        { 'intense': 'rage', 'moderate': 'anger', 'mild': 'annoyance' },
        { 'intense': 'aggressiveness', 'moderate': 'demanding', 'mild': 'pushy' },
        { 'intense': 'vigilance', 'moderate': 'anticipation', 'mild': 'interest' },
        { 'intense': 'optimism', 'moderate': 'hope', 'mild': 'easiness' },

    ]

    const intensityList = [
        { 'value': 'mild', 'label': 'mild(ly)' },
        { 'value': 'moderate', 'label': 'moderate(ly)' },
        { 'value': 'intense', 'label': 'intense' },
    ]

    return (
        <div className='row pb-3'>
            <p>{startOrEnd}</p>
            <div className='col-md-6'>
                <select required className='fs-5 form-select form-inline' value={!emotion['intensity'] ? 'intense' : emotion['intensity']} onChange={onIntensityChange}>
                    {
                        intensityList.map(function (o) {
                            return <option key={o.value} value={o.value}>{o.label}</option>
                        })
                    }
                </select>
            </div>
            <div className='col-md-6'>
                <select required className='fs-5 form-select form-inline' value={!emotion['emotion'] ? '' : emotion['emotion']} onChange={onEmotionChange}>
                    {
                        emotionList.map(function (o) {
                            return <option key={o['intense']} value={o['intense']}>{!emotion['intensity'] ? 'intense' : o[emotion['intensity']]}</option>
                        })
                    }
                </select>
            </div>
        </div>
    )
}

export default SceneEmotion