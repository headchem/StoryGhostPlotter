import React from 'react'

import Select from 'react-select'
import { selectDarkTheme, selectLightTheme } from '../../../util/SelectTheme'

import SceneEmotion from './SceneEmotion'

const SceneEmotions = ({
    mode,
    sequence,
    scene,
    updateScene,
    emotionsOptions,
}) => {

    const getBlankEmotion = () => {
        return {
            'emotion': 'ecstacy',
            'intensity': 'intense'
        }
    }

    const onEmotionsChange = (inputValue) => {
        const newEmotions = inputValue.map(el => el.value)
        updateScene(sequence.sequenceName, scene.id, 'emotions', newEmotions)
    }

    const filteredEmotionsValues = !scene['emotions'] ? [] : emotionsOptions.filter(o => scene['emotions'].indexOf(o.value) > -1)

    return (
        <>
            <div className='row w-100 m-0 mb-3'>
                {
                    <div style={{ width: '100%' }}>

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
                        />
                    </div>
                }
            </div>
            <div className='row w-100 m-0 mb-3'>
                <SceneEmotion
                    sequence={sequence}
                    scene={scene}
                    emotion={!scene['startEmotion'] ? getBlankEmotion() : scene['startEmotion']}
                    updateScene={updateScene}
                    startOrEnd={'start'}
                />
            </div>
            <div className='row w-100 m-0 mb-3'>
                <SceneEmotion
                    sequence={sequence}
                    scene={scene}
                    emotion={!scene['endEmotion'] ? getBlankEmotion() : scene['endEmotion']}
                    updateScene={updateScene}
                    startOrEnd={'end'}
                />
            </div>
        </>
    )
}

export default SceneEmotions