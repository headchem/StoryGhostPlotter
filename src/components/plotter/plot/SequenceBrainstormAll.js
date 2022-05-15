import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { fetchWithTimeout } from '../../../util/FetchUtil'
import Spinner from 'react-bootstrap/Spinner';

const SequenceBrainstormAll = ({
    plotId,
    sequences,
    userInfo,
    logLineDescription,
    genres,
    problemTemplate,
    keywords,
    characters,
    dramaticQuestion,
    setSequences,
    tokensRemaining
}) => {

    const navigate = useNavigate()

    const [showConfirmReplaceAll, setShowConfirmReplaceAll] = useState(false)
    const [isReplaceAllLoading, setIsReplaceAllLoading] = useState(false)
    const [upToTargetSequenceExclusive, setUpToTargetSequenceExclusive] = useState('Fun And Games')

    const generateAll = () => {
        setIsReplaceAllLoading(true)

        fetchWithTimeout('/api/Sequence/GenerateAll?upToTargetSequenceExclusive=' + upToTargetSequenceExclusive, {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: plotId,
                logLineDescription: logLineDescription,
                genres: genres,
                problemTemplate: problemTemplate,
                dramaticQuestion: dramaticQuestion,
                keywords: keywords,
                sequences: sequences,
                characters: characters,
            })
        }).then(function (response) {
            if (response.status === 401 || response.status === 403) {
                navigate('/plots')
            } else {
                if (response.ok) {
                    return response.json();
                }
            }
            return Promise.reject(response);
        }).then(function (data) {
            console.log('save this data:')
            console.log(data)
            setSequences(data)
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server or you have run out of tokens');
        }).finally(function () {
            setIsReplaceAllLoading(false)
            setShowConfirmReplaceAll(false)
        });
    }


    return (
        <>
            <div className='row'>
                <div className="alert alert-warning" role="alert">

                    {
                        tokensRemaining <= 0 &&
                        <>
                            <p>You have run out of tokens.</p>
                        </>
                    }
                    {
                        tokensRemaining > 0 &&
                        <>
                            {
                                isReplaceAllLoading === true &&
                                <>
                                    <Spinner animation="border" variant="secondary" />
                                    <p>This may take 1-2 minutes...</p>
                                </>
                            }
                            {
                                isReplaceAllLoading === false &&
                                <>
                                    {
                                        showConfirmReplaceAll === false &&
                                        <div className="row g-3 align-items-center">
                                            <div className='col-auto'>
                                                <button className='btn btn-warning' onClick={() => { setShowConfirmReplaceAll(true) }}>Delete and Regenerate All Sequences</button>
                                                <p>Tokens remaining: {tokensRemaining}</p>
                                            </div>
                                            <div className='col-auto'>
                                                <label htmlFor='gen-up-to' className='col-form-label'>Generate sequences up to: </label>
                                            </div>
                                            <div className="col-auto">
                                                <select id="gen-up-to" required className='form-select form-inline form-control' defaultValue={upToTargetSequenceExclusive} onChange={(e) => { setUpToTargetSequenceExclusive(e.target.value) }}>
                                                    <option value="Fun And Games">Fun And Games</option>
                                                    <option value="Break Into Three">Break Into Three</option>
                                                    <option value="All">Complete Story</option>
                                                </select>
                                            </div>
                                        </div>
                                    }
                                    {
                                        showConfirmReplaceAll === true &&
                                        <>
                                            <p>Are you sure?</p>
                                            <button className='btn btn-warning me-3' onClick={() => setShowConfirmReplaceAll(false)}>Cancel</button>
                                            <button className='btn btn-danger' onClick={generateAll}>Yes, delete all sequences and replace with a new story</button>
                                        </>
                                    }

                                    <p className='mt-3'>Caution! This will generate a new complete story, <strong>permanently deleting all existing sequences and sequence brainstorms.</strong> You will be prompted to confirm.</p>
                                </>
                            }
                        </>
                    }

                </div>
            </div>

        </>
    )
}

export default SequenceBrainstormAll
