import React, { useState } from 'react'
import { FaLock, FaLockOpen, FaCaretRight, FaGhost, FaArrowDown, FaArrowUp } from 'react-icons/fa'
import { fetchWithTimeout } from '../../../util/FetchUtil'
import LimitedTextArea from './LimitedTextArea'
//import Select, { components } from 'react-select'

// const Placeholder = (props) => {
//     return <components.Placeholder {...props} />;
// };

const Sequence = ({

    onFocusChange,

    genre,
    problemTemplate,
    keywords,
    heroArchetype,
    enemyArchetype,
    primalStakes,
    dramaticQuestion,

    sequence,
    sequences,

    addSequence,
    deleteSequence,
    updateSequenceText,
    updateSequenceLocked,
    updateSequenceName,
}) => {

    //const [sequenceName, setSequenceName] = useState('')
    //const [sequenceText, setSequenceText] = useState('')

    // const onGenreChange = (inputValue, { action, prevInputValue }) => { // optional method signature if we ever need the previous value from the dropdown
    const onSequenceChange = (event) => {
        var selectElement = event.target;
        var value = selectElement.value;

        updateSequenceName(sequence.sequenceName, value)
        console.log('current sequence: ');
        console.log(sequence);
    }

    const mapToSelectOptions = (arr) => {
        return arr.map(function (x) {
            return { value: x, label: x }
        })
    }

    //const sequenceNames = ['Opening Image', 'Theme Stated', 'Setup', 'Inciting Incident', 'Debate', 'Break Into Two', 'Fun And Games', 'First Pinch Point', 'Midpoint', 'Bad Guys Close In', 'Second Pinch Point', 'All Hope Is Lost', 'Dark Night Of The Soul', 'Break Into Three', 'Climax', 'Cooldown']
    const sequenceOptions = mapToSelectOptions(sequence.allowed)

    const moveToNextSequence = (sequenceName) => {

        const newSequence = {
            sequenceName: 'Theme Stated', // TODO: make this dyanmic based on existing sequences
            text: '',
            isLocked: false,
            allowed: ['Opening Image', 'Theme Stated', 'Setup', 'Inciting Incident', 'Debate', 'Break Into Two', 'Fun And Games', 'First Pinch Point', 'Midpoint', 'Bad Guys Close In', 'Second Pinch Point', 'All Hope Is Lost', 'Dark Night Of The Soul', 'Break Into Three', 'Climax', 'Cooldown'] //['Opening Image', 'Theme Stated', 'Setup'] // TODO: make this dyanmic based on existing sequences
        }

        updateSequenceLocked(sequenceName, true)
        addSequence(newSequence)
    }

    const moveToPrevSequence = (sequenceName) => {
        updateSequenceLocked(sequenceName, false)
        deleteSequence(sequences.at(-1))
    }


    return (
        <div className='row border-top' onClick={onFocusChange}>
            <div className='col-3'>
                {
                    console.log(sequence)
                }
                {
                    sequence.isLocked === true &&
                    <p>locked</p>
                }
                {
                    sequence.isLocked === false &&
                    <p>not locked</p>
                }
                {/* <Select
                    menuPlacement="auto"
                    menuPosition="fixed"
                    components={{ Placeholder }}
                    placeholder={'Sequence'}
                    options={sequenceOptions}
                    defaultInputValue={sequence.sequenceName}
                    onChange={onSequenceChange}
                /> */}
                <select placeholder='Sequence' defaultValue={sequence.sequenceName} onChange={onSequenceChange}>
                    {
                        sequence.allowed.map(function (o) {
                            return <option key={o} value={o}>{o}</option>
                        })
                    }
                </select>

                {
                    sequence.isLocked === false &&
                    <button className='lock btn btn-secondary m-3 text-right' onClick={() => moveToNextSequence()}>
                        <>
                            <FaLockOpen /> Lock
                            <FaArrowDown />
                        </>
                    </button>
                }
                {
                    sequence.isLocked === true &&
                    <button className='lock btn btn-secondary m-3 text-right' onClick={() => moveToPrevSequence(sequence.sequenceName)}>
                        <>
                            <FaLock /> Unlock
                            <FaArrowUp />
                        </>
                    </button>
                }

            </div>
            <div className='col-4'>
                <LimitedTextArea className="form-control" value={sequence.text} setValue={(newValue) => updateSequenceText(sequence.sequenceName, newValue)} rows={3} limit={100} />
                <button type="button" className="generate btn btn-primary m-3 text-right">
                    <FaGhost /> Generate with AI
                </button>
            </div>
            <div className='col-5'>
                <p>advice</p>
            </div>
        </div>
    )
}

export default Sequence
