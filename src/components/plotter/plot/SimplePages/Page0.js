import React from 'react'
import Genres from '../Fields/Genres'
import Keywords from '../Fields/Keywords'
import GenresAdvice from '../Advice/GenresAdvice'
import KeywordsBrainstorm from '../Brainstorm/KeywordsBrainstorm'

const Page0 = (
    {
        genreOptions,
        genres,
        onGenresChange,
        onFocusChange,
        mode,

        keywords,
        onKeywordsChange,
    }
) => {

    return (
        <>
            <div className="card-group">
                <div className="card">

                    <div className="card-body">
                        <Genres
                            genreOptions={genreOptions}
                            genres={genres}
                            onGenresChange={onGenresChange}
                            onFocusChange={onFocusChange}
                            mode={mode}
                        />
                        <GenresAdvice
                            genres={genres}
                        />
                    </div>
                </div>
                <div className="card">
                    <div className="card-body">
                        <Keywords
                            keywords={keywords}
                            onKeywordsChange={onKeywordsChange}
                            onFocusChange={onFocusChange}
                            mode={mode}
                        />
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