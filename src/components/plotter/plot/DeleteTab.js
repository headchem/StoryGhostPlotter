import React, { useState } from 'react'
import { FaTrash } from 'react-icons/fa'


const DeleteTab = (
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
                    <a className="btn btn-link" onClick={() => onDeleteBrainstorm(idx)}>delete</a>
                    /
                    <a className="btn btn-link" onClick={() => setShowConfirm(false)}>cancel</a>
                </span>
            }

        </span>
    )
}

export default DeleteTab