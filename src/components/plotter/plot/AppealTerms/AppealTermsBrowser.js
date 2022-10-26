import React, { useState } from 'react'

const AppealTermsBrowser = (
    {
        genres,
        setGenres,
        appealTermsOptions,
        appealTerms,
        setAppealTerms,
    }
) => {

    const [selectedGenre, setSelectedGenre] = useState('')
    const [selectedCategory, setSelectedCategory] = useState('')
    const [selectedAppealTerm, setSelectedAppealTerm] = useState('')

    const allGenresWithDupes = appealTermsOptions.map(a => a['genres']).flat()
    const allGenres = [...new Set(allGenresWithDupes)].filter(g => g !== '').sort()

    const onSelectGenre = (g) => {
        setSelectedGenre(g)
        setSelectedCategory('')
        setSelectedAppealTerm('')
    }

    const allGenresListItems = allGenres.map((g) => <li key={g} className={g === selectedGenre ? 'fw-bold' : ''}>
        <span onClick={() => onSelectGenre(g)}>{g}</span>
    </li>)

    const appealTermsOptionsForGenre = appealTermsOptions.filter(a => a['genres'].includes(selectedGenre))

    const allGenreCategoriesWithDupes = appealTermsOptionsForGenre.map(a => a['categories']).flat()
    const allGenreCategories = [...new Set(allGenreCategoriesWithDupes)].filter(c => c !== '').sort()

    const onSelectCategory = (c) => {
        if (c === selectedCategory) {
            setSelectedCategory('')
        } else {
            setSelectedCategory(c)
        }
        setSelectedAppealTerm('')
    }

    const allGenreCategoriesListItems = allGenreCategories.map((c) => <li key={c} className={c === selectedCategory ? 'fw-bold' : ''}>
        <span onClick={() => onSelectCategory(c)}>{c}</span>
    </li>)

    const appealTermsOptionsForGenreAndCategory = selectedCategory === '' ? appealTermsOptionsForGenre : appealTermsOptionsForGenre.filter(a => a['categories'].includes(selectedCategory))
    const allGenreCategoriesAppealTerms = appealTermsOptionsForGenreAndCategory.map(a => a['value']).sort()

    const getAppealTermListItem = (a) => {
        return <li key={a} className={a === selectedAppealTerm ? 'fw-bold' : ''}>
            <span onClick={() => setSelectedAppealTerm(a)}>{a}</span>
        </li>
    }

    const allGenreCategoryAppealTermsListItems = allGenreCategoriesAppealTerms.map(getAppealTermListItem)

    const selectedAppealTermObj = appealTermsOptions.filter(a => a['value'] === selectedAppealTerm)[0]

    const selectedAppealTermGenres = !selectedAppealTermObj ? [] : selectedAppealTermObj['genres']

    const onAddAppealTerm = () => {
        const newAppealTermsWithDupes = [...appealTerms, selectedAppealTermObj['value']]
        const newAppealTerms = [...new Set(newAppealTermsWithDupes)]

        setAppealTerms(newAppealTerms)
    }

    const onAddGenre = (curGenre) => {
        const newGenresWithDupes = genres.concat(curGenre)
        const newGenres = [...new Set(newGenresWithDupes)]

        setGenres(newGenres)
    }

    const onRemoveGenre = (curGenre) => {
        const newGenres = genres.filter(g => g !== curGenre)
        setGenres(newGenres)
    }

    const onRemoveAppealTerm = (curAppealTerm) => {
        const newAppealTerms = appealTerms.filter(a => a !== curAppealTerm)
        setAppealTerms(newAppealTerms)
    }

    return (
        <>
            <div className='row'>
                <div className='col'>
                    <p>selected genre: {selectedGenre}</p>
                    <ul>
                        {allGenresListItems}
                    </ul>
                </div>
                <div className='col'>
                    <p>selected category: {selectedCategory}</p>
                    <ul>
                        {allGenreCategoriesListItems}
                    </ul>
                </div>
                <div className='col'>
                    <p>selected appeal term: {selectedAppealTerm}</p>
                    <ul>
                        {allGenreCategoryAppealTermsListItems}
                    </ul>
                </div>
                <div className='col'>
                    {
                        selectedAppealTermObj &&
                        <>
                            {selectedAppealTermObj['description']}
                            <button className='btn btn-primary' onClick={onAddAppealTerm}>Add Appeal Term</button>
                            {
                                selectedAppealTermGenres.map(g =>
                                    <button key={'add_genre_' + g} className='btn btn-primary' onClick={() => onAddGenre(g)}>Add Genre "{g}"</button>
                                )
                            }

                        </>
                    }
                </div>
            </div>
            <div className='row'>
                <div className='col'>
                    <h4>Selected Genres</h4>

                    {
                        genres.map(g => <button key={g} onClick={() => onRemoveGenre(g)}>Remove {g}</button>)
                    }
                </div>
                <div className='col'>
                    <h4>Selected Appeal Terms</h4>

                    {
                        appealTerms.map(a => <button key={a} onClick={() => onRemoveAppealTerm(a)}>Remove {a}</button>)
                    }
                </div>
            </div>
        </>
    )
}

export default AppealTermsBrowser