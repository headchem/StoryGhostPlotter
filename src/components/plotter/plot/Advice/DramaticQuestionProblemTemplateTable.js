import React, { useState, useEffect } from 'react'
import { useNavigate } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import { isNullOrEmpty } from '../../../../util/Helpers';
import { fetchData } from '../../../../util/FetchUtil';

const DramaticQuestionProblemTemplateTable = (
    {
        problemTemplate,
        dramaticQuestion
    }
) => {

    const navigate = useNavigate()

    const [isProblemTemplateLoading, setProblemTemplateIsLoading] = useState(false)
    const [problemTemplateData, setProblemTemplateData] = useState(null)

    const [isDramaticQuestionLoading, setDramaticQuestionIsLoading] = useState(false)
    const [dramaticQuestionData, setDramaticQuestionData] = useState(null)

    const loadProblemTemplate = async () => {
        if (isNullOrEmpty(problemTemplate)) return

        const url = '/api/LogLine/ProblemTemplateDescription?problemTemplate=' + problemTemplate

        fetchData(url, setProblemTemplateIsLoading, setProblemTemplateData, navigate)
    }

    const loadDramaticQuestion = async () => {
        if (isNullOrEmpty(dramaticQuestion)) return

        const url = '/api/LogLine/DramaticQuestionDescription?dramaticQuestion=' + dramaticQuestion

        fetchData(url, setDramaticQuestionIsLoading, setDramaticQuestionData, navigate)
    }

    useEffect(() => {
        loadProblemTemplate()
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [problemTemplate]);

    useEffect(() => {
        loadDramaticQuestion()
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [dramaticQuestion]);

    return (
        <>
            {
                (isProblemTemplateLoading === true || isDramaticQuestionLoading) && <Spinner animation="border" variant="secondary" />
            }
            {
                (isProblemTemplateLoading === false && isDramaticQuestionLoading === false && problemTemplateData && dramaticQuestionData) &&
                <>
                    <div className='row pt-5'>
                        <div className='col-12'>
                            <p>As the story progresses, the Hero and Enemy will move through the following phases:</p>
                        </div>
                    </div>
                    <div className="card-group">

                        <div className="card">
                            <div className="card-body bg-danger">
                                Hero: {problemTemplateData.wandererAdjectives.heroAdjective}
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body bg-warning">
                                Hero: {problemTemplateData.warriorAdjectives.heroAdjective}
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body bg-success">
                                Hero: {problemTemplateData.martyrAdjectives.heroAdjective}
                            </div>
                        </div>
                    </div>

                    <div className="card-group">

                        <div className="card">
                            <div className="card-body bg-info">
                                Hero: {dramaticQuestionData.contrary}
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body bg-warning">
                                Hero: {dramaticQuestionData.contradiction}
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body bg-danger">
                                Hero: {dramaticQuestionData.negation}
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body bg-success">
                                Hero: {dramaticQuestionData.positive}
                            </div>
                        </div>
                    </div>

                    <div className="card-group">

                        <div className="card">
                            <div className="card-body bg-success">
                                Enemy: {problemTemplateData.wandererAdjectives.enemyAdjective}
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body bg-danger">
                                Enemy: {problemTemplateData.warriorAdjectives.enemyAdjective}
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body bg-success">
                                Enemy: {problemTemplateData.martyrAdjectives.enemyAdjective}
                            </div>
                        </div>
                    </div>

                </>
            }
        </>
    )
}

export default DramaticQuestionProblemTemplateTable