import { FaPlusCircle } from 'react-icons/fa'

const NextSequencesButtonGroup = ({ allowed, onInsertSequence }) => {

    const optionalSequences = ['Theme Stated', 'Setup (Continued)', 'Debate (Continued)', 'B Story', 'First Pinch Point', 'Second Pinch Point']

    return (
        <>
            {
                allowed.length > 0 &&
                <div className="btn-group btn-block" role="group" aria-label="choose next sequence">
                    {
                        allowed.map(function (nextAllowed, idx) {
                            return <button
                                // key={sequence.sequenceName + nextAllowed}
                                key={'nextSeq' + idx}
                                type='button'
                                className={optionalSequences.indexOf(nextAllowed) > -1 ? 'btn btn-outline-secondary' : 'btn btn-outline-primary'}
                                onClick={() => onInsertSequence(nextAllowed)}
                            ><FaPlusCircle /> {nextAllowed}</button>
                        })
                    }
                </div>
            }
        </>

    )
}

export default NextSequencesButtonGroup
