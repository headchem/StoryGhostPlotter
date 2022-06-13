import React, { useState, useEffect } from 'react'
import DramaticQuestionProblemTemplateTable from '../Advice/DramaticQuestionProblemTemplateTable'
import { useNavigate } from "react-router-dom";
import Spinner from 'react-bootstrap/Spinner';
import { isNullOrEmpty } from '../../../../util/Helpers';

const Page4 = (
    {
        title,
        logLineDescription,
        genres,
        keywords,
        problemTemplate,
        dramaticQuestion,
        characters
    }
) => {

    const hero = !characters ? null : characters.filter(c => c['isHero'] === true)[0]
    const heroArchetype = hero['archetype']

    const navigate = useNavigate()
    const [heroArchetypeDescObj, setHeroArchetypeDescObj] = useState('')
    const [isHeroArchetypeLoading, setIsHeroArchetypeLoading] = useState(false)

    useEffect(() => {
        fetchArchetype()
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [characters]);

    const fetchArchetype = async () => {
        if (isNullOrEmpty(heroArchetype)) return;

        setIsHeroArchetypeLoading(true)

        const url = '/api/LogLine/ArchetypeDescription?archetype=' + heroArchetype

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
                setHeroArchetypeDescObj(data)

                console.log(data)
            }).catch(function (error) {
                console.warn(error);
            }).finally(function () {
                setIsHeroArchetypeLoading(false)
            });
    }

    return (
        <div className='row'>
            <div className='col-9'>

                <h1>{title}</h1>
                <p className='fs-5'>{logLineDescription}</p>
                {
                    isHeroArchetypeLoading === true &&
                    <Spinner size="sm" as="span" animation="border" variant="secondary" />
                }
                {
                    isHeroArchetypeLoading === false &&
                    <DramaticQuestionProblemTemplateTable
                        problemTemplate={problemTemplate}
                        dramaticQuestion={dramaticQuestion}
                        heroName={hero['name']}
                        heroArchetype={heroArchetypeDescObj}
                    />
                }
            </div>
            <div className="col-3">
                <p><strong>Genres: </strong>{genres.join(', ')}</p>
                <p><strong>Keywords: </strong>{keywords.join(', ')}</p>
                {
                    isHeroArchetypeLoading === false &&
                    <>
                        <p><strong>Hero {hero['name']}</strong> has the archetype of <strong>{heroArchetypeDescObj['name']}</strong>. {heroArchetypeDescObj['description']}</p>
                        <p>{hero['description']}</p>
                    </>
                }
            </div>
        </div>
    )
}

export default Page4