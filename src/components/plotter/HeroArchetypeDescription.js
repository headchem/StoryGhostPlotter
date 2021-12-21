

const HeroArchetypeDescription = ({ logLine }) => {

    return (
        <div>
            {
                logLine.heroArchetypeDescObj && <>
                    Hero Archetype desc obj goes here
                    <p>name: {logLine.heroArchetypeDescObj.name}</p>
                    <p>desc: {logLine.heroArchetypeDescObj.description}</p>
                </>
            }
        </div>
    )
}

export default HeroArchetypeDescription
