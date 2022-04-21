export const getTokenCount = async (text) => {

    const response = await fetch('/api/Tokenizer/Encode', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            'text': text
        })
    }).then(function (response) {
        if (response.status === 401 || response.status === 403) {
            console.error('auth failed or expired')
        } else {
            if (response.ok) {
                return response.json();
            }
        }
        return Promise.reject(response);
    }).catch(function (error) {
        console.warn(error);
    }).finally(function () {

    });

    return await response['count']

}