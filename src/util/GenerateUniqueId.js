export const useUniqueId = (prefix) => {
    return `${prefix}-${Math.random().toString(16).slice(2)}`
}