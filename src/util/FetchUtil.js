export const fetchWithTimeout = async (resource, options = {}) => {
    const { timeout = 30 * 1000 } = options; // 8 sec default, but is overridable

    const controller = new AbortController();
    const id = setTimeout(() => controller.abort(), timeout);
    const response = await fetch(resource, {
        ...options,
        signal: controller.signal
    });
    clearTimeout(id);
    return response;
}

export const fetchData = (url, setIsLoading, setData, navigate) => {
    setIsLoading(true)

    fetch(url)
        .then(function (response) {
            if (response.status === 401 || response.status === 403) {
                navigate('/plots')
            } else {
                if (response.ok) {
                    return response.json();
                }
            }
            return Promise.reject(response);
        }).then(function (data) {
            setData(data)
        }).catch(function (error) {
            console.warn(error);
        }).finally(function () {
            setIsLoading(false)
        });
}