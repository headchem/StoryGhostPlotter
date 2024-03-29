import React from 'react'
import LimitedTextArea from './LimitedTextArea'
import LogLineObjDetails from './LogLineObjDetails'
import LogLineBrainstormAll from './Brainstorm/LogLineBrainstormAll'
import Genres from './Fields/Genres'
import AppealTerms from './Fields/AppealTerms'
import Keywords from './Fields/Keywords'

const LogLine = (
    {
        userInfo,
        plotId,
        mode,
        genreOptions,
        genres,
        onGenresChange,
        appealTermsOptions,
        appealTerms,
        onAppealTermsChange,
        onFocusChange,

        setKeywords,
        setLogLineDescription,
        setTitle,
        setProblemTemplate,
        setDramaticQuestion,
        keywords,
        onKeywordsChange,
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

        tokensRemaining
    }
) => {

    const selectedLogLineBrainstorm = AILogLineDescriptions ? AILogLineDescriptions.filter(brainstorm => brainstorm['isSelected'] === true) : null

    return (
        <>
            <div className='col-md-7 logline'>
                <div className='row pb-3' onClick={() => onFocusChange('genres')}>
                    <div className='col-md-3'>
                        <label htmlFor="genres" className="form-label">Genres</label>
                    </div>
                    <div className='col-md-9'>
                        <Genres
                            genreOptions={genreOptions}
                            genres={genres}
                            onGenresChange={onGenresChange}
                            mode={mode}
                        />
                    </div>
                </div>

                {
                    userInfo && userInfo.userRoles.includes('admin') &&
                    <div className='row pb-3' onClick={() => onFocusChange('appealTerms')}>
                        <div className='col-md-3'>
                            <label htmlFor="appealTerms" className="form-label">Appeal Terms</label>
                        </div>
                        <div className='col-md-9'>
                            <AppealTerms
                                genres={genres}
                                appealTermsOptions={appealTermsOptions}
                                appealTerms={appealTerms}
                                onAppealTermsChange={onAppealTermsChange}
                                mode={mode}
                            />
                        </div>
                    </div>
                }

                {
                    userInfo && userInfo.userRoles.includes('customer') &&
                    <LogLineBrainstormAll
                        plotId={plotId}
                        genres={genres}
                        setKeywords={setKeywords}
                        setLogLineDescription={setLogLineDescription}
                        setTitle={setTitle}
                        setProblemTemplate={setProblemTemplate}
                        setDramaticQuestion={setDramaticQuestion}
                        tokensRemaining={tokensRemaining}
                    />
                }


                <div className='row pb-3' onClick={() => onFocusChange('keywords')}>
                    <div className='col-md-3'>
                        <label htmlFor="keywords" className="form-label">Keywords:</label>
                    </div>
                    <div className='col-md-9'>
                        <Keywords
                            keywords={keywords}
                            onKeywordsChange={onKeywordsChange}
                            //onFocusChange={onFocusChange}
                            mode={mode}
                        />
                    </div>
                </div>

                <div className='row pb-3' onClick={() => onFocusChange('logLineDescription')}>
                    <div className='col-md-3'>
                        <label htmlFor="logLineDesc" className="form-label">Log Line</label>
                    </div>
                    <div className='col-md-9'>
                        {
                            selectedLogLineBrainstorm && selectedLogLineBrainstorm.length > 0 &&
                            <p>{selectedLogLineBrainstorm[0]['completion']}</p>
                        }
                        {
                            (!selectedLogLineBrainstorm || selectedLogLineBrainstorm.length === 0) &&
                            <LimitedTextArea
                                id='logLineDesc'
                                className="form-control"
                                value={logLineDescription}
                                setValue={(newValue) => onLogLineDescriptionChange(newValue)}
                                rows={4}
                                limit={700}
                                showCount={true}
                            />
                        }

                    </div>
                </div>

                <div className='row pb-3' onClick={() => onFocusChange('title')}>
                    <div className='col-md-3'>
                        <label htmlFor="title" className="form-label">Title</label>
                    </div>
                    <div className='col-md-9'>
                        <input
                            type='text'
                            className='fs-5 form-control'
                            placeholder='Plot Title'
                            required
                            onChange={onTitleChange}
                            //defaultValue={title}
                            value={title}
                            //onFocus={() => onFocusChange('title')}
                            aria-describedby="titleHelp"
                            id="title" />
                    </div>
                </div>

                <div className='row pb-3' onClick={() => onFocusChange('problem template')}>
                    <div className='col-md-3'>
                        <label htmlFor="problemTemplate" className="form-label">Problem Template</label>
                    </div>
                    <div className='col-md-9'>
                        {
                            <select
                                id='problemTemplate'
                                required
                                className='fs-5 form-select'
                                value={!problemTemplate ? '' : problemTemplate}
                                //defaultValue={problemTemplate}
                                onChange={onProblemTemplateChange}
                            //onFocus={() => onFocusChange('problem template')}
                            >
                                <option key="blank" value="" disabled>Problem Template</option>
                                {
                                    problemTemplateOptions.map(function (o, idx) {
                                        return <option key={idx} value={o.value}>{o.label}</option>
                                    })
                                }
                            </select>
                        }

                    </div>
                </div>

                <div className='row pb-3' onClick={() => onFocusChange('dramatic question')}>
                    <div className='col-md-3'>
                        <label htmlFor="dramaticQuestion" className="form-label" title='also called the "theme"'>Dramatic Question</label>
                    </div>
                    <div className='col-md-9'>
                        <select
                            id='dramaticQuestion'
                            required
                            className='fs-5 form-select dramaticQuestionSelect'
                            value={!dramaticQuestion ? '' : dramaticQuestion}
                            onChange={onDramaticQuestionChange}
                        //onFocus={() => onFocusChange('dramatic question')}
                        >
                            <option key="blank" value="" disabled>Dramatic Question</option>
                            {
                                dramaticQuestionOptions.map(function (o) {
                                    return <option key={o.value} value={o.value}>{o.label}</option>
                                })
                            }
                        </select>
                    </div>
                </div>

            </div>
            <div className='col-md-5'>
                <LogLineObjDetails
                    userInfo={userInfo}
                    plotId={plotId}
                    onKeywordsChange={onKeywordsChange}
                    logLineDescription={logLineDescription}
                    updateLogLineDescription={setLogLineDescription}
                    updateLogLineDescriptionCompletions={updateLogLineDescriptionCompletions}
                    AILogLineDescriptions={AILogLineDescriptions}
                    setTitle={setTitle}
                    AITitles={AITitles}
                    setAITitles={setAITitles}
                    curFocusElName={curFocusElName}
                    genres={genres}
                    appealTerms={appealTerms}
                    problemTemplate={problemTemplate}
                    dramaticQuestion={dramaticQuestion}
                    keywords={keywords}
                    tokensRemaining={tokensRemaining}
                />
            </div>
        </>
    )
}

export default LogLine