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
                        <span className='d-block p-1'><span className='text-muted'>Definition:</span> {emotion.description}</span>
                        <span className='d-block p-1'><span className='text-muted'>Synonyms:</span> {emotion.synonyms.join(', ')}</span>
                        <span className='d-block p-1'><span className='text-muted'>Types:</span> {emotion.kinds.join(', ')}</span>
                    </span>
                }
            </span>
        </>
    )
}

export default EmotionFinderSingle