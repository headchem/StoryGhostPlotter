import React from 'react'

const LimitedTextArea = ({ rows, cols, value, limit, className, setValue }) => {

    const setTruncatedContent = React.useCallback(
        text => {
            const truncatedVal = text.slice(0, limit)
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