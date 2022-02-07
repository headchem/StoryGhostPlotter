import React, { useState, useEffect } from 'react'

import LogLineSelect from './LogLineSelect'
import LogLineDescription from './LogLineDescription'
import CharacterStage from './CharacterStage'
import * as PromptArea from '../../../util/PromptArea'

const PlotHome = (
    {
        userInfo,
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

        onFocusChange,
        onGenreChange,
        onProblemTemplateChange,
        onKeywordChange,
        onHeroArchetypeChange,
        onEnemyArchetypeChange,
        onPrimalStakesChange,
        onDramaticQuestionChange,

        orphanSummaryStatus,
        orphanSummary,
        setOrphanSummary,
        orphanFull,
        setOrphanFull,

        wandererSummaryStatus,
        setWandererSummaryStatus,
        wandererSummary,
        setWandererSummary,
        wandererFull,
        setWandererFull,
        orphanComplete,
        setOrphanComplete,

        warriorSummaryStatus,
        setWarriorSummaryStatus,
        warriorSummary,
        setWarriorSummary,
        warriorFull,
        setWarriorFull,
        wandererComplete,
        setWandererComplete,

        martyrSummaryStatus,
        setMartyrSummaryStatus,
        martyrSummary,
        setMartyrSummary,
        martyrFull,
        setMartyrFull,
        warriorComplete,
        setWarriorComplete,
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
        // upon initial page load, call API that returns all of the Log Line dropdown options
        if (optionsLoaded === true) return // only load once on initial page load

        setOptionsLoading(true)

        const loadOptions = async () => {

            fetch('/api/LogLine/LogLineOptions').then(function (response) {
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
                                width='8em'
                                isMultiSelect={false}
                                onFocusChange={() => onFocusChange('genre')}
                                options={genreOptions}
                                value={genre}
                                onChange={onGenreChange}
                            />

                            <LogLineSelect
                                placeholder='Problem Template'
                                width='14em'
                                isMultiSelect={false}
                                onFocusChange={() => onFocusChange('problem template')}
                                options={problemTemplateOptions}
                                value={problemTemplate}
                                onChange={onProblemTemplateChange}
                            />

                            <span>story that focuses on </span>

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
                                placeholder='Personality'
                                width='9em'
                                isMultiSelect={false}
                                onFocusChange={() => onFocusChange('hero archetype')}
                                options={archetypeOptions}
                                value={heroArchetype}
                                onChange={onHeroArchetypeChange}
                            />

                            <span> main character ultimately seeks to </span>

                            <LogLineSelect
                                placeholder='Primal Stakes'
                                width='13em'
                                isMultiSelect={false}
                                onFocusChange={() => onFocusChange('primal stakes')}
                                options={primalStakesOptions}
                                value={primalStakes}
                                onChange={onPrimalStakesChange}
                            />

                            <span> in relation to the </span>

                            <LogLineSelect
                                placeholder='Personality'
                                width='9em'
                                isMultiSelect={false}
                                onFocusChange={() => onFocusChange('enemy archetype')}
                                options={archetypeOptions}
                                value={enemyArchetype}
                                onChange={onEnemyArchetypeChange}
                            />

                            <span> secondary character. The theme of </span>

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

                    {
                        userInfo && userInfo.userRoles.includes('customer') === false &&
                        <div className='row'>
                            <p>You must be a customer to use the Generate feature.</p>
                        </div>
                    }

                    {
                        userInfo && userInfo.userRoles.includes('customer') === true && logLineIncomplete === true &&
                        <div className='row'>
                            <p>All fields above must be completed.</p>
                        </div>
                    }

                    {
                        userInfo && userInfo.userRoles.includes('customer') &&
                        <>
                            {
                                orphanSummaryStatus === PromptArea.Status.AVAILABLE &&
                                <>
                                    <CharacterStage
                                        stage='orphan'
                                        summary={orphanSummary}
                                        setSummary={setOrphanSummary}
                                        full={orphanFull}
                                        setFull={setOrphanFull}
                                        setNextAvailable={() => {
                                            setWandererSummaryStatus(PromptArea.Status.AVAILABLE)
                                        }}
                                        setNextUnavailable={() => setWandererSummaryStatus(PromptArea.Status.UNAVAILABLE)}
                                        // do nothing on prev complete/incomplete
                                        setPrevComplete={() => { return false }}
                                        setPrevIncomplete={() => { return false }}
                                        isComplete={orphanComplete}
                                        onFocusChange={() => onFocusChange('orphan')}

                                        genre={genre}
                                        problemTemplate={problemTemplate}
                                        keywords={keywords}
                                        heroArchetype={heroArchetype}
                                        enemyArchetype={enemyArchetype}
                                        primalStakes={primalStakes}
                                        dramaticQuestion={dramaticQuestion}

                                        orphanSummary={orphanSummary}
                                        orphanFull={orphanFull}
                                        wandererSummary={wandererSummary}
                                        wandererFull={wandererFull}
                                        warriorSummary={warriorSummary}
                                        warriorFull={warriorFull}
                                        martyrSummary={martyrSummary}
                                        martyrFull={martyrFull}
                                    />
                                </>
                            }
                            {
                                wandererSummaryStatus === PromptArea.Status.AVAILABLE &&
                                <CharacterStage
                                    stage='wanderer'
                                    summary={wandererSummary}
                                    setSummary={setWandererSummary}
                                    full={wandererFull}
                                    setFull={setWandererFull}
                                    setNextAvailable={() => {
                                        setWarriorSummaryStatus(PromptArea.Status.AVAILABLE)
                                    }}
                                    setNextUnavailable={() => setWarriorSummaryStatus(PromptArea.Status.UNAVAILABLE)}
                                    isComplete={wandererComplete}
                                    setPrevComplete={() => setOrphanComplete(true)}
                                    setPrevIncomplete={() => setOrphanComplete(false)}
                                    onFocusChange={() => onFocusChange('wanderer')}

                                    genre={genre}
                                    problemTemplate={problemTemplate}
                                    keywords={keywords}
                                    heroArchetype={heroArchetype}
                                    enemyArchetype={enemyArchetype}
                                    primalStakes={primalStakes}
                                    dramaticQuestion={dramaticQuestion}

                                    orphanSummary={orphanSummary}
                                    orphanFull={orphanFull}
                                    wandererSummary={wandererSummary}
                                    wandererFull={wandererFull}
                                    warriorSummary={warriorSummary}
                                    warriorFull={warriorFull}
                                    martyrSummary={martyrSummary}
                                    martyrFull={martyrFull}
                                />
                            }
                            {
                                warriorSummaryStatus === PromptArea.Status.AVAILABLE &&
                                <CharacterStage
                                    stage='warrior'
                                    summary={warriorSummary}
                                    setSummary={setWarriorSummary}
                                    full={warriorFull}
                                    setFull={setWarriorFull}
                                    setNextAvailable={() => {
                                        setMartyrSummaryStatus(PromptArea.Status.AVAILABLE)
                                    }}
                                    setNextUnavailable={() => setMartyrSummaryStatus(PromptArea.Status.UNAVAILABLE)}
                                    isComplete={warriorComplete}
                                    setPrevComplete={() => setWandererComplete(true)}
                                    setPrevIncomplete={() => setWandererComplete(false)}
                                    onFocusChange={() => onFocusChange('warrior')}

                                    genre={genre}
                                    problemTemplate={problemTemplate}
                                    keywords={keywords}
                                    heroArchetype={heroArchetype}
                                    enemyArchetype={enemyArchetype}
                                    primalStakes={primalStakes}
                                    dramaticQuestion={dramaticQuestion}

                                    orphanSummary={orphanSummary}
                                    orphanFull={orphanFull}
                                    wandererSummary={wandererSummary}
                                    wandererFull={wandererFull}
                                    warriorSummary={warriorSummary}
                                    warriorFull={warriorFull}
                                    martyrSummary={martyrSummary}
                                    martyrFull={martyrFull}
                                />
                            }
                            {
                                martyrSummaryStatus === PromptArea.Status.AVAILABLE &&
                                <CharacterStage
                                    stage='martyr'
                                    summary={martyrSummary}
                                    setSummary={setMartyrSummary}
                                    full={martyrFull}
                                    setFull={setMartyrFull}
                                    // do nothing on setNextAvailable/setNextUnavailable
                                    setNextAvailable={() => { return false }}
                                    setNextUnavailable={() => { return false }}
                                    isComplete={false} // hardcoded to false because nothing comes after Martyr to force it to complete
                                    setPrevComplete={() => setWarriorComplete(true)}
                                    setPrevIncomplete={() => setWarriorComplete(false)}
                                    onFocusChange={() => onFocusChange('martyr')}

                                    genre={genre}
                                    problemTemplate={problemTemplate}
                                    keywords={keywords}
                                    heroArchetype={heroArchetype}
                                    enemyArchetype={enemyArchetype}
                                    primalStakes={primalStakes}
                                    dramaticQuestion={dramaticQuestion}

                                    orphanSummary={orphanSummary}
                                    orphanFull={orphanFull}
                                    wandererSummary={wandererSummary}
                                    wandererFull={wandererFull}
                                    warriorSummary={warriorSummary}
                                    warriorFull={warriorFull}
                                    martyrSummary={martyrSummary}
                                    martyrFull={martyrFull}
                                />
                            }
                        </>
                    }


                </>
            }
        </>
    )
}

export default PlotHome