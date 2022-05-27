export const allSequencesHaveValues = (sequences, targetSequence, textPropName) => {
    if (!sequences || sequences.length === 0) {
        //console.log('sequences for ' + targetSequence + ' was blank, looking at ' + textPropName)
        return false;
    }
    const existingSequenceNamesArr = sequences.map((seq) => seq.sequenceName.toLowerCase())
    const curSeqIndex = existingSequenceNamesArr.indexOf(targetSequence.toLowerCase())

    if (curSeqIndex === -1) { // if the target sequence doesn't exist in sequences, then we can't consider all values to be complete
        //console.log('target sequence ' + targetSequence + ' not in sequences')
        return false
    }

    let prevSeqsArr = sequences.slice(0, curSeqIndex)

    if (targetSequence.toLowerCase() === 'cooldown') { // if we're targeting cooldown, then don't slice
        prevSeqsArr = sequences;
    }

    const prevTexts = prevSeqsArr.map((seq) => seq[textPropName])

    //console.log(prevTexts);

    const isBlank = (str) => (!str || str.trim().length === 0);

    return prevTexts.some(isBlank) === false
}