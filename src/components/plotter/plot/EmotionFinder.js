import React, { useState } from 'react'


const EmotionFinder = ({
    emotions,
}) => {

    const dotproduct = (a, b) => {
        var n = 0, lim = Math.min(a.length, b.length);
        for (var i = 0; i < lim; i++) n += a[i] * b[i];
        return n;
    }

    const norm2 = (a) => {
        var sumsqr = 0;
        for (var i = 0; i < a.length; i++) {
            sumsqr += a[i] * a[i];
        }
        return Math.sqrt(sumsqr);
    }

    const cosineSim = (a, b) => {
        for (let i = 0; i < a.length; i++) {
            // change scale from -1/+1 to 0/+1
            a[i] = (parseFloat(a[i]) + 1) / 2
            b[i] = (parseFloat(b[i]) + 1) / 2
        }

        return dotproduct(a, b) / norm2(a) / norm2(b);
    }

    const euclideanSim = (a, b) => {
        // for (let i = 0; i < a.length; i++) {
        //     // change scale from -1/+1 to 0/+1
        //     a[i] = (parseFloat(a[i]) + 1) / 2
        //     b[i] = (parseFloat(b[i]) + 1) / 2
        // }

        return a
            .map((x, i) => Math.abs(x - b[i]) ** 2) // square the difference
            .reduce((sum, now) => sum + now) // sum
            ** (1 / 2)
    }

    const [joyToSadness, setJoyToSadness] = useState(0.0)
    const [trustToDisgust, setTrustToDisgust] = useState(0.0)
    const [fearToAnger, setFearToAnger] = useState(0.0)
    const [surpriseToAnticipation, setSurpriseToAnticipation] = useState(0.0)

    const [bestEmotionMatches, setBestEmotionMatches] = useState([])
    //const [worstEmotionMatches, setWorstEmotionMatches] = useState([])

    const onJoyToSadnessChange = (val) => {
        setJoyToSadness(val)
        search()
    }

    const onTrustToDisgustChange = (val) => {
        setTrustToDisgust(val)
        search()
    }

    const onFearToAngerChange = (val) => {
        setFearToAnger(val)
        search()
    }

    const onSurpriseToAnticipationChange = (val) => {
        setSurpriseToAnticipation(val)
        search()
    }

    const search = () => {
        let cosineResults = {}
        let euclideanResults = {}

        emotions.forEach(emotion => {
            //console.log(emotion)
            var searchVector = [joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation]
            var curEmoVector = [emotion.joyToSadness, emotion.trustToDisgust, emotion.fearToAnger, emotion.surpriseToAnticipation]

            // this jitter seemed to improve tie-breaker scenarios
            // for (let i = 0; i < searchVector.length; i++) {
            //     searchVector[i] += Math.random() * 0.00000001
            //     curEmoVector[i] += Math.random() * 0.00000001
            // }

            var cosineDist = cosineSim(searchVector, curEmoVector);
            var euclideanDist = euclideanSim(searchVector, curEmoVector)

            //console.log(dist)

            cosineResults[emotion.id] = cosineDist
            euclideanResults[emotion.id] = euclideanDist
        });

        //console.log(cosineResults)
        //console.log(euclideanResults)

        // sort dict, which needs the following in js: https://stackoverflow.com/a/25500462
        // Create items array
        var cosineItems = Object.keys(cosineResults).map(function (key) {
            return [key, cosineResults[key]];
        });

        // Sort the array based on the second element
        cosineItems.sort(function (first, second) {
            return second[1] - first[1];
        });

        var eucItems = Object.keys(euclideanResults).map(function (key) {
            return [key, euclideanResults[key]];
        });

        // Sort the array based on the second element
        eucItems.sort(function (first, second) {
            return first[1] - second[1];
        });

        let cosineTop = cosineItems.slice(0, 3).map((i) => i[0])
        let eucTop = eucItems.slice(0, 3).map((i) => i[0])

        const intersection = cosineTop.filter(value => eucTop.includes(value));

        if (!intersection || intersection.length === 0) {
            setBestEmotionMatches([cosineTop[0], eucTop[0]])
        } else {
            setBestEmotionMatches(intersection.slice(0, 2))
        }
    }

    const bestMatchesListItems = bestEmotionMatches.map((emo) => <li key={emo}>{emo}</li>)

    return (
        <>
            {
                emotions &&
                <>
                    <div className='row'>
                        <label>joyToSadness
                            <input type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onJoyToSadnessChange(parseFloat(e.target.value))} value={joyToSadness} />
                        </label>
                        <span>{joyToSadness}</span>
                    </div>
                    <div className='row'>
                        <label>trustToDisgust
                            <input type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onTrustToDisgustChange(parseFloat(e.target.value))} value={trustToDisgust} />
                        </label>
                        <span>{trustToDisgust}</span>
                    </div>
                    <div className='row'>
                        <label>fearToAnger
                            <input type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onFearToAngerChange(parseFloat(e.target.value))} value={fearToAnger} />
                        </label>
                        <span>{fearToAnger}</span>
                    </div>
                    <div className='row'>
                        <label>surpriseToAnticipation
                            <input type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onSurpriseToAnticipationChange(parseFloat(e.target.value))} value={surpriseToAnticipation} />
                        </label>
                        <span>{surpriseToAnticipation}</span>
                    </div>

                    <ul>
                        {bestMatchesListItems}
                    </ul>
                </>
            }

        </>
    )
}

export default EmotionFinder