import React from 'react'
import DramaticQuestionProblemTemplateTable from '../Advice/DramaticQuestionProblemTemplateTable'

const Page3 = (
    {
        title,
        logLineDescription,
        genres,
        keywords,
        problemTemplate,
        dramaticQuestion
    }
) => {

    return (
        <div className='row'>
            <div className='col-12'>
                <p><strong>Genres: </strong>{genres.join(', ')}</p>
                <p><strong>Keywords: </strong>{keywords.join(', ')}</p>
                <h1>{title}</h1>
                <p className='fs-5'>{logLineDescription}</p>
                <DramaticQuestionProblemTemplateTable
                    problemTemplate={problemTemplate}
                    dramaticQuestion={dramaticQuestion}
                />
            </div>
        </div>
    )
}

export default Page3