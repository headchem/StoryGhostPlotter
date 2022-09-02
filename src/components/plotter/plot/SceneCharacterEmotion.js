import React from 'react'

import Select from 'react-select'
import { selectDarkTheme, selectLightTheme } from '../../../util/SelectTheme'
import { FaTrash } from 'react-icons/fa'


const SceneCharacterEmotion = ({
    characterEmotion,
    emotionsOptions,
    mode,
    deleteCharacterEmotion,
    updateSelectedCharacter,
    updateSelectedEmotion,
    characters
}) => {

    const onEmotionsChange = (inputValue) => {
        console.log(inputValue)
        const newEmotions = inputValue.value//.map(el => el.value)
        updateSelectedEmotion(characterEmotion.id, newEmotions)
    }

    return (
        <>
            <div className='col-4'>
                <select required className='fs-5 form-select form-inline' value={!characterEmotion.characterId ? '' : characterEmotion.characterId} onChange={(e) => updateSelectedCharacter(characterEmotion.id, e.target.value)}>
                    <option key="blank" value="">None/Other</option>
                    {
                        characters.map(function (c) {
                            return <option key={c.id} value={c.id}>{c.name}</option>
                        })
                    }
                </select>
            </div>
            <div className='col-7'>
                <div className='m-0 p-0' style={{ width: '100%' }}>
                    {
                        <Select
                            placeholder='Emotions'
                            className="character-emotion-select"
                            classNamePrefix="select"
                            defaultValue={emotionsOptions.filter((opt) => opt.value === characterEmotion['emotion'])[0]}
                            isSearchable={true}
                            name="color"
                            options={emotionsOptions}
                            onChange={onEmotionsChange}
                            theme={mode === 'dark' ? selectDarkTheme : selectLightTheme}
                            menuPortalTarget={document.body}
                            menuPosition="fixed"
                            styles={{
                                menuPortal: (provided) => ({ ...provided, zIndex: 9999 }),
                                menu: (provided) => ({ ...provided, zIndex: 9999 })
                            }}
                        />
                    }
                </div>
            </div>
            <div className='col-1'>
                <button onClick={() => deleteCharacterEmotion(characterEmotion.id)} className="btn btn-danger"><FaTrash /></button>
            </div>
        </>
    )
}

export default SceneCharacterEmotion