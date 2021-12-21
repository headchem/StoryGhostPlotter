

const PrimalStakesDescription = ({ logLine }) => {

    return (
        <div>
            {
                logLine.primalStakesDescObj && <>
                    Primal Stakes desc obj goes here
                    <p>name: {logLine.primalStakesDescObj.name}</p>
                    <p>desc: {logLine.primalStakesDescObj.description}</p>
                </>
            }
        </div>
    )
}

export default PrimalStakesDescription
