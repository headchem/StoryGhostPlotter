

const GenreDescription = ({ genreDescObj }) => {

    return (
        <div>
            {
                genreDescObj &&
                <>
                    <h2>{genreDescObj.name}</h2>
                    <p>{genreDescObj.description}</p>
                </>
            }
        </div>
    )
}

export default GenreDescription
