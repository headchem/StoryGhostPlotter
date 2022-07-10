import React from 'react'
import LimitedTextArea from './LimitedTextArea'
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'


const Scene = ({
    userInfo,
    plotId,
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
}) => {


    return (
        <>
            <button onClick={() => deleteScene(sequence.sequenceName, scene.id)}>Delete</button>
            <Tabs defaultActiveKey="summary" className="mb-3">
                <Tab eventKey="summary" title="Summary">
                    <label htmlFor={sequence.sequenceName + '_scene_summary_textarea' + scene.id} className="form-label w-100 d-none">Scene Summary</label>
                    <LimitedTextArea
                        id={sequence.sequenceName + '_scene_summary_textarea' + scene.id}
                        className="form-control"
                        value={scene.summary}
                        setValue={(newValue) => updateScene(sequence.sequenceName, scene.id, 'summary', newValue)}
                        rows={5}
                        limit={1000}
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
                        rows={5}
                        limit={1000}
                        showCount={true}
                    />
                </Tab>
            </Tabs>
        </>
    )
}

export default Scene