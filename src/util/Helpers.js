export const isNullOrEmpty = (val) => {
    if (val === undefined) return true
    if (val === null) return true
    if (val === '') return true
    if (val.length === 0) return true

    return false
}