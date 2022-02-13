import React, { useState } from 'react'
import { FaTrash } from 'react-icons/fa'

const DeletePlot = ({ plotId, plotTitle, loadAllPlots }) => {

    const [showConfirm, setShowConfirm] = useState(false)
    const [confirmTitle, setConfirmTitle] = useState('')
    const [isDeleting, setIsDeleting] = useState(false)

    const onShowConfirm = async () => {
        setShowConfirm(true)
    }

    const onConfirmTitleChange = (event) => {
        setConfirmTitle(event.target.value)
    }

    const onDelete = () => {
        setShowConfirm(false)
        setIsDeleting(true)

        fetch('/api/DeletePlot?id=' + plotId, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .catch(error => {
                console.error(error)
            }).finally(function () {
                setIsDeleting(false)
                loadAllPlots();
            });

    }

    return (
        <div>
            {
                showConfirm === false && isDeleting === false &&
                <button onClick={onShowConfirm} className="btn btn-danger" title='you will be prompted to confirm'>
                    <FaTrash />
                </button>
            }
            {
                showConfirm === true && isDeleting === false &&
                <button className='btn btn-link' onClick={() => setShowConfirm(false)}>cancel delete</button>
            }
            {
                showConfirm === true &&
                <>
                    <p>Confirm by typing the plot title:</p>
                    <input type='text' className='fs-5 form-control' placeholder='Plot Title' required onChange={onConfirmTitleChange} />
                </>
            }
            {
                confirmTitle === plotTitle && showConfirm === true &&
                <>
                    {
                        isDeleting === false &&
                        <>
                            <button onClick={onDelete} className="btn btn-primary">Delete Plot</button>
                            <p>This will delete the plot titled: {plotTitle}</p>
                        </>
                    }
                </>
            }
            {
                isDeleting === true &&
                <>
                    <p>deleting...</p>
                </>
            }
        </div>
    )
}

export default DeletePlot
