import React from 'react'
//import Genres from '../Fields/Genres'
import Keywords from '../Fields/Keywords'
import GenresAdvice from '../Advice/GenresAdvice'
import AppealTermsAdvice from '../Advice/AppealTermsAdvice'
import KeywordsBrainstorm from '../Brainstorm/KeywordsBrainstorm'
import AppealTermsBrowser from '../AppealTerms/AppealTermsBrowser'

const Page0 = (
    {
        genreOptions,
        genres,
        onGenresChange,
        onFocusChange,
        mode,

        setGenres,
        appealTermsOptions,
        appealTerms,
        setAppealTerms,

        keywords,
        onKeywordsChange,
    }
) => {

    return (
        <>
            <div className="card-group">
                <div className="card">

                    <div className="card-body">
                        <div className='fs-5 mb-3'>
                            {/* <Genres
                                genreOptions={genreOptions}
                                genres={genres}
                                onGenresChange={onGenresChange}
                                onFocusChange={onFocusChange}
                                mode={mode}
                            /> */}
                            <AppealTermsBrowser
                                genres={genres}
                                setGenres={setGenres}
                                genreOptions={genreOptions}
                                appealTermsOptions={appealTermsOptions}
                                appealTerms={appealTerms}
                                setAppealTerms={setAppealTerms}
                            />
                        </div>
                    </div>
                </div>
            </div>
            <div className='card-group'>
                <div className='card'>
                    <div className='card-body'>
                        <GenresAdvice
                            genres={genres}
                        />
                    </div>
                </div>
                <div className='card'>
                    <div className='card-body'>
                        <AppealTermsAdvice
                            appealTerms={appealTerms}
                        />
                    </div>
                </div>
                <div className="card">
                    <div className="card-body">
                        <div className='fs-5 mb-3'>
                            <Keywords
                                keywords={keywords}
                                onKeywordsChange={onKeywordsChange}
                                onFocusChange={onFocusChange}
                                mode={mode}
                            />
                        </div>
                        <KeywordsBrainstorm
                            keywords={keywords}
                            onKeywordsChange={onKeywordsChange}
                            genres={genres}
                        />
                    </div>
                </div>
            </div>
        </>
    )
}

export default Page0