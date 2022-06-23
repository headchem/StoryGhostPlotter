import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import SimpleSequenceList from '../SimplePages/SimpleSequenceList'

const Page5 = (
    {
        userInfo,
        plotId,
        logLineDescription,
        genres,
        problemTemplate,
        dramaticQuestion,
        keywords,
        sequences,
        characters,
        setSequences,
        updateSequenceCompletions,
        heroCharacterArchetype,
        editCompletion
    }
) => {

    const [isNewSequencesLoading, setIsNewSequencesLoading] = useState(false)
    const [showConfirmNewGame, setShowConfirmNewGame] = useState(false)

    const navigate = useNavigate()

    const generateNewSequences = () => {
        // call Sequence/GetRandomSequenceList then setSequences with new blank sequences

        setIsNewSequencesLoading(true)

        fetch('/api/Sequence/GetRandomSequenceList?upToTargetSequenceExclusive=All', {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
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
            setSequences(data)
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server or you have run out of tokens');
        }).finally(function () {
            setIsNewSequencesLoading(false)
            setShowConfirmNewGame(false)
        });
    }

    return (
        <>
            <div className="row">
                <div className='col-12'>
                    <p>Start with 1-2 sentences that describe the minimum logical events of each sequence. These are meant to be dry and nearly devoid of emotion. Focus on the mechanics of what happens.</p>

                    {
                        isNewSequencesLoading === true &&
                        <Spinner size="sm" as="span" animation="border" variant="secondary" />
                    }
                    {
                        isNewSequencesLoading === false &&
                        <>
                            {
                                showConfirmNewGame === false &&
                                <button className='btn btn-primary mb-5' onClick={() => setShowConfirmNewGame(true)}>Start Story</button>
                            }
                            {
                                showConfirmNewGame === true &&
                                <>
                                    <p>Are you sure? This will delete all text from existing sequences.</p>
                                    <button className='btn btn-link me-3' onClick={() => setShowConfirmNewGame(false)}>Cancel</button>
                                    <button className='btn btn-danger' onClick={generateNewSequences}>Yes, delete all sequences</button>
                                </>
                            }
                            {
                                userInfo && userInfo.userRoles.includes('customer') &&
                                <p>Generate choices, then click on the choice that best meets the sequence advice.</p>
                            }

                        </>
                    }
                </div>

            </div>
            {
                <SimpleSequenceList
                    userInfo={userInfo}
                    plotId={plotId}
                    logLineDescription={logLineDescription}
                    genres={genres}
                    problemTemplate={problemTemplate}
                    dramaticQuestion={dramaticQuestion}
                    keywords={keywords}
                    sequences={sequences}
                    characters={characters}
                    updateSequenceCompletions={updateSequenceCompletions}
                    heroCharacterArchetype={heroCharacterArchetype}
                    textPropName={'blurb'}
                    completionsPropName={'blurbCompletions'}
                    completionURL={'GenerateBlurb'}
                    editCompletion={editCompletion}
                />
            }
        </>
    )
}

export default Page5