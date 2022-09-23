import React from 'react'
import AppealTermsBrainstorm from './Brainstorm/AppealTermsBrainstorm'
import KeywordsBrainstorm from './Brainstorm/KeywordsBrainstorm'
import TitleBrainstorm from './Brainstorm/TitleBrainstorm';
import LogLineDescriptionBrainstorm from './Brainstorm/LogLineDescriptionBrainstorm'
import GenresAdvice from './Advice/GenresAdvice'
import AppealTermsAdvice from './Advice/AppealTermsAdvice'
import ProblemTemplateAdvice from './Advice/ProblemTemplateAdvice'
import DramaticQuestionAdvice from './Advice/DramaticQuestionAdvice'

const LogLineObjDetails = (
    {
        userInfo,
        plotId,
        onKeywordsChange,
        logLineDescription,
        updateLogLineDescription,
        AILogLineDescriptions,
        AITitles,
        updateLogLineDescriptionCompletions,
        setTitle,
        curFocusElName,
        genres,
        appealTerms,
        problemTemplate,
        dramaticQuestion,
        keywords,
        setAITitles,
        tokensRemaining
    }
) => {

    return (
        <>
            {
                curFocusElName === 'genres' &&
                <GenresAdvice
                    genres={genres}
                />
            }
            {
                curFocusElName === 'appealTerms' &&
                <>
                    <AppealTermsAdvice
                        appealTerms={appealTerms}
                    />
                    <hr />
                    <AppealTermsBrainstorm
                        genres={genres}
                    />
                </>
            }
            {
                curFocusElName === 'keywords' &&
                <KeywordsBrainstorm
                    keywords={keywords}
                    onKeywordsChange={onKeywordsChange}
                    genres={genres}
                />
            }
            {
                (curFocusElName === 'logLineDescription') &&
                <LogLineDescriptionBrainstorm
                    userInfo={userInfo}
                    plotId={plotId}
                    completions={AILogLineDescriptions}
                    updateLogLineDescription={updateLogLineDescription}
                    updateLogLineDescriptionCompletions={updateLogLineDescriptionCompletions}
                    genres={genres}
                    keywords={keywords}
                    tokensRemaining={tokensRemaining}
                />
            }
            {
                curFocusElName === 'title' &&
                <TitleBrainstorm
                    userInfo={userInfo}
                    plotId={plotId}
                    setTitle={setTitle}
                    AITitles={AITitles}
                    logLineDescription={logLineDescription}
                    genres={genres}
                    setAITitles={setAITitles}
                    tokensRemaining={tokensRemaining}
                />
            }
            {
                curFocusElName === 'problem template' &&
                <ProblemTemplateAdvice
                    problemTemplate={problemTemplate}
                    showHeader={true}
                />
            }
            {
                curFocusElName === 'dramatic question' &&
                <DramaticQuestionAdvice
                    dramaticQuestion={dramaticQuestion}
                    showHeader={true}
                />
            }
        </>
    )
}

export default LogLineObjDetails