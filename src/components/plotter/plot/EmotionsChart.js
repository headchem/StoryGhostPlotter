import React, { useState } from 'react'
import { AreaChart, Area, LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';
import { v4 as uuid } from 'uuid';
import { interpolateTurbo } from '../../../util/ChartUtil'

const EmotionsChart = ({
    data,
    mode,
    showCharacterDropdown,
}) => {

    const uniqueId = uuid()

    const [showJoyToSadness, setShowJoyToSadness] = useState(true)
    const [showTrustToDisgust, setShowTrustToDisgust] = useState(true)
    const [showFearToAnger, setShowFearToAnger] = useState(true)
    const [showSurpriseToAnticipation, setShowSurpriseToAnticipation] = useState(true)

    const [showAnxietyToConfidence, setShowAnxietyToConfidence] = useState(true)
    const [showBoredomToFascination, setShowBoredomToFascination] = useState(true)
    const [showFrustrationToEuphoria, setShowFrustrationToEuphoria] = useState(true)
    const [showDispiritedToEncouraged, setShowDispiritedToEncouraged] = useState(true)
    const [showTerrorToEnchantment, setShowTerrorToEnchantment] = useState(true)
    const [showHumiliationToPride, setShowHumiliationToPride] = useState(true)

    const [showPleasureToDispleasure, setShowPleasureToDispleasure] = useState(true)
    const [showArousalToNonarousal, setShowArousalToNonarousal] = useState(true)
    const [showDominanceToSubmissiveness, setShowDominanceToSubmissiveness] = useState(true)

    const [showInnerFocusToOutwardTarget, setShowInnerFocusToOutwardTarget] = useState(true)


    const [showJoy, setShowJoy] = useState(true)
    const [showSadness, setShowSadness] = useState(true)
    const [showTrust, setShowTrust] = useState(true)
    const [showDisgust, setShowDisgust] = useState(true)
    const [showFear, setShowFear] = useState(true)
    const [showAnger, setShowAnger] = useState(true)
    const [showSurprise, setShowSurprise] = useState(true)
    const [showAnticipation, setShowAnticipation] = useState(true)
    const [showAnxiety, setShowAnxiety] = useState(true)
    const [showConfidence, setShowConfidence] = useState(true)
    const [showBoredom, setShowBoredom] = useState(true)
    const [showFascination, setShowFascination] = useState(true)
    const [showFrustration, setShowFrustration] = useState(true)
    const [showEuphoria, setShowEuphoria] = useState(true)
    const [showDispirited, setShowDispirited] = useState(true)
    const [showEncouraged, setShowEncouraged] = useState(true)
    const [showTerror, setShowTerror] = useState(true)
    const [showEnchantment, setShowEnchantment] = useState(true)
    const [showHumiliation, setShowHumiliation] = useState(true)
    const [showPride, setShowPride] = useState(true)
    const [showPleasure, setShowPleasure] = useState(true)
    const [showDispleasure, setShowDispleasure] = useState(true)
    const [showArousal, setShowArousal] = useState(true)
    const [showNonarousal, setShowNonarousal] = useState(true)
    const [showDominance, setShowDominance] = useState(true)
    const [showSubmissiveness, setShowSubmissiveness] = useState(true)

    const [selectedCharacter, setSelectedCharacter] = useState('')

    const [chartType, setChartType] = useState('line')

    const handleChartTypeChange = e => {
        const target = e.target;
        if (target.checked) {
            setChartType('area');
        } else {
            setChartType('line');
        }
    };

    const uniqueCharacterNames = [...new Set(data.map(d => d.characterName))]

    const characterFilteredData = data.filter(row => {
        if (selectedCharacter === '') return true

        if (row['characterName'] === selectedCharacter) return true

        return false

    })

    const lineData = characterFilteredData.map((emoObj, i) => {
        let row = {
            name: emoObj['name']
        }

        if (showJoyToSadness === true) {
            row['joyToSadness'] = emoObj['joyToSadness']
        }
        if (showTrustToDisgust === true) {
            row['trustToDisgust'] = emoObj['trustToDisgust']
        }
        if (showFearToAnger === true) {
            row['fearToAnger'] = emoObj['fearToAnger']
        }
        if (showSurpriseToAnticipation === true) {
            row['surpriseToAnticipation'] = emoObj['surpriseToAnticipation']
        }

        if (showAnxietyToConfidence === true) {
            row['anxietyToConfidence'] = emoObj['anxietyToConfidence']
        }
        if (showBoredomToFascination === true) {
            row['boredomToFascination'] = emoObj['boredomToFascination']
        }
        if (showFrustrationToEuphoria === true) {
            row['frustrationToEuphoria'] = emoObj['frustrationToEuphoria']
        }
        if (showDispiritedToEncouraged === true) {
            row['dispiritedToEncouraged'] = emoObj['dispiritedToEncouraged']
        }
        if (showTerrorToEnchantment === true) {
            row['terrorToEnchantment'] = emoObj['terrorToEnchantment']
        }
        if (showHumiliationToPride === true) {
            row['humiliationToPride'] = emoObj['humiliationToPride']
        }

        if (showPleasureToDispleasure === true) {
            row['pleasureToDispleasure'] = emoObj['pleasureToDispleasure']
        }
        if (showArousalToNonarousal === true) {
            row['arousalToNonarousal'] = emoObj['arousalToNonarousal']
        }
        if (showDominanceToSubmissiveness === true) {
            row['dominanceToSubmissiveness'] = emoObj['dominanceToSubmissiveness']
        }

        if (showInnerFocusToOutwardTarget === true) {
            row['innerFocusToOutwardTarget'] = emoObj['innerFocusToOutwardTarget']
        }

        return row
    })

    // convert the 14 axes of -1/+1 to 28 axes of 0-1
    const areaData = characterFilteredData.map((emoObj, i) => {

        let row = {
            name: emoObj['name']
        }

        if (showJoy === true) {
            row['joy'] = emoObj['joyToSadness'] < 0 ? emoObj['joyToSadness'] * -1 : 0
        }
        if (showSadness === true) {
            row['sadness'] = emoObj['joyToSadness'] > 0 ? emoObj['joyToSadness'] : 0
        }
        if (showTrust === true) {
            row['trust'] = emoObj['trustToDisgust'] < 0 ? emoObj['trustToDisgust'] * -1 : 0
        }
        if (showDisgust === true) {
            row['disgust'] = emoObj['trustToDisgust'] > 0 ? emoObj['trustToDisgust'] : 0
        }
        if (showFear === true) {
            row['fear'] = emoObj['fearToAnger'] < 0 ? emoObj['fearToAnger'] * -1 : 0
        }
        if (showAnger === true) {
            row['anger'] = emoObj['fearToAnger'] > 0 ? emoObj['fearToAnger'] : 0
        }
        if (showSurprise === true) {
            row['surprise'] = emoObj['surpriseToAnticipation'] < 0 ? emoObj['surpriseToAnticipation'] * -1 : 0
        }
        if (showAnticipation === true) {
            row['anticipation'] = emoObj['surpriseToAnticipation'] > 0 ? emoObj['surpriseToAnticipation'] : 0
        }

        if (showAnxiety === true) {
            row['anxiety'] = emoObj['anxietyToConfidence'] < 0 ? emoObj['anxietyToConfidence'] * -1 : 0
        }
        if (showConfidence === true) {
            row['confidence'] = emoObj['anxietyToConfidence'] > 0 ? emoObj['anxietyToConfidence'] : 0
        }
        if (showBoredom === true) {
            row['boredom'] = emoObj['boredomToFascination'] < 0 ? emoObj['boredomToFascination'] * -1 : 0
        }
        if (showFascination === true) {
            row['fascination'] = emoObj['boredomToFascination'] > 0 ? emoObj['boredomToFascination'] : 0
        }
        if (showFrustration === true) {
            row['frustration'] = emoObj['frustrationToEuphoria'] < 0 ? emoObj['frustrationToEuphoria'] * -1 : 0
        }
        if (showEuphoria === true) {
            row['euphoria'] = emoObj['frustrationToEuphoria'] > 0 ? emoObj['frustrationToEuphoria'] : 0
        }
        if (showDispirited === true) {
            row['dispirited'] = emoObj['dispiritedToEncouraged'] < 0 ? emoObj['dispiritedToEncouraged'] * -1 : 0
        }
        if (showEncouraged === true) {
            row['encouraged'] = emoObj['dispiritedToEncouraged'] > 0 ? emoObj['dispiritedToEncouraged'] : 0
        }
        if (showTerror === true) {
            row['terror'] = emoObj['terrorToEnchantment'] < 0 ? emoObj['terrorToEnchantment'] * -1 : 0
        }
        if (showEnchantment === true) {
            row['enchantment'] = emoObj['terrorToEnchantment'] > 0 ? emoObj['terrorToEnchantment'] : 0
        }
        if (showHumiliation === true) {
            row['humiliation'] = emoObj['humiliationToPride'] < 0 ? emoObj['humiliationToPride'] * -1 : 0
        }
        if (showPride === true) {
            row['pride'] = emoObj['humiliationToPride'] > 0 ? emoObj['humiliationToPride'] : 0
        }

        if (showPleasure === true) {
            row['pleasure'] = emoObj['pleasureToDispleasure'] < 0 ? emoObj['pleasureToDispleasure'] * -1 : 0
        }
        if (showDispleasure === true) {
            row['displeasure'] = emoObj['pleasureToDispleasure'] > 0 ? emoObj['pleasureToDispleasure'] : 0
        }
        if (showArousal === true) {
            row['arousal'] = emoObj['arousalToNonarousal'] < 0 ? emoObj['arousalToNonarousal'] * -1 : 0
        }
        if (showNonarousal === true) {
            row['nonarousal'] = emoObj['arousalToNonarousal'] > 0 ? emoObj['arousalToNonarousal'] : 0
        }
        if (showDominance === true) {
            row['dominance'] = emoObj['dominanceToSubmissiveness'] < 0 ? emoObj['dominanceToSubmissiveness'] * -1 : 0
        }
        if (showSubmissiveness === true) {
            row['submissiveness'] = emoObj['dominanceToSubmissiveness'] > 0 ? emoObj['dominanceToSubmissiveness'] : 0
        }

        return row
    })

    const lineKeys = (!lineData || lineData.length === 0) ? [] : Object.keys(lineData[0]).filter(o => o !== 'name')
    const areaKeys = (!areaData || areaData.length === 0) ? [] : Object.keys(areaData[0]).filter(o => o !== 'name')
    //const areaKeys = keys.map(key => key.split('To')).flat().filter(k => k !== 'innerFocus' && k !== 'OutwardTarget').map(k => k.toLowerCase())

    // the +1/+2 is intended to get the colors to avoid the extremes of the color ramp, which are difficult see in dark mode
    const colorMapLine = !lineKeys ? {} : Object.assign({}, ...lineKeys.map((key, i) => ({ [key]: interpolateTurbo((i + 1) / (lineKeys.length + 2)) })));
    const colorMapArea = !areaKeys ? {} : Object.assign({}, ...areaKeys.map((key, i) => ({ [key]: interpolateTurbo((i + 1) / (areaKeys.length + 2)) })));

    const showNone = () => {
        setShowJoyToSadness(false)
        setShowTrustToDisgust(false)
        setShowFearToAnger(false)
        setShowSurpriseToAnticipation(false)

        setShowAnxietyToConfidence(false)
        setShowBoredomToFascination(false)
        setShowFrustrationToEuphoria(false)
        setShowDispiritedToEncouraged(false)
        setShowTerrorToEnchantment(false)
        setShowHumiliationToPride(false)

        setShowPleasureToDispleasure(false)
        setShowArousalToNonarousal(false)
        setShowDominanceToSubmissiveness(false)

        setShowInnerFocusToOutwardTarget(false)

        setShowJoy(false)
        setShowSadness(false)
        setShowTrust(false)
        setShowDisgust(false)
        setShowFear(false)
        setShowAnger(false)
        setShowSurprise(false)
        setShowAnticipation(false)
        setShowAnxiety(false)
        setShowConfidence(false)
        setShowBoredom(false)
        setShowFascination(false)
        setShowFrustration(false)
        setShowEuphoria(false)
        setShowDispirited(false)
        setShowEncouraged(false)
        setShowTerror(false)
        setShowEnchantment(false)
        setShowHumiliation(false)
        setShowPride(false)
        setShowPleasure(false)
        setShowDispleasure(false)
        setShowArousal(false)
        setShowNonarousal(false)
        setShowDominance(false)
        setShowSubmissiveness(false)
    }

    const showAll = () => {
        setShowJoyToSadness(true)
        setShowTrustToDisgust(true)
        setShowFearToAnger(true)
        setShowSurpriseToAnticipation(true)

        setShowAnxietyToConfidence(true)
        setShowBoredomToFascination(true)
        setShowFrustrationToEuphoria(true)
        setShowDispiritedToEncouraged(true)
        setShowTerrorToEnchantment(true)
        setShowHumiliationToPride(true)

        setShowPleasureToDispleasure(true)
        setShowArousalToNonarousal(true)
        setShowDominanceToSubmissiveness(true)

        setShowInnerFocusToOutwardTarget(true)

        setShowJoy(true)
        setShowSadness(true)
        setShowTrust(true)
        setShowDisgust(true)
        setShowFear(true)
        setShowAnger(true)
        setShowSurprise(true)
        setShowAnticipation(true)
        setShowAnxiety(true)
        setShowConfidence(true)
        setShowBoredom(true)
        setShowFascination(true)
        setShowFrustration(true)
        setShowEuphoria(true)
        setShowDispirited(true)
        setShowEncouraged(true)
        setShowTerror(true)
        setShowEnchantment(true)
        setShowHumiliation(true)
        setShowPride(true)
        setShowPleasure(true)
        setShowDispleasure(true)
        setShowArousal(true)
        setShowNonarousal(true)
        setShowDominance(true)
        setShowSubmissiveness(true)
    }

    const showPlutchik = () => {
        setShowJoyToSadness(true)
        setShowTrustToDisgust(true)
        setShowFearToAnger(true)
        setShowSurpriseToAnticipation(true)

        setShowAnxietyToConfidence(false)
        setShowBoredomToFascination(false)
        setShowFrustrationToEuphoria(false)
        setShowDispiritedToEncouraged(false)
        setShowTerrorToEnchantment(false)
        setShowHumiliationToPride(false)

        setShowPleasureToDispleasure(false)
        setShowArousalToNonarousal(false)
        setShowDominanceToSubmissiveness(false)

        setShowInnerFocusToOutwardTarget(false)

        setShowJoy(true)
        setShowSadness(true)
        setShowTrust(true)
        setShowDisgust(true)
        setShowFear(true)
        setShowAnger(true)
        setShowSurprise(true)
        setShowAnticipation(true)

        setShowAnxiety(false)
        setShowConfidence(false)
        setShowBoredom(false)
        setShowFascination(false)
        setShowFrustration(false)
        setShowEuphoria(false)
        setShowDispirited(false)
        setShowEncouraged(false)
        setShowTerror(false)
        setShowEnchantment(false)
        setShowHumiliation(false)
        setShowPride(false)

        setShowPleasure(false)
        setShowDispleasure(false)
        setShowArousal(false)
        setShowNonarousal(false)
        setShowDominance(false)
        setShowSubmissiveness(false)
    }

    const showVAD = () => {
        setShowJoyToSadness(false)
        setShowTrustToDisgust(false)
        setShowFearToAnger(false)
        setShowSurpriseToAnticipation(false)

        setShowAnxietyToConfidence(false)
        setShowBoredomToFascination(false)
        setShowFrustrationToEuphoria(false)
        setShowDispiritedToEncouraged(false)
        setShowTerrorToEnchantment(false)
        setShowHumiliationToPride(false)

        setShowPleasureToDispleasure(true)
        setShowArousalToNonarousal(true)
        setShowDominanceToSubmissiveness(true)

        setShowInnerFocusToOutwardTarget(false)

        setShowJoy(false)
        setShowSadness(false)
        setShowTrust(false)
        setShowDisgust(false)
        setShowFear(false)
        setShowAnger(false)
        setShowSurprise(false)
        setShowAnticipation(false)

        setShowAnxiety(false)
        setShowConfidence(false)
        setShowBoredom(false)
        setShowFascination(false)
        setShowFrustration(false)
        setShowEuphoria(false)
        setShowDispirited(false)
        setShowEncouraged(false)
        setShowTerror(false)
        setShowEnchantment(false)
        setShowHumiliation(false)
        setShowPride(false)

        setShowPleasure(true)
        setShowDispleasure(true)
        setShowArousal(true)
        setShowNonarousal(true)
        setShowDominance(true)
        setShowSubmissiveness(true)
    }

    return (
        <>
            <div className="form-check form-switch fs-5 mb-4 mt-4">
                <input className="form-check-input" type="checkbox" id={uniqueId + 'ChartFlexSwitchCheckChecked'} onChange={handleChartTypeChange} checked={chartType === 'area'} />
                <label className="form-check-label" htmlFor={uniqueId + 'ChartFlexSwitchCheckChecked'}>Area</label>
            </div>
            {
                showCharacterDropdown &&
                <select required className='fs-5 form-select form-inline' value={selectedCharacter} onChange={(e) => setSelectedCharacter(e.target.value)}>
                    <option key="blank" value="">All</option>
                    {
                        uniqueCharacterNames.map(function (name) {
                            return <option key={name} value={name}>{name}</option>
                        })
                    }
                </select>
            }

            <div className='row'>
                <div className='col'>
                    <button className='btn btn-primary' onClick={() => showNone()}>None</button>
                    <button className='btn btn-primary' onClick={() => showAll()}>All</button>
                    <button className='btn btn-primary' onClick={() => showVAD()}>VAD</button>
                    <button className='btn btn-primary' onClick={() => showPlutchik()}>Plutchik</button>
                </div>
            </div>

            {
                chartType === 'line' &&
                <>
                    <div style={{ height: '400px' }}>
                        <ResponsiveContainer width="100%" height="100%">
                            <LineChart
                                width={500}
                                height={300}
                                data={lineData}
                                margin={{
                                    top: 5,
                                    right: 30,
                                    left: 20,
                                    bottom: 5,
                                }}
                            >

                                <CartesianGrid strokeDasharray="3 3" />
                                <XAxis dataKey="name" />
                                <YAxis />
                                <Tooltip />
                                <Legend />
                                {
                                    lineKeys.map((key) => <Line key={key} type="monotone" dataKey={key} stroke={colorMapLine[key]} activeDot={{ r: 8 }} />)
                                }
                            </LineChart>
                        </ResponsiveContainer>
                    </div>

                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'joyToSadness'}>joyToSadness</label>
                        <input id={uniqueId + 'joyToSadness'} className='form-check-input' type='checkbox' onChange={(e) => setShowJoyToSadness(e.currentTarget.checked)} checked={showJoyToSadness} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'trustToDisgust'}>trustToDisgust</label>
                        <input id={uniqueId + 'trustToDisgust'} className='form-check-input' type='checkbox' onChange={(e) => setShowTrustToDisgust(e.currentTarget.checked)} checked={showTrustToDisgust} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'fearToAnger'}>fearToAnger</label>
                        <input id={uniqueId + 'fearToAnger'} className='form-check-input' type='checkbox' onChange={(e) => setShowFearToAnger(e.currentTarget.checked)} checked={showFearToAnger} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'surpriseToAnticipation'}>surpriseToAnticipation</label>
                        <input id={uniqueId + 'surpriseToAnticipation'} className='form-check-input' type='checkbox' onChange={(e) => setShowSurpriseToAnticipation(e.currentTarget.checked)} checked={showSurpriseToAnticipation} />
                    </div>

                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'anxietyToConfidence'}>anxietyToConfidence</label>
                        <input id={uniqueId + 'anxietyToConfidence'} className='form-check-input' type='checkbox' onChange={(e) => setShowAnxietyToConfidence(e.currentTarget.checked)} checked={showAnxietyToConfidence} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'boredomToFascination'}>boredomToFascination</label>
                        <input id={uniqueId + 'boredomToFascination'} className='form-check-input' type='checkbox' onChange={(e) => setShowBoredomToFascination(e.currentTarget.checked)} checked={showBoredomToFascination} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'frustrationToEuphoria'}>frustrationToEuphoria</label>
                        <input id={uniqueId + 'frustrationToEuphoria'} className='form-check-input' type='checkbox' onChange={(e) => setShowFrustrationToEuphoria(e.currentTarget.checked)} checked={showFrustrationToEuphoria} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'dispiritedToEncouraged'}>dispiritedToEncouraged</label>
                        <input id={uniqueId + 'dispiritedToEncouraged'} className='form-check-input' type='checkbox' onChange={(e) => setShowDispiritedToEncouraged(e.currentTarget.checked)} checked={showDispiritedToEncouraged} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'terrorToEnchantment'}>terrorToEnchantment</label>
                        <input id={uniqueId + 'terrorToEnchantment'} className='form-check-input' type='checkbox' onChange={(e) => setShowTerrorToEnchantment(e.currentTarget.checked)} checked={showTerrorToEnchantment} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'humiliationToPride'}>humiliationToPride</label>
                        <input id={uniqueId + 'humiliationToPride'} className='form-check-input' type='checkbox' onChange={(e) => setShowHumiliationToPride(e.currentTarget.checked)} checked={showHumiliationToPride} />
                    </div>

                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'pleasureToDispleasure'}>pleasureToDispleasure</label>
                        <input id={uniqueId + 'pleasureToDispleasure'} className='form-check-input' type='checkbox' onChange={(e) => setShowPleasureToDispleasure(e.currentTarget.checked)} checked={showPleasureToDispleasure} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'arousalToNonarousal'}>arousalToNonarousal</label>
                        <input id={uniqueId + 'arousalToNonarousal'} className='form-check-input' type='checkbox' onChange={(e) => setShowArousalToNonarousal(e.currentTarget.checked)} checked={showArousalToNonarousal} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'dominanceToSubmissiveness'}>dominanceToSubmissiveness</label>
                        <input id={uniqueId + 'dominanceToSubmissiveness'} className='form-check-input' type='checkbox' onChange={(e) => setShowDominanceToSubmissiveness(e.currentTarget.checked)} checked={showDominanceToSubmissiveness} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'innerFocusToOutwardTarget'}>innerFocusToOutwardTarget</label>
                        <input id={uniqueId + 'innerFocusToOutwardTarget'} className='form-check-input' type='checkbox' onChange={(e) => setShowInnerFocusToOutwardTarget(e.currentTarget.checked)} checked={showInnerFocusToOutwardTarget} />
                    </div>
                </>
            }

            {
                chartType === 'area' &&
                <>
                    <div style={{ height: '400px' }}>
                        <ResponsiveContainer width="100%" height="100%">
                            <AreaChart
                                width={500}
                                height={400}
                                data={areaData}
                                margin={{
                                    top: 10,
                                    right: 30,
                                    left: 0,
                                    bottom: 0,
                                }}
                            >
                                <CartesianGrid strokeDasharray="3 3" />
                                <XAxis dataKey="name" />
                                <YAxis />
                                {/* <Tooltip /> */}
                                <Legend />
                                {
                                    areaKeys.map((key) => <Area key={key} type="linear" dataKey={key} stackId="1" stroke={colorMapArea[key]} fill={colorMapArea[key]} activeDot={{ r: 8 }} />)
                                }
                            </AreaChart>
                        </ResponsiveContainer>
                    </div>

                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'joy'}>joy</label>
                        <input id={uniqueId + 'joy'} className='form-check-input' type='checkbox' onChange={(e) => setShowJoy(e.currentTarget.checked)} checked={showJoy} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'sadness'}>sadness</label>
                        <input id={uniqueId + 'sadness'} className='form-check-input' type='checkbox' onChange={(e) => setShowSadness(e.currentTarget.checked)} checked={showSadness} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'trust'}>trust</label>
                        <input id={uniqueId + 'trust'} className='form-check-input' type='checkbox' onChange={(e) => setShowTrust(e.currentTarget.checked)} checked={showTrust} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'disgust'}>disgust</label>
                        <input id={uniqueId + 'disgust'} className='form-check-input' type='checkbox' onChange={(e) => setShowDisgust(e.currentTarget.checked)} checked={showDisgust} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'fear'}>fear</label>
                        <input id={uniqueId + 'fear'} className='form-check-input' type='checkbox' onChange={(e) => setShowFear(e.currentTarget.checked)} checked={showFear} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'anger'}>anger</label>
                        <input id={uniqueId + 'anger'} className='form-check-input' type='checkbox' onChange={(e) => setShowAnger(e.currentTarget.checked)} checked={showAnger} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'surprise'}>surprise</label>
                        <input id={uniqueId + 'surprise'} className='form-check-input' type='checkbox' onChange={(e) => setShowSurprise(e.currentTarget.checked)} checked={showSurprise} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'anticipation'}>anticipation</label>
                        <input id={uniqueId + 'anticipation'} className='form-check-input' type='checkbox' onChange={(e) => setShowAnticipation(e.currentTarget.checked)} checked={showAnticipation} />
                    </div>

                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'anxiety'}>anxiety</label>
                        <input id={uniqueId + 'anxiety'} className='form-check-input' type='checkbox' onChange={(e) => setShowAnxiety(e.currentTarget.checked)} checked={showAnxiety} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'confidence'}>confidence</label>
                        <input id={uniqueId + 'confidence'} className='form-check-input' type='checkbox' onChange={(e) => setShowConfidence(e.currentTarget.checked)} checked={showConfidence} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'boredom'}>boredom</label>
                        <input id={uniqueId + 'boredom'} className='form-check-input' type='checkbox' onChange={(e) => setShowBoredom(e.currentTarget.checked)} checked={showBoredom} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'fascination'}>fascination</label>
                        <input id={uniqueId + 'fascination'} className='form-check-input' type='checkbox' onChange={(e) => setShowFascination(e.currentTarget.checked)} checked={showFascination} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'frustration'}>frustration</label>
                        <input id={uniqueId + 'frustration'} className='form-check-input' type='checkbox' onChange={(e) => setShowFrustration(e.currentTarget.checked)} checked={showFrustration} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'euphoria'}>euphoria</label>
                        <input id={uniqueId + 'euphoria'} className='form-check-input' type='checkbox' onChange={(e) => setShowEuphoria(e.currentTarget.checked)} checked={showEuphoria} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'dispirited'}>dispirited</label>
                        <input id={uniqueId + 'dispirited'} className='form-check-input' type='checkbox' onChange={(e) => setShowDispirited(e.currentTarget.checked)} checked={showDispirited} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'encouraged'}>encouraged</label>
                        <input id={uniqueId + 'encouraged'} className='form-check-input' type='checkbox' onChange={(e) => setShowEncouraged(e.currentTarget.checked)} checked={showEncouraged} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'terror'}>terror</label>
                        <input id={uniqueId + 'terror'} className='form-check-input' type='checkbox' onChange={(e) => setShowTerror(e.currentTarget.checked)} checked={showTerror} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'enchantment'}>enchantment</label>
                        <input id={uniqueId + 'enchantment'} className='form-check-input' type='checkbox' onChange={(e) => setShowEnchantment(e.currentTarget.checked)} checked={showEnchantment} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'humiliation'}>humiliation</label>
                        <input id={uniqueId + 'humiliation'} className='form-check-input' type='checkbox' onChange={(e) => setShowHumiliation(e.currentTarget.checked)} checked={showHumiliation} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'pride'}>pride</label>
                        <input id={uniqueId + 'pride'} className='form-check-input' type='checkbox' onChange={(e) => setShowPride(e.currentTarget.checked)} checked={showPride} />
                    </div>

                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'pleasure'}>pleasure</label>
                        <input id={uniqueId + 'pleasure'} className='form-check-input' type='checkbox' onChange={(e) => setShowPleasure(e.currentTarget.checked)} checked={showPleasure} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'displeasure'}>displeasure</label>
                        <input id={uniqueId + 'displeasure'} className='form-check-input' type='checkbox' onChange={(e) => setShowDispleasure(e.currentTarget.checked)} checked={showDispleasure} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'arousal'}>arousal</label>
                        <input id={uniqueId + 'arousal'} className='form-check-input' type='checkbox' onChange={(e) => setShowArousal(e.currentTarget.checked)} checked={showArousal} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'nonarousal'}>nonarousal</label>
                        <input id={uniqueId + 'nonarousal'} className='form-check-input' type='checkbox' onChange={(e) => setShowNonarousal(e.currentTarget.checked)} checked={showNonarousal} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'dominance'}>dominance</label>
                        <input id={uniqueId + 'dominance'} className='form-check-input' type='checkbox' onChange={(e) => setShowDominance(e.currentTarget.checked)} checked={showDominance} />
                    </div>
                    <div className="col-2 form-check form-check-inline">
                        <label className="form-check-label" htmlFor={uniqueId + 'submissiveness'}>submissiveness</label>
                        <input id={uniqueId + 'submissiveness'} className='form-check-input' type='checkbox' onChange={(e) => setShowSubmissiveness(e.currentTarget.checked)} checked={showSubmissiveness} />
                    </div>
                </>
            }
        </>
    )
}

export default EmotionsChart