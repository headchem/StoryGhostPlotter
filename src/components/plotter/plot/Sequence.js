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

    updateSequenceText,
    updateSequenceName,
    moveToNextSequence,
    moveToPrevSequence,
}) => {

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

    const sequenceOptions = mapToSelectOptions(sequence.allowed)


    return (

        <div className='row border-top' onClick={onFocusChange}>
            <div className='col-3'>
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
                    sequence.isReadOnly === false &&
                    <>
                        {
                            sequence.isLocked === false &&
                            <button className='lock btn btn-secondary m-3 text-right' onClick={() => moveToNextSequence(sequence.sequenceName)}>
                                <>
                                    <FaLockOpen /> Lock
                                    {/* <FaArrowDown /> */}
                                </>
                            </button>
                        }
                        {
                            sequence.isLocked === true &&
                            <button className='lock btn btn-secondary m-3 text-right' onClick={() => moveToPrevSequence(sequence.sequenceName)}>
                                <>
                                    <FaLock /> Unlock
                                    {/* <FaArrowUp /> */}
                                </>
                            </button>
                        }
                    </>
                }


            </div>
            <div className='col-4'>
                <LimitedTextArea className="form-control" value={sequence.text} setValue={(newValue) => updateSequenceText(sequence.sequenceName, newValue)} rows={3} limit={100} showCount={!sequence.isLocked} />
                {
                    sequence.isLocked === false &&
                    <button type="button" className="generate btn btn-primary mt-1 text-right">
                        <FaGhost /> Generate with AI
                    </button>
                }

            </div>
            <div className='col-5'>
                <p>Tabs? advice specific to {sequence.sequenceName}. Public user-submitted comments (from other authenticated users). Checkboxes for "addressed", "ignored" like a mini TODO list per Sequence. Tab for AI-generated image inspiration? Tab for search for similar stories?</p>
            </div>
        </div>
    )
}

export default Sequence
