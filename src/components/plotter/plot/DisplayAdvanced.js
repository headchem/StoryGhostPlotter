import React from 'react'
import Tabs from 'react-bootstrap/Tabs'
import Tab from 'react-bootstrap/Tab'

import LogLine from './LogLine'
import SequenceList from './SequenceList'
import CharacterList from './CharacterList'
import CharacterBrainstormAll from './Brainstorm/CharacterBrainstormAll';

const DisplayAdvanced = (
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

    return (

        <>
            <div className='row pb-5'>
                <LogLine
                    userInfo={userInfo}
                    plotId={plotId}
                    mode={mode}
                    genreOptions={genreOptions}
                    genres={genres}
                    onGenresChange={onGenresChange}
                    onFocusChange={onFocusChange}

                    setKeywords={setKeywords}
                    setLogLineDescription={setLogLineDescription}
                    setTitle={setTitle}
                    setProblemTemplate={setProblemTemplate}
                    setDramaticQuestion={setDramaticQuestion}

                    keywords={keywords}
                    onKeywordsChange={onKeywordsChange}
                    logLineDescription={logLineDescription}
                    onLogLineDescriptionChange={onLogLineDescriptionChange}
                    logLineDescriptionTokenCount={logLineDescriptionTokenCount}

                    onTitleChange={onTitleChange}
                    title={title}

                    problemTemplate={problemTemplate}
                    onProblemTemplateChange={onProblemTemplateChange}

                    problemTemplateOptions={problemTemplateOptions}

                    dramaticQuestion={dramaticQuestion}
                    onDramaticQuestionChange={onDramaticQuestionChange}
                    dramaticQuestionOptions={dramaticQuestionOptions}

                    updateLogLineDescriptionCompletions={updateLogLineDescriptionCompletions}
                    AILogLineDescriptions={AILogLineDescriptions}
                    AITitles={AITitles}
                    setAITitles={setAITitles}

                    curFocusElName={curFocusElName}

                    tokensRemaining={tokensRemaining}
                />
            </div>

            {
                logLineIncomplete === true &&
                <p>All fields above must be completed.</p>
            }
            {
                logLineIncomplete === false &&
                <Tabs defaultActiveKey="characters" className="mb-3" onFocus={() => onFocusChange('tabs')}>
                    <Tab eventKey="characters" title="1. Characters">
                        {
                            userInfo && userInfo.userRoles.includes('customer') &&
                            <CharacterBrainstormAll
                                userInfo={userInfo}
                                plotId={plotId}
                                logLineDescription={logLineDescription}
                                problemTemplate={problemTemplate}
                                dramaticQuestion={dramaticQuestion}
                                setCharacters={setCharacters}
                                tokensRemaining={tokensRemaining}
                            />
                        }

                        {
                            <CharacterList
                                plotId={plotId}
                                characters={characters}
                                userInfo={userInfo}
                                archetypeOptions={archetypeOptions}
                                onFocusChange={onFocusChange}
                                updateCharacterName={updateCharacterName}
                                updateCharacterIsHero={updateCharacterIsHero}
                                updateCharacterArchetype={updateCharacterArchetype}
                                updateCharacterDescription={updateCharacterDescription}
                                updateAICharacterCompletion={updateAICharacterCompletion}
                                updateCharacterPersonality={updateCharacterPersonality}
                                insertCharacter={insertCharacter}
                                deleteCharacter={deleteCharacter}

                                tokensRemaining={tokensRemaining}
                            />
                        }
                    </Tab>
                    <Tab eventKey="blurbs" title="2. Blurbs">
                        <p>Write the absolute minimum logical sequence of events that propel the story. This should be a dry A therefore B therefore C style of writing.</p>
                        {
                            hideBlurbs === true &&
                            <p>You must have a protagonist character with an archetype, and all characters must have a name.</p>
                        }
                        {
                            hideBlurbs === false &&
                            <>
                                {
                                    <SequenceList
                                        sequenceType='blurb'
                                        plotId={plotId}
                                        sequences={sequences}
                                        userInfo={userInfo}
                                        logLineDescription={logLineDescription}
                                        setLastFocusedSequenceName={setLastFocusedSequenceName}
                                        lastFocusedSequenceName={lastFocusedSequenceName}
                                        updateBlurb={updateBlurb}
                                        updateExpandedSummary={updateExpandedSummary}
                                        updateFull={updateFull}
                                        insertSequence={insertSequence}
                                        deleteSequence={deleteSequence}
                                        genres={genres}
                                        problemTemplate={problemTemplate}
                                        keywords={keywords}
                                        characters={characters}
                                        heroCharacterArchetype={heroCharacterArchetype}
                                        dramaticQuestion={dramaticQuestion}
                                        updateBlurbCompletions={updateBlurbCompletions}
                                        updateExpandedSummaryCompletions={updateExpandedSummaryCompletions}
                                        updateFullCompletions={updateFullCompletions}
                                        setSequences={setSequences}

                                        tokensRemaining={tokensRemaining}
                                    />
                                }
                            </>
                        }
                    </Tab>
                    <Tab eventKey="expandedSummaries" title="3. Expanded Summaries">
                        <p>Expand the logical blurbs into more colorful paragraphs, including details of the setting, characters, emotions, and symbolism.</p>
                        {
                            hideBlurbs === false &&
                            <SequenceList
                                sequenceType='expandedSummary'
                                plotId={plotId}
                                sequences={sequences}
                                userInfo={userInfo}
                                logLineDescription={logLineDescription}
                                setLastFocusedSequenceName={setLastFocusedSequenceName}
                                lastFocusedSequenceName={lastFocusedSequenceName}
                                updateBlurb={updateBlurb}
                                updateExpandedSummary={updateExpandedSummary}
                                updateFull={updateFull}
                                insertSequence={insertSequence}
                                deleteSequence={deleteSequence}
                                genres={genres}
                                problemTemplate={problemTemplate}
                                keywords={keywords}
                                characters={characters}
                                heroCharacterArchetype={heroCharacterArchetype}
                                dramaticQuestion={dramaticQuestion}
                                updateBlurbCompletions={updateBlurbCompletions}
                                updateExpandedSummaryCompletions={updateExpandedSummaryCompletions}
                                updateFullCompletions={updateFullCompletions}
                                setSequences={setSequences}

                                tokensRemaining={tokensRemaining}
                            />
                        }
                        {
                            blurbsIncomplete &&
                            <p>Not all blurbs have been completed. Additional expanded summaries will only appear when their corresponding blurb has been entered.</p>
                        }

                    </Tab>
                    {
                        userInfo && userInfo.userRoles.includes('admin') &&
                        <Tab eventKey="full" title="4. Full">
                            <p>Expand the summaries into full prose or a screenplay.</p>

                            {
                                hideBlurbs === false &&
                                <SequenceList
                                    sequenceType='full'
                                    plotId={plotId}
                                    sequences={sequences}
                                    userInfo={userInfo}
                                    logLineDescription={logLineDescription}
                                    setLastFocusedSequenceName={setLastFocusedSequenceName}
                                    lastFocusedSequenceName={lastFocusedSequenceName}
                                    updateBlurb={updateBlurb}
                                    updateExpandedSummary={updateExpandedSummary}
                                    updateFull={updateFull}
                                    insertSequence={insertSequence}
                                    deleteSequence={deleteSequence}
                                    genres={genres}
                                    problemTemplate={problemTemplate}
                                    keywords={keywords}
                                    characters={characters}
                                    heroCharacterArchetype={heroCharacterArchetype}
                                    dramaticQuestion={dramaticQuestion}
                                    updateBlurbCompletions={updateBlurbCompletions}
                                    updateExpandedSummaryCompletions={updateExpandedSummaryCompletions}
                                    updateFullCompletions={updateFullCompletions}
                                    setSequences={setSequences}

                                    tokensRemaining={tokensRemaining}
                                />
                            }
                            {
                                expandedSummariesIncomplete &&
                                <p>Not all blurbs and expanded summaries have been completed. Additional full text areas will only appear when their corresponding blurbs and expanded summary has been entered.</p>
                            }
                        </Tab>
                    }
                </Tabs>

            }
            <div className='row mb-4 pt-5 border-top'>
                <div className='col-8'>
                    <button className='btn btn-primary' onClick={goToViewPlot}>View and Share</button>
                </div>
                <div className="col-2 form-check" title="check this box to make your plot public">
                    <label className="form-check-label" htmlFor={isPublicCheckboxId}>
                        Is Public
                    </label>
                    <input id={isPublicCheckboxId} className='form-check-input' type='checkbox' onChange={onIsPublicChange} checked={isPublic} />

                </div>
                <div className='col-2'>
                    <p className='text-muted text-end'>
                        {
                            lastSaveSuccess === null &&
                            <span>not yet saved in this session</span>
                        }
                        {
                            lastSaveSuccess !== null &&
                            <span>last saved: {new Date(lastSaveSuccess).toLocaleTimeString()}</span>
                        }
                        {
                            <>
                                <br />
                                <span>{totalTokens}/{2048 - 320} tokens</span>
                            </>
                        }
                    </p>
                </div>
            </div>
        </>

    )
}

export default DisplayAdvanced