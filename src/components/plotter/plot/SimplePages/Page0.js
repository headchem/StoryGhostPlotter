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
                        <div className='fs-5 mb-3'>
                            <Genres
                                genreOptions={genreOptions}
                                genres={genres}
                                onGenresChange={onGenresChange}
                                onFocusChange={onFocusChange}
                                mode={mode}
                            />
                        </div>
                        <GenresAdvice
                            genres={genres}
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