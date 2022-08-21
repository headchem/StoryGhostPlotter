import React, { useState } from 'react'


const EmotionFinder = ({
    emotions,
}) => {

    // const cosinesim = (A, B) => {
    //     var dotproduct = 0;
    //     var mA = 0;
    //     var mB = 0;
    //     for (let i = 0; i < A.length; i++) {
    //         dotproduct += (A[i] * B[i]);
    //         mA += (A[i] * A[i]);
    //         mB += (B[i] * B[i]);
    //     }
    //     mA = Math.sqrt(mA);
    //     mB = Math.sqrt(mB);
    //     var similarity = (dotproduct) / ((mA) * (mB))
    //     return similarity;
    // }

    const [joyToSadness, setJoyToSadness] = useState(0.0)
    const [trustToDisgust, setTrustToDisgust] = useState(0.0)
    const [fearToAnger, setFearToAnger] = useState(0.0)
    const [surpriseToAnticipation, setSurpriseToAnticipation] = useState(0.0)

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
        // LEFT OFF: loop through all emotions, calculate cosine distance to current slider values, sort by dist and show nearest/farthest results

        /*
        var array1 = [1,0,0,1];
        var array2 = [1,0,0,0];

        var p = cosinesim(array1,array2);
        */
    }

    return (
        <>
            {
                emotions &&
                <>
                    <div className='row'>
                        <label>joyToSadness
                            <input type="range" min="-1.0" max="1.0" step="0.2" onChange={(e) => onJoyToSadnessChange(parseFloat(e.target.value))} value={joyToSadness} />
                        </label>
                        <span>{joyToSadness}</span>
                    </div>
                    <div className='row'>
                        <label>trustToDisgust
                            <input type="range" min="-1.0" max="1.0" step="0.2" onChange={(e) => onTrustToDisgustChange(parseFloat(e.target.value))} value={trustToDisgust} />
                        </label>
                        <span>{trustToDisgust}</span>
                    </div>
                    <div className='row'>
                        <label>fearToAnger
                            <input type="range" min="-1.0" max="1.0" step="0.2" onChange={(e) => onFearToAngerChange(parseFloat(e.target.value))} value={fearToAnger} />
                        </label>
                        <span>{fearToAnger}</span>
                    </div>
                    <div className='row'>
                        <label>surpriseToAnticipation
                            <input type="range" min="-1.0" max="1.0" step="0.2" onChange={(e) => onSurpriseToAnticipationChange(parseFloat(e.target.value))} value={surpriseToAnticipation} />
                        </label>
                        <span>{surpriseToAnticipation}</span>
                    </div>
                </>
            }

        </>
    )
}

export default EmotionFinder