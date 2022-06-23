import React, { useState, useEffect } from 'react'
import { useNavigate } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import { isNullOrEmpty } from '../../../../util/Helpers';
import { fetchData } from '../../../../util/FetchUtil';

const DramaticQuestionAdvice = (
    {
        dramaticQuestion,
        showHeader,
    }
) => {

    const navigate = useNavigate()

    const [isLoading, setIsLoading] = useState(false)
    const [data, setData] = useState(null)

    const load = async () => {
        if (isNullOrEmpty(dramaticQuestion)) return

        const url = '/api/LogLine/DramaticQuestionDescription?dramaticQuestion=' + dramaticQuestion

        fetchData(url, setIsLoading, setData, navigate)
    }

    useEffect(() => {
        load()
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [dramaticQuestion]);

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

                    <p><strong>{data.description}</strong></p>
                    <p>As the Hero moves through the 4 stages of character growth (orphan, wanderer, warrior, martyr), different aspects of the theme are presented.</p>
                    <ol>
                        <li>Contrary: <strong>{data.contrary}</strong> - <em>better than the Contradiction, but still not Positive</em></li>
                        <li>Contradiction: <strong>{data.contradiction}</strong> - <em>opposite of the Positive</em></li>
                        <li>Negation: <strong>{data.negation}</strong> - <em>darkest depths, extreme perversion of the Positive</em></li>
                        <li>Positive: <strong>{data.positive}</strong> - <em>primary value at stake</em></li>
                    </ol>
                </>
            }
        </div >
    )
}

export default DramaticQuestionAdvice