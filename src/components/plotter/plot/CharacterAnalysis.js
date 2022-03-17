import React from 'react'


const CharacterAnalysis = ({
    userInfo,

    character,
    characters,

}) => {

    const isOpposingPrimary = (aVal, bVal) => {
        if ((aVal < 0 && bVal > 0) || (aVal > 0 && bVal < 0)) {
            return true
        }
        return false
    }

    const eucDistance = (a, b) => {

        // if a and b are on different sides of the primary spectrum, then apply Math.abs to the aspect values in that axis, since it doesn't matter if the aspect is up or down

        // loop over first 5 positions, which represent the primary values
        for (var i = 0; i < 5; i++) {
            if (isOpposingPrimary(a[i], b[i])) {
                // aspect is 5 positions away from primary
                a[i + 5] = Math.abs(a[i + 5])
                b[i + 5] = Math.abs(b[i + 5])
            }
        }

        return a
            .map((x, i) => Math.abs(x - b[i]) ** 2) // square the difference
            .reduce((sum, now) => sum + now) // sum
            ** (1 / 2)
    }

    const otherCharacters = characters.filter((ch) => ch.id !== character.id)

    const getVector = (ch) => {
        if (!ch['personality']) return [0, 0, 0, 0, 0, 0, 0, 0, 0, 0]

        const closemindedToImaginativePrimary = ch['personality']['closemindedToImaginative']['primary']
        const coldToEmpatheticPrimary = ch['personality']['coldToEmpathetic']['primary']
        const disciplinedToSpontaneousPrimary = ch['personality']['disciplinedToSpontaneous']['primary']
        const introvertToExtrovertPrimary = ch['personality']['introvertToExtrovert']['primary']
        const unflappableToAnxiousPrimary = ch['personality']['unflappableToAnxious']['primary']

        const closemindedToImaginativeAspect = ch['personality']['closemindedToImaginative']['aspect']
        const coldToEmpatheticAspect = ch['personality']['coldToEmpathetic']['aspect']
        const disciplinedToSpontaneousAspect = ch['personality']['disciplinedToSpontaneous']['aspect']
        const introvertToExtrovertAspect = ch['personality']['introvertToExtrovert']['aspect']
        const unflappableToAnxiousAspect = ch['personality']['unflappableToAnxious']['aspect']

        const primaryScale = 2.0 // the idea is to amplify the distances for primary attributes so they have a bigger impact on distance than aspect

        let vec = [
            closemindedToImaginativePrimary * primaryScale,
            coldToEmpatheticPrimary * primaryScale,
            disciplinedToSpontaneousPrimary * primaryScale,
            introvertToExtrovertPrimary * primaryScale,
            unflappableToAnxiousPrimary * primaryScale,

            closemindedToImaginativeAspect,
            coldToEmpatheticAspect,
            disciplinedToSpontaneousAspect,
            introvertToExtrovertAspect,
            unflappableToAnxiousAspect
        ]

        return vec
    }

    const sortBySimilarity = () => {
        return function (a, b) {
            const distA = eucDistance(getVector(character), getVector(a))
            const distB = eucDistance(getVector(character), getVector(b))

            return (distA > distB) - (distA < distB)
        };
    }

    const mostSimilarCharacters = otherCharacters.sort(sortBySimilarity())

    const getDist = (otherChar) => {
        return eucDistance(getVector(character), getVector(otherChar))
    }

    const getDiffDesc = (dist) => {
        if (dist <= 2.51) return 'low'
        if (dist <= 5.1) return 'medium'
        return 'high'
    }

    const characterAnalysisItems = mostSimilarCharacters.map((otherCharacter) => {
        const dist = getDist(otherCharacter)
        const diffStr = getDiffDesc(dist)
        let className = ''
        let title = ''

        if (diffStr === 'low') {
            className = 'text-danger'
            title = 'These characters are very similar in personality. Extra care may be needed to help differentiate them.'
        }
        if (diffStr === 'medium') {
            className = 'text-warning'
        }
        if (diffStr === 'high') {
            className = 'text-success'
            title = 'These characters have extremely different personalities. Watch the sparks fly when they interact!'
        }

        return <li key={'char_analysis_' + otherCharacter.id} className={className} title={title}>
            <strong>{otherCharacter.name}</strong> ({otherCharacter.archetype}) {getDiffDesc(dist)} personality difference ({dist.toFixed(1)})
        </li>
    })

    return (
        <>
            <div className='col'>
                <p>Sorted from most to least similar (0 distance = identical)</p>
                <ul>
                    {
                        characterAnalysisItems
                    }
                </ul>
            </div>
        </>
    )
}

export default CharacterAnalysis