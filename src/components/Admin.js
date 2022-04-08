import { Link } from "react-router-dom";

import React, { useState } from 'react'

const Admin = () => {

    const [logLineFile, setLogLineFile] = useState(null)
    const [logLineJSONL, setLogLineJSONL] = useState(null)

    const [characterJSONL, setCharacterJSONL] = useState(null)
    const [sequenceJSONL, setSequenceJSONL] = useState(null)
    const [sequenceName, setSequenceName] = useState('Opening Image')

    const onLogLineChangeFile = e => {
        setLogLineFile(e.target.files[0]);
    };

    const uploadLogLineFile = () => {
        const formData = new FormData()
        formData.append('logLineFile', logLineFile)

        fetch('/api/SGAdmin/CreateLogLineFinetuningDataset', {
            method: 'POST',
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                console.log(data)
                setLogLineJSONL(data['text'])
            })
            .catch(error => {
                console.error(error)
            })
    }

    const getCharacterFinetuningData = () => {

        fetch('/api/SGAdmin/CreateCharacterFinetuningDataset', {
            method: 'GET'
        })
            .then(response => response.json())
            .then(data => {
                console.log(data)
                setCharacterJSONL(data['text'])
            })
            .catch(error => {
                console.error(error)
            })
    }

    const onSequenceNameChange = (event) => {
        setSequenceName(event.target.value)
    }

    const getSequenceFinetuningData = () => {

        fetch('/api/SGAdmin/CreateSequenceFinetuningDataset?targetSequence=' + sequenceName, {
            method: 'GET'
        })
            .then(response => response.json())
            .then(data => {
                console.log(data)
                setSequenceJSONL(data['text'])
            })
            .catch(error => {
                console.error(error)
            })
    }

    return (
        <div>
            <p>Export Top_10000_Movies from Google Sheets as CSV, then upload that file here.</p>

            <input
                type="file"
                onChange={e => onLogLineChangeFile(e)}
            />

            <button onClick={uploadLogLineFile}>Upload Log Line Data</button>
            <label htmlFor="logLineFinetune" className="fs-3">Log Line Finetune</label>
            <textarea className="form-control" id="logLineFinetune" rows="6" defaultValue={logLineJSONL}></textarea>

            <hr />

            <button onClick={getCharacterFinetuningData}>Get Character Data</button>
            <label htmlFor="characterFinetune" className="fs-3">Character Finetune</label>
            <textarea className="form-control" id="characterFinetune" rows="6" defaultValue={characterJSONL}></textarea>

            <hr />

            <select id='sequenceName' required className='fs-5 form-select' defaultValue={sequenceName} onChange={onSequenceNameChange}>
                <option value="Opening Image" selected>Opening Image</option>
                <option value="Setup" selected>Setup</option>
                <option value="Theme Stated" selected>Theme Stated</option>
                <option value="Catalyst" selected>Catalyst</option>
                <option value="Debate" selected>Debate</option>
                <option value="B Story" selected>B Story</option>
                <option value="Break Into Two" selected>Break Into Two</option>
                <option value="Fun And Games" selected>Fun And Games</option>
                <option value="Midpoint" selected>Midpoint</option>
                <option value="Bad Guys Close In" selected>Bad Guys Close In</option>
                <option value="All Hope Is Lost" selected>All Hope Is Lost</option>
                <option value="Dark Night Of The Soul" selected>Dark Night Of The Soul</option>
                <option value="Break Into Three" selected>Break Into Three</option>
                <option value="Climax" selected>Climax</option>
                <option value="Cooldown" selected>Cooldown</option>
            </select>
            <button onClick={getSequenceFinetuningData}>Get Sequence Data</button>
            <label htmlFor="sequenceFinetune" className="fs-3">Sequence Finetune</label>
            <textarea className="form-control" id="sequenceFinetune" rows="6" defaultValue={sequenceJSONL}></textarea>

            <Link to="/">Back to Home</Link>
        </div>
    )
}

export default Admin