import React, { useState, useEffect } from 'react'
import { useNavigate } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import { isNullOrEmpty } from '../../../../util/Helpers';

const GenresAdvice = (
    {
        genres
    }
) => {

    const navigate = useNavigate()

    const [isLoading, setIsLoading] = useState(false)
    const [data, setData] = useState(null)

    const load = async () => {
        if (isNullOrEmpty(genres)) return

        let url = '/api/LogLine/GenresDescription?genres=' + genres.join(',')

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

    useEffect(() => {
        load()
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [genres]);

    return (
        <div>
            {
                isLoading === true && <Spinner animation="border" variant="secondary" />
            }
            {
                !isNullOrEmpty(data) &&
                data.map((genreObj) => (
                    <div key={genreObj.name}>
                        <h2>{genreObj.name}</h2>
                        <p>{genreObj.description}</p>
                    </div>
                ))
            }
        </div >
    )
}

export default GenresAdvice