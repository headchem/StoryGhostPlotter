import React from 'react'

const Pagination = (
    {
        showPrevNext,
        curPage,
        prevPage,
        nextPage,
        goToPage,
        pageNames
    }
) => {

    const totalPages = pageNames.length

    return (
        <>
            <div className="d-md-none">
                <select className='fs-5 form-select form-inline' value={curPage} onChange={(e) => goToPage(parseInt(e.target.value))}>
                    {Array.from({ length: totalPages }, (_, i) => {
                        return <option key={i} value={i}>{(i+1).toString()}: {pageNames[i]}</option>
                    })}
                </select>
            </div>
            <div className="d-none d-md-block">
                <nav aria-label="Page navigation">
                    <ul className="pagination justify-content-center">
                        {
                            showPrevNext &&
                            <>
                                {
                                    curPage === 0 &&
                                    <li className="page-item disabled">
                                        <button onClick={prevPage} className="btn-link page-link" href="#" tabIndex="-1" aria-disabled="true">Previous</button>
                                    </li>
                                }
                                {
                                    curPage > 0 &&
                                    <li className="page-item">
                                        <button onClick={prevPage} className="btn-link page-link">Previous</button>
                                    </li>
                                }
                            </>
                        }

                        {Array.from({ length: totalPages }, (_, i) => {
                            if (curPage === i) {
                                return <li key={i} onClick={() => goToPage(i)} className="page-item active" aria-current="page">
                                    <button className="btn-link page-link">{i + 1}. {pageNames[i]}</button>
                                </li>
                            }
                            return <li key={i} onClick={() => goToPage(i)} className="page-item">
                                <button className="btn-link page-link">{i + 1}. {pageNames[i]}</button>
                            </li>
                        })}

                        {
                            showPrevNext &&
                            <>
                                {
                                    curPage >= totalPages - 1 &&
                                    <li className="page-item disabled">
                                        <button onClick={nextPage} className="btn-link page-link" tabIndex="-1" aria-disabled="true">Next</button>
                                    </li>
                                }
                                {
                                    curPage < totalPages - 1 &&
                                    <li className="page-item">
                                        <button onClick={nextPage} className="btn-link page-link">Next</button>
                                    </li>
                                }
                            </>
                        }

                    </ul>
                </nav>
            </div>


        </>
    )
}

export default Pagination