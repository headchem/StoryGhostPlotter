import React, { useState } from 'react'
import { v4 as uuid } from 'uuid';
import Modal from 'react-bootstrap/Modal'
import LimitedTextArea from './LimitedTextArea'
import { toTitleCase } from '../../../util/Helpers';


const SceneImport = ({
    userInfo,
    setSequences
}) => {

    const [show, setShow] = useState(false);
    const [fullScreenplay, setFullScreenplay] = useState('')

    const handleClose = () => setShow(false)
    const handleShow = () => setShow(true)
    const completeImport = () => {
        //console.log(fullScreenplay)

        // LEFT OFF: split on "\n# " to populate an ordered list, then the first line is SEQUENCE_NAME. Call setSequences to overwrite existing with new blank ones with the full scene text populated, and the scene summary, if any.

        const seqTexts = fullScreenplay.split('# ').filter(v => v.trim() !== '')

        let newSequences = []

        seqTexts.forEach(seq => {
            const [seqName, ...rest] = seq.split('\n')
            const seqScenes = rest.join('\n').trim()

            const seqNameTitleCase = toTitleCase(seqName).replace('continued', 'Continued')

            let newSequence = {
                'sequenceName': seqNameTitleCase,
                'blurb': 'todo',
                'text': 'todo',
                'blurbCompletions': null,
                'completions': null,
                'scenes': []
            }

            const scenes = seqScenes.split('= ').filter(v => v.trim() !== '')

            scenes.forEach(scene => {
                let newScene = {
                    'id': uuid(),
                    'summary': '',
                    'full': '',
                    'summaryCompletions': [],
                    'fullCompletions': []
                }

                //console.log(seqName, scene)
                const [sceneSummary, ...restScene] = scene.split('\n')
                const sceneFull = restScene.join('\n').trim()

                newScene['summary'] = sceneSummary
                newScene['full'] = sceneFull

                newSequence['scenes'].push(newScene)

                //console.table([seqName, sceneSummary, sceneFull])
            })

            newSequences.push(newSequence)
        });

        console.log(newSequences)
        setSequences(newSequences)
        setShow(false)
    }

    return (
        <>
            <button className='btn btn-primary' onClick={handleShow}>Import Scenes</button>
            <Modal show={show} onHide={handleClose}>
                <Modal.Header closeButton>
                    <Modal.Title>Modal heading</Modal.Title>
                </Modal.Header>
                <Modal.Body>

                    <LimitedTextArea
                        id={'scene_full_screenplay_textarea'}
                        className="form-control"
                        value={fullScreenplay}
                        setValue={(newValue) => setFullScreenplay(newValue)}
                        rows={10}
                        limit={1000000}
                        showCount={true}
                    />

                </Modal.Body>
                <Modal.Footer>
                    <button className="btn btn-secondary" onClick={handleClose}>
                        Close
                    </button>
                    <button className='btn btn-danger' onClick={completeImport}>Complete Import (DELETES EXISTING!)</button>
                    <p>Make sure you have copied existing BLURBS and EXPANDED because they will be lost.</p>
                </Modal.Footer>
            </Modal>
        </>
    )
}

export default SceneImport