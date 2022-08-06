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
        <div className='row w-100 pb-3'>
            <div className='col'>
                <SceneEmotion
                    sequence={sequence}
                    scene={scene}
                    emotion={!scene['startEmotion'] ? getBlankEmotion() : scene['startEmotion']}
                    updateScene={updateScene}
                    startOrEnd={'start'}
                />
            </div>
            <div className='col'>
                <SceneEmotion
                    sequence={sequence}
                    scene={scene}
                    emotion={!scene['endEmotion'] ? getBlankEmotion() : scene['endEmotion']}
                    updateScene={updateScene}
                    startOrEnd={'end'}
                />
            </div>
        </div>
    )
}

export default SceneEmotions