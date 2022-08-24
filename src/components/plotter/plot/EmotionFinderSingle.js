import React, { useState } from 'react'

const EmotionFinderSingle = ({
    emotion,
    isInCommon
}) => {

    const [showDetails, setShowDetails] = useState(false)

    const emoNameEl = isInCommon === true ? <strong>{emotion.name}</strong> : <span>{emotion.name}</span>
    const emoNameElLink = <button className='btn btn-link' onClick={() => setShowDetails(!showDetails)}>{emoNameEl}</button>

    return (
        <>
            <span>{emoNameElLink}
                {
                    showDetails === true &&
                    <span className='ps-2'>
                        <span className='d-block'>{emotion.kinds}</span>
                        <span className='d-block'>{emotion.description}</span>
                    </span>
                }
            </span>
        </>
    )
}

export default EmotionFinderSingle