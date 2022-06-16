import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import { isNullOrEmpty } from '../../../../util/Helpers';
import SimpleSequence from './SimpleSequence'
import SequenceAdvice from '../Advice/SequenceAdvice'

const Page5 = (
    {
        plotId,
        logLineDescription,
        genres,
        problemTemplate,
        dramaticQuestion,
        keywords,
        sequences,
        characters,
        setSequences,
        //updateBlurb,
        updateSequenceCompletions,
        heroCharacterArchetype,
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

    const simpleSequenceRows = sequences.map((sequence, idx) => {
        // only show this sequence if: it's the Opening Image, or the previous sequence either has a blurb or has a selected brainstorm
        const isOpeningImage = idx === 0
        const prevSequence = isOpeningImage ? sequences[0] : sequences[idx - 1]
        const prevBlurbNotEmpty = isNullOrEmpty(prevSequence['blurb']) === false
        const prevSeqHasSelectedBrainstorm = !prevSequence['blurbCompletions'] ? false : prevSequence['blurbCompletions'].filter(brainstorm => brainstorm['isSelected'] === true).length > 0
        const showCurSequence = isOpeningImage || prevBlurbNotEmpty || prevSeqHasSelectedBrainstorm

        if (showCurSequence && sequences && sequences.length > 1) {
            return <div className='row pb-5' key={sequence['sequenceName']}>
                <div className='col-8'>
                    <SimpleSequence
                        plotId={plotId}
                        targetSequence={sequence['sequenceName']}
                        logLineDescription={logLineDescription}
                        genres={genres}
                        problemTemplate={problemTemplate}
                        dramaticQuestion={dramaticQuestion}
                        keywords={keywords}
                        sequences={sequences}
                        characters={characters}
                        //setSequences={setSequences}
                        //updateBlurb={updateBlurb}
                        updateSequenceCompletions={updateSequenceCompletions}
                    />
                </div>
                <div className='col-4'>
                    <SequenceAdvice
                        sequenceName={sequence.sequenceName}
                        genres={genres}
                        problemTemplate={problemTemplate}
                        keywords={keywords}
                        heroCharacterArchetype={heroCharacterArchetype}
                        dramaticQuestion={dramaticQuestion}
                    />
                </div>
            </div>
        }
        return null
    }
    );

    return (
        <>
            <div className="row">
                <div className='col-12'>
                    {
                        isNewSequencesLoading === true &&
                        <Spinner size="sm" as="span" animation="border" variant="secondary" />
                    }
                    {
                        isNewSequencesLoading === false &&
                        <>
                            {
                                showConfirmNewGame === false &&
                                <button className='btn btn-primary mb-5' onClick={() => setShowConfirmNewGame(true)}>Start Game</button>
                            }
                            {
                                showConfirmNewGame === true &&
                                <>
                                    <p>Are you sure? This will delete all text from existing sequences.</p>
                                    <button className='btn btn-link me-3' onClick={() => setShowConfirmNewGame(false)}>Cancel</button>
                                    <button className='btn btn-danger' onClick={generateNewSequences}>Yes, delete all sequences</button>
                                </>
                            }
                            <p>Generate choices, then click on the choice that best meets the sequence advice.</p>
                        </>
                    }
                </div>

            </div>
            {
                simpleSequenceRows
            }
        </>
    )
}

export default Page5