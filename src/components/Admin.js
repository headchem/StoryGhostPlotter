import { Link } from "react-router-dom";

import React, { useState } from 'react'

const Admin = () => {

    const [logLineFile, setLogLineFile] = useState(null)
    const [logLineJSONL, setLogLineJSONL] = useState(null)

    const [characterJSONL, setCharacterJSONL] = useState(null)
    const [sequenceBlurbJSONL, setSequenceBlurbJSONL] = useState(null)
    const [sequenceExpandedSummaryJSONL, setSequenceExpandedSummaryJSONL] = useState(null)
    const [sequenceFullJSONL, setSequenceFullJSONL] = useState(null)

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

    const getSequenceBlurbFinetuningData = () => {
        fetch('/api/SGAdmin/CreateSequenceBlurbFinetuningDataset', {
            method: 'GET'
        })
            .then(response => response.json())
            .then(data => {
                console.log(data)
                setSequenceBlurbJSONL(data['jsonl'])
            })
            .catch(error => {
                console.error(error)
            })
    }

    const getSequenceExpandedSummaryFinetuningData = () => {
        fetch('/api/SGAdmin/CreateSequenceExpandedSummaryFinetuningDataset', {
            method: 'GET'
        })
            .then(response => response.json())
            .then(data => {
                console.log(data)
                setSequenceExpandedSummaryJSONL(data['jsonl'])
            })
            .catch(error => {
                console.error(error)
            })
    }

    const getSequenceFullFinetuningData = () => {
        fetch('/api/SGAdmin/CreateSequenceFullFinetuningDataset', {
            method: 'GET'
        })
            .then(response => response.json())
            .then(data => {
                console.log(data)
                setSequenceFullJSONL(data['jsonl'])
            })
            .catch(error => {
                console.error(error)
            })
    }

    return (
        <div>
            <p>Export Top_10000_Movies from Google Sheets as CSV, run it through the Google Colab notebook "KeyBERT.ipynb" to attach keywords, then upload that CSV file here.</p>

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

            <button onClick={getSequenceBlurbFinetuningData}>Get Sequence Blurb Data</button>
            <label htmlFor="sequenceBlurbFinetune" className="fs-3">Sequence Blurb Finetune</label>
            <textarea className="form-control" id="sequenceBlurbFinetune" rows="6" defaultValue={sequenceBlurbJSONL}></textarea>

            <hr />

            <button onClick={getSequenceExpandedSummaryFinetuningData}>Get Sequence Expanded Summary Data</button>
            <label htmlFor="sequenceExpandedSummaryFinetune" className="fs-3">Sequence Expanded Summary Finetune</label>
            <textarea className="form-control" id="sequenceExpandedSummaryFinetune" rows="6" defaultValue={sequenceExpandedSummaryJSONL}></textarea>

            <hr />

            <button onClick={getSequenceFullFinetuningData}>Get Sequence Full Data</button>
            <label htmlFor="sequenceFullFinetune" className="fs-3">Sequence Full Finetune</label>
            <textarea className="form-control" id="sequenceFullFinetune" rows="6" defaultValue={sequenceFullJSONL}></textarea>

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