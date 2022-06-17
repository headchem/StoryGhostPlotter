// textPropName=blurb|text|full
// completionPropName=blurbCompletions|completions|fullCompletions
export const allSequencesHaveValues = (sequences, targetSequence, textPropName, completionPropName) => {
    if (!sequences || sequences.length === 0) {
        return false;
    }
    const existingSequenceNamesArr = sequences.map((seq) => seq.sequenceName.toLowerCase())
    const curSeqIndex = existingSequenceNamesArr.indexOf(targetSequence.toLowerCase())

    if (curSeqIndex === -1) { // if the target sequence doesn't exist in sequences, then we can't consider all values to be complete
        return false
    }

    let prevSeqsArr = sequences.slice(0, curSeqIndex)

    // get array of strings of either the selected brainstorm or none is selected, return the textarea text
    const prevTexts = prevSeqsArr.map(seq => {
        if (!seq || !seq[completionPropName]) return ''
        const selectedCompletions = seq[completionPropName].filter(c => c['isSelected'] === true)

        if (selectedCompletions.length > 0) {
            return selectedCompletions[0]['completion']
        }
        return seq[textPropName]
    })

    //const prevTexts = prevSeqsArr.map((seq) =>  seq[textPropName])

    const isBlank = (str) => (!str || str.trim().length === 0);

    return prevTexts.some(isBlank) === false
}

export const blurbLimits = {
    'Opening Image': {
        'max': 200,
        'rows': 2
    },
    'Setup': {
        'max': 400,
        'rows': 4
    },
    'Theme Stated': {
        'max': 200,
        'rows': 2
    },
    'Setup (Continued)': {
        'max': 200,
        'rows': 2
    },
    'Catalyst': {
        'max': 200,
        'rows': 2
    },
    'Debate': {
        'max': 350,
        'rows': 3
    },
    'B Story': {
        'max': 150,
        'rows': 2
    },
    'Debate (Continued)': {
        'max': 100,
        'rows': 1
    },
    'Break Into Two': {
        'max': 250,
        'rows': 2
    },
    'Fun And Games': {
        'max': 400,
        'rows': 5
    },
    'First Pinch Point': {
        'max': 100,
        'rows': 2
    },
    'Midpoint': {
        'max': 200,
        'rows': 2
    },
    'Bad Guys Close In': {
        'max': 400,
        'rows': 4
    },
    'Second Pinch Point': {
        'max': 150,
        'rows': 2
    },
    'All Hope Is Lost': {
        'max': 300,
        'rows': 3
    },
    'Dark Night Of The Soul': {
        'max': 350,
        'rows': 4
    },
    'Break Into Three': {
        'max': 200,
        'rows': 2
    },
    'Climax': {
        'max': 400,
        'rows': 4
    },
    'Cooldown': {
        'max': 200,
        'rows': 2
    }
}

export const expandedSummaryLimits = {
    'Opening Image': {
        'max': 400,
        'rows': 4
    },
    'Setup': {
        'max': 900,
        'rows': 9
    },
    'Theme Stated': {
        'max': 500,
        'rows': 6
    },
    'Setup (Continued)': {
        'max': 500,
        'rows': 7
    },
    'Catalyst': {
        'max': 500,
        'rows': 7
    },
    'Debate': {
        'max': 800,
        'rows': 11
    },
    'B Story': {
        'max': 400,
        'rows': 5
    },
    'Debate (Continued)': {
        'max': 300,
        'rows': 5
    },
    'Break Into Two': {
        'max': 650,
        'rows': 8
    },
    'Fun And Games': {
        'max': 1700,
        'rows': 22
    },
    'First Pinch Point': {
        'max': 150,
        'rows': 2
    },
    'Midpoint': {
        'max': 500,
        'rows': 6
    },
    'Bad Guys Close In': {
        'max': 1000,
        'rows': 14
    },
    'Second Pinch Point': {
        'max': 350,
        'rows': 5
    },
    'All Hope Is Lost': {
        'max': 500,
        'rows': 7
    },
    'Dark Night Of The Soul': {
        'max': 750,
        'rows': 10
    },
    'Break Into Three': {
        'max': 600,
        'rows': 8
    },
    'Climax': {
        'max': 1100,
        'rows': 14
    },
    'Cooldown': {
        'max': 600,
        'rows': 8
    }
}

export const fullLimits = {
    'Opening Image': {
        'max': 4000,
        'rows': 4
    },
    'Setup': {
        'max': 9000,
        'rows': 9
    },
    'Theme Stated': {
        'max': 5000,
        'rows': 6
    },
    'Setup (Continued)': {
        'max': 5000,
        'rows': 7
    },
    'Catalyst': {
        'max': 5000,
        'rows': 7
    },
    'Debate': {
        'max': 8000,
        'rows': 11
    },
    'B Story': {
        'max': 4000,
        'rows': 5
    },
    'Debate (Continued)': {
        'max': 3000,
        'rows': 5
    },
    'Break Into Two': {
        'max': 6500,
        'rows': 8
    },
    'Fun And Games': {
        'max': 17000,
        'rows': 22
    },
    'First Pinch Point': {
        'max': 1500,
        'rows': 2
    },
    'Midpoint': {
        'max': 5000,
        'rows': 6
    },
    'Bad Guys Close In': {
        'max': 10000,
        'rows': 14
    },
    'Second Pinch Point': {
        'max': 3500,
        'rows': 5
    },
    'All Hope Is Lost': {
        'max': 5000,
        'rows': 7
    },
    'Dark Night Of The Soul': {
        'max': 7500,
        'rows': 10
    },
    'Break Into Three': {
        'max': 6000,
        'rows': 8
    },
    'Climax': {
        'max': 11000,
        'rows': 14
    },
    'Cooldown': {
        'max': 6000,
        'rows': 8
    }
}