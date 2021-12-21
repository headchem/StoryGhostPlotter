

const HeroArchetypeDescription = ({ heroArchetypeDescObj }) => {

    return (
        <div>
            {
                heroArchetypeDescObj && <>
                    Hero Archetype desc obj goes here
                    <p>name: {heroArchetypeDescObj.name}</p>
                    <p>desc: {heroArchetypeDescObj.description}</p>
                </>
            }
        </div>
    )
}

export default HeroArchetypeDescription
