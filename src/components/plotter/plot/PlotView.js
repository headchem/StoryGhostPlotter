import React, { useState, useEffect } from 'react'
import { useSearchParams } from "react-router-dom";


const PlotView = (
    {
        userInfo,
    }
) => {

    console.log(userInfo)

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
                plotLoading === true && <p>loading...</p>
            }
            {
                isNotFound === true &&
                <>
                    <p>This plot either doesn't exist, or the author has not made it public.</p>
                </>
            }
            {/* {
                userInfo && userInfo.
            } */}
            {
                plotLoading === false && isNotFound === false &&
                <div className='row mb-4'>
                    {
                        userInfo && userInfo.userId === authorUserId && isPublic === false &&
                        <>
                            <p>Only you the author can see this because you have not set this plot to be public.</p>
                        </>
                    }
                    <h1 className='pb-4'>{title}</h1>
                    {
                        sequences &&
                        <>
                            {
                                sequences.map((sequence) => (
                                    <p key={sequence.sequenceName} className='fs-5'>{sequence.text}</p>
                                ))
                            }
                        </>
                    }
                </div>
            }
        </>
    )
}

export default PlotView