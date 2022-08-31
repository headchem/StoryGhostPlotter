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

    const [anxietyToConfidence, setAnxietyToConfidence] = useState(0.0)
    const [boredomToFascination, setBoredomToFascination] = useState(0.0)
    const [frustrationToEuphoria, setFrustrationToEuphoria] = useState(0.0)
    const [dispiritedToEncouraged, setDispiritedToEncouraged] = useState(0.0)
    const [terrorToEnchantment, setTerrorToEnchantment] = useState(0.0)
    const [humiliationToPride, setHumiliationToPride] = useState(0.0)

    const [includeJoyToSadness, setIncludeJoyToSadness] = useState(false)
    const [includeTrustToDisgust, setIncludeTrustToDisgust] = useState(false)
    const [includeFearToAnger, setIncludeFearToAnger] = useState(false)
    const [includeSurpriseToAnticipation, setIncludeSurpriseToAnticipation] = useState(false)

    const [includePleasureToDispleasure, setIncludePleasureToDispleasure] = useState(true)
    const [includeArousalToNonarousal, setIncludeArousalToNonarousal] = useState(false)
    const [includeDominanceToSubmissiveness, setIncludeDominanceToSubmissiveness] = useState(false)

    const [includeInnerFocusToOutwardTarget, setIncludeInnerFocusToOutwardTarget] = useState(false)

    const [includeAnxietyToConfidence, setIncludeAnxietyToConfidence] = useState(false)
    const [includeBoredomToFascination, setIncludeBoredomToFascination] = useState(false)
    const [includeFrustrationToEuphoria, setIncludeFrustrationToEuphoria] = useState(false)
    const [includeDispiritedToEncouraged, setIncludeDispiritedToEncouraged] = useState(false)
    const [includeTerrorToEnchantment, setIncludeTerrorToEnchantment] = useState(false)
    const [includeHumiliationToPride, setIncludeHumiliationToPride] = useState(false)

    const [bestCosineEmotionMatches, setBestCosineEmotionMatches] = useState([])
    const [bestEuclideanEmotionMatches, setBestEuclideanEmotionMatches] = useState([])
    const [bestManhattanEmotionMatches, setBestManhattanEmotionMatches] = useState([])
    const [bestChebyshevEmotionMatches, setBestChebyshevEmotionMatches] = useState([])

    const [showEmotionDistanceDetails, setShowEmotionDistanceDetails] = useState(false)


    const [emotionKindFilter, setEmotionKindFilter] = useState('')

    const emotionMap = Object.assign({}, ...emotions.map((x) => ({ [x.id]: x }))); // convert array of emotions into a dictionary

    const onJoyToSadnessChange = (val) => {
        setJoyToSadness(val)
        search(emotionKindFilter, val, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onTrustToDisgustChange = (val) => {
        setTrustToDisgust(val)
        search(emotionKindFilter, joyToSadness, val, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onFearToAngerChange = (val) => {
        setFearToAnger(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, val, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onSurpriseToAnticipationChange = (val) => {
        setSurpriseToAnticipation(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, val, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }

    const onPleasureToDispleasureChange = (val) => {
        setPleasureToDispleasure(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, val, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onArousalToNonarousalChange = (val) => {
        setArousalToNonarousal(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, val, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onDominanceToSubmissivenessChange = (val) => {
        setDominanceToSubmissiveness(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, val, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }

    const onInnerFocusToOutwardTargetChange = (val) => {
        setInnerFocusToOutwardTarget(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, val, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }

    const onAnxietyToConfidenceChange = (val) => {
        setAnxietyToConfidence(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, val, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onBoredomToFascinationChange = (val) => {
        setBoredomToFascination(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, val, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onFrustrationToEuphoriaChange = (val) => {
        setFrustrationToEuphoria(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, val, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onDispiritedToEncouragedChange = (val) => {
        setDispiritedToEncouraged(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, val, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onTerrorToEnchantmentChange = (val) => {
        setTerrorToEnchantment(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, val, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onHumiliationToPrideChange = (val) => {
        setHumiliationToPride(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, val, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }



    const onIncludeJoyToSadnessChange = (val) => {
        setIncludeJoyToSadness(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, val, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onIncludeTrustToDisgustChange = (val) => {
        setIncludeTrustToDisgust(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, val, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onIncludeFearToAngerChange = (val) => {
        setIncludeFearToAnger(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, val, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onIncludeSurpriseToAnticipationChange = (val) => {
        setIncludeSurpriseToAnticipation(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, val, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }

    const onIncludePleasureToDispleasureChange = (val) => {
        setIncludePleasureToDispleasure(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, val, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onIncludeArousalToNonarousalChange = (val) => {
        setIncludeArousalToNonarousal(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, val, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onIncludeDominanceToSubmissivenessChange = (val) => {
        setIncludeDominanceToSubmissiveness(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, val, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }

    const onIncludeInnerFocusToOutwardTargetChange = (val) => {
        setIncludeInnerFocusToOutwardTarget(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, val, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }

    const onIncludeAnxietyToConfidenceChange = (val) => {
        setIncludeAnxietyToConfidence(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, val, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onIncludeBoredomToFascinationChange = (val) => {
        setIncludeBoredomToFascination(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, val, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onIncludeFrustrationToEuphoriaChange = (val) => {
        setIncludeFrustrationToEuphoria(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, val, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onIncludeDispiritedToEncouragedChange = (val) => {
        setIncludeDispiritedToEncouraged(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, val, includeTerrorToEnchantment, includeHumiliationToPride)
    }
    const onIncludeTerrorToEnchantmentChange = (val) => {
        setIncludeTerrorToEnchantment(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, val, includeHumiliationToPride)
    }
    const onIncludeHumiliationToPrideChange = (val) => {
        setIncludeHumiliationToPride(val)
        search(emotionKindFilter, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, val)
    }


    const onEmotionKindFilterChange = (e) => {
        setEmotionKindFilter(e.target.value)
        search(e.target.value, joyToSadness, trustToDisgust, fearToAnger, surpriseToAnticipation, pleasureToDispleasure, arousalToNonarousal, dominanceToSubmissiveness, innerFocusToOutwardTarget, anxietyToConfidence, boredomToFascination, frustrationToEuphoria, dispiritedToEncouraged, terrorToEnchantment, humiliationToPride, includeJoyToSadness, includeTrustToDisgust, includeFearToAnger, includeSurpriseToAnticipation, includePleasureToDispleasure, includeArousalToNonarousal, includeDominanceToSubmissiveness, includeInnerFocusToOutwardTarget, includeAnxietyToConfidence, includeBoredomToFascination, includeFrustrationToEuphoria, includeDispiritedToEncouraged, includeTerrorToEnchantment, includeHumiliationToPride)
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

    // https://github.com/semibran/manhattan/blob/master/index.js
    const manhattanSim = (a, b) => {
        var distance = 0
        var dimensions = Math.max(a.length, b.length)
        for (var i = 0; i < dimensions; i++) {
            distance += Math.abs((b[i] || 0) - (a[i] || 0))
        }
        return distance
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

    const chebyshevSim = (a, b) => {
        var farthest = 0
        var dimensions = Math.max(a.length, b.length)
        for (var i = 0; i < dimensions; i++) {
            var distance = Math.abs((b[i] || 0) - (a[i] || 0))
            if (distance > farthest) {
                farthest = distance
            }
        }
        return farthest
    }

    const search = (searchEmotionKindFilter, searchJoyToSadness, searchTrustToDisgust, searchFearToAnger, searchSurpriseToAnticipation, searchPleasureToDispleasure, searchArousalToNonarousal, searchDominanceToSubmissiveness, searchInnerFocusToOutwardTarget, searchAnxietyToConfidence, searchBoredomToFascination, searchFrustrationToEuphoria, searchDispiritedToEncouraged, searchTerrorToEnchantment, searchHumiliationToPride, curIncludeJoyToSadness, curIncludeTrustToDisgust, curIncludeFearToAnger, curIncludeSurpriseToAnticipation, curIncludePleasureToDispleasure, curIncludeArousalToNonarousal, curIncludeDominanceToSubmissiveness, curIncludeInnerFocusToOutwardTarget, curIncludeAnxietyToConfidence, curIncludeBoredomToFascination, curIncludeFrustrationToEuphoria, curIncludeDispiritedToEncouraged, curIncludeTerrorToEnchantment, curIncludeHumiliationToPride) => {
        let cosineResults = {}
        let euclideanResults = {}
        let manhattanResults = {}
        let chebyshevResults = {}

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

            if (curIncludeAnxietyToConfidence === true) {
                searchVector.push(searchAnxietyToConfidence)
                curEmoVector.push(emotion.anxietyToConfidence)
            }
            if (curIncludeBoredomToFascination === true) {
                searchVector.push(searchBoredomToFascination)
                curEmoVector.push(emotion.boredomToFascination)
            }
            if (curIncludeFrustrationToEuphoria === true) {
                searchVector.push(searchFrustrationToEuphoria)
                curEmoVector.push(emotion.frustrationToEuphoria)
            }
            if (curIncludeDispiritedToEncouraged === true) {
                searchVector.push(searchDispiritedToEncouraged)
                curEmoVector.push(emotion.dispiritedToEncouraged)
            }
            if (curIncludeTerrorToEnchantment === true) {
                searchVector.push(searchTerrorToEnchantment)
                curEmoVector.push(emotion.terrorToEnchantment)
            }
            if (curIncludeHumiliationToPride === true) {
                searchVector.push(searchHumiliationToPride)
                curEmoVector.push(emotion.humiliationToPride)
            }

            if (searchVector.length === 0) return

            var cosineDist = cosineSim(searchVector, curEmoVector);
            var euclideanDist = euclideanSim(searchVector, curEmoVector)
            var manhattanDist = manhattanSim(searchVector, curEmoVector)
            var chebyshevDist = chebyshevSim(searchVector, curEmoVector)

            cosineResults[emotion.id] = cosineDist
            euclideanResults[emotion.id] = euclideanDist
            manhattanResults[emotion.id] = manhattanDist
            chebyshevResults[emotion.id] = chebyshevDist
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

        eucItems.sort(function (first, second) {
            return first[1] - second[1];
        });

        var manhattanItems = Object.keys(manhattanResults).map(function (key) {
            return [key, manhattanResults[key]];
        });

        manhattanItems.sort(function (first, second) {
            return first[1] - second[1];
        });

        var chebyshevItems = Object.keys(chebyshevResults).map(function (key) {
            return [key, chebyshevResults[key]];
        });

        chebyshevItems.sort(function (first, second) {
            return first[1] - second[1];
        });

        const top_n = 4

        const cosineTop = cosineItems.slice(0, top_n).map((i) => i[0])
        const eucTop = eucItems.slice(0, top_n).map((i) => i[0])
        const manhattanTop = manhattanItems.slice(0, top_n).map((i) => i[0])
        const chebyshevTop = chebyshevItems.slice(0, top_n).map((i) => i[0])

        setBestCosineEmotionMatches(cosineTop)
        setBestEuclideanEmotionMatches(eucTop)
        setBestManhattanEmotionMatches(manhattanTop)
        setBestChebyshevEmotionMatches(chebyshevTop)
    }

    const searchLabel = (includeJoyToSadness ? (joyToSadness < 0 ? 'Joy + ' : 'Sadness + ') : '')
        + (includeTrustToDisgust ? (trustToDisgust < 0 ? 'Trust + ' : 'Disgust + ') : '')
        + (includeFearToAnger ? (fearToAnger < 0 ? 'Fear + ' : 'Anger + ') : '')
        + (includeSurpriseToAnticipation ? (surpriseToAnticipation < 0 ? 'Surprise + ' : 'Anticipation + ') : '')
        + (includePleasureToDispleasure ? (pleasureToDispleasure < 0 ? 'Pleasure + ' : 'Displeasure + ') : '')
        + (includeArousalToNonarousal ? (arousalToNonarousal < 0 ? 'Arousal + ' : 'Nonarousal + ') : '')
        + (includeDominanceToSubmissiveness ? (dominanceToSubmissiveness < 0 ? 'Dominance + ' : 'Submissiveness + ') : '')
        + (includeInnerFocusToOutwardTarget ? (innerFocusToOutwardTarget < 0 ? 'Inner Focus + ' : 'Outward Target + ') : '')

        + (includeAnxietyToConfidence ? (anxietyToConfidence < 0 ? 'Anxious + ' : 'Confident + ') : '')
        + (includeBoredomToFascination ? (boredomToFascination < 0 ? 'Ennui + ' : 'Intrigue + ') : '')
        + (includeFrustrationToEuphoria ? (frustrationToEuphoria < 0 ? 'Frustration + ' : 'Epiphany + ') : '')
        + (includeDispiritedToEncouraged ? (dispiritedToEncouraged < 0 ? 'Dispirited + ' : 'Enthusiastic + ') : '')
        + (includeTerrorToEnchantment ? (terrorToEnchantment < 0 ? 'Terror + ' : 'Excited + ') : '')
        + (includeHumiliationToPride ? (humiliationToPride < 0 ? 'Humiliated + ' : 'Proud + ') : '')

    const getEmotion = (emoName, isInCommon) => {
        if (!emoName || emoName === '') return <></>

        return <EmotionFinderSingle
            emotion={emotionMap[emoName]}
            isInCommon={isInCommon}
        />
    }

    const bestCosineMatchesListItems = bestCosineEmotionMatches.map((emo) => <li key={emo}>
        {
            getEmotion(emo, bestEuclideanEmotionMatches.includes(emo) && bestManhattanEmotionMatches.includes(emo) && bestChebyshevEmotionMatches.includes(emo))
        }
    </li >)
    const bestEuclideanMatchesListItems = bestEuclideanEmotionMatches.map((emo) => <li key={emo}>
        {
            getEmotion(emo, bestCosineEmotionMatches.includes(emo) && bestManhattanEmotionMatches.includes(emo) && bestChebyshevEmotionMatches.includes(emo))
        }
    </li>)
    const bestManhattanMatchesListItems = bestManhattanEmotionMatches.map((emo) => <li key={emo}>
        {
            getEmotion(emo, bestCosineEmotionMatches.includes(emo) && bestEuclideanEmotionMatches.includes(emo) && bestChebyshevEmotionMatches.includes(emo))
        }
    </li>)
    const bestChebyshevMatchesListItems = bestChebyshevEmotionMatches.map((emo) => <li key={emo}>
        {
            getEmotion(emo, bestCosineEmotionMatches.includes(emo) && bestEuclideanEmotionMatches.includes(emo) && bestManhattanEmotionMatches.includes(emo))
        }
    </li>)

    const allEmoMatches = [bestCosineEmotionMatches, bestEuclideanEmotionMatches, bestManhattanEmotionMatches, bestChebyshevEmotionMatches]
    const allEmoIntersection = allEmoMatches.reduce((a, b) => a.filter(c => b.includes(c)));

    const bestOverallMatchesListItems = allEmoIntersection.sort(function (first, second) {
        // add up the index of both items, return the lowest index count (if an emotion is index 0 in 3 out of 4 lists, it should rank first)

        const firstCosineIndex = bestCosineEmotionMatches.indexOf(first)
        const firstEuclideanIndex = bestEuclideanEmotionMatches.indexOf(first)
        const firstManhattanIndex = bestManhattanEmotionMatches.indexOf(first)
        const firstChebyshevIndex = bestChebyshevEmotionMatches.indexOf(first)

        const secondCosineIndex = bestCosineEmotionMatches.indexOf(second)
        const secondEuclideanIndex = bestEuclideanEmotionMatches.indexOf(second)
        const secondManhattanIndex = bestManhattanEmotionMatches.indexOf(second)
        const secondChebyshevIndex = bestChebyshevEmotionMatches.indexOf(second)

        const firstIdxSum = firstCosineIndex + firstEuclideanIndex + firstManhattanIndex + firstChebyshevIndex
        const secondIdxSum = secondCosineIndex + secondEuclideanIndex + secondManhattanIndex + secondChebyshevIndex

        return firstIdxSum - secondIdxSum
    }).map((emo) => <li key={emo}>
        {
            getEmotion(emo, false)
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
                                <label className='form-check-label' htmlFor={unique_id + 'includeJoyToSadness'}>Include Joy-to-sadness</label>
                            </div>
                            <label htmlFor={unique_id + 'joyToSadness'} className='form-label'>Joy - Sadness <span>{joyToSadness}</span></label>
                            <input id={unique_id + 'joyToSadness'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onJoyToSadnessChange(parseFloat(e.target.value))} value={joyToSadness} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeTrustToDisgust'} type="checkbox" checked={includeTrustToDisgust} value={includeTrustToDisgust} onChange={(e) => onIncludeTrustToDisgustChange(e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeTrustToDisgust'}>Include trust-to-disgust</label>
                            </div>
                            <label htmlFor={unique_id + 'trustToDisgust'} className='form-label'>Trust - Disgust <span>{trustToDisgust}</span></label>
                            <input id={unique_id + 'trustToDisgust'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onTrustToDisgustChange(parseFloat(e.target.value))} value={trustToDisgust} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeFearToAnger'} type="checkbox" checked={includeFearToAnger} value={includeFearToAnger} onChange={(e) => onIncludeFearToAngerChange(e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeFearToAnger'}>Include fear-to-anger</label>
                            </div>
                            <label htmlFor={unique_id + 'fearToAnger'} className='form-label'>Fear - Anger <span>{fearToAnger}</span></label>
                            <input id={unique_id + 'fearToAnger'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onFearToAngerChange(parseFloat(e.target.value))} value={fearToAnger} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeSurpriseToAnticipation'} type="checkbox" checked={includeSurpriseToAnticipation} value={includeSurpriseToAnticipation} onChange={(e) => onIncludeSurpriseToAnticipationChange(e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeSurpriseToAnticipation'}>Include surprise-to-anticipation</label>
                            </div>
                            <label htmlFor={unique_id + 'surpriseToAnticipation'} className='form-label'>Surprise - Anticipation <span>{surpriseToAnticipation}</span></label>
                            <input id={unique_id + 'surpriseToAnticipation'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onSurpriseToAnticipationChange(parseFloat(e.target.value))} value={surpriseToAnticipation} />
                        </div>
                        <div className='col-6'>
                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includePleasureToDispleasure'} type="checkbox" checked={includePleasureToDispleasure} value={includePleasureToDispleasure} onChange={(e) => onIncludePleasureToDispleasureChange(e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includePleasureToDispleasure'}>Include pleasure-to-displeasure</label>
                            </div>
                            <label htmlFor={unique_id + 'pleasureToDispleasure'} className='form-label'>Pleasure - Displeasure <span>{pleasureToDispleasure}</span></label>
                            <input id={unique_id + 'pleasureToDispleasure'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onPleasureToDispleasureChange(parseFloat(e.target.value))} value={pleasureToDispleasure} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeArousalToNonarousal'} type="checkbox" checked={includeArousalToNonarousal} value={includeArousalToNonarousal} onChange={(e) => onIncludeArousalToNonarousalChange(e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeArousalToNonarousal'}>Include arousal-to-nonarousal</label>
                            </div>
                            <label htmlFor={unique_id + 'arousalToNonarousal'} className='form-label'>Arousal (energetic) - Nonarousal (lethargic) <span>{arousalToNonarousal}</span></label>
                            <input id={unique_id + 'arousalToNonarousal'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onArousalToNonarousalChange(parseFloat(e.target.value))} value={arousalToNonarousal} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeDominanceToSubmissiveness'} type="checkbox" checked={includeDominanceToSubmissiveness} value={includeDominanceToSubmissiveness} onChange={(e) => onIncludeDominanceToSubmissivenessChange(e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeDominanceToSubmissiveness'}>Include dominance-to-submissiveness</label>
                            </div>
                            <label htmlFor={unique_id + 'dominanceToSubmissiveness'} className='form-label'>Dominance - Submissiveness <span>{dominanceToSubmissiveness}</span></label>
                            <input id={unique_id + 'dominanceToSubmissiveness'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onDominanceToSubmissivenessChange(parseFloat(e.target.value))} value={dominanceToSubmissiveness} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeInnerFocusToOutwardTarget'} type="checkbox" checked={includeInnerFocusToOutwardTarget} value={includeInnerFocusToOutwardTarget} onChange={(e) => onIncludeInnerFocusToOutwardTargetChange(e.currentTarget.checked)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeInnerFocusToOutwardTarget'}>Include inner focus-to-outward target</label>
                            </div>
                            <label htmlFor={unique_id + 'innerFocusToOutwardTarget'} className='form-label'>Inner Focus - Outward Target <span>{innerFocusToOutwardTarget}</span></label>
                            <input id={unique_id + 'innerFocusToOutwardTarget'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onInnerFocusToOutwardTargetChange(parseFloat(e.target.value))} value={innerFocusToOutwardTarget} />
                        </div>
                    </div>
                    <div className='row'>
                        <div className='col-6'>
                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeAnxietyToConfidence'} type="checkbox" checked={includeAnxietyToConfidence} value={includeAnxietyToConfidence} onChange={(e) => onIncludeAnxietyToConfidenceChange(!includeAnxietyToConfidence)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeAnxietyToConfidence'}>Include anxiety-to-confidence</label>
                            </div>
                            <label htmlFor={unique_id + 'anxietyToConfidence'} className='form-label'>Anxiety - Confident <span>{anxietyToConfidence}</span></label>
                            <input id={unique_id + 'anxietyToConfidence'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onAnxietyToConfidenceChange(parseFloat(e.target.value))} value={anxietyToConfidence} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeBoredomToFascination'} type="checkbox" checked={includeBoredomToFascination} value={includeBoredomToFascination} onChange={(e) => onIncludeBoredomToFascinationChange(!includeBoredomToFascination)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeBoredomToFascination'}>Include ennui-to-intrigue</label>
                            </div>
                            <label htmlFor={unique_id + 'boredomToFascination'} className='form-label'>Ennui (boredom) - Intrigue (fascination) <span>{boredomToFascination}</span></label>
                            <input id={unique_id + 'boredomToFascination'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onBoredomToFascinationChange(parseFloat(e.target.value))} value={boredomToFascination} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeFrustrationToEuphoria'} type="checkbox" checked={includeFrustrationToEuphoria} value={includeFrustrationToEuphoria} onChange={(e) => onIncludeFrustrationToEuphoriaChange(!includeFrustrationToEuphoria)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeFrustrationToEuphoria'}>Include frustration-to-epiphany</label>
                            </div>
                            <label htmlFor={unique_id + 'frustrationToEuphoria'} className='form-label'>Frustration - Epiphany <span>{frustrationToEuphoria}</span></label>
                            <input id={unique_id + 'frustrationToEuphoria'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onFrustrationToEuphoriaChange(parseFloat(e.target.value))} value={frustrationToEuphoria} />
                        </div>
                        <div className='col-6'>
                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeDispiritedToEncouraged'} type="checkbox" checked={includeDispiritedToEncouraged} value={includeDispiritedToEncouraged} onChange={(e) => onIncludeDispiritedToEncouragedChange(!includeDispiritedToEncouraged)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeDispiritedToEncouraged'}>Include anxiety-to-confident</label>
                            </div>
                            <label htmlFor={unique_id + 'dispiritedToEncouraged'} className='form-label'>Anxiety (dispirited) - Confident (encouraged) <span>{dispiritedToEncouraged}</span></label>
                            <input id={unique_id + 'dispiritedToEncouraged'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onDispiritedToEncouragedChange(parseFloat(e.target.value))} value={dispiritedToEncouraged} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeTerrorToEnchantment'} type="checkbox" checked={includeTerrorToEnchantment} value={includeTerrorToEnchantment} onChange={(e) => onIncludeTerrorToEnchantmentChange(!includeTerrorToEnchantment)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeTerrorToEnchantment'}>Include terror-to-excited</label>
                            </div>
                            <label htmlFor={unique_id + 'terrorToEnchantment'} className='form-label'>Terror - Excited <span>{terrorToEnchantment}</span></label>
                            <input id={unique_id + 'terrorToEnchantment'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onTerrorToEnchantmentChange(parseFloat(e.target.value))} value={terrorToEnchantment} />

                            <div className='form-check'>
                                <input className='form-check-input' id={unique_id + 'includeHumiliationToPride'} type="checkbox" checked={includeHumiliationToPride} value={includeHumiliationToPride} onChange={(e) => onIncludeHumiliationToPrideChange(!includeHumiliationToPride)} />
                                <label className='form-check-label' htmlFor={unique_id + 'includeHumiliationToPride'}>Include humiliated-to-proud</label>
                            </div>
                            <label htmlFor={unique_id + 'humiliationToPride'} className='form-label'>Humiliated - Proud <span>{humiliationToPride}</span></label>
                            <input id={unique_id + 'humiliationToPride'} className='form-range' type="range" min="-1.0" max="1.0" step="0.05" onChange={(e) => onHumiliationToPrideChange(parseFloat(e.target.value))} value={humiliationToPride} />
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
                            {
                                bestOverallMatchesListItems.length === 0 &&
                                <p>No emotion agreement</p>
                            }
                            {
                                bestOverallMatchesListItems.length > 0 &&
                                <ul>
                                    {bestOverallMatchesListItems}
                                </ul>
                            }
                        </div>
                    </div>
                    <div className='row'>
                        {
                            showEmotionDistanceDetails === false &&
                            <button onClick={() => setShowEmotionDistanceDetails(true)} className='btn btn-link'>show distance details</button>
                        }
                        {
                            showEmotionDistanceDetails === true &&
                            <button onClick={() => setShowEmotionDistanceDetails(false)} className='btn btn-link'>hide distance details</button>
                        }
                        {
                            showEmotionDistanceDetails === true &&
                            <>
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
                                <div className='col'>
                                    <p>Manhattan distance</p>
                                    <ul>
                                        {bestManhattanMatchesListItems}
                                    </ul>
                                </div>
                                <div className='col'>
                                    <p>Chebyshev distance</p>
                                    <ul>
                                        {bestChebyshevMatchesListItems}
                                    </ul>
                                </div>
                            </>
                        }
                    </div>
                </>
            }

        </>
    )
}

export default EmotionFinder