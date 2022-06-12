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

    const totalPages = 6 // should match the number of pages in the SimplePages folder

    return (

        <>
            <div className='row pb-5'>
                <div className='col-12'>
                    <div className='row pb-5'>
                        <div className='col'>
                            <Pagination
                                curPage={curPage}
                                prevPage={prevPage}
                                nextPage={nextPage}
                                goToPage={goToPage}
                                totalPages={totalPages}
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
                        curPage === 3 && // logline overview
                        <Page3
                            title={title}
                            logLineDescription={logLineDescription}
                            genres={genres}
                            keywords={keywords}
                            problemTemplate={problemTemplate}
                            dramaticQuestion={dramaticQuestion}
                        />
                    }
                    {
                        curPage === 4 && // characters
                        <Page4
                            characters={characters}
                        />
                    }
                    {
                        curPage === 5 && // sequences
                        <Page5
                            sequences={sequences}
                        />
                    }

                    <div className='row pt-5'>
                        <div className='col'>
                            <Pagination
                                curPage={curPage}
                                prevPage={prevPage}
                                nextPage={nextPage}
                                goToPage={goToPage}
                                totalPages={totalPages}
                            />
                        </div>
                    </div>
                </div>
            </div>
        </>

    )
}

export default DisplaySimple