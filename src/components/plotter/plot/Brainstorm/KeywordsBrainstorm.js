import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import { FaGhost, FaCopy } from 'react-icons/fa'
import Spinner from 'react-bootstrap/Spinner';
import { fetchData } from '../../../../util/FetchUtil'
const KeywordsBrainstorm = (
    {
        keywords,
        onKeywordsChange,
        genres
    }
) => {

    const navigate = useNavigate()

    const [isKeywordsLoading, setIsKeywordsLoading] = useState(false)
    const [aiKeywords, setAIKeywords] = useState([])

    const onGenerateKeywords = async () => {
        setIsKeywordsLoading(true)
        fetchKeywords()
    }

    const fetchKeywords = async () => {
        const url = '/api/Keywords?genres=' + genres.join(',') + '&numKeywords=7'

        fetchData(url, setIsKeywordsLoading, setAIKeywords, navigate)
    }

    const addKeyword = (keyword) => {
        if (keywords.indexOf(keyword) === -1) {
            const newKeywords = [...keywords.map(k => ({ 'label': k, 'value': k })), { 'label': keyword, 'value': keyword }]
            onKeywordsChange(newKeywords)
        }
    }

    const aiKeywordsListItems = (aiKeywords ?? []).map((keyword, idx) =>
        <li key={idx}>
            {keyword} <button title="add keyword" className="btn btn-link" onClick={() => addKeyword(keyword)}><FaCopy /></button>
        </li>
    )

    return (

        <>
            <p>Genre-appropriate {!genres ? '' : ('(' + genres.join(', ') + ')')} keywords and concepts this story focuses on.</p>

            <ul>
                {
                    aiKeywordsListItems
                }
            </ul>
            <button disabled={isKeywordsLoading} title='Generate ' type="button" className="btn btn-info mt-2" onClick={onGenerateKeywords}>
                {
                    isKeywordsLoading === true &&
                    <Spinner size="sm" as="span" animation="border" variant="secondary" />
                }
                {
                    isKeywordsLoading === false &&
                    <FaGhost />
                }
                <span> New Keywords Brainstorm</span>
            </button>
        </>

    )
}

export default KeywordsBrainstorm