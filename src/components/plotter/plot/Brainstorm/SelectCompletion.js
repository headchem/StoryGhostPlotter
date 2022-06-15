import React from 'react'
import { FaStar, FaRegStar } from 'react-icons/fa'


const SelectCompletion = (
    {
        idx,
        isSelected,
        onSelectBrainstormChange
    }
) => {


    return (
        <span className='ms-3 card-link'>
            {
                isSelected === false &&
                <FaRegStar onClick={() => onSelectBrainstormChange(idx, true)} />
            }
            {
                isSelected === true &&
                <FaStar onClick={() => onSelectBrainstormChange(idx, false)} />
            }
        </span>
    )
}

export default SelectCompletion