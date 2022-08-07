import React from 'react'
import SceneEmotion from './SceneEmotion'


const SceneEmotions = ({
    sequence,
    scene,
    updateScene,
}) => {

    const getBlankEmotion = () => {
        return {
            'emotion': 'ecstacy',
            'intensity': 'intense'
        }
    }

    return (
        <>
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