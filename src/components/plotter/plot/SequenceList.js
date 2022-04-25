import React, { useState } from 'react'
import { useNavigate } from "react-router-dom";
import Sequence from './Sequence'
import { fetchWithTimeout } from '../../../util/FetchUtil'
import Spinner from 'react-bootstrap/Spinner';

const SequenceList = ({
    sequences,
    userInfo,
    logLineDescription,
    updateSequenceEventsText,
    insertSequence,
    deleteSequence,
    genres,
    problemTemplate,
    keywords,
    characters,
    dramaticQuestion,
    updateSequenceCompletions,
    setSequences
}) => {

    const navigate = useNavigate()

    const [showConfirmReplaceAll, setShowConfirmReplaceAll] = useState(false)
    const [isReplaceAllLoading, setIsReplaceAllLoading] = useState(false)

    // given all the existing sequences, choose the allowed next sequences. For example, if we already have [Opening Image] then the allowed next sequences can only be [Setup, Theme Stated]. If we start with [Opening Image, Setup] then the only allowed next sequences are [Theme Stated, Catalyst]
    const getAllowedNextSequenceNames = (curSequenceName, existingSequences) => {
        const existingSequenceNamesArr = existingSequences.map((seq) => seq.sequenceName)
        const existingSequenceNames = new Set(existingSequenceNamesArr)
        let allowedSequenceNames = []

        switch (curSequenceName) {
            case 'Opening Image':
                allowedSequenceNames = ['Setup', 'Theme Stated']
                break;
            case 'Setup':
                allowedSequenceNames = ['Theme Stated', 'Catalyst']
                break;
            case 'Theme Stated':
                allowedSequenceNames = ['Setup', 'Setup (Continued)', 'B Story', 'Catalyst', 'Debate', 'Debate (Continued)', 'Break Into Two']
                break;
            case 'Setup (Continued)':
                allowedSequenceNames = ['Catalyst', 'Debate', 'Debate (Continued)', 'Fun And Games']
                break;
            case 'Catalyst':
                allowedSequenceNames = ['B Story', 'Debate', 'Theme Stated']
                break;
            case 'Debate':
                allowedSequenceNames = ['Break Into Two', 'B Story', 'Theme Stated']
                break;
            case 'B Story':
                allowedSequenceNames = ['Theme Stated', 'Debate', 'Debate (Continued)', 'Setup', 'Setup (Continued)', 'Catalyst', 'Fun And Games', 'Break Into Two']
                break;
            case 'Debate (Continued)':
                allowedSequenceNames = ['Break Into Two', 'B Story', 'Theme Stated', 'Fun And Games']
                break;
            case 'Break Into Two':
                allowedSequenceNames = ['Fun And Games', 'B Story']
                break;
            case 'Fun And Games':
                allowedSequenceNames = ['Midpoint', 'First Pinch Point']
                break;
            case 'First Pinch Point':
                allowedSequenceNames = ['Midpoint']
                break;
            case 'Midpoint':
                allowedSequenceNames = ['Bad Guys Close In']
                break;
            case 'Bad Guys Close In':
                allowedSequenceNames = ['All Hope Is Lost', 'Second Pinch Point']
                break;
            case 'Second Pinch Point':
                allowedSequenceNames = ['All Hope Is Lost']
                break;
            case 'All Hope Is Lost':
                allowedSequenceNames = ['Dark Night Of The Soul']
                break;
            case 'Dark Night Of The Soul':
                allowedSequenceNames = ['Break Into Three']
                break;
            case 'Break Into Three':
                allowedSequenceNames = ['Climax']
                break;
            case 'Climax':
                allowedSequenceNames = ['Cooldown']
                break;
            case 'Cooldown':
                allowedSequenceNames = []
                break;
            default:
                console.error('unhandled fallthrough case for allowed next sequences: "' + curSequenceName + '"');
        }

        if (curSequenceName !== 'Opening Image') {
            // filter out entries if their requirements don't appear before the curSequenceName
            const curSeqIndex = existingSequenceNamesArr.indexOf(curSequenceName)
            const prevSeqsArr = existingSequenceNamesArr.slice(0, curSeqIndex + 1) // +1 to include self
            const prevSeqs = new Set(prevSeqsArr)

            //console.log('curSequenceName: ' + curSequenceName + ', original allowedSequenceNames: ' + allowedSequenceNames + ', prevSeqsArr: ' + prevSeqsArr)

            // for each allowed Seq, check if that seq's prereq exists in prevSeqs
            allowedSequenceNames = allowedSequenceNames.filter(seqName => prevSeqs.has(seqTemporalDeps[seqName]))
        }

        // remove any sequences that have already been used
        allowedSequenceNames = allowedSequenceNames.filter(seqName => !existingSequenceNames.has(seqName))

        return allowedSequenceNames;
    }

    // only allow creating a new Sequence of the key if the value has already occurred in the list of sequences prior to the current key
    const seqTemporalDeps = {
        'Opening Image': [],
        'Setup': 'Opening Image',
        'Theme Stated': 'Opening Image',
        'Setup (Continued)': 'Setup',
        'Catalyst': 'Setup',
        'Debate': 'Catalyst',
        'B Story': 'Setup',
        'Debate (Continued)': 'Debate',
        'Break Into Two': 'Debate',
        'Fun And Games': 'Debate',
        'First Pinch Point': 'Fun And Games',
        'Midpoint': 'Fun And Games',
        'Bad Guys Close In': 'Midpoint',
        'Second Pinch Point': 'Bad Guys Close In',
        'All Hope Is Lost': 'Bad Guys Close In',
        'Dark Night Of The Soul': 'All Hope Is Lost',
        'Break Into Three': 'Dark Night Of The Soul',
        'Climax': 'Break Into Three',
        'Cooldown': 'Climax',
    }

    const generateAll = () => {
        console.log('generate all')
        setIsReplaceAllLoading(true)

        fetchWithTimeout('/api/Sequence/GenerateAll', {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                logLineDescription: logLineDescription,
                genres: genres,
                problemTemplate: problemTemplate,
                dramaticQuestion: dramaticQuestion,
                keywords: keywords,
                sequences: sequences,
                characters: characters,
            })
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
            console.log('save this data:')
            console.log(data)
            setSequences(data)
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server. Please wait a few minutes and try again.');
        }).finally(function () {
            setIsReplaceAllLoading(false)
            setShowConfirmReplaceAll(false)
        });
    }


    return (
        <>
            <div className='row'>
                <div className="col alert alert-warning" role="alert">
                    {
                        isReplaceAllLoading === true &&
                        <>
                            <Spinner animation="border" variant="secondary" />
                            <p>This may take 1-2 minutes...</p>
                        </>
                    }
                    {
                        isReplaceAllLoading === false &&
                        <>
                            {
                                showConfirmReplaceAll === false &&
                                <button className='btn btn-warning' onClick={() => { setShowConfirmReplaceAll(true) }}>Delete and Regenerate All Sequences</button>
                            }
                            {
                                showConfirmReplaceAll === true &&
                                <>
                                    <p>Are you sure?</p>
                                    <button className='btn btn-warning me-3' onClick={() => setShowConfirmReplaceAll(false)}>Cancel</button>
                                    <button className='btn btn-danger' onClick={generateAll}>Yes, delete all and replace with a new story</button>
                                </>
                            }

                            <p className='mt-3'>Caution! This will generate a new complete story, <strong>permanently deleting all existing sequences and sequence brainstorms.</strong> You will be prompted to confirm.</p>
                        </>
                    }
                </div>
            </div>
            {
                sequences
                    .map((sequence) => (
                        <Sequence
                            key={sequence.sequenceName}
                            userInfo={userInfo}
                            sequence={sequence}
                            sequences={sequences}
                            updateEventsText={updateSequenceEventsText}

                            insertSequence={insertSequence}
                            deleteSequence={deleteSequence}

                            allowed={getAllowedNextSequenceNames(sequence.sequenceName, sequences)}

                            genres={genres}
                            problemTemplate={problemTemplate}
                            keywords={keywords}
                            characters={characters}
                            dramaticQuestion={dramaticQuestion}
                            logLineDescription={logLineDescription}

                            updateSequenceCompletions={updateSequenceCompletions}
                        />
                    ))
            }
        </>
    )
}

export default SequenceList
