import React, { useState } from 'react'
import { v4 as uuid } from 'uuid';
import EmotionFinderSingle from './EmotionFinderSingle'

const EmotionFinder = ({
    emotions,
}) => {

    const unique_id = uuid();

    const [joyToSadness, setJoyToSadness] = useState(0.0)
    const [trustToDisgust, setTrustToDisgust] = useState(0.0)
    const [fearToAnger, setFearToAnger] = useState(0.0)
    const [surpriseToAnticipation, setSurpriseToAnticipation] = useState(0.0)

    const [pleasureToDispleasure, setPleasureToDispleasure] = useState(0.0)
    const [arousalToNonarousal, setArousalToNonarousal] = useState(0.0)
    const [dominanceToSubmissiveness, setDominanceToSubmissiveness] = useState(0.0)

    const [innerFocusToOutwardTarget, setInnerFocusToOutwardTarget] = useState(0.0)

    const [includeJoyToSadness, setIncludeJoyToSadness] = useState(false)
    const [includeTrustToDisgust, setIncludeTrustToDisgust] = useState(false)
    const [includeFearToAnger, setIncludeFearToAnger] = useState(false)
    const [includeSurpriseToAnticipation, setIncludeSurpriseToAnticipation] = useState(false)

    const [includePleasureToDispleasure, setIncludePleasureToDispleasure] = useState(true)
    const [includeArousalToNonarousal, setIncludeArousalToNonarousal] = useState(false)
    const [includeDominanceToSubmissiveness, setIncludeDominanceToSubmissiveness] = useState(false)

    const [includeInnerFocusToOutwardTarget, setIncludeInnerFocusToOutwardTarget] = useState(false)

    const [bestCosineEmotionMatches, setBestCosineEmotionMatches] = useState([])
    const [bestEuclideanEmotionMatches, setBestEuclideanEmotionMatches] = useState([])

    const [emotionKindFilter, setEmotionKindFilter] = useState('')

    const emotionMap = Object.assign({}, ...emotions.map((x) => ({ [x.id]: x }))); // convert array of emotions into a dictionary

    const onJoyToSadnessChange = (val) => {
        setJoyToSadness(val)
        search(emotionKindFilter, val, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }

    const onTrustToDisgustChange = (val) => {
        setTrustToDisgust(val)
        search(emotionKindFilter, joyToSadness, val, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }

    const onFearToAngerChange = (val) => {
        setFearToAnger(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, val, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }

    const onSurpriseToAnticipationChange = (val) => {
        setSurpriseToAnticipation(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, val, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }

    const onPleasureToDispleasureChange = (val) => {
        setPleasureToDispleasure(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, val, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }
    const onArousalToNonarousalChange = (val) => {
        setArousalToNonarousal(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, val, dominanceToSubmissiveness, innerFocusToOutwardTarget, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }
    const onDominanceToSubmissivenessChange = (val) => {
        setDominanceToSubmissiveness(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, val, innerFocusToOutwardTarget, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }

    const onInnerFocusToOutwardTargetChange = (val) => {
        setInnerFocusToOutwardTarget(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, val, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }



    const onIncludeJoyToSadnessChange = (val) => {
        setIncludeJoyToSadness(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, val, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }

    const onIncludeTrustToDisgustChange = (val) => {
        setIncludeTrustToDisgust(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, includeJoyToSadness, val, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }

    const onIncludeFearToAngerChange = (val) => {
        setIncludeFearToAnger(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, includeJoyToSadness, includeTrustToDisgust, val, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }

    const onIncludeSurpriseToAnticipationChange = (val) => {
        setIncludeSurpriseToAnticipation(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, val, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }

    const onIncludePleasureToDispleasureChange = (val) => {
        setIncludePleasureToDispleasure(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, val, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }
    const onIncludeArousalToNonarousalChange = (val) => {
        setIncludeArousalToNonarousal(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, val, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }
    const onIncludeDominanceToSubmissivenessChange = (val) => {
        setIncludeDominanceToSubmissiveness(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, val, includeInnerFocusToOutwardTarget)
    }

    const onIncludeInnerFocusToOutwardTargetChange = (val) => {
        setIncludeInnerFocusToOutwardTarget(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, val)
    }


    const onEmotionKindFilterChange = (e) => {
        setEmotionKindFilter(e.target.value)
        search(e.target.value, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget)
    }


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
        // for (let i = 0; i < a.length; i++) {
        //     // change scale from -1/+1 to 0/+1
        //     a[i] = (parseFloat(a[i]) + 1) / 2
        //     b[i] = (parseFloat(b[i]) + 1) / 2
        // }

        return dotproduct(a, b) / norm2(a) / norm2(b);
    }

    const euclideanSim = (a, b) => {
        // for (let i = 0; i < a.length; i++) {
        //     // change scale from -1/+1 to 0/+1
        //     a[i] = (parseFloat(a[i]) + 1) / 2
        //     b[i] = (parseFloat(b[i]) + 1) / 2
        // }

        if (a.length === 0) return 0.0

        return a
            .map((x, i) => Math.abs(x - b[i]) ** 2) // square the difference
            .reduce((sum, now) => sum + now) // sum
            ** (1 / 2)
    }

    const search = (searchEmotionKindFilter, searchJoyToSadness, searchTrustToDisgust, searchFearToAnger, searchSurpriseToAnticipation, searchPleasureToDispleasure, searchArousalToNonarousal, searchDominanceToSubmissiveness, searchInnerFocusToOutwardTarget, curIncludeJoyToSadness, curIncludeTrustToDisgust, curIncludeFearToAnger, curIncludeSurpriseToAnticipation, curIncludePleasureToDispleasure, curIncludeArousalToNonarousal, curIncludeDominanceToSubmissiveness, curIncludeInnerFocusToOutwardTarget) => {
        let cosineResults = {}
        let euclideanResults = {}

        const filteredEmotions = searchEmotionKindFilter === '' ? emotions : emotions.filter(emotion => emotion.kinds.includes(searchEmotionKindFilter))

        filteredEmotions.forEach(emotion => {
            var searchVector = [];
            var curEmoVector = [];

            if (curIncludeJoyToSadness === true) {
                searchVector.push(searchJoyToSadness)
                curEmoVector.push(emotion.joyToSadness)
            }
            if (curIncludeTrustToDisgust === true) {
                searchVector.push(searchTrustToDisgust)
                curEmoVector.push(emotion.trustToDisgust)
            }
            if (curIncludeFearToAnger === true) {
                searchVector.push(searchFearToAnger)
                curEmoVector.push(emotion.fearToAnger)
            }
            if (curIncludeSurpriseToAnticipation === true) {
                searchVector.push(searchSurpriseToAnticipation)
                curEmoVector.push(emotion.surpriseToAnticipation)
            }

            if (curIncludePleasureToDispleasure === true) {
                searchVector.push(searchPleasureToDispleasure)
                curEmoVector.push(emotion.pleasureToDispleasure)
            }
            if (curIncludeArousalToNonarousal === true) {
                searchVector.push(searchArousalToNonarousal)
                curEmoVector.push(emotion.arousalToNonarousal)
            }
            if (curIncludeDominanceToSubmissiveness === true) {
                searchVector.push(searchDominanceToSubmissiveness)
                curEmoVector.push(emotion.dominanceToSubmissiveness)
            }

            if (curIncludeInnerFocusToOutwardTarget === true) {
                searchVector.push(searchInnerFocusToOutwardTarget)
                curEmoVector.push(emotion.innerFocusToOutwardTarget)
            }

            if (searchVector.length === 0) return

            var cosineDist = cosineSim(searchVector, curEmoVector);
            var euclideanDist = euclideanSim(searchVector, curEmoVector)

            cosineResults[emotion.id] = cosineDist
            euclideanResults[emotion.id] = euclideanDist
        });

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

        const top_n = 4

        const cosineTop = cosineItems.slice(0, top_n).map((i) => i[0])
        const eucTop = eucItems.slice(0, top_n).map((i) => i[0])

        setBestCosineEmotionMatches(cosineTop)
        setBestEuclideanEmotionMatches(eucTop)
    }

    const searchLabel = (includeJoyToSadness ? (joyToSadness < 0 ? 'Joy + ' : 'Sadness + ') : '')
        + (includeTrustToDisgust ? (trustToDisgust < 0 ? 'Trust + ' : 'Disgust + ') : '')
        + (includeFearToAnger ? (fearToAnger < 0 ? 'Fear + ' : 'Anger + ') : '')
        + (includeSurpriseToAnticipation ? (surpriseToAnticipation < 0 ? 'Surprise + ' : 'Anticipation + ') : '')
        + (includePleasureToDispleasure ? (pleasureToDispleasure < 0 ? 'Pleasure + ' : 'Displeasure + ') : '')
        + (includeArousalToNonarousal ? (arousalToNonarousal < 0 ? 'Arousal + ' : 'Nonarousal + ') : '')
        + (includeDominanceToSubmissiveness ? (dominanceToSubmissiveness < 0 ? 'Dominance + ' : 'Submissiveness + ') : '')
        + (includeInnerFocusToOutwardTarget ? (innerFocusToOutwardTarget < 0 ? 'Inner Focus + ' : 'Outward Target + ') : '')

    const getEmotion = (emoName, isInCommon) => {
        if (!emoName || emoName === '') return <></>

        return <EmotionFinderSingle
            emotion={emotionMap[emoName]}
            isInCommon={isInCommon}
        />
    }

    const bestCosineMatchesListItems = bestCosineEmotionMatches.map((emo) => <li key={emo}>
        {
            getEmotion(emo, bestEuclideanEmotionMatches.includes(emo))
        }
    </li >)
    const bestEuclideanMatchesListItems = bestEuclideanEmotionMatches.map((emo) => <li key={emo}>
        {
            getEmotion(emo, bestCosineEmotionMatches.includes(emo))
        }
    </li>)

    return (
        <>
            {
                emotions &&
                <>
                    <div className='row'>
                        <div className='col mb-3'>
                            <select required className='fs-5 form-select form-inline' value={emotionKindFilter} onChange={onEmotionKindFilterChange}>
                                <option value="">All Emotion Types</option>
                                <option value="related to object properties">Related to object properties</option>
                                <option value="future appraisal">Future appraisal</option>
                                <option value="event-related">Event-related</option>
                                <option value="self-appraisal">Self-appraisal</option>
                                <option value="social">Social</option>
                                <option value="cathected">Cathected</option>
                            </select>
                        </div>
                    </div>
                    <div className='row'>
                        <div className='col-6'>
                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeJoyToSadness'} type="checkbox" checked={includeJoyToSadness} value={includeJoyToSadness} onChange={(e) => onIncludeJoyToSadnessChange(!includeJoyToSadness)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeJoyToSadness'}>Include JoyToSadness</label>
                            </div>
                            <label htmlFor={unique_id + 'joyToSadness'} className='form-label'>Joy - Sadness <span>{joyToSadness}</span></label>
                            <input id={unique_id + 'joyToSadness'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onJoyToSadnessChange(parseFloat(e.target.value))} value={joyToSadness} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeTrustToDisgust'} type="checkbox" checked={includeTrustToDisgust} value={includeTrustToDisgust} onChange={(e) => onIncludeTrustToDisgustChange(e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeTrustToDisgust'}>Include TrustToDisgust</label>
                            </div>
                            <label htmlFor={unique_id + 'trustToDisgust'} className='form-label'>Trust - Disgust <span>{trustToDisgust}</span></label>
                            <input id={unique_id + 'trustToDisgust'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onTrustToDisgustChange(parseFloat(e.target.value))} value={trustToDisgust} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeFearToAnger'} type="checkbox" checked={includeFearToAnger} value={includeFearToAnger} onChange={(e) => onIncludeFearToAngerChange(e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeFearToAnger'}>Include FearToAnger</label>
                            </div>
                            <label htmlFor={unique_id + 'fearToAnger'} className='form-label'>Fear - Anger <span>{fearToAnger}</span></label>
                            <input id={unique_id + 'fearToAnger'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onFearToAngerChange(parseFloat(e.target.value))} value={fearToAnger} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeSurpriseToAnticipation'} type="checkbox" checked={includeSurpriseToAnticipation} value={includeSurpriseToAnticipation} onChange={(e) => onIncludeSurpriseToAnticipationChange(e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeSurpriseToAnticipation'}>Include SurpriseToAnticipation</label>
                            </div>
                            <label htmlFor={unique_id + 'surpriseToAnticipation'} className='form-label'>Surprise - Anticipation <span>{surpriseToAnticipation}</span></label>
                            <input id={unique_id + 'surpriseToAnticipation'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onSurpriseToAnticipationChange(parseFloat(e.target.value))} value={surpriseToAnticipation} />
                        </div>
                        <div className='col-6'>
                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includePleasureToDispleasure'} type="checkbox" checked={includePleasureToDispleasure} value={includePleasureToDispleasure} onChange={(e) => onIncludePleasureToDispleasureChange(e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includePleasureToDispleasure'}>Include PleasureToDispleasure</label>
                            </div>
                            <label htmlFor={unique_id + 'pleasureToDispleasure'} className='form-label'>Pleasure - Displeasure <span>{pleasureToDispleasure}</span></label>
                            <input id={unique_id + 'pleasureToDispleasure'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onPleasureToDispleasureChange(parseFloat(e.target.value))} value={pleasureToDispleasure} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeArousalToNonarousal'} type="checkbox" checked={includeArousalToNonarousal} value={includeArousalToNonarousal} onChange={(e) => onIncludeArousalToNonarousalChange(e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeArousalToNonarousal'}>Include ArousalToNonarousal</label>
                            </div>
                            <label htmlFor={unique_id + 'arousalToNonarousal'} className='form-label'>Arousal - Nonarousal <span>{arousalToNonarousal}</span></label>
                            <input id={unique_id + 'arousalToNonarousal'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onArousalToNonarousalChange(parseFloat(e.target.value))} value={arousalToNonarousal} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeDominanceToSubmissiveness'} type="checkbox" checked={includeDominanceToSubmissiveness} value={includeDominanceToSubmissiveness} onChange={(e) => onIncludeDominanceToSubmissivenessChange(e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeDominanceToSubmissiveness'}>Include DominanceToSubmissiveness</label>
                            </div>
                            <label htmlFor={unique_id + 'dominanceToSubmissiveness'} className='form-label'>Dominance - Submissiveness <span>{dominanceToSubmissiveness}</span></label>
                            <input id={unique_id + 'dominanceToSubmissiveness'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onDominanceToSubmissivenessChange(parseFloat(e.target.value))} value={dominanceToSubmissiveness} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeInnerFocusToOutwardTarget'} type="checkbox" checked={includeInnerFocusToOutwardTarget} value={includeInnerFocusToOutwardTarget} onChange={(e) => onIncludeInnerFocusToOutwardTargetChange(e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeInnerFocusToOutwardTarget'}>Include InnerFocusToOutwardTarget</label>
                            </div>
                            <label htmlFor={unique_id + 'innerFocusToOutwardTarget'} className='form-label'>Inner Focus - Outward Target <span>{innerFocusToOutwardTarget}</span></label>
                            <input id={unique_id + 'innerFocusToOutwardTarget'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onInnerFocusToOutwardTargetChange(parseFloat(e.target.value))} value={innerFocusToOutwardTarget} />
                        </div>
                    </div>

                    {
                        searchLabel && searchLabel.length > 0 &&
                        <div className='row'>
                            <div className='col'>
                                <h3>{searchLabel.slice(0, searchLabel.lastIndexOf("+"))}</h3>
                            </div>

                        </div>
                    }
                    <div className='row'>
                        <div className='col'>
                            <p>Cosine distance</p>
                            <ul>
                                {bestCosineMatchesListItems}
                            </ul>
                        </div>
                        <div className='col'>
                            <p>Euclidean distance</p>
                            <ul>
                                {bestEuclideanMatchesListItems}
                            </ul>
                        </div>
                    </div>


                </>
            }

        </>
    )
}

export default EmotionFinder