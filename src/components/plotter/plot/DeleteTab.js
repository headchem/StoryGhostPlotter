import React, { useState, useEffect } from 'react'
import { FaTrash } from 'react-icons/fa'
import Spinner from 'react-bootstrap/Spinner';


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
                    <button className="btn btn-link" onClick={() => onDeleteBrainstorm(idx)}>delete</button>
                    /
                    <button className="btn btn-link" onClick={() => setShowConfirm(false)}>cancel</button>
                </span>
            }

        </span>
    )
}

export default DeleteTab