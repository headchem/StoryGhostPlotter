

const GenreDescription = ({ logLine }) => {

    return (
        <div>
            {
                logLine.genreDescObj && <>
                    Genre desc obj goes here
                    <p>name: {logLine.genreDescObj.name}</p>
                    <p>desc: {logLine.genreDescObj.description}</p>
                </>
            }
        </div>
    )
}

export default GenreDescription
