import { Link } from "react-router-dom";

import React, { useState } from 'react'

const Admin = () => {

    const [finetuningData, setFinetuningData] = useState(null)

    const [logLineFile, setLogLineFile] = useState(null)
    const [logLineJSONL, setLogLineJSONL] = useState(null)

    // const [orphanSummary, setOrphanSummary] = useState('')
    // const [orphanFull, setOrphanFull] = useState('')
    // const [wandererSummary, setWandererSummary] = useState('')
    // const [wandererFull, setWandererFull] = useState('')
    // const [warriorSummary, setWarriorSummary] = useState('')
    // const [warriorFull, setWarriorFull] = useState('')
    // const [martyrSummary, setMartyrSummary] = useState('')
    // const [martyrFull, setMartyrFull] = useState('')

    // const [longestWordCount, setLongestWordCount] = useState(0)

    const onLogLineChangeFile = e => {
        setLogLineFile(e.target.files[0]);
    };

    const clean = (str) => {
        return str.replaceAll('\n', '\\n').replaceAll('"', '\\"')
    }

    // OpenAI has specific requirements for the format: https://beta.openai.com/docs/guides/fine-tuning/preparing-your-dataset
    const objToString = (arr) => {
        var strArr = arr.map(function (row) {
            //const wordCount = row['prompt'].split(' ').length + row['completion'].split(' ').length;

            // if (wordCount > longestWordCount) {
            //     setLongestWordCount(wordCount)
            // }

            return '{"prompt":"' + clean(row['prompt']) + '", "completion":"' + clean(row['completion']) + '"}'
        })

        return strArr.join('\n')
    }

    const getFinetuningData = () => {
        //const formData = new FormData()
        //formData.append('myFile', file)

        fetch('/api/SGAdmin/CreateSequenceFinetuningDataset', {
            method: 'GET',
        })
            .then(response => response.json())
            .then(data => {
                setFinetuningData(data)
            })
            .catch(error => {
                console.error(error)
            })
    }

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

    return (
        <div>
            <p>Admin page</p>

            <input
                type="file"
                onChange={e => onLogLineChangeFile(e)}
            />

            <button onClick={uploadLogLineFile}>Upload Log Line Data</button>
            <label htmlFor="logLineFinetune" className="fs-3">Log Line Finetune</label>
            <textarea className="form-control" id="logLineFinetune" rows="3" defaultValue={logLineJSONL}></textarea>


            <hr/>

            <button onClick={getFinetuningData}>Get Data</button>

            {
                finetuningData && Object.keys(finetuningData).map((sequenceName) => (
                    <>
                        <div key={sequenceName} className="form-group mt-4">
                            <label htmlFor={sequenceName + '_textarea'} className="fs-3">{sequenceName}</label>
                            <textarea className="form-control" id={sequenceName + '_textarea'} rows="3" defaultValue={objToString(finetuningData[sequenceName])}></textarea>
                        </div>
                    </>
                ))
            }

            <Link to="/">Back to Home</Link>
        </div>
    )
}

export default Admin