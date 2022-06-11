import React from 'react'

const Pagination = (
    {
        curPage,
        prevPage,
        nextPage,
        goToPage,
        totalPages
    }
) => {

    return (
        <nav className="pt-5" aria-label="Page navigation">
            <ul className="pagination justify-content-center pagination-lg">
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

                {Array.from({ length: totalPages }, (_, i) => {
                    if (curPage === i) {
                        return <li key={i} onClick={() => goToPage(i)} className="page-item active" aria-current="page">
                            <button className="btn-link page-link">{i}</button>
                        </li>
                    }
                    return <li key={i} onClick={() => goToPage(i)} className="page-item">
                        <button className="btn-link page-link">{i}</button>
                    </li>
                })}

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

            </ul>
        </nav>
    )
}

export default Pagination