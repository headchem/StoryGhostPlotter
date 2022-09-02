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
    emotionsMap,
    characters
}) => {

    const [showEmotionFinder, setShowEmotionFinder] = useState(false)

    return (
        <>
            <div className='row w-100'>

                <div className='col'>
                    {
                        showEmotionFinder === true &&
                        <button className='btn btn-link mb-3' onClick={() => setShowEmotionFinder(false)}>hide emotion finder</button>
                    }
                    {
                        showEmotionFinder === false &&
                        <button className='btn btn-link mb-3' onClick={() => setShowEmotionFinder(true)}>show emotion finder</button>
                    }

                    {
                        showEmotionFinder === true &&
                        <EmotionFinder
                            emotions={emotions}
                            emotionsMap={emotionsMap}
                        />
                    }
                </div>
            </div>
            <SceneCharacterEmotionList
                emotionsOptions={emotionsOptions}
                characters={characters}
                sequence={sequence}
                scene={scene}
                mode={mode}
                updateScene={updateScene}
                emotions={emotions}
                emotionsMap={emotionsMap}
            />
        </>
    )
}

export default SceneEmotions