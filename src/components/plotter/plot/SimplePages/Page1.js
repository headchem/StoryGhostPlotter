import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import LimitedTextArea from '../LimitedTextArea'
import Spinner from 'react-bootstrap/Spinner';
import { fetchWithTimeout } from '../../../../util/FetchUtil'
import { FaSyncAlt } from 'react-icons/fa'

const Page1 = (
    {
        userInfo,

        genres,
        keywords,
        logLineDescription,
        onLogLineDescriptionChange,
        onFocusChange,
        title,
        onTitleChange,

        plotId,
        updateLogLineDescriptionCompletions,
        AILogLineDescriptions,

        setAITitles

    }
) => {

    const navigate = useNavigate()

    const [isLogLineDescLoading, setIsLogLineDescLoading] = useState(false)
    const [isTitleLoading, setIsTitleLoading] = useState(false)

    const loadLogLineDesc = async () => {
        setIsLogLineDescLoading(true)

        fetchWithTimeout('/api/LogLineDescription/Generate?temperature=0.9&keywordsImpact=4', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: plotId,
                genres: genres,
                keywords: keywords,
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
            if (!AILogLineDescriptions || AILogLineDescriptions.length === 0) {
                updateLogLineDescriptionCompletions([data])
            } else {
                const newCompletionList = [...AILogLineDescriptions, data]
                updateLogLineDescriptionCompletions(newCompletionList)
            }

            onLogLineDescriptionChange(data['completion'])
            loadTitle(data['completion'])
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server or you have run out of tokens');
        }).finally(function () {
            setIsLogLineDescLoading(false)
        });
    }

    const loadTitle = async (desc) => {
        setIsTitleLoading(true)

        fetchWithTimeout('/api/Titles/Generate', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'seed': 123,
                'id': plotId,
                'genres': genres,
                'logLineDescription': desc
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
            setAITitles(data)
            onTitleChange({ 'target': { 'value': data[0] } })
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server or you have run out of tokens');
        }).finally(function () {
            setIsTitleLoading(false)
        });
    }

    return (
        <>
            <div className="card-group">
                <div className="card">

                    <div className="card-body">
                        <div className='row'>
                            <div className='col-8'>

                                {
                                    (isLogLineDescLoading === false && isTitleLoading === false) &&
                                    <>
                                        <input
                                            type='text'
                                            className='fs-5 form-control mb-3'
                                            placeholder='Plot Title'
                                            required
                                            onChange={onTitleChange}
                                            //defaultValue={title}
                                            value={title}
                                            onFocus={() => onFocusChange('title')}
                                            aria-describedby="titleHelp"
                                            id="title" />

                                        <LimitedTextArea
                                            id='logLineDesc'
                                            className="form-control"
                                            value={logLineDescription}
                                            setValue={(newValue) => onLogLineDescriptionChange(newValue)}
                                            rows={4}
                                            limit={700}
                                            showCount={true}
                                            onFocus={() => onFocusChange('logLineDescription')}
                                        />
                                    </>
                                }
                                <span className='float-end'>
                                    {
                                        userInfo && userInfo.userRoles.includes('customer') && isLogLineDescLoading === false && isTitleLoading === false &&
                                        <button onClick={loadLogLineDesc} className='btn btn-primary btn-lg mt-3' title='Replace existing text with a new story idea'><FaSyncAlt /> Brainstorm with AI</button>
                                    }
                                    {
                                        (isLogLineDescLoading === true || isTitleLoading === true) && <Spinner animation="border" variant="secondary" />
                                    }
                                </span>
                            </div>
                            <div className='col-4'>
                                <p><strong>Genres:</strong> {genres.join(', ')}.</p>
                                <p><strong>Keywords:</strong> {keywords.join(', ')}</p>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </>
    )
}

export default Page1