import React, { useState, useEffect } from 'react'
import { useNavigate } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import { isNullOrEmpty } from '../../../../util/Helpers';
import { fetchData } from '../../../../util/FetchUtil';

const ProblemTemplateAdvice = (
    {
        problemTemplate,
        showHeader
    }
) => {

    const navigate = useNavigate()

    const [isLoading, setIsLoading] = useState(false)
    const [data, setData] = useState(null)

    const load = async () => {
        if (isNullOrEmpty(problemTemplate)) return

        const url = '/api/LogLine/ProblemTemplateDescription?problemTemplate=' + problemTemplate

        fetchData(url, setIsLoading, setData, navigate)
    }

    useEffect(() => {
        load()
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [problemTemplate]);

    const keywordsList = !data ? <></> : data.keywords.map((word) =>
        <li key={word}>{word}</li>
    );

    return (
        <div>
            {
                isLoading === true && <Spinner animation="border" variant="secondary" />
            }
            {
                !isNullOrEmpty(data) &&
                <>
                    {
                        showHeader &&
                        <h2>{data.name}</h2>
                    }

                    <p>{data.description}</p>
                    <figure className="list-to-comma-str">
                        <figcaption>Keywords</figcaption>
                        <ul>
                            {
                                keywordsList
                            }
                        </ul>
                    </figure>
                    <p>Hero's initial attitude is <strong>{data.wandererAdjectives.heroAdjective}</strong> while the enemy is <strong>{data.wandererAdjectives.enemyAdjective}</strong>.</p>
                    <p>Although faltering, Hero moves toward <strong>{data.warriorAdjectives.heroAdjective}</strong> while the enemy becomes <strong>{data.warriorAdjectives.enemyAdjective}</strong>.</p>
                    <p>At the end, Hero is consistently <strong>{data.martyrAdjectives.heroAdjective}</strong> while the enemy reverts to <strong>{data.martyrAdjectives.enemyAdjective}</strong>.</p>
                </>
            }
        </div >
    )
}

export default ProblemTemplateAdvice