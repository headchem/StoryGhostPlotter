import React from 'react'

const LimitedTextArea = ({ id, rows, cols, value, limit, curTokenCount, className, setValue, showCount, onFocus }) => {

    const setTruncatedContent = React.useCallback(
        text => {
            const truncatedVal = text.slice(0, limit)
            setValue(truncatedVal)
        },
        [limit, setValue]
    )

    const txtValue = !value ? '' : value

    return (
        <>
            <textarea
                id={id}
                className={className}
                rows={rows}
                cols={cols}
                onChange={e => setTruncatedContent(e.target.value)}
                value={value}
                onFocus={onFocus}
            />
            {
                showCount === true &&
                <p className="char-count" title="seek brevity, this is a technical maximum">
                    {txtValue.length}/{limit} ({curTokenCount} tokens)
                </p>
            }

        </>
    )
}

export default LimitedTextArea