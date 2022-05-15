import { Link } from "react-router-dom";

import React, { useState } from 'react'

const Admin = () => {

    const [logLineFile, setLogLineFile] = useState(null)
    const [logLineJSONL, setLogLineJSONL] = useState(null)

    const [characterJSONL, setCharacterJSONL] = useState(null)
    const [sequenceJSONL, setSequenceJSONL] = useState(null)

    const [numTokensToAdd, setNumTokensToAdd] = useState(4096)
    const [tokensTargetUserId, setTokensTargetUserId] = useState('')

    const addTokens = () => {
        fetch('/api/SGAdmin/AddTokens?targetUserId=' + tokensTargetUserId + '&tokensToAdd=' + numTokensToAdd, {
            method: 'POST'
        })
            .then(response => response.text())
            .then(data => {
                console.log(data)
            })
            .catch(error => {
                console.error(error)
            })
    }

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

    const getSequenceFinetuningData = () => {

        fetch('/api/SGAdmin/CreateSequenceFinetuningDataset', {
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

            <button onClick={getSequenceFinetuningData}>Get Sequence Data</button>
            <label htmlFor="sequenceFinetune" className="fs-3">Sequence Finetune</label>
            <textarea className="form-control" id="sequenceFinetune" rows="6" defaultValue={sequenceJSONL}></textarea>

            <hr />

            <label htmlFor="addTokens">Add Tokens to User</label>
            <input type="text" id="tokensTargetUserId" value={tokensTargetUserId} onChange={e => setTokensTargetUserId(e.target.value)} />
            <input type="number" id="addTokens" value={numTokensToAdd} onChange={e => setNumTokensToAdd(e.target.value)} />
            <button onClick={addTokens}>Add Tokens</button>

            <Link to="/">Back to Home</Link>
        </div>
    )
}

export default Admin