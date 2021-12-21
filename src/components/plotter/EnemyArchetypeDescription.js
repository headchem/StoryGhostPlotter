

const EnemyArchetypeDescription = ({ enemyArchetypeDescObj }) => {

    return (
        <div>
            {
                enemyArchetypeDescObj && <>
                    Enemy Archetype desc obj goes here
                    <p>name: {enemyArchetypeDescObj.name}</p>
                    <p>desc: {enemyArchetypeDescObj.description}</p>
                </>
            }
        </div>
    )
}

export default EnemyArchetypeDescription
