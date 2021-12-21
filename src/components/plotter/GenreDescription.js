

const GenreDescription = ({ genreDescObj }) => {

    return (
        <div>
            {
                genreDescObj && <>
                    Genre desc obj goes here
                    <p>name: {genreDescObj.name}</p>
                    <p>desc: {genreDescObj.description}</p>
                </>
            }
        </div>
    )
}

export default GenreDescription
