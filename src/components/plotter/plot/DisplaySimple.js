import React, { useState } from 'react'
import Pagination from './SimplePages/Pagination'
import Page0 from './SimplePages/Page0'

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

    const totalPages = 3

    return (

        <>
            <div className='row pb-5'>
                <div className='col-12'>
                    {
                        curPage === 0 &&
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
                        curPage === 1 &&
                        <div className="card-group">
                            <div className="card">

                                <div className="card-body">
                                    <h5 className="card-title">Card title</h5>
                                    <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer. With supporting text below as a natural lead-in to additional content. With supporting text below as a natural lead-in to additional content. With supporting text below as a natural lead-in to additional content. With supporting text below as a natural lead-in to additional content. </p>
                                    <p className="card-text"><small className="text-muted">Last updated 3 mins ago</small></p>
                                </div>
                            </div>
                            <div className="card">
                                <div className="card-body">
                                    <h5 className="card-title">Card title</h5>
                                    <p className="card-text">This card has supporting text below as a natural lead-in to additional content.</p>
                                    <p className="card-text"><small className="text-muted">Last updated 3 mins ago</small></p>
                                </div>
                            </div>
                        </div>
                    }

                    <Pagination
                        curPage={curPage}
                        prevPage={prevPage}
                        nextPage={nextPage}
                        goToPage={goToPage}
                        totalPages={totalPages}
                    />
                </div>
            </div>
        </>

    )
}

export default DisplaySimple