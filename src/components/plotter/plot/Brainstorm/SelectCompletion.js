import React, { useState } from 'react'
import { FaCopy } from 'react-icons/fa'


const SelectCompletion = (
    {
        idx,
        onSelectBrainstorm
    }
) => {
    const [showConfirm, setShowConfirm] = useState(false);

    const onSelect = () => {
        setShowConfirm(true)
    }

    return (
        <span className='ms-3'>
            {
                showConfirm === false &&
                <FaCopy title='will prompt to confirm' onClick={onSelect} />
            }
            {
                showConfirm === true &&
                <span>
                    <span className="btn btn-link" onClick={() => onSelectBrainstorm(idx)}>copy to textarea</span>
                    /
                    <span className="btn btn-link" onClick={() => setShowConfirm(false)}>cancel</span>
                </span>
            }

        </span>
    )
}

export default SelectCompletion