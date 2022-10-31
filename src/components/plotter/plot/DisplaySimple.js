import React, { useState } from 'react'
import Pagination from './SimplePages/Pagination'
import Page0 from './SimplePages/Page0'
import Page1 from './SimplePages/Page1'
import Page2 from './SimplePages/Page2'
import Page3 from './SimplePages/Page3'
import Page4 from './SimplePages/Page4'
import Page5 from './SimplePages/Page5'
import Page6 from './SimplePages/Page6'
import { getText } from '../../../util/Helpers'

const DisplaySimple = (
    {
        userInfo,
        plotId,
        mode,
        genreOptions,
        genres,
        onGenresChange,

        setGenres,
        appealTermsOptions,
        appealTerms,
        setAppealTerms,

        onFocusChange,
        setKeywords,
        setLogLineDescription,
        setTitle,
        setProblemTemplate,
        setDramaticQuestion,
        keywords,
        onKeywordsChange,
        logLineIncomplete,
        logLineDescription,
        onLogLineDescriptionChange,
        onTitleChange,
        title,
        problemTemplate,
        onProblemTemplateChange,
        problemTemplateOptions,
        dramaticQuestion,
        onDramaticQuestionChange,
        dramaticQuestionOptions,
        updateLogLineDescriptionCompletions,
        AILogLineDescriptions,
        AITitles,
        setAITitles,
        curFocusElName,
        tokensRemaining,

        setCharacters,

        characters,
        archetypeOptions,
        updateCharacterName,
        updateCharacterIsHero,
        updateCharacterArchetype,
        updateCharacterDescription,
        updateAICharacterCompletion,
        updateCharacterPersonality,
        insertCharacter,
        deleteCharacter,

        sequences,
        setLastFocusedSequenceName,
        lastFocusedSequenceName,
        updateBlurb,
        updateExpandedSummary,
        updateFull,
        insertSequence,
        deleteSequence,
        heroCharacterArchetype,
        updateBlurbCompletions,
        updateExpandedSummaryCompletions,
        updateFullCompletions,
        setSequences,

        hideBlurbs,
        blurbsIncomplete,
        expandedSummariesIncomplete,

        goToViewPlot,
        isPublicCheckboxId,
        onIsPublicChange,
        isPublic,
        lastSaveSuccess,

        editCompletion,
        updateScenes,
        deleteScene,
    }
) => {

    const [curPage, setCurPage] = useState(0)

    const prevPage = () => {
        setCurPage(curPage - 1)
    }

    const nextPage = () => {
        setCurPage(curPage + 1)
    }

    const goToPage = (pageNum) => {
        setCurPage(pageNum)
    }

    const pageNames = (userInfo && userInfo.userRoles.includes('customer')) ? [
        'Genres / Keywords',
        'Log Line',
        'Problem / Theme',
        'Characters',
        'Review',
        'Blurbs',
        'Expanded',
        'Final'
    ] : [
        'Genres / Keywords',
        'Log Line',
        'Problem / Theme',
        'Characters',
        'Review',
        'Blurbs',
        'Expanded',
        'Final'
    ]

    return (

        <>
            <div className='row pb-5'>
                <div className='col-12'>
                    <div className='row pb-5'>
                        <div className='col'>
                            <Pagination
                                showPrevNext={false}
                                curPage={curPage}
                                prevPage={prevPage}
                                nextPage={nextPage}
                                goToPage={goToPage}
                                pageNames={pageNames}
                            />
                        </div>
                    </div>

                    {
                        curPage === 0 && // genres and keywords
                        <Page0
                            genreOptions={genreOptions}
                            genres={genres}
                            onGenresChange={onGenresChange}
                            onFocusChange={onFocusChange}
                            mode={mode}

                            setGenres={setGenres}
                            appealTermsOptions={appealTermsOptions}
                            appealTerms={appealTerms}
                            setAppealTerms={setAppealTerms}

                            keywords={keywords}
                            onKeywordsChange={onKeywordsChange}
                        />
                    }
                    {
                        curPage === 1 && // logline desc and title
                        <Page1
                            userInfo={userInfo}

                            genres={genres}
                            appealTermsIDs={appealTerms}
                            keywords={keywords}

                            logLineDescription={logLineDescription}
                            onLogLineDescriptionChange={onLogLineDescriptionChange}
                            onFocusChange={onFocusChange}

                            title={title}
                            onTitleChange={onTitleChange}

                            plotId={plotId}
                            updateLogLineDescriptionCompletions={updateLogLineDescriptionCompletions}
                            AILogLineDescriptions={AILogLineDescriptions}

                            setAITitles={setAITitles}
                        />
                    }
                    {
                        curPage === 2 && // problem template and dramatic question
                        <Page2
                            problemTemplate={problemTemplate}
                            onProblemTemplateChange={onProblemTemplateChange}
                            onFocusChange={onFocusChange}
                            problemTemplateOptions={problemTemplateOptions}
                            dramaticQuestion={dramaticQuestion}
                            onDramaticQuestionChange={onDramaticQuestionChange}
                            dramaticQuestionOptions={dramaticQuestionOptions}

                            genres={genres}
                            keywords={keywords}
                            appealTermsIDs={appealTerms}
                            logLineDescription={logLineDescription}
                        />
                    }
                    {
                        curPage === 3 && // characters
                        <Page3

                            userInfo={userInfo}
                            plotId={plotId}
                            logLineDescription={logLineDescription}
                            updateCharacterName={updateCharacterName}
                            updateCharacterDescription={updateCharacterDescription}
                            setCharacters={setCharacters}

                            characters={characters}
                        />

                    }
                    {
                        curPage === 4 && // logline overview
                        <Page4
                            title={title}
                            logLineDescription={logLineDescription}
                            genres={genres}
                            keywords={keywords}
                            problemTemplate={problemTemplate}
                            dramaticQuestion={dramaticQuestion}
                            characters={characters}
                        />
                    }

                    {
                        //userInfo && userInfo.userRoles.includes('customer') &&
                        <>
                            {
                                curPage === 5 && // sequences
                                <Page5
                                    userInfo={userInfo}
                                    plotId={plotId}
                                    logLineDescription={logLineDescription}
                                    genres={genres}
                                    problemTemplate={problemTemplate}
                                    dramaticQuestion={dramaticQuestion}
                                    keywords={keywords}
                                    sequences={sequences}
                                    characters={characters}
                                    setSequences={setSequences}
                                    updateSequenceCompletions={updateBlurbCompletions}
                                    heroCharacterArchetype={heroCharacterArchetype}
                                    editCompletion={editCompletion}
                                />
                            }
                        </>
                    }

                    {
                        //userInfo && userInfo.userRoles.includes('customer') &&
                        <>
                            {
                                curPage === 6 && // sequences
                                <Page6
                                    userInfo={userInfo}
                                    plotId={plotId}
                                    logLineDescription={logLineDescription}
                                    genres={genres}
                                    problemTemplate={problemTemplate}
                                    dramaticQuestion={dramaticQuestion}
                                    keywords={keywords}
                                    sequences={sequences}
                                    characters={characters}
                                    updateSequenceCompletions={updateExpandedSummaryCompletions}
                                    heroCharacterArchetype={heroCharacterArchetype}
                                    editCompletion={editCompletion}
                                />
                            }
                        </>
                    }

                    {
                        curPage === pageNames.length - 1 &&
                        <>
                            {
                                sequences.map((sequence) => (
                                    <span key={sequence.sequenceName}>
                                        <p className='fs-5' title={sequence.sequenceName}>{getText(sequence, 'text', 'completions')}</p>
                                    </span>
                                ))
                            }
                        </>
                    }


                    <div className='row pt-5'>
                        <div className='col'>
                            <Pagination
                                showPrevNext={false}
                                curPage={curPage}
                                prevPage={prevPage}
                                nextPage={nextPage}
                                goToPage={goToPage}
                                pageNames={pageNames}
                            />
                        </div>
                    </div>
                    <p className='text-muted text-end'>
                        {
                            lastSaveSuccess === null &&
                            <span>not yet saved in this session</span>
                        }
                        {
                            lastSaveSuccess !== null &&
                            <span>last saved: {new Date(lastSaveSuccess).toLocaleTimeString()}</span>
                        }
                    </p>
                </div>
            </div>
        </>

    )
}

export default DisplaySimple