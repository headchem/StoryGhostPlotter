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
        dramaticQuestionOptions
    }
) => {

    return (
        <>
            <div className="card-group">
                <div className="card">

                    <div className="card-body">
                        {/* <h5 class="card-title">Problem Template</h5> */}
                        <label htmlFor="problemTemplate" className="form-label card-title">Problem Template</label>
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
                        <ProblemTemplateAdvice
                            problemTemplate={problemTemplate}
                        />
                    </div>
                </div>
                <div className="card">
                    <div className="card-body">
                        {/* <h5 class="card-title">Dramatic Question</h5> */}
                        <label htmlFor="dramaticQuestion" className="form-label" title='also called the "theme"'>Dramatic Question</label>

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

                        <DramaticQuestionAdvice
                            dramaticQuestion={dramaticQuestion}
                        />
                    </div>
                </div>
            </div>
            <div className='pt-5'>
                <DramaticQuestionProblemTemplateTable
                    problemTemplate={problemTemplate}
                    dramaticQuestion={dramaticQuestion}
                />
            </div>
        </>
    )
}

export default Page2