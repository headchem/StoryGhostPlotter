import React, { useState } from 'react'
import { FaEdit, FaCheck } from 'react-icons/fa'
import LimitedTextArea from '../LimitedTextArea'

const SimpleBrainstorm = (
    {
        userInfo,
        brainstorm,
        editCompletion,
        sequences,
        sequenceName,
        completionPropName,

    }
) => {

    const [showEditCompletion, setShowEditCompletion] = useState(false)

    const textClass = brainstorm['isSelected'] === true ? 'fw-bold' : 'text-muted'

    return (
        <>
            {
                showEditCompletion === true &&
                <>
                    <LimitedTextArea
                        id={brainstorm['id'] + completionPropName + '_completion'}
                        className="form-control"
                        value={brainstorm['completion']}
                        setValue={(newValue) => editCompletion(brainstorm['id'], sequences, sequenceName, completionPropName, newValue)}
                        rows={5}
                        limit={1900}
                        showCount={true}
                    />

                    <button className='btn btn-outline-secondary float-end mt-3' onClick={() => setShowEditCompletion(false)}>
                        <FaCheck />
                    </button>
                </>
            }
            {
                showEditCompletion === false &&
                <>
                    <button className='btn btn-outline-secondary float-end m-1' onClick={() => setShowEditCompletion(true)}>
                        <FaEdit />
                    </button>
                    <p className={textClass}>{brainstorm['completion']}</p>
                </>
            }
        </>
    )
}

export default SimpleBrainstorm