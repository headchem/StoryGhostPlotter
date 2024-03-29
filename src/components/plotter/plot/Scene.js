import React, { useState } from 'react'
import LimitedTextArea from './LimitedTextArea'
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import { FaMinusCircle } from 'react-icons/fa'
import SceneSummarizer from './SceneSummarizer'
import SceneEmotions from './SceneEmotions'


const Scene = ({
    userInfo,
    plotId,
    mode,
    sequenceType,
    genres,
    problemTemplate,
    keywords,
    characters,
    heroCharacterArchetype,
    dramaticQuestion,
    logLineDescription,
    sequence,
    scene,
    tokensRemaining,
    AILogLineDescriptions,
    updateScene,
    deleteScene,
    sceneIdx,
    insertScene,

    emotionsOptions,
    emotions,
    emotionsMap,
}) => {

    const [showConfirmDelete, setShowConfirmDelete] = useState(false)

    return (
        <>
            <div className='row'>
                <div className='col'>
                    <div className='float-end'>
                        {
                            showConfirmDelete === false &&
                            <>
                                <button onClick={() => setShowConfirmDelete(true)} className='btn btn-outline-danger btn-no-border' title='Delete this scene. You will be prompted to confirm.'><FaMinusCircle /></button>
                            </>
                        }
                        {
                            showConfirmDelete === true &&
                            <>
                                <button onClick={() => deleteScene(sequence.sequenceName, scene.id)} className="btn btn-danger">Delete</button>
                                <button className='btn btn-link' onClick={() => setShowConfirmDelete(false)}>cancel delete</button>
                            </>
                        }
                    </div>

                    <Tabs defaultActiveKey="summary" className="mb-3">
                        <Tab eventKey="summary" title="Summary">
                            <label htmlFor={sequence.sequenceName + '_scene_summary_textarea' + scene.id} className="form-label w-100 d-none">Scene Summary</label>
                            <LimitedTextArea
                                id={sequence.sequenceName + '_scene_summary_textarea' + scene.id}
                                className="form-control"
                                value={scene.summary}
                                setValue={(newValue) => updateScene(sequence.sequenceName, scene.id, 'summary', newValue)}
                                rows={5}
                                limit={600}
                                showCount={true}
                            />
                        </Tab>
                        <Tab eventKey="full" title="Full Screenplay">
                            <label htmlFor={sequence.sequenceName + '_scene_full_textarea' + scene.id} className="form-label w-100 d-none">Scene Full</label>
                            <LimitedTextArea
                                id={sequence.sequenceName + '_scene_full_textarea' + scene.id}
                                className="form-control"
                                value={scene.full}
                                setValue={(newValue) => updateScene(sequence.sequenceName, scene.id, 'full', newValue)}
                                //rows={parseInt(scene.full.length / 35)}
                                limit={5000}
                                showCount={true}
                            />
                        </Tab>
                    </Tabs>

                    {
                        userInfo && userInfo.userRoles.includes('admin') &&
                        <>
                            <SceneEmotions
                                mode={mode}
                                sequence={sequence}
                                scene={scene}
                                updateScene={updateScene}
                                emotionsOptions={emotionsOptions}
                                emotions={emotions}
                                emotionsMap={emotionsMap}
                                characters={characters}
                                
                            />
                            <SceneSummarizer
                                userInfo={userInfo}
                                plotId={plotId}
                                characters={characters}
                                scene={scene}
                                tokensRemaining={tokensRemaining}
                            />
                        </>
                    }

                    <div className='row w-100'>
                        <div className='col'>
                            <button className='btn btn-primary mb-3' onClick={() => insertScene(sceneIdx)}>Add Scene</button>
                        </div>
                    </div>

                </div>
            </div>
        </>
    )
}

export default Scene