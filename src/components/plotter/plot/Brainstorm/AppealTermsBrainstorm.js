import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { FaGhost } from 'react-icons/fa'
import Spinner from 'react-bootstrap/Spinner';
import { fetchData } from '../../../../util/FetchUtil'
const AppealTermsBrainstorm = (
    {
        genres
    }
) => {

    const navigate = useNavigate()

    const [isLoading, setIsLoading] = useState(false)
    const [brainstormedAppealTerms, setBrainstormedAppealTerms] = useState([])

    const onGenerateAppealTerms = async () => {
        setIsLoading(true)
        fetchAppealTerms()
    }

    const getRandomInt = (min, max) => {
        min = Math.ceil(min);
        max = Math.floor(max);
        return Math.floor(Math.random() * (max - min) + min); // The maximum is exclusive and the minimum is inclusive
    }

    const fetchAppealTerms = async () => {

        const randNum = getRandomInt(2,4)

        const url = '/api/LogLine/AppealTermsRandom?genres=' + genres.join(',') + '&numAppealTerms=' + randNum

        fetchData(url, setIsLoading, setBrainstormedAppealTerms, navigate)
    }

    const appealTermsListItems = (brainstormedAppealTerms ?? []).map((appealTerm, idx) =>
        <li key={idx}>
            <strong>{appealTerm['name']}</strong> - {appealTerm['description']}
        </li>
    )

    return (

        <>
            <p>Genre-appropriate {!genres ? '' : ('(' + genres.join(', ') + ')')} appeal terms this story focuses on.</p>

            <ul>
                {
                    appealTermsListItems
                }
            </ul>
            <button disabled={isLoading} title='Generate ' type="button" className="btn btn-info mt-2" onClick={onGenerateAppealTerms}>
                {
                    isLoading === true &&
                    <Spinner size="sm" as="span" animation="border" variant="secondary" />
                }
                {
                    isLoading === false &&
                    <FaGhost />
                }
                <span> New Appeal Terms Brainstorm</span>
            </button>
        </>

    )
}

export default AppealTermsBrainstorm