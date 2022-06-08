import React, { useState, useEffect } from 'react'
import { useNavigate } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import GenresDescription from './GenresDescription'
import ProblemTemplateDescription from './ProblemTemplateDescription'
import DramaticQuestionDescription from './DramaticQuestionDescription'
import KeywordsBrainstorm from './Brainstorm/KeywordsBrainstorm'
import TitleBrainstorm from './Brainstorm/TitleBrainstorm';
import LogLineDescriptionBrainstorm from './Brainstorm/LogLineDescriptionBrainstorm'

const LogLineObjDetails = (
    {
        userInfo,
        plotId,
        onKeywordsChange,
        logLineDescription,
        updateLogLineDescription,
        AILogLineDescriptions,
        AITitles,
        updateLogLineDescriptionCompletions,
        curFocusElName,
        genres,
        problemTemplate,
        dramaticQuestion,
        keywords,
        setAITitles,
        tokensRemaining
    }
) => {

    const navigate = useNavigate()

    const [descIsLoading, setDescIsLoading] = useState(false)
    const [genresDescObjs, setGenresDescObjs] = useState(null)
    const [problemTemplateDescObj, setProblemTemplateDescObj] = useState(null)
    const [dramaticQuestionDescObj, setDramaticQuestionDescObj] = useState(null)

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        loadDescObj(curFocusElName)

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [curFocusElName, genres, problemTemplate, dramaticQuestion]);

    const isNullOrEmpty = (val) => {
        if (val === undefined) return true
        if (val === null) return true
        if (val === '') return true
        if (val.length === 0) return true

        return false
    }

    const loadDescObj = async (elName) => {
        let url = ''

        if (elName === 'genres' && !isNullOrEmpty(genres)) {
            url = '/api/LogLine/GenresDescription?genres=' + genres.join(',')
        } else if (elName === 'problem template' && !isNullOrEmpty(problemTemplate)) {
            url = '/api/LogLine/ProblemTemplateDescription?problemTemplate=' + problemTemplate
        } else if (elName === 'dramatic question' && !isNullOrEmpty(dramaticQuestion)) {
            url = '/api/LogLine/DramaticQuestionDescription?dramaticQuestion=' + dramaticQuestion
        }

        if (url !== '') {
            setDescIsLoading(true)

            fetch(url)
                .then(function (response) {
                    if (response.status === 401 || response.status === 403) {
                        navigate('/plots')
                    } else {
                        if (response.ok) {
                            return response.json();
                        }
                    }
                    return Promise.reject(response);
                }).then(function (data) {

                    if (elName === 'genres') {
                        setGenresDescObjs(data)
                    } else if (elName === 'problem template') {
                        setProblemTemplateDescObj(data)
                    } else if (elName === 'dramatic question') {
                        setDramaticQuestionDescObj(data)
                    }
                }).catch(function (error) {
                    console.warn(error);
                }).finally(function () {
                    setDescIsLoading(false)
                });
        }
    }

    return (
        <div>
            {
                descIsLoading === true && <Spinner animation="border" variant="secondary" />
            }
            {
                descIsLoading === false &&
                <>
                    {
                        (curFocusElName === 'genres' && genresDescObjs !== null) &&
                        <GenresDescription
                            genresDescObjs={genresDescObjs}
                        />
                    }
                    {
                        curFocusElName === 'keywords' &&
                        <KeywordsBrainstorm
                            keywords={keywords}
                            onKeywordsChange={onKeywordsChange}
                            userInfo={userInfo}
                            genres={genres}
                        />
                    }
                    {
                        (curFocusElName === 'logLineDescription') &&
                        <LogLineDescriptionBrainstorm
                            userInfo={userInfo}
                            plotId={plotId}
                            completions={AILogLineDescriptions}
                            updateLogLineDescription={updateLogLineDescription}
                            updateLogLineDescriptionCompletions={updateLogLineDescriptionCompletions}
                            genres={genres}
                            keywords={keywords}
                            tokensRemaining={tokensRemaining}
                        />
                    }
                    {
                        curFocusElName === 'title' &&
                        <TitleBrainstorm
                            userInfo={userInfo}
                            plotId={plotId}
                            AITitles={AITitles}
                            logLineDescription={logLineDescription}
                            genres={genres}
                            setAITitles={setAITitles}
                            tokensRemaining={tokensRemaining}
                        />
                    }

                    {
                        (curFocusElName === 'problem template' && problemTemplateDescObj) &&
                        <ProblemTemplateDescription
                            problemTemplateDescObj={problemTemplateDescObj}
                        />
                    }
                    {
                        (curFocusElName === 'dramatic question' && dramaticQuestionDescObj) &&
                        <DramaticQuestionDescription
                            dramaticQuestionDescObj={dramaticQuestionDescObj}
                        />
                    }
                </>
            }
        </div>
    )
}

export default LogLineObjDetails