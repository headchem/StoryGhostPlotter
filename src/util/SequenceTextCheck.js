export const allSequencesHaveValues = (sequences, targetSequence, textPropName) => {
    if (!sequences || sequences.length === 0) {
        return false;
    }
    const existingSequenceNamesArr = sequences.map((seq) => seq.sequenceName.toLowerCase())
    const curSeqIndex = existingSequenceNamesArr.indexOf(targetSequence.toLowerCase())

    if (curSeqIndex === -1) { // if the target sequence doesn't exist in sequences, then we can't consider all values to be complete
        return false
    }

    let prevSeqsArr = sequences.slice(0, curSeqIndex)

    const prevTexts = prevSeqsArr.map((seq) => seq[textPropName])

    const isBlank = (str) => (!str || str.trim().length === 0);

    return prevTexts.some(isBlank) === false
}