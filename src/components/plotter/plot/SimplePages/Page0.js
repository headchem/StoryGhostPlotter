import React from 'react'
import Genres from '../Fields/Genres'
import GenresAdvice from '../Advice/GenresAdvice'

const Page0 = (
    {
        genreOptions,
        genres,
        onGenresChange,
        onFocusChange,
        mode
    }
) => {

    return (
        <>
            <div className="card-group">
                <div className="card">

                    <div className="card-body">
                        {/* <h5 className="card-title">Card title</h5>
                        <p className="card-text">This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer. With supporting text below as a natural lead-in to additional content. With supporting text below as a natural lead-in to additional content. With supporting text below as a natural lead-in to additional content. With supporting text below as a natural lead-in to additional content. </p> */}
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
                        <h5 className="card-title">Card title</h5>
                        <p className="card-text">This card has supporting text below as a natural lead-in to additional content.</p>

                    </div>
                </div>
            </div>
        </>
    )
}

export default Page0