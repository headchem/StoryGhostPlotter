import React, { useState } from 'react'
//import LimitedTextArea from '../LimitedTextArea'
import Spinner from 'react-bootstrap/Spinner';
import { useNavigate } from "react-router-dom";
import { fetchWithTimeout } from '../../../../util/FetchUtil'
//import { blurbLimits } from '../../../../util/SequenceTextCheck';

const SimpleSequence = (
    {
        userInfo,
        plotId,
        targetSequence,
        logLineDescription,
        genres,
        problemTemplate,
        dramaticQuestion,
        keywords,
        sequences,
        characters,
        //setSequences
        //updateBlurb,
        updateSequenceCompletions
    }
) => {

    const navigate = useNavigate()

    const sequence = sequences.filter(seq => seq['sequenceName'] === targetSequence)[0]


    const [isCompletionLoading, setIsCompletionLoading] = useState(false)

    const generateChoices = async () => {

        console.log('generate 2 new choices and append to existing aiCompletions for this sequence');

        setIsCompletionLoading(true)

        const completions = sequence['blurbCompletions']
        const completionURL = 'GenerateBlurb'
        const temperature = 0.9

        fetchWithTimeout('/api/Sequence/' + completionURL + '?targetSequence=' + targetSequence + '&temperature=' + temperature, {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                id: plotId,
                logLineDescription: logLineDescription,
                genres: genres,
                problemTemplate: problemTemplate,
                dramaticQuestion: dramaticQuestion,
                keywords: keywords,
                sequences: sequences,
                characters: characters,
            })
        }).then(function (response) {
            if (response.status === 401 || response.status === 403) {
                navigate('/plots')
            } else {
                if (response.ok) {
                    return response.json();
                }
            }
            return Promise.reject(response);
        }).then(function (data) {
            //console.log('save this data:')
            //console.log(data)
            if (!completions || completions.length === 0) {
                updateSequenceCompletions(targetSequence, [data])
            } else {
                const newCompletionList = [...completions, data]
                updateSequenceCompletions(targetSequence, newCompletionList)
            }
        }).catch(function (error) {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server or you have run out of tokens');
        }).finally(function () {
            setIsCompletionLoading(false)
        });
    }

    const selectCompletion = (brainstorm) => {

        const idxOfCompletion = sequence['blurbCompletions'].findIndex(o => {
            return o['completion'] === brainstorm['completion'];
        });

        // first set all completions isSelected to false
        const newCompletions = sequence['blurbCompletions'].map(
            (completion) => { return { ...completion, isSelected: false } }
        )

        // second set just the newly selected completion to true
        const newCompletionsWithSelected = newCompletions.map(
            (completion, idx) => idx === idxOfCompletion ? { ...completion, isSelected: true } : completion
        )

        updateSequenceCompletions(targetSequence, newCompletionsWithSelected)

        //console.log('select completion at idx: ' + idxOfCompletion)
    }

    const numChoices = 2

    const mostRecentBrainstorms = (!sequence || !sequence['blurbCompletions']) ? [] : sequence['blurbCompletions'].slice(-1 * numChoices);
    const olderBrainstorms = (!sequence || !sequence['blurbCompletions']) ? [] : sequence['blurbCompletions'].slice(0, sequence['blurbCompletions'].length - numChoices);
    const olderSelectedBrainstorm = olderBrainstorms.filter(brainstorm => brainstorm['isSelected'] === true)
    const mostRecentBrainstormsWithSelected = olderSelectedBrainstorm.length > 0 ? olderSelectedBrainstorm.concat(mostRecentBrainstorms) : mostRecentBrainstorms
    const isNoneSelected = !sequence || !sequence['blurbCompletions'] || sequence['blurbCompletions'].filter(brainstorm => brainstorm['isSelected'] === true).length === 0

    const mostRecentBrainstormsChoices = mostRecentBrainstormsWithSelected.map((brainstorm, idx) => {

        const textClass = brainstorm['isSelected'] === true ? 'fw-bold' : 'text-muted'

        const card = <div key={idx + sequence['sequenceName']} className="card" onClick={() => selectCompletion(brainstorm)}>
            <div className="card-body">
                <p className={textClass}>{brainstorm['completion']}</p>
            </div>
        </div>

        return card
    })


    return (
        <div className='row'>
            <div className='col'>
                <div className='row'>
                    <div className='col'>
                        <h3 className='float-start'>{sequence['sequenceName']}</h3>
                        <div className='float-end'>
                            {
                                isCompletionLoading === false &&
                                <button onClick={generateChoices} className='btn btn-primary'>Generate Choices</button>
                            }
                            {
                                isCompletionLoading === true &&
                                <Spinner size="sm" as="span" animation="border" variant="secondary" />
                            }
                        </div>
                    </div>
                </div>

                <div className="card-group mt-3">
                    {
                        isNoneSelected === true &&
                        <div key={'cur_selected_blurb_' + sequence['sequenceName']} className="card">
                            <div className="card-body">
                                <p className='fw-bold'>{sequence['blurb']}</p>
                            </div>
                        </div>
                    }
                    {
                        mostRecentBrainstormsChoices
                    }
                </div>

                {/* <div className='d-none'>
                    <LimitedTextArea
                        id={sequence.sequenceName + '_blurb_textarea'}
                        className="form-control"
                        value={sequence.blurb}
                        setValue={(newValue) => updateBlurb(sequence.sequenceName, newValue)}
                        rows={blurbLimits[sequence.sequenceName]['rows']}
                        limit={blurbLimits[sequence.sequenceName]['max']}
                        showCount={true}
                    />
                </div> */}
            </div>
        </div>
    )
}

export default SimpleSequence