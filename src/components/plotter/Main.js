import React, { useState, useEffect } from 'react'

import LogLineSelect from './LogLineSelect'
import LogLineDescription from './LogLineDescription'
import LogLinePrompt from './LogLinePrompt'

const Main = (
    {
        curFocusElName,
        genre,
        problemTemplate,
        keywords,
        heroArchetype,
        enemyArchetype,
        primalStakes,
        dramaticQuestion,

        descIsLoading,
        genreDescObj,
        problemTemplateDescObj,
        heroArchetypeDescObj,
        enemyArchetypeDescObj,
        primalStakesDescObj,
        dramaticQuestionDescObj,

        logLineIncomplete,
        logLinePromptIsLoading,
        logLinePrompt,

        onFocusChange,
        onGenreChange,
        onProblemTemplateChange,
        onKeywordChange,
        onHeroArchetypeChange,
        onEnemyArchetypeChange,
        onPrimalStakesChange,
        onDramaticQuestionChange
    }
) => {

    const [optionsLoading, setOptionsLoading] = useState(false)
    const [optionsLoaded, setOptionsLoaded] = useState(false)

    const [genreOptions, setGenreOptions] = useState(null)
    const [problemTemplateOptions, setProblemTemplateOptions] = useState(null)
    const [archetypeOptions, setArchetypeOptions] = useState(null)
    const [primalStakesOptions, setPrimalStakesOptions] = useState(null)
    const [dramaticQuestionOptions, setDramaticQuestionOptions] = useState(null)

    useEffect(() => {

        if (optionsLoaded === true) return // only load once on initial page load

        setOptionsLoading(true)

        const loadOptions = async () => {

            fetch('/api/LogLineOptions').then(function (response) {
                if (response.ok) {
                    return response.json();
                }
                return Promise.reject(response);
            }).then(function (data) {
                // convert list of string tuples from the webservice into the format expected by React-Select
                const mapToSelectOptions = (arr) => {
                    return arr.map(function (x) {
                        return { value: x['item1'], label: x['item2'] }
                    })
                }

                const mappedGenreOptions = mapToSelectOptions(data['genres'])
                const mappedProblemTemplateOptions = mapToSelectOptions(data['problemTemplates'])
                const mappedArchetypeOptions = mapToSelectOptions(data['archetypes'])
                const mappedPrimalStakesOptions = mapToSelectOptions(data['primalStakes'])
                const mappedDramaticQuestionsOptions = mapToSelectOptions(data['dramaticQuestions'])

                setGenreOptions(mappedGenreOptions)
                setProblemTemplateOptions(mappedProblemTemplateOptions)
                setArchetypeOptions(mappedArchetypeOptions)
                setPrimalStakesOptions(mappedPrimalStakesOptions)
                setDramaticQuestionOptions(mappedDramaticQuestionsOptions)

            }).catch(function (error) {
                console.warn(error);
            }).finally(function () {
                setOptionsLoading(false)
                setOptionsLoaded(true)
            });
        }

        loadOptions()
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, []);

    return (
        <>
            {
                optionsLoading === true && <p>loading...</p>
            }
            {
                optionsLoading === false &&
                <>
                    <div className='row align-items-md-stretch'>
                        <div className='col-md-7 logline fs-5'>
                            <span>I want a </span>

                            <LogLineSelect
                                placeholder='Genre'
                                width='15em'
                                isMultiSelect={false}
                                onFocusChange={() => onFocusChange('genre')}
                                options={genreOptions}
                                value={genre}
                                onChange={onGenreChange}
                            />

                            <LogLineSelect
                                placeholder='Problem Template'
                                width='15em'
                                isMultiSelect={false}
                                onFocusChange={() => onFocusChange('problem template')}
                                options={problemTemplateOptions}
                                value={problemTemplate}
                                onChange={onProblemTemplateChange}
                            />

                            <span>story involving</span>

                            <LogLineSelect
                                placeholder='Keywords'
                                width='20em'
                                isMultiSelect={true}
                                onFocusChange={() => onFocusChange('keywords')}
                                value={keywords}
                                onChange={onKeywordChange}
                            />

                            <span>. The </span>

                            <LogLineSelect
                                placeholder='Hero Archetype'
                                width='15em'
                                isMultiSelect={false}
                                onFocusChange={() => onFocusChange('hero archetype')}
                                options={archetypeOptions}
                                value={heroArchetype}
                                onChange={onHeroArchetypeChange}
                            />

                            <span> hero ultimately seeks to </span>

                            <LogLineSelect
                                placeholder='Primal Stakes'
                                width='15em'
                                isMultiSelect={false}
                                onFocusChange={() => onFocusChange('primal stakes')}
                                options={primalStakesOptions}
                                value={primalStakes}
                                onChange={onPrimalStakesChange}
                            />

                            <span> while the </span>

                            <LogLineSelect
                                placeholder='Enemy Archetype'
                                width='15em'
                                isMultiSelect={false}
                                onFocusChange={() => onFocusChange('enemy archetype')}
                                options={archetypeOptions}
                                value={enemyArchetype}
                                onChange={onEnemyArchetypeChange}
                            />

                            <span> enemy attempts to thwart them. The theme of </span>

                            <LogLineSelect
                                placeholder='Dramatic Question'
                                width='15em'
                                isMultiSelect={false}
                                onFocusChange={() => onFocusChange('dramatic question')}
                                options={dramaticQuestionOptions}
                                value={dramaticQuestion}
                                onChange={onDramaticQuestionChange}
                            />

                            <span> occurs throughout.</span>
                        </div>
                        <div className='col-md-5'>
                            <LogLineDescription
                                curFocusElName={curFocusElName}
                                descIsLoading={descIsLoading}

                                genreDescObj={genreDescObj}
                                problemTemplateDescObj={problemTemplateDescObj}
                                heroArchetypeDescObj={heroArchetypeDescObj}
                                enemyArchetypeDescObj={enemyArchetypeDescObj}
                                primalStakesDescObj={primalStakesDescObj}
                                dramaticQuestionDescObj={dramaticQuestionDescObj}
                            />
                        </div>
                    </div>
                    <div className='row'>
                        <LogLinePrompt onFocusChange={() => onFocusChange('log line prompt')} logLineIncomplete={logLineIncomplete} logLinePromptIsLoading={logLinePromptIsLoading} logLinePrompt={logLinePrompt} />
                    </div>
                </>
            }
        </>
    )
}

export default Main