import React, { useEffect, useState } from 'react'
import { useNavigate } from "react-router-dom";

const SequenceAdvice = ({
    userInfo,
    sequenceName,

    genres,
    problemTemplate,
    keywords,
    characters,
    dramaticQuestion,

    //sequence,
    sequences
}) => {

    const navigate = useNavigate()

    const [contextCommonAdvice, setContextCommonAdvice] = useState('')
    const [contextGenresAdvice, setContextGenresAdvice] = useState('')
    const [contextProblemTemplateAdvice, setContextProblemTemplateAdvice] = useState('')
    const [contextDramaticQuestionAdvice, setContextDramaticQuestionAdvice] = useState('')
    const [contextHeroArchetypeAdvice, setContextHeroArchetypeAdvice] = useState('')

    const [eventsCommonAdvice, setEventsCommonAdvice] = useState('')
    const [eventsGenresAdvice, setEventsGenresAdvice] = useState('')
    const [eventsProblemTemplateAdvice, setEventsProblemTemplateAdvice] = useState('')
    const [eventsDramaticQuestionAdvice, setEventsDramaticQuestionAdvice] = useState('')
    const [eventsHeroArchetypeAdvice, setEventsHeroArchetypeAdvice] = useState('')

    const [contextAdviceIsEmpty, setContextAdviceIsEmpty] = useState(true)
    const [eventsAdviceIsEmpty, setEventsAdviceIsEmpty] = useState(true)

    const [isAdviceLoading, setIsAdviceLoading] = useState(false)

    const getAdvice = async () => {
        setIsAdviceLoading(true)
        fetchAdvice()
    }

    const fetchAdvice = async () => {
        let heroCharacter = characters.filter((character) => character.isHero === true);
        heroCharacter = heroCharacter.length > 0 ? heroCharacter[0] : null;

        if (sequenceName === '') return

        fetch('/api/Sequence/Advice?sequenceName=' + sequenceName, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                'genres': genres,
                'problemTemplate': problemTemplate,
                'keywords': keywords,
                'heroArchetype': (heroCharacter ? heroCharacter.archetype : ''),
                'dramaticQuestion': dramaticQuestion,
                //'text': sequence.text,
                //'context': sequence.context
            })
        }).then(function (response) {
            if (response.status === 401 || response.status === 403) {
                navigate('/plots')
            } else {
                if (response.ok) {
                    return response.json();
                }
            }
            return Promise.reject(response);
        }).then(function (data) {
            const eventsAdvice = data['events']
            const contextAdvice = data['context']

            const combinedContext = contextAdvice['common'] + contextAdvice['genres'] + contextAdvice['problemTemplate'] + contextAdvice['dramaticQuestion'] + contextAdvice['heroArchetype']
            const combinedContextTrimmed = combinedContext.replace(/\s/g, '').trim()

            setContextAdviceIsEmpty(combinedContextTrimmed.length === 0)


            setContextCommonAdvice(contextAdvice['common'])
            setContextGenresAdvice(contextAdvice['genres'])
            setContextProblemTemplateAdvice(contextAdvice['problemTemplate'])
            setContextDramaticQuestionAdvice(contextAdvice['dramaticQuestion'])
            setContextHeroArchetypeAdvice(contextAdvice['heroArchetype'])

            const combinedEvents = eventsAdvice['common'] + eventsAdvice['genres'] + eventsAdvice['problemTemplate'] + eventsAdvice['dramaticQuestion'] + eventsAdvice['heroArchetype']
            const combinedEventsTrimmed = combinedEvents.replace(/\s/g, '').trim()

            setEventsAdviceIsEmpty(combinedEventsTrimmed.length === 0)

            setEventsCommonAdvice(eventsAdvice['common'])
            setEventsGenresAdvice(eventsAdvice['genres'])
            setEventsProblemTemplateAdvice(eventsAdvice['problemTemplate'])
            setEventsDramaticQuestionAdvice(eventsAdvice['dramaticQuestion'])
            setEventsHeroArchetypeAdvice(eventsAdvice['heroArchetype'])
        }).catch(function (error) {
            console.warn(error);
        }).finally(function () {
            setIsAdviceLoading(false)
        });

    }

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        const timeout = setTimeout(() => {
            getAdvice()
        }, 500) // timeout to execute this function if timeout will be not cleared

        return () => clearTimeout(timeout) //clear timeout (delete function execution)

        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [genres, problemTemplate, dramaticQuestion, characters]); // sequence,

    return (
        <>
            <h3>Advice for {sequenceName}</h3>
            {
                contextAdviceIsEmpty === false &&
                <>
                    <h5 title="Info hidden from the reader, or character backstories that inform the visible events">Background Context</h5>
                    <p className={`${isAdviceLoading ? 'text-loading' : ''}`}>
                        <span title="common advice">{contextCommonAdvice} </span>
                        <span title="genres advice">{contextGenresAdvice} </span>
                        <span title="problem template advice">{contextProblemTemplateAdvice} </span>
                        <span title="dramatic question advice">{contextDramaticQuestionAdvice} </span>
                        <span title="hero archetype advice">{contextHeroArchetypeAdvice} </span>
                    </p>
                </>
            }
            {
                contextAdviceIsEmpty === false && eventsAdviceIsEmpty === false &&
                <hr title="given the context above, therefore the events below transpired..." />
            }
            {
                eventsAdviceIsEmpty === false &&
                <>
                    <h5 title="string events together with 'therefore' instead of 'and then'">Events</h5>
                    <p className={`${isAdviceLoading ? 'text-loading' : ''}`}>
                        <span title="common advice">{eventsCommonAdvice} </span>
                        <span title="genres advice">{eventsGenresAdvice} </span>
                        <span title="problem template advice">{eventsProblemTemplateAdvice} </span>
                        <span title="dramatic question advice">{eventsDramaticQuestionAdvice} </span>
                        <span title="hero archetype advice">{eventsHeroArchetypeAdvice} </span>
                    </p>
                </>
            }
        </>
    )
}

export default SequenceAdvice