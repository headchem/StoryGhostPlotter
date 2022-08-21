import React, { useState } from 'react'

import Select from 'react-select'
import { selectDarkTheme, selectLightTheme } from '../../../util/SelectTheme'

import EmotionFinder from './EmotionFinder'

const SceneEmotions = ({
    mode,
    sequence,
    scene,
    updateScene,
    emotionsOptions,
    emotions,
}) => {

    const [showEmotionFinder, setShowEmotionFinder] = useState(false)

    const onEmotionsChange = (inputValue) => {
        const newEmotions = inputValue.map(el => el.value)
        updateScene(sequence.sequenceName, scene.id, 'emotions', newEmotions)
    }

    const filteredEmotionsValues = !scene['emotions'] ? [] : emotionsOptions.filter(o => scene['emotions'].indexOf(o.value) > -1)

    return (
        <>
            <div className='row w-100 m-0 mb-3'>

                <div className='col'>
                    {
                        showEmotionFinder === true &&
                        <button className='btn btn-link' onClick={() => setShowEmotionFinder(false)}>hide emotion finder</button>
                    }
                    {
                        showEmotionFinder === false &&
                        <button className='btn btn-link' onClick={() => setShowEmotionFinder(true)}>show emotion finder</button>
                    }

                    {
                        showEmotionFinder === true &&
                        <EmotionFinder
                            emotions={emotions}
                        />
                    }
                </div>

                {
                    <div className='m-0 p-0' style={{ width: '100%' }}>

                        <Select
                            defaultValue={filteredEmotionsValues}
                            isMulti
                            placeholder='Emotions'
                            name="emotions"
                            options={emotionsOptions}
                            className="emotions-multi-select"
                            classNamePrefix="select"
                            onChange={onEmotionsChange}
                            theme={mode === 'dark' ? selectDarkTheme : selectLightTheme}

                            menuPortalTarget={document.body}
                            menuPosition="fixed"
                            styles={{
                                menuPortal: (provided) => ({ ...provided, zIndex: 9999 }),
                                menu: (provided) => ({ ...provided, zIndex: 9999 })
                            }}
                        />
                    </div>
                }
            </div>
        </>
    )
}

export default SceneEmotions