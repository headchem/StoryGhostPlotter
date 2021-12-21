

const EnemyArchetypeDescription = ({ logLine }) => {

    return (
        <div>
            {
                logLine.enemyArchetypeDescObj && <>
                    Enemy Archetype desc obj goes here
                    <p>name: {logLine.enemyArchetypeDescObj.name}</p>
                    <p>desc: {logLine.enemyArchetypeDescObj.description}</p>
                </>
            }
        </div>
    )
}

export default EnemyArchetypeDescription
