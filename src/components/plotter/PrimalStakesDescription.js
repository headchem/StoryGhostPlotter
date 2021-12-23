

const PrimalStakesDescription = ({ primalStakesDescObj }) => {

    return (
        <div>
            {
                primalStakesDescObj &&
                <>
                    <h2>{primalStakesDescObj.name}</h2>
                    <p>{primalStakesDescObj.description}</p>
                </>
            }
        </div>
    )
}

export default PrimalStakesDescription
