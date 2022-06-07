import React from 'react'
import Select from 'react-select';
import LimitedTextArea from './LimitedTextArea'
import LogLineSelect from './LogLineSelect'
import LogLineObjDetails from './LogLineObjDetails'
import LogLineBrainstormAll from './LogLineBrainstormAll'

const LogLine = (
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

        tokensRemaining
    }
) => {


    var selectTheme = (theme) => {
        if (mode === 'dark') {
            const darkTheme = {
                ...theme,
                borderRadius: 0,
                colors: {
                    ...theme.colors,
                    neutral0: '#222',
                    neutral5: '#333',
                    neutral10: '#444',
                    neutral20: '#666',
                    neutral30: '#888',
                    neutral40: '#999',
                    neutral50: '#aaa',
                    neutral60: '#bbb',
                    neutral70: '#ccc',
                    neutral80: '#ddd',
                    neutral90: '#eee',

                    primary: '#444',
                    primary25: '#333',
                    primary50: '#444',
                    primary75: '#555',

                    danger: '#ffb3ab',
                    dangerLight: '#601a13'
                },
            }

            return darkTheme;
        } else {
            return theme
        }
    }

    return (
        <>
            <div className='col-md-7 logline'>
                <div className='row pb-3'>
                    <div className='col-md-3'>
                        <label htmlFor="genres" className="form-label">Genres</label>
                    </div>
                    <div className='col-md-9'>
                        <div style={{ width: '100%' }}>
                            <Select
                                defaultValue={genreOptions.filter(o => genres.indexOf(o.value) > -1)}
                                isMulti
                                name="genres"
                                options={genreOptions}
                                className="genres-multi-select"
                                classNamePrefix="select"
                                onChange={onGenresChange}
                                onFocus={() => onFocusChange('genres')}
                                theme={selectTheme}
                            />
                        </div>
                    </div>
                </div>

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


                <div className='row pb-3'>
                    <div className='col-md-3'>
                        <label htmlFor="keywords" className="form-label">Keywords:</label>
                    </div>
                    <div className='col-md-9'>
                        <div style={{ width: '100%' }}>
                            <LogLineSelect
                                selectTheme={selectTheme}
                                placeholder='Keywords'
                                isMultiSelect={true}
                                onFocusChange={() => onFocusChange('keywords')}
                                value={keywords}
                                onChange={onKeywordsChange}
                            />
                        </div>
                    </div>
                </div>

                <div className='row pb-3'>
                    <div className='col-md-3'>
                        <label htmlFor="logLineDesc" className="form-label">Log Line</label>
                    </div>
                    <div className='col-md-9'>
                        <LimitedTextArea
                            id='logLineDesc'
                            className="form-control"
                            value={logLineDescription}
                            setValue={(newValue) => onLogLineDescriptionChange(newValue)}
                            rows={4}
                            limit={700}
                            curTokenCount={logLineDescriptionTokenCount}
                            showCount={true}
                            onFocus={() => onFocusChange('logLineDescription')}
                        />
                    </div>
                </div>

                <div className='row pb-3'>
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
                            onFocus={() => onFocusChange('title')}
                            aria-describedby="titleHelp"
                            id="title" />
                    </div>
                </div>

                <div className='row pb-3'>
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
                                onFocus={() => onFocusChange('problem template')}>
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

                <div className='row pb-3'>
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
                            onFocus={() => onFocusChange('dramatic question')}>
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
                    logLineDescription={logLineDescription}
                    updateLogLineDescriptionCompletions={updateLogLineDescriptionCompletions}
                    AILogLineDescriptions={AILogLineDescriptions}
                    AITitles={AITitles}
                    setAITitles={setAITitles}
                    curFocusElName={curFocusElName}
                    genres={genres}
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