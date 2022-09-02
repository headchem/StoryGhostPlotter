import React from 'react';
import { AreaChart, Area, LineChart, Line, XAxis, YAxis, CartesianGrid, Tooltip, Legend, ResponsiveContainer } from 'recharts';

const EmotionsChart = ({
    keys,
    data,
    mode,
    chartType,
}) => {

    // FROM: https://observablehq.com/@mbostock/turbo
    // Google's Turbo color palette (https://ai.googleblog.com/2019/08/turbo-improved-rainbow-colormap-for.html)
    const interpolateTurbo = (x) => {
        x = Math.max(0, Math.min(1, x));
        return `rgb(${[
            34.61 + x * (1172.33 - x * (10793.56 - x * (33300.12 - x * (38394.49 - x * 14825.05)))),
            23.31 + x * (557.33 + x * (1225.33 - x * (3574.96 - x * (1073.77 + x * 707.56)))),
            27.2 + x * (3211.1 - x * (15327.97 - x * (27814 - x * (22569.18 - x * 6838.66))))
        ].map(Math.floor).join(", ")})`;
    }

    const areaData = data.map((emoObj, i) => {

        return {
            name: emoObj['name'],

            joy: emoObj['joyToSadness'] < 0 ? emoObj['joyToSadness'] * -1 : 0,
            sadness: emoObj['joyToSadness'] > 0 ? emoObj['joyToSadness'] : 0,
            trust: emoObj['trustToDisgust'] < 0 ? emoObj['trustToDisgust'] * -1 : 0,
            disgust: emoObj['trustToDisgust'] > 0 ? emoObj['trustToDisgust'] : 0,
            fear: emoObj['fearToAnger'] < 0 ? emoObj['fearToAnger'] * -1 : 0,
            anger: emoObj['fearToAnger'] > 0 ? emoObj['fearToAnger'] : 0,
            surprise: emoObj['surpriseToAnticipation'] < 0 ? emoObj['surpriseToAnticipation'] * -1 : 0,
            anticipation: emoObj['surpriseToAnticipation'] > 0 ? emoObj['surpriseToAnticipation'] : 0,

            anxiety: emoObj['anxietyToConfidence'] < 0 ? emoObj['anxietyToConfidence'] * -1 : 0,
            confidence: emoObj['anxietyToConfidence'] > 0 ? emoObj['anxietyToConfidence'] : 0,
            boredom: emoObj['boredomToFascination'] < 0 ? emoObj['boredomToFascination'] * -1 : 0,
            fascination: emoObj['boredomToFascination'] > 0 ? emoObj['boredomToFascination'] : 0,
            frustration: emoObj['frustrationToEuphoria'] < 0 ? emoObj['frustrationToEuphoria'] * -1 : 0,
            euphoria: emoObj['frustrationToEuphoria'] > 0 ? emoObj['frustrationToEuphoria'] : 0,
            dispirited: emoObj['dispiritedToEncouraged'] < 0 ? emoObj['dispiritedToEncouraged'] * -1 : 0,
            encouraged: emoObj['dispiritedToEncouraged'] > 0 ? emoObj['dispiritedToEncouraged'] : 0,
            terror: emoObj['terrorToEnchantment'] < 0 ? emoObj['terrorToEnchantment'] * -1 : 0,
            enchantment: emoObj['terrorToEnchantment'] > 0 ? emoObj['terrorToEnchantment'] : 0,
            humiliation: emoObj['humiliationToPride'] < 0 ? emoObj['humiliationToPride'] * -1 : 0,
            pride: emoObj['humiliationToPride'] > 0 ? emoObj['humiliationToPride'] : 0,

            pleasure: emoObj['pleasureToDispleasure'] < 0 ? emoObj['pleasureToDispleasure'] * -1 : 0,
            displeasure: emoObj['pleasureToDispleasure'] > 0 ? emoObj['pleasureToDispleasure'] : 0,
            arousal: emoObj['arousalToNonarousal'] < 0 ? emoObj['arousalToNonarousal'] * -1 : 0,
            nonarousal: emoObj['arousalToNonarousal'] > 0 ? emoObj['arousalToNonarousal'] : 0,
            dominance: emoObj['dominanceToSubmissiveness'] < 0 ? emoObj['dominanceToSubmissiveness'] * -1 : 0,
            submissiveness: emoObj['dominanceToSubmissiveness'] > 0 ? emoObj['dominanceToSubmissiveness'] : 0,

            // these don't really make sense as indicators of "intensity"
            //innerFocus: emoObj['innerFocusToOutwardTarget'] < 0 ? emoObj['innerFocusToOutwardTarget']*-1 : 0,
            //outwardTarget: emoObj['innerFocusToOutwardTarget'] > 0 ? emoObj['innerFocusToOutwardTarget'] : 0,
        }
    })

    const areaKeys = keys.map(key => key.split('To')).flat().filter(k => k !== 'innerFocus' && k !== 'OutwardTarget').map(k => k.toLowerCase())

    // the +1/+2 is intended to get the colors to avoid the extremes of the color ramp, which are difficult see in dark mode
    const colorMap = !keys ? {} : Object.assign({}, ...keys.map((key, i) => ({ [key]: interpolateTurbo((i + 1) / (keys.length + 2)) })));
    const colorMapArea = !areaKeys ? {} : Object.assign({}, ...areaKeys.map((key, i) => ({ [key]: interpolateTurbo((i + 1) / (areaKeys.length + 2)) })));
    // convert the 14 axes of -1/+1 to 28 axes of 0-1



    return (
        <>
            <div style={{ height: '400px' }}>
                {
                    chartType === 'line' &&
                    <ResponsiveContainer width="100%" height="100%">
                        <LineChart
                            width={500}
                            height={300}
                            data={data}
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
                                keys.map((key) => <Line key={key} type="monotone" dataKey={key} stroke={colorMap[key]} activeDot={{ r: 8 }} />)
                            }
                        </LineChart>
                    </ResponsiveContainer>
                }
                {
                    chartType === 'area' &&
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
                }
            </div>
        </>
    )
}

export default EmotionsChart