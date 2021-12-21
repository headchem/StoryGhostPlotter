

const PrimalStakesDescription = ({ primalStakesDescObj }) => {

    return (
        <div>
            {
                primalStakesDescObj && <>
                    Primal Stakes desc obj goes here
                    <p>name: {primalStakesDescObj.name}</p>
                    <p>desc: {primalStakesDescObj.description}</p>
                </>
            }
        </div>
    )
}

export default PrimalStakesDescription
