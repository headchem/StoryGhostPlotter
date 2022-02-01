import React, { useState } from 'react'

const LimitedTextArea = ({ rows, cols, value, limit, className, setValue }) => {
    //const [content, setContent] = React.useState(value.slice(0, limit));

    const setTruncatedContent = React.useCallback(
        text => {
            const truncatedVal = text.slice(0, limit)
            //setContent(truncatedVal)
            setValue(truncatedVal)
        },
        [limit, setValue]
    )

    return (
        <>
            <textarea
                className={className}
                rows={rows}
                cols={cols}
                onChange={e => setTruncatedContent(e.target.value)}
                value={value}
            />
            <p>
                {value.length}/{limit}
            </p>
        </>
    )
}

export default LimitedTextArea