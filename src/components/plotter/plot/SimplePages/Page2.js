import React from 'react'
import ProblemTemplateAdvice from '../Advice/ProblemTemplateAdvice'
import DramaticQuestionAdvice from '../Advice/DramaticQuestionAdvice'
import DramaticQuestionProblemTemplateTable from '../Advice/DramaticQuestionProblemTemplateTable'

const Page2 = (
    {
        problemTemplate,
        onProblemTemplateChange,
        onFocusChange,
        problemTemplateOptions,
        dramaticQuestion,
        onDramaticQuestionChange,
        dramaticQuestionOptions,

        genres,
        keywords,
        appealTermsIDs,
        logLineDescription,
    }
) => {

    return (
        <>
            <div className="card-group">
                <div className="card">
                    <div className="card-body">
                        <div className='row'>
                            <div className='col'>
                                <p><strong>Genres:</strong> {genres.join(', ')}</p>
                            </div>
                            <div className='col'>
                                <p><strong>Appeal Terms:</strong> {appealTermsIDs.join(', ')}</p>
                            </div>
                            <div className='col'>
                                <p><strong>Keywords:</strong> {keywords.join(', ')}</p>
                            </div>
                        </div>
                        <div className='row'>
                            <div className='col'>
                                <p>{logLineDescription}</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div className="card-group">
                <div className="card">

                    <div className="card-body">
                        {/* <h5 class="card-title">Problem Template</h5> */}
                        <label htmlFor="problemTemplate" className="form-label card-title fs-3">Problem Template</label>
                        <select
                            id='problemTemplate'
                            required
                            className='fs-5 form-select'
                            value={!problemTemplate ? '' : problemTemplate}
                            //defaultValue={problemTemplate}
                            onChange={onProblemTemplateChange}
                            onFocus={() => onFocusChange('problem template')}>
                            <option key="blank" value="" disabled>Problem Template</option>
                            {
                                problemTemplateOptions.map(function (o, idx) {
                                    return <option key={idx} value={o.value}>{o.label}</option>
                                })
                            }
                        </select>
                        <div className='mt-3'>
                            <ProblemTemplateAdvice
                                problemTemplate={problemTemplate}
                            />
                        </div>
                    </div>
                </div>
                <div className="card">
                    <div className="card-body">
                        {/* <h5 class="card-title">Dramatic Question</h5> */}
                        <label htmlFor="dramaticQuestion" className="form-label fs-3" title='also called the "theme"'>Dramatic Question</label>

                        <select
                            id='dramaticQuestion'
                            required
                            className='fs-5 form-select dramaticQuestionSelect'
                            value={!dramaticQuestion ? '' : dramaticQuestion}
                            onChange={onDramaticQuestionChange}
                            onFocus={() => onFocusChange('dramatic question')}>
                            <option key="blank" value="" disabled>Dramatic Question</option>
                            {
                                dramaticQuestionOptions.map(function (o) {
                                    return <option key={o.value} value={o.value}>{o.label}</option>
                                })
                            }
                        </select>
                        <div className='mt-3'>
                            <DramaticQuestionAdvice
                                dramaticQuestion={dramaticQuestion}
                            />
                        </div>
                    </div>
                </div>
            </div>
            <div className='pt-5'>
                <DramaticQuestionProblemTemplateTable
                    showExplanation={true}
                    problemTemplate={problemTemplate}
                    dramaticQuestion={dramaticQuestion}
                />
            </div>
        </>
    )
}

export default Page2