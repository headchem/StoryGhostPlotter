import React, { useState } from 'react'

import EmotionFinder from './EmotionFinder'
import SceneCharacterEmotionList from './SceneCharacterEmotionList'

const SceneEmotions = ({
    mode,
    sequence,
    scene,
    updateScene,
    emotionsOptions,
    emotions,
    characters
}) => {

    const [showEmotionFinder, setShowEmotionFinder] = useState(false)

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

                <SceneCharacterEmotionList
                    emotionsOptions={emotionsOptions}
                    characters={characters}
                    sequence={sequence}
                    scene={scene}
                    mode={mode}
                    updateScene={updateScene}
                />

            </div>
        </>
    )
}

export default SceneEmotions