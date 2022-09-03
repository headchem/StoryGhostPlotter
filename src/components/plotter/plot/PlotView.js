import React, { useState, useEffect } from 'react'
import { useSearchParams, Link } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import { getText } from '../../../util/Helpers'
//import EmotionsChart from './EmotionsChart'

const PlotView = (
    {
        userInfo,
    }
) => {

    const [title, setTitle] = useState('')
    const [sequences, setSequences] = useState(null)
    const [isPublic, setIsPublic] = useState(false)
    const [isNotFound, setIsNotFound] = useState(false)
    const [plotLoading, setPlotLoading] = useState(false)
    const [authorUserId, setAuthorUserId] = useState('')

    const [searchParams] = useSearchParams()

    const populatePlot = (data) => {
        setTitle(data['title'])
        setSequences(data['sequences'])
        setIsPublic(data['isPublic'])
        setAuthorUserId(data['userId'])
    }

    // on page load, this is called, which waits for both LogLineOptions and GetPlot to complete before setting any values (LogLineOptions must populate dropdowns before we can set values)
    useEffect(() => {
        // clean up controller. FROM: https://stackoverflow.com/a/63144665 avoids the error "To fix, cancel all subscriptions and asynchronous tasks in a useEffect cleanup function."
        // eslint-disable-next-line no-unused-vars
        let isSubscribed = true;

        setPlotLoading(true)

        const plotId = searchParams.get("id")
        const authorId = searchParams.get("a")

        Promise.all([
            fetch('/api/GetPlot?id=' + plotId + '&a=' + authorId)
            // other fetches could go here
        ]).then(function (responses) {
            if (responses[0].ok === false) {
                setIsNotFound(true)
            } else {
                // Get a JSON object from each of the responses
                return Promise.all(responses.map(function (response) {
                    return response.json();
                }));
            }
        }).then(function (data) {
            const plotData = data[0]

            populatePlot(plotData)

        }).catch(function (error) {
            // if there's an error, log it
            console.log(error);
        }).finally(function () {
            setPlotLoading(false)
        });

        return () => (isSubscribed = false)
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    return (
        <>
            {
                plotLoading === true && <Spinner animation="border" variant="secondary" />
            }
            {
                isNotFound === true &&
                <>
                    <p>Plot not found! This plot either doesn't exist, the author has not made it public, or your network connection is down. If you are the author, ensure you are logged in.</p>
                </>
            }
            {
                plotLoading === false && isNotFound === false &&
                <div className='row mb-4'>
                    {
                        userInfo && userInfo.userId === authorUserId &&
                        <Link className="nav-link" to={'/plot?id=' + searchParams.get("id")}>Edit your plot</Link>
                    }
                    {
                        userInfo && userInfo.userId === authorUserId && isPublic === false &&
                        <>
                            <p>Only you, the author, can see this because you have not set this plot to be public.</p>
                        </>
                    }
                    <h1 className='pb-4'>{title}</h1>
                    {
                        sequences &&
                        <>
                            <Tabs defaultActiveKey="blurbs" className="mb-3">
                                <Tab eventKey="blurbs" title="Blurbs">
                                    {
                                        sequences.map((sequence) => (
                                            <span key={sequence.sequenceName}>
                                                <p className='fs-5' title={sequence.sequenceName}>{getText(sequence, 'blurb', 'blurbCompletions')}</p>
                                            </span>
                                        ))
                                    }
                                </Tab>
                                <Tab eventKey="expandedSummaries" title="Expanded Summaries">
                                    {
                                        sequences.map((sequence) => (
                                            <span key={sequence.sequenceName}>
                                                <p className='fs-5' title={sequence.sequenceName}>{getText(sequence, 'text', 'completions')}</p>
                                            </span>
                                        ))
                                    }
                                </Tab>
                                {
                                    userInfo && userInfo.userRoles.includes('admin') &&

                                    <Tab eventKey="scenes" title="Scenes">
                                        {
                                            sequences.map((sequence) => (
                                                <span key={sequence.sequenceName}>
                                                    {
                                                        <>
                                                            {
                                                                sequence.scenes && sequence.scenes.length > 0 && sequence.scenes.map((scene) => (
                                                                    <span key={scene.id}>
                                                                        <p className='fs-5' title={sequence.sequenceName}>{getText(scene, 'summary', 'fullsummaryCompletions')}</p>
                                                                    </span>
                                                                ))
                                                            }
                                                        </>
                                                    }
                                                    <p className='fs-5' title={sequence.sequenceName}>{getText(sequence, 'full', 'fullCompletions')}</p>
                                                </span>
                                            ))
                                        }
                                    </Tab>
                                }
                                {
                                    userInfo && userInfo.userRoles.includes('admin') &&
                                    <Tab eventKey="emotions" title="Emotions">
                                        <>
                                        <p>Summed Sequence Emotions</p>
                                        <p>All Scene Emotions</p>
                                        {/* <EmotionsChart
                                        data={data}
                                    /> */}
                                        </>
                                        
                                    </Tab>
                                }
                                <Tab eventKey="all" title="All">
                                    {
                                        sequences.map((sequence) => (
                                            <div className='row border-bottom' key={sequence.sequenceName}>
                                                {
                                                    <>
                                                        <div className='col'>
                                                            <div className='sticky-md-top'>
                                                                <p className='fs-5' title={sequence.sequenceName}>{getText(sequence, 'blurb', 'blurbCompletions')}</p>
                                                            </div>
                                                        </div>
                                                        <div className='col'>
                                                            <div className='sticky-md-top'>
                                                                <p className='fs-5' title={sequence.sequenceName}>{getText(sequence, 'text', 'completions')}</p>

                                                            </div>
                                                        </div>
                                                        {
                                                            userInfo && userInfo.userRoles.includes('admin') &&
                                                            <>
                                                                <div className='col'>
                                                                    <div className='sticky-md-top'>
                                                                        {
                                                                            sequence.scenes && sequence.scenes.length > 0 && sequence.scenes.map((scene) => (
                                                                                <span key={scene.id}>
                                                                                    <p className='fs-5' title={sequence.sequenceName}>{getText(scene, 'summary', 'fullsummaryCompletions')}</p>
                                                                                </span>
                                                                            ))
                                                                        }
                                                                    </div>
                                                                </div>

                                                                <div className='col'>
                                                                    <div className='sticky-md-top'>
                                                                        {
                                                                            sequence.scenes && sequence.scenes.length > 0 && sequence.scenes.map((scene) => (
                                                                                <span key={scene.id}>
                                                                                    <p className='fs-5' style={{ 'whiteSpace': 'pre-line' }} title={sequence.sequenceName}>{scene.full}</p>
                                                                                </span>
                                                                            ))
                                                                        }
                                                                    </div>
                                                                </div>
                                                            </>
                                                        }
                                                    </>
                                                }
                                                <p className='fs-5' title={sequence.sequenceName}>{getText(sequence, 'full', 'fullCompletions')}</p>
                                            </div>
                                        ))
                                    }
                                </Tab>
                            </Tabs>

                        </>
                    }
                </div>
            }
        </>
    )
}

export default PlotView