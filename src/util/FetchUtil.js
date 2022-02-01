export const fetchWithTimeout = async (resource, options = {}) => {
    const { timeout = 8 * 1000 } = options; // 8 sec default, but is overridable

    const controller = new AbortController();
    const id = setTimeout(() => controller.abort(), timeout);
    const response = await fetch(resource, {
        ...options,
        signal: controller.signal
    });
    clearTimeout(id);
    return response;
}