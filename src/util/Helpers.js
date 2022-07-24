export const isNullOrEmpty = (val) => {
    if (val === undefined) return true
    if (val === null) return true
    if (val === '') return true
    if (val.length === 0) return true

    return false
}

export const getText = (sequence, textPropName, completionPropName) => {
    const selectedCompletions = !sequence[completionPropName] ? [] : sequence[completionPropName].filter(c => c['isSelected'] === true)

    if (selectedCompletions.length > 0) {
        return selectedCompletions[0]['completion']
    }
    return sequence[textPropName]
}

export const toTitleCase = (str) => {
    return str.toLowerCase().split(' ').map(function (word) {
        return (word.charAt(0).toUpperCase() + word.slice(1));
    }).join(' ');
}