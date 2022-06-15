import React, { useState } from 'react'
import { FaCopy } from 'react-icons/fa'


const CopyCompletionToText = (
    {
        idx,
        onCopyBrainstorm
    }
) => {
    const [showConfirm, setShowConfirm] = useState(false);

    const onSelect = () => {
        setShowConfirm(true)
    }

    return (
        <span className='ms-3 card-link'>
            {
                showConfirm === false &&
                <FaCopy title='will prompt to confirm' onClick={onSelect} />
            }
            {
                showConfirm === true &&
                <span>
                    <span title="WARNING: replaces existing text" className="btn btn-link" onClick={() => onCopyBrainstorm(idx)}>copy to textarea</span>
                    /
                    <span className="btn btn-link" onClick={() => setShowConfirm(false)}>cancel</span>
                </span>
            }

        </span>
    )
}

export default CopyCompletionToText