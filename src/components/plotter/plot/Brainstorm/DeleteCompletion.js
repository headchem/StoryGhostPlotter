import React, { useState } from 'react'
import { FaTrash } from 'react-icons/fa'


const DeleteCompletion = (
    {
        idx,
        onDeleteBrainstorm
    }
) => {
    const [showConfirm, setShowConfirm] = useState(false);

    const onDelete = () => {
        setShowConfirm(true)
    }

    return (
        <span className='ms-3'>
            {
                showConfirm === false &&
                <FaTrash title='will prompt to confirm' onClick={onDelete} />
            }
            {
                showConfirm === true &&
                <span>
                    <span className="btn btn-link" onClick={() => onDeleteBrainstorm(idx)}>delete</span>
                    /
                    <span className="btn btn-link" onClick={() => setShowConfirm(false)}>cancel</span>
                </span>
            }

        </span>
    )
}

export default DeleteCompletion