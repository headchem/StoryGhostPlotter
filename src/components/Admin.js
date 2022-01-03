import { Link } from "react-router-dom";

import React, { useState } from 'react'

const Admin = () => {

    const [file, setFile] = useState(null);

    const onChangeFile = e => {
        setFile(e.target.files[0]);
    };

    const upload = () => {
        console.log('file: ', file);

        const formData = new FormData()
        formData.append('myFile', file)

        fetch('/api/CreateFinetuningDataset', {
            method: 'POST',
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                console.log(data)
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

            <Link to="/">Back to Home</Link>
        </div>
    )
}

export default Admin
