import React, { useState, useEffect } from 'react'
import { useNavigate } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import { isNullOrEmpty } from '../../../../util/Helpers';
import { fetchData } from '../../../../util/FetchUtil';

const DramaticQuestionProblemTemplateTable = (
    {
        showExplanation,
        problemTemplate,
        dramaticQuestion,
        heroName,
        heroArchetype
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

    const heroLabel = isNullOrEmpty(heroName) ? 'Hero' : heroName

    return (
        <>
            {
                (isProblemTemplateLoading === true || isDramaticQuestionLoading) && <Spinner animation="border" variant="secondary" />
            }
            {
                (isProblemTemplateLoading === false && isDramaticQuestionLoading === false && problemTemplateData && dramaticQuestionData) &&
                <>
                    {
                        showExplanation &&
                        <div className='row'>
                            <div className='col-12'>
                                <p>Problem Template: <strong>{problemTemplateData['name']}</strong>, Dramatic Question: <strong>{dramaticQuestionData['name']}</strong>.</p>
                                <p>As the story progresses, the Hero and Enemy will move through the following phases:</p>
                            </div>
                        </div>
                    }
                    {
                        heroArchetype &&
                        <div className="card-group">
                            <div className="card">
                                <div className="card-body bg-info">
                                    {heroLabel} ({heroArchetype['name']}): {heroArchetype['orphanDesires']}
                                </div>
                            </div>
                            <div className="card">
                                <div className="card-body bg-warning">
                                    {heroLabel} ({heroArchetype['name']}): {heroArchetype['wandererResponse']}
                                </div>
                            </div>
                            <div className="card">
                                <div className="card-body bg-danger">
                                    {heroLabel} ({heroArchetype['name']}): {heroArchetype['shadowSide']}
                                </div>
                            </div>
                            <div className="card">
                                <div className="card-body bg-success">
                                    {heroLabel} ({heroArchetype['name']}): {heroArchetype['warriorResponse']}
                                </div>
                            </div>
                        </div>
                    }


                    <div className="card-group">

                        <div className="card">
                            <div className="card-body bg-danger">
                                {heroLabel} ({problemTemplateData['name']}): {problemTemplateData.wandererAdjectives.heroAdjective}
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body bg-warning">
                                {heroLabel} ({problemTemplateData['name']}): {problemTemplateData.warriorAdjectives.heroAdjective}
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body bg-success">
                                {heroLabel} ({problemTemplateData['name']}): {problemTemplateData.martyrAdjectives.heroAdjective}
                            </div>
                        </div>
                    </div>

                    <div className="card-group">

                        <div className="card">
                            <div className="card-body bg-info">
                                {heroLabel} ({dramaticQuestionData['name']}): {dramaticQuestionData.contrary}
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body bg-warning">
                                {heroLabel} ({dramaticQuestionData['name']}): {dramaticQuestionData.contradiction}
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body bg-danger">
                                {heroLabel} ({dramaticQuestionData['name']}): {dramaticQuestionData.negation}
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body bg-success">
                                {heroLabel} ({dramaticQuestionData['name']}): {dramaticQuestionData.positive}
                            </div>
                        </div>
                    </div>

                    <div className="card-group">

                        <div className="card">
                            <div className="card-body bg-danger">
                                Enemy ({problemTemplateData['name']}): {problemTemplateData.wandererAdjectives.enemyAdjective}
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body bg-success">
                                Enemy ({problemTemplateData['name']}): {problemTemplateData.warriorAdjectives.enemyAdjective}
                            </div>
                        </div>
                        <div className="card">
                            <div className="card-body bg-danger">
                                Enemy ({problemTemplateData['name']}): {problemTemplateData.martyrAdjectives.enemyAdjective}
                            </div>
                        </div>
                    </div>

                </>
            }
        </>
    )
}

export default DramaticQuestionProblemTemplateTable