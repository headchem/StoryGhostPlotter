import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import { isNullOrEmpty } from '../../../../util/Helpers';
import SimpleSequence from './SimpleSequence'

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
        updateBlurb,
        updateSequenceCompletions,
    }
) => {

    const [isNewSequencesLoading, setIsNewSequencesLoading] = useState(false)

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
            console.log(data)
            setSequences(data)
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server or you have run out of tokens');
        }).finally(function () {
            setIsNewSequencesLoading(false)
        });
    }

    const simpleSequences = sequences.map((sequence, idx) => {
        if (idx === 0 || isNullOrEmpty(sequences[idx - 1]['blurb']) === false) {
            return <SimpleSequence
                key={sequence['sequenceName']}
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
                updateBlurb={updateBlurb}
                updateSequenceCompletions={updateSequenceCompletions}
            />
        }
        return <></>
    }
    );

    return (
        <>
            <div className="row">
                <div className='col-8'>
                    {
                        simpleSequences
                    }
                </div>
                <div className='col-4'>
                    {
                        isNewSequencesLoading === true &&
                        <Spinner size="sm" as="span" animation="border" variant="secondary" />
                    }
                    {
                        isNewSequencesLoading === false &&
                        <button className='btn btn-primary float-end' onClick={generateNewSequences}>Start Game (warning: clears all values)</button>
                    }
                </div>

            </div>
        </>
    )
}

export default Page5