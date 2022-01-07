import { Link } from "react-router-dom";

import React, { useState } from 'react'

const Admin = () => {

    const [file, setFile] = useState(null)
    const [orphanSummary, setOrphanSummary] = useState('')
    const [orphanFull, setOrphanFull] = useState('')
    const [wandererSummary, setWandererSummary] = useState('')
    const [wandererFull, setWandererFull] = useState('')
    const [warriorSummary, setWarriorSummary] = useState('')
    const [warriorFull, setWarriorFull] = useState('')
    const [martyrSummary, setMartyrSummary] = useState('')
    const [martyrFull, setMartyrFull] = useState('')

    const [longestWordCount, setLongestWordCount] = useState(0)

    const onChangeFile = e => {
        setFile(e.target.files[0]);
    };

    const clean = (str) => {
        return str.replaceAll('\n', '\\n').replaceAll('"', '\\"')
    }

    // OpenAI has specific requirements for the format: https://beta.openai.com/docs/guides/fine-tuning/preparing-your-dataset
    const objToString = (arr) => {
        var strArr = arr.map(function (row) {
            const wordCount = row['prompt'].split(' ').length + row['completion'].split(' ').length;

            if (wordCount > longestWordCount) {
                setLongestWordCount(wordCount)
            }

            return '{"prompt":"' + clean(row['prompt']) + '", "completion":" ' + clean(row['completion']) + '"}'
        })

        return strArr.join('\n')
    }

    const upload = () => {
        const formData = new FormData()
        formData.append('myFile', file)

        fetch('/api/CreateFinetuningDataset', {
            method: 'POST',
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                setOrphanSummary(objToString(data['orphanSummary']))
                setOrphanFull(objToString(data['orphanFull']))
                setWandererSummary(objToString(data['wandererSummary']))
                setWandererFull(objToString(data['wandererFull']))
                setWarriorSummary(objToString(data['warriorSummary']))
                setWarriorFull(objToString(data['warriorFull']))
                setMartyrSummary(objToString(data['martyrSummary']))
                setMartyrFull(objToString(data['martyrFull']))
            })
            .catch(error => {
                console.error(error)
            })
    }

    return (
        <div>
            <p>Admin page</p>

            <input
                type="file"
                onChange={e => onChangeFile(e)}
            />
            <button onClick={upload}>Upload</button>

            <div className="form-group mt-4">
                <label htmlFor="orphanSummary" className="fs-3">Orphan Summary</label>
                <textarea className="form-control" id="orphanSummary" rows="3" value={orphanSummary}></textarea>
            </div>

            <div className="form-group mt-4">
                <label htmlFor="orphanFull" className="fs-3">Orphan Full</label>
                <textarea className="form-control" id="orphanFull" rows="3" value={orphanFull}></textarea>
            </div>

            <div className="form-group mt-4">
                <label htmlFor="wandererSummary" className="fs-3">Wanderer Summary</label>
                <textarea className="form-control" id="wandererSummary" rows="3" value={wandererSummary}></textarea>
            </div>

            <div className="form-group mt-4">
                <label htmlFor="wandererFull" className="fs-3">Wanderer Full</label>
                <textarea className="form-control" id="wandererFull" rows="3" value={wandererFull}></textarea>
            </div>

            <div className="form-group mt-4">
                <label htmlFor="warriorSummary" className="fs-3">Warrior Summary</label>
                <textarea className="form-control" id="warriorSummary" rows="3" value={warriorSummary}></textarea>
            </div>

            <div className="form-group mt-4">
                <label htmlFor="warriorFull" className="fs-3">Warrior Full</label>
                <textarea className="form-control" id="warriorFull" rows="3" value={warriorFull}></textarea>
            </div>

            <div className="form-group mt-4">
                <label htmlFor="martyrSummary" className="fs-3">Martyr Summary</label>
                <textarea className="form-control" id="martyrSummary" rows="3" value={martyrSummary}></textarea>
            </div>

            <div className="form-group mt-4">
                <label htmlFor="martyrFull" className="fs-3">Martyr Full</label>
                <textarea className="form-control" id="martyrFull" rows="3" value={martyrFull}></textarea>
                <p><strong>Longest row word count: {longestWordCount}</strong></p>
            </div>


            <Link to="/">Back to Home</Link>
        </div>
    )
}

export default Admin