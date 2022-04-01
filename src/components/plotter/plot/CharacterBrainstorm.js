import React, { useState, useEffect } from 'react'
import { useNavigate } from "react-router-dom";
import { FaGhost, FaCog } from 'react-icons/fa'
import Accordion from 'react-bootstrap/Accordion';
import Spinner from 'react-bootstrap/Spinner';
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'
import Carousel from 'react-bootstrap/Carousel'
import GenresDescription from './GenresDescription'
import ProblemTemplateDescription from './ProblemTemplateDescription'
import DramaticQuestionDescription from './DramaticQuestionDescription'
import { fetchWithTimeout } from '../../../util/FetchUtil'
//import 'react-bootstrap-range-slider/dist/react-bootstrap-range-slider.css';
//import RangeSlider from 'react-bootstrap-range-slider';

const CharacterBrainstorm = (
    {
        userInfo,
        character
    }
) => {

    const navigate = useNavigate()
    const [isCompletionLoading, setIsCompletionLoading] = useState(false)
    const [completionText, setCompletionText] = useState(false)

    const fetchCompletion = async () => {
        setIsCompletionLoading(true)

        fetchWithTimeout('/api/Character/Generate', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(character)
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
            console.log(data)
            setCompletionText(data['completion'])

        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server. Please wait a few minutes and try again.');
        }).finally(function () {
            setIsCompletionLoading(false)
        });
    }

    return (
        <div>
            {
                isCompletionLoading === true && <Spinner animation="border" variant="secondary" />
            }
            {
                isCompletionLoading === false &&
                <>
                    <p>{completionText}</p>
                    <button disabled={isCompletionLoading} type="button" className="btn btn-info mt-2" onClick={fetchCompletion}>
                        <FaGhost />
                        <span> New AI Brainstorm</span>
                    </button>
                </>
            }

        </div>
    )
}

export default CharacterBrainstorm