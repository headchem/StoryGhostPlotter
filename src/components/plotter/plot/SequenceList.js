import Sequence from './Sequence'
import SequenceAdvice from './SequenceAdvice'
import Accordion from 'react-bootstrap/Accordion';
import SequenceBrainstorm from './SequenceBrainstorm'

const SequenceList = ({
    sequences,
    userInfo,
    logLineDescription,
    setLastFocusedSequenceName,
    lastFocusedSequenceName,
    updateSequenceContextText,
    updateSequenceEventsText,
    updateAISequenceText,
    insertSequence,
    deleteSequence,
    genres,
    problemTemplate,
    keywords,
    characters,
    dramaticQuestion,
    sequenceCompletions,
    setSequenceCompletions
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

    const firstPartBrainstormVisible = () => {
        switch (lastFocusedSequenceName) {
            case 'Opening Image':
                return true;
            case 'Setup':
                return true;
            case 'Theme Stated':
                return true;
            case 'Setup (Continued)':
                return true;
            case 'Catalyst':
                return true;
            case 'Debate':
                return true;
            case 'B Story':
                return true;
            case 'Debate (Continued)':
                return true;
            case 'Break Into Two':
                return true;
            case 'Fun And Games':
                return true;
            default:
                console.error('unhandled fallthrough case for: "' + lastFocusedSequenceName + '"');
        }

        return false
    }

    const secondPartBrainstormVisible = () => {
        switch (lastFocusedSequenceName) {
            case 'First Pinch Point':
                return true;
            case 'Midpoint':
                return true;
            case 'Bad Guys Close In':
                return true;
            case 'Second Pinch Point':
                return true;
            case 'All Hope Is Lost':
                return true;
            case 'Dark Night Of The Soul':
                return true;
            default:
                console.error('unhandled fallthrough case for: "' + lastFocusedSequenceName + '"');
        }

        return false
    }

    const thirdPartBrainstormVisible = () => {
        switch (lastFocusedSequenceName) {
            case 'Break Into Three':
                return true;
            case 'Climax':
                return true;
            case 'Cooldown':
                return true;
            default:
                console.error('unhandled fallthrough case for: "' + lastFocusedSequenceName + '"');
        }

        return false
    }

    const updateStartSequenceCompletions = (newCompletionList) => {
        const newObj = {
            'startCompletions': newCompletionList,
            'middleCompletions': !sequenceCompletions ? [] : [...sequenceCompletions['middleCompletions']],
            'endingCompletions': !sequenceCompletions ? [] : [...sequenceCompletions['endingCompletions']]
        }

        console.log('set new completion obj to:')
        console.log(newObj)
        setSequenceCompletions(newObj)
    }

    const updateMiddleSequenceCompletions = (newCompletionList) => {
        const newObj = {
            'startCompletions': !sequenceCompletions ? [] : [...sequenceCompletions['startCompletions']],
            'middleCompletions': newCompletionList,
            'endingCompletions': !sequenceCompletions ? [] : [...sequenceCompletions['endingCompletions']]
        }
        setSequenceCompletions(newObj)
    }

    const updateEndingSequenceCompletions = (newCompletionList) => {
        const newObj = {
            'startCompletions': !sequenceCompletions ? [] : [...sequenceCompletions['startCompletions']],
            'middleCompletions': !sequenceCompletions ? [] : [...sequenceCompletions['middleCompletions']],
            'endingCompletions': newCompletionList
        }
        setSequenceCompletions(newObj)
    }

    return (
        <>
            <div className='row'>
                <div className='col-md-7'>
                    {
                        sequences
                            .map((sequence) => (
                                <Sequence
                                    key={sequence.sequenceName}
                                    userInfo={userInfo}
                                    sequence={sequence}
                                    sequences={sequences}
                                    setLastFocusedSequenceName={setLastFocusedSequenceName}
                                    lastFocusedSequenceName={lastFocusedSequenceName}
                                    updateContextText={updateSequenceContextText}
                                    updateEventsText={updateSequenceEventsText}
                                    updateAIText={updateAISequenceText}

                                    insertSequence={insertSequence}
                                    deleteSequence={deleteSequence}

                                    allowed={getAllowedNextSequenceNames(sequence.sequenceName, sequences)}

                                    genres={genres}
                                    problemTemplate={problemTemplate}
                                    keywords={keywords}
                                    characters={characters}
                                    dramaticQuestion={dramaticQuestion}
                                />
                            ))
                    }
                </div>
                <div className='col-md-5 sticky-top pt-5 mt-5 h-100'>

                    <Accordion defaultActiveKey={['0']}>

                        <Accordion.Item eventKey="0">
                            <Accordion.Header>Advice</Accordion.Header>
                            <Accordion.Body>
                                <SequenceAdvice
                                    userInfo={userInfo}
                                    lastFocusedSequenceName={lastFocusedSequenceName}
                                    genres={genres}
                                    problemTemplate={problemTemplate}
                                    keywords={keywords}
                                    characters={characters}
                                    dramaticQuestion={dramaticQuestion}
                                    //sequence={sequence}
                                    sequences={sequences}
                                />
                            </Accordion.Body>
                        </Accordion.Item>
                        {
                            firstPartBrainstormVisible() &&

                            <Accordion.Item eventKey="1">
                                <Accordion.Header>Brainstorm Start</Accordion.Header>
                                <Accordion.Body>
                                    {
                                        <div className='row'>
                                            <div className='col'>
                                                <p>Based on the log line and characters, ask the AI to brainstorm the start of a story (through the Fun And Games sequence).</p>
                                                {
                                                    userInfo && userInfo.userRoles.includes('customer') &&

                                                    <SequenceBrainstorm
                                                        userInfo={userInfo}
                                                        logLineDescription={logLineDescription}
                                                        genres={genres}
                                                        problemTemplate={problemTemplate}
                                                        dramaticQuestion={dramaticQuestion}
                                                        keywords={keywords}
                                                        sequences={sequences}
                                                        characters={characters}
                                                        completions={!sequenceCompletions ? [] : sequenceCompletions['startCompletions']}
                                                        updateSequenceCompletions={updateStartSequenceCompletions}
                                                        part='start'
                                                    />
                                                }
                                                {
                                                    (!userInfo || !userInfo.userRoles.includes('customer')) &&
                                                    <>
                                                        <p>Sign up for our premium plan to ask the AI to brainstorm ideas.</p>
                                                    </>
                                                }
                                            </div>
                                        </div>
                                    }
                                </Accordion.Body>
                            </Accordion.Item>
                        }
                        {
                            secondPartBrainstormVisible() &&
                            <Accordion.Item eventKey="2">
                                <Accordion.Header>Brainstorm Middle</Accordion.Header>
                                <Accordion.Body>
                                    {
                                        <div className='row'>
                                            <div className='col'>
                                                <p>Based on the sequences you have already entered through Fun And Games, ask the AI to brainstorm how everything unravels for the protagonist.</p>
                                                {
                                                    userInfo && userInfo.userRoles.includes('customer') &&

                                                    <SequenceBrainstorm
                                                        userInfo={userInfo}
                                                        logLineDescription={logLineDescription}
                                                        genres={genres}
                                                        problemTemplate={problemTemplate}
                                                        dramaticQuestion={dramaticQuestion}
                                                        keywords={keywords}
                                                        sequences={sequences}
                                                        characters={characters}
                                                        completions={!sequenceCompletions ? [] : sequenceCompletions['middleCompletions']}
                                                        updateSequenceCompletions={updateMiddleSequenceCompletions}
                                                        part='middle'
                                                    />
                                                }
                                                {
                                                    (!userInfo || !userInfo.userRoles.includes('customer')) &&
                                                    <>
                                                        <p>Sign up for our premium plan to ask the AI to brainstorm ideas.</p>
                                                    </>
                                                }
                                            </div>
                                        </div>
                                    }
                                </Accordion.Body>
                            </Accordion.Item>
                        }
                        {
                            thirdPartBrainstormVisible() &&
                            <Accordion.Item eventKey="3">
                                <Accordion.Header>Brainstorm Ending</Accordion.Header>
                                <Accordion.Body>
                                    {
                                        <div className='row'>
                                            <div className='col'>
                                                <p>Based on the sequences you have entered through Dark Night Of The Soul, ask the AI to brainstorm how the protagonist ultimately succeeds.</p>
                                                {
                                                    userInfo && userInfo.userRoles.includes('customer') &&

                                                    <SequenceBrainstorm
                                                        userInfo={userInfo}
                                                        logLineDescription={logLineDescription}
                                                        genres={genres}
                                                        problemTemplate={problemTemplate}
                                                        dramaticQuestion={dramaticQuestion}
                                                        keywords={keywords}
                                                        sequences={sequences}
                                                        characters={characters}
                                                        completions={!sequenceCompletions ? [] : sequenceCompletions['endingCompletions']}
                                                        updateSequenceCompletions={updateEndingSequenceCompletions}
                                                        part='ending'
                                                    />
                                                }
                                                {
                                                    (!userInfo || !userInfo.userRoles.includes('customer')) &&
                                                    <>
                                                        <p>Sign up for our premium plan to ask the AI to brainstorm ideas.</p>
                                                    </>
                                                }
                                            </div>
                                        </div>
                                    }
                                </Accordion.Body>
                            </Accordion.Item>
                        }

                    </Accordion>


                </div>
            </div>
        </>
    )
}

export default SequenceList
