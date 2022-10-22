import React, { useState } from 'react'

const AppealTermsBrowser = (
    {
        genres,
        setGenres,
        appealTermsOptions,
        appealTerms,
        onAppealTermsChange,
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

    const allGenresListItems = allGenres.map((g) => <li key={g}>
        <span onClick={() => onSelectGenre(g)}>{g}</span>
    </li>)

    const appealTermsOptionsForGenre = appealTermsOptions.filter(a => a['genres'].includes(selectedGenre))

    const allGenreCategoriesWithDupes = appealTermsOptionsForGenre.map(a => a['categories']).flat()
    const allGenreCategories = [...new Set(allGenreCategoriesWithDupes)].filter(c => c !== '').sort()

    const onSelectCategory = (c) => {
        setSelectedCategory(c)
        setSelectedAppealTerm('')
    }

    const allGenreCategoriesListItems = allGenreCategories.map((c) => <li key={c}>
        <span onClick={() => onSelectCategory(c)}>{c}</span>
    </li>)

    //const allGenreCategoriesAppealTerms = ['Historical20thCentury', 'BuffoonDetective'] // TODO: filter based on all appeal terms within the current selected genre category
    const appealTermsOptionsForGenreAndCategory = appealTermsOptionsForGenre.filter(a => a['categories'].includes(selectedCategory))
    const allGenreCategoriesAppealTerms = appealTermsOptionsForGenreAndCategory.map(a => a['value']).sort()

    const allGenreCategoryAppealTermsListItems = allGenreCategoriesAppealTerms.map((a) => <li key={a}>
        <span onClick={() => setSelectedAppealTerm(a)}>{a}</span>
    </li>)

    const selectedAppealTermObj = appealTermsOptions.filter(a => a['value'] === selectedAppealTerm)[0]

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
                        </>
                    }
                </div>
            </div>
        </>
    )
}

export default AppealTermsBrowser