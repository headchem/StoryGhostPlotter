import React, { useState, useEffect } from 'react'
import { useNavigate } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import { isNullOrEmpty } from '../../../../util/Helpers';
import { fetchData } from '../../../../util/FetchUtil';

const AppealTermsAdvice = (
    {
        appealTerms
    }
) => {

    const navigate = useNavigate()

    const [isLoading, setIsLoading] = useState(false)
    const [data, setData] = useState(null)

    const load = async () => {
        if (isNullOrEmpty(appealTerms)) return

        const url = '/api/LogLine/AppealTermsDescription?appealTerms=' + appealTerms.join(',')

        fetchData(url, setIsLoading, setData, navigate)
    }

    useEffect(() => {
        load()
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [appealTerms]);

    return (
        <div>
            {
                isLoading === true && <Spinner animation="border" variant="secondary" />
            }
            {
                !isNullOrEmpty(data) &&
                data.map((appealTermObj) => (
                    <div key={appealTermObj.name}>
                        <h3>{appealTermObj.name}</h3>
                        <p>{appealTermObj.description}</p>
                    </div>
                ))
            }
        </div >
    )
}

export default AppealTermsAdvice