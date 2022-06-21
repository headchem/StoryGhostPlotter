import React, { useState } from 'react'
import Spinner from 'react-bootstrap/Spinner';
import { useNavigate } from "react-router-dom";
import { fetchWithTimeout } from '../../../../util/FetchUtil'
import { isNullOrEmpty } from '../../../../util/Helpers';
import SimpleBrainstorm from './SimpleBrainstorm';
import { getText } from '../../../../util/Helpers'

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
        updateSequenceCompletions,
        textPropName,
        completionsPropName,
        completionURL,
        editCompletion
    }
) => {


    const navigate = useNavigate()

    const sequence = sequences.filter(seq => seq['sequenceName'] === targetSequence)[0]


    const [isCompletionLoading, setIsCompletionLoading] = useState(false)

    const generateChoices = async () => {
        setIsCompletionLoading(true)

        const completions = sequence[completionsPropName]
        const temperature = 0.9

        const body = JSON.stringify({
            id: plotId,
            logLineDescription: logLineDescription,
            genres: genres,
            problemTemplate: problemTemplate,
            dramaticQuestion: dramaticQuestion,
            keywords: keywords,
            sequences: sequences,
            characters: characters,
        })

        const fetchParams = {
            timeout: 515 * 1000,  // this is the max timeout on the Function side, but in testing, it seems the browser upper limit is still enforced, so the real limit is 300 sec (5 min)
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: body
        }

        const checkSuccess = (response) => {
            if (response.status === 401 || response.status === 403) {
                navigate('/plots')
            } else {
                if (response.ok) {
                    return response.json();
                }
            }
            return Promise.reject(response);
        }

        const handleResponse = (data) => {
            console.log(data)

            if (!completions || completions.length === 0) {
                updateSequenceCompletions(targetSequence, data)
            } else {
                const newCompletionListFirst = [...completions, data[0]]

                if (data.length === 1) {
                    updateSequenceCompletions(targetSequence, newCompletionListFirst)
                } else if (data.length > 1) {
                    const newCompletionListSecond = [...newCompletionListFirst, data[1]]
                    updateSequenceCompletions(targetSequence, newCompletionListSecond)
                }
            }
        }

        const handleError = (error) => {
            console.warn(error);
            console.warn('usually this means the model is still loading on the server or you have run out of tokens');
        }

        const numCompletions = (userInfo && userInfo.userRoles.includes('customer')) ? 2 : 1

        fetchWithTimeout('/api/Sequence/' + completionURL + '?targetSequence=' + targetSequence + '&temperature=' + temperature + '&numCompletions=' + numCompletions, fetchParams)
            .then(checkSuccess)
            .then(handleResponse)
            .catch(handleError)
            .finally(function () {
                setIsCompletionLoading(false)
            });
    }

    const selectCompletion = (brainstorm) => {

        const idxOfCompletion = sequence[completionsPropName].findIndex(o => {
            return o['completion'] === brainstorm['completion'];
        });

        // first set all completions isSelected to false
        const newCompletions = sequence[completionsPropName].map(
            (completion) => { return { ...completion, isSelected: false } }
        )

        // second set just the newly selected completion to true
        const newCompletionsWithSelected = newCompletions.map(
            (completion, idx) => idx === idxOfCompletion ? { ...completion, isSelected: true } : completion
        )

        updateSequenceCompletions(targetSequence, newCompletionsWithSelected)
    }

    const numChoices = 2
    const allBrainstorms = (!sequence || !sequence[completionsPropName]) ? [] : sequence[completionsPropName]
    const mostRecentBrainstorms = allBrainstorms.slice(-1 * numChoices);
    const olderBrainstorms = (!sequence || !sequence[completionsPropName]) ? [] : sequence[completionsPropName].slice(0, sequence[completionsPropName].length - numChoices);
    const olderSelectedBrainstorm = olderBrainstorms.filter(brainstorm => brainstorm['isSelected'] === true)
    const mostRecentBrainstormsWithSelected = olderSelectedBrainstorm.length > 0 ? olderSelectedBrainstorm.concat(mostRecentBrainstorms) : mostRecentBrainstorms
    const isNoneSelected = !sequence || !sequence[completionsPropName] || sequence[completionsPropName].filter(brainstorm => brainstorm['isSelected'] === true).length === 0

    const mostRecentBrainstormsChoices = mostRecentBrainstormsWithSelected.map((brainstorm, idx) => {

        const card = <div key={idx + sequence['sequenceName']} className="card" onClick={() => selectCompletion(brainstorm)}>
            <div className="card-body">
                <SimpleBrainstorm
                    brainstorm={brainstorm}
                    editCompletion={editCompletion}
                    sequences={sequences}
                    sequenceName={sequence['sequenceName']}
                    completionPropName={completionsPropName}
                />
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
                                <>
                                    {
                                        ((userInfo && userInfo.userRoles.includes('customer')) || allBrainstorms.length <= 1) &&
                                        <button onClick={generateChoices} className='btn btn-primary'>Generate Choices</button>
                                    }
                                </>
                            }
                            {
                                isCompletionLoading === true &&
                                <Spinner size="sm" as="span" animation="border" variant="secondary" />
                            }
                        </div>
                    </div>
                </div>
                {
                    textPropName === 'text' &&
                    <div className='row'>
                        <div className='col'>
                            <p className='text-muted'>{getText(sequence, 'blurb', 'blurbCompletions')}</p>
                        </div>
                    </div>
                }

                <div className="card-group mt-3">
                    {
                        isNoneSelected === true && isNullOrEmpty(sequence[textPropName]) === false &&
                        <div key={'cur_selected_' + sequence['sequenceName']} className="card">
                            <div className="card-body">
                                <p className='fw-bold'>{sequence[textPropName]}</p>
                            </div>
                        </div>
                    }
                    {
                        mostRecentBrainstormsChoices
                    }
                </div>

            </div>
        </div>
    )
}

export default SimpleSequence