import React from 'react'
import { FaExclamationTriangle } from 'react-icons/fa'

const ToxicMessage = () => {

    return (
        <div className="alert alert-danger" role="alert">
            <FaExclamationTriangle />
            <p>The AI categorized this text as unsafe. This means that the text may contain profane language, prejudiced or hateful language, something that could be NSFW, or text that portrays certain groups/people in a harmful manner.</p>
        </div >
    )
}

export default ToxicMessage