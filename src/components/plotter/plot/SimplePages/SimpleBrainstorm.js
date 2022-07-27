import React, { useState } from 'react'
import { FaEdit, FaCheck } from 'react-icons/fa'
import LimitedTextArea from '../LimitedTextArea'
import { blurbLimits, expandedSummaryLimits } from '../../../../util/SequenceTextCheck';

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

    const limitObj = completionPropName === 'blurb' ? blurbLimits : expandedSummaryLimits

    const rows = limitObj[sequenceName]['rows']
    const charLimit = limitObj[sequenceName]['max']

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
                        rows={rows}
                        limit={charLimit}
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