import React, { useState } from 'react'
import Pagination from './SimplePages/Pagination'
import Page0 from './SimplePages/Page0'
import Page1 from './SimplePages/Page1'
import Page2 from './SimplePages/Page2'
import Page3 from './SimplePages/Page3'
import Page4 from './SimplePages/Page4'
import Page5 from './SimplePages/Page5'

const DisplaySimple = (
    {
        userInfo,
        plotId,
        mode,
        genreOptions,
        genres,
        onGenresChange,
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
        logLineDescriptionTokenCount,
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
        totalTokens,

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
        'Genres/Keywords',
        'Log Line',
        'Problem/Theme',
        'Characters',
        'Review',
        'Sequences',
        'Final'
    ] : [
        'Genres/Keywords',
        'Log Line',
        'Problem/Theme',
        'Characters',
        'Review',
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

                            keywords={keywords}
                            onKeywordsChange={onKeywordsChange}
                        />
                    }
                    {
                        curPage === 1 && // logline desc and title
                        <Page1
                            userInfo={userInfo}

                            genres={genres}
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
                        userInfo && userInfo.userRoles.includes('customer') &&
                        <>
                            {
                                curPage === 5 && // sequences
                                <Page5
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
                                />
                            }
                        </>
                    }

                    {
                        curPage === pageNames.length - 1 &&
                        <>
                            <p>Last page here. Paragraph explaining what to do next.</p>
                            <p>Link to display story page?</p>
                            <p>Link to advanced UI?</p>
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
                </div>
            </div>
        </>

    )
}

export default DisplaySimple