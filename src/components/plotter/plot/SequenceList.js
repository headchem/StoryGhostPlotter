import React from 'react'
import Sequence from './Sequence'
import SequenceBrainstormAll from './SequenceBrainstormAll';

const SequenceList = ({
    plotId,
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
    heroCharacterArchetype,
    dramaticQuestion,
    updateSequenceCompletions,
    setSequences,
    tokensRemaining
}) => {

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

    return (
        <>
            {
                userInfo && userInfo.userRoles.includes('customer') &&
                <SequenceBrainstormAll
                    plotId={plotId}
                    sequences={sequences}
                    userInfo={userInfo}
                    logLineDescription={logLineDescription}
                    genres={genres}
                    problemTemplate={problemTemplate}
                    keywords={keywords}
                    characters={characters}
                    dramaticQuestion={dramaticQuestion}
                    setSequences={setSequences}
                    tokensRemaining={tokensRemaining}
                />
            }

            {
                sequences && sequences
                    .map((sequence) => (
                        <Sequence
                            key={sequence.sequenceName}
                            userInfo={userInfo}
                            plotId={plotId}
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
                            heroCharacterArchetype={heroCharacterArchetype}
                            dramaticQuestion={dramaticQuestion}
                            logLineDescription={logLineDescription}

                            updateSequenceCompletions={updateSequenceCompletions}

                            tokensRemaining={tokensRemaining}
                        />
                    ))
            }
        </>
    )
}

export default SequenceList