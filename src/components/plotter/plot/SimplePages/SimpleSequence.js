import React, { useState } from 'react'
import LimitedTextArea from '../LimitedTextArea'
import Spinner from 'react-bootstrap/Spinner';
import { useNavigate } from "react-router-dom";
import { fetchWithTimeout } from '../../../../util/FetchUtil'
import { blurbLimits } from '../../../../util/SequenceTextCheck';

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
        updateBlurb,
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

    const mostRecentBrainstorms = (!sequence || !sequence['blurbCompletions']) ? [] : sequence['blurbCompletions'].slice(-2);
    const mostRecentBrainstormsCompletions = mostRecentBrainstorms.map(brainstorm => brainstorm['completion'])
    const mostRecentBrainstormsChoices = mostRecentBrainstorms.map((brainstorm, idx) => {

        const textClass = sequence['blurb'] === brainstorm['completion'] ? 'fw-bold' : 'text-muted'

        const card = <div key={idx} className="card" onClick={() => updateBlurb(sequence.sequenceName, brainstorm['completion'])}>
            <div className="card-body">
                <p className={textClass}>{brainstorm['completion']}</p>
            </div>
        </div>

        return card
    }
    )

    return (
        <div className='row'>
            <div className='col-12 pb-5'>
                <h3>{sequence['sequenceName']}</h3>
                {
                    isCompletionLoading === false &&
                    <button onClick={generateChoices} className='btn btn-primary float-end'>Generate Choices</button>
                }
                {
                    isCompletionLoading === true &&
                    <Spinner size="sm" as="span" animation="border" variant="secondary" />
                }

                <div className="card-group">
                    {
                        mostRecentBrainstormsCompletions.every(completion => completion !== sequence['blurb']) &&
                        <div key={'cur_selected_blurb'} className="card" onClick={() => updateBlurb(sequence.sequenceName, sequence['blurb'])}>
                            <div className="card-body">
                                <p className='fw-bold'>{sequence['blurb']}</p>
                            </div>
                        </div>
                    }
                    {
                        mostRecentBrainstormsChoices
                    }
                </div>

                <div className='d-none'>
                    <LimitedTextArea
                        id={sequence.sequenceName + '_blurb_textarea'}
                        className="form-control"
                        value={sequence.blurb}
                        setValue={(newValue) => updateBlurb(sequence.sequenceName, newValue)}
                        rows={blurbLimits[sequence.sequenceName]['rows']}
                        limit={blurbLimits[sequence.sequenceName]['max']}
                        showCount={true}
                    />
                </div>


            </div>
        </div>
    )
}

export default SimpleSequence