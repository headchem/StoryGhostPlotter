import React, { useState } from 'react'

const AppealTermsBrowser = (
    {
        genres,
        setGenres,
        genreOptions,
        appealTermsOptions,
        appealTerms,
        setAppealTerms,
    }
) => {

    const [showBrowser, setShowBrowser] = useState(false)

    const [selectedGenre, setSelectedGenre] = useState('')
    const [selectedCategory, setSelectedCategory] = useState('')
    const [selectedAppealTerm, setSelectedAppealTerm] = useState('')

    // any appeal term with more than x genres will be put into a special catch-all genre
    const catchAllGenreName = 'common and multi-genre'
    const multiGenreThreshold = 4
    const appealTermsOptionsModified = appealTermsOptions.map((a) => {
        if (a['genres'].length >= multiGenreThreshold) {
            a['genres'] = [catchAllGenreName].concat(a['genres'])
        }

        return a
    })

    const allGenresWithDupes = appealTermsOptionsModified.map(a => a['genres']).flat()
    const allGenres = [catchAllGenreName].concat([...new Set([...allGenresWithDupes.filter(g => g !== catchAllGenreName).filter(g => g !== '')].sort())])

    const onSelectGenre = (g) => {
        setSelectedGenre(g)
        setSelectedCategory('')
        setSelectedAppealTerm('')
    }

    const allGenresListItems = allGenres.map((g) => <li key={g} className={g === selectedGenre ? 'fw-bold' : ''}>
        <span onClick={() => onSelectGenre(g)}>{g}</span>
    </li>)

    const appealTermsOptionsForGenre = appealTermsOptionsModified.filter(a => a['genres'].includes(selectedGenre) && (selectedGenre !== catchAllGenreName ? !a['genres'].includes(catchAllGenreName) : true))

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

    const selectedAppealTermObj = appealTermsOptionsModified.filter(a => a['value'] === selectedAppealTerm)[0]

    const selectedAppealTermGenres = !selectedAppealTermObj ? [] : selectedAppealTermObj['genres'].filter(g => g !== catchAllGenreName)

    const onAddAppealTerm = () => {
        const newAppealTermsWithDupes = !appealTerms ? [selectedAppealTermObj['value']] : [...appealTerms, selectedAppealTermObj['value']]
        const newAppealTerms = [...new Set(newAppealTermsWithDupes)]

        setAppealTerms(newAppealTerms)
    }

    const onAddGenre = (curGenre) => {
        const newGenresWithDupes = !genres ? [curGenre] : genres.concat(curGenre)
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

    const getRandomInt = (min, max) => {
        min = Math.ceil(min);
        max = Math.floor(max);
        return Math.floor(Math.random() * (max - min) + min); // The maximum is exclusive and the minimum is inclusive
    }

    const shuffleArray = (array) => {
        const cloned = structuredClone(array)

        for (let i = cloned.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [cloned[i], cloned[j]] = [cloned[j], cloned[i]];
        }

        return cloned
    }

    const selectRandomAppealTerms = () => {
        // select 2-3 appeal terms across all genres
        // create list of genres present in selected appeal terms
        // select 2-3 genres to add from list

        const numAppealTerms = getRandomInt(2, 4)

        const shuffledArray = shuffleArray(appealTermsOptions)

        const randomAppealTerms = shuffledArray.slice(0, numAppealTerms);

        const genresWithDupes = randomAppealTerms.map(a => {
            return a['genres']
        }).flat().filter(g => g !== catchAllGenreName)

        const genresPresent = [...new Set(genresWithDupes)]

        const shuffledGenres = shuffleArray(genresPresent)

        const numGenres = getRandomInt(2, 4)

        const randomGenres = shuffledGenres.slice(0, numGenres)

        const newAppealTerms = randomAppealTerms.map(a => a['value'])

        setAppealTerms(newAppealTerms)
        setGenres(randomGenres)
    }

    return (
        <>
            <div className='row'>
                <div className='col'>
                    <button className='btn btn-primary' onClick={() => selectRandomAppealTerms()}>Randomize</button>
                    <button className='btn btn-link' onClick={() => setShowBrowser(!showBrowser)}>
                        {
                            showBrowser === true &&
                            <span>hide appeal terms browser</span>
                        }
                        {
                            showBrowser === false &&
                            <span>show appeal terms browser</span>
                        }
                    </button>
                </div>
            </div>
            <div className='row'>
                <div className='col'>
                    <h4>Selected Genres</h4>
                    {
                        genres.map(g => <button className='btn btn-secondary m-2' key={g} onClick={() => onRemoveGenre(g)}>Remove {g}</button>)
                    }
                    {/* <ul>
                        {
                            genres.map(g => <li key={g}>{genreOptions.filter(curGenre => curGenre['value'] === g)[0]['description']}</li>)
                        }
                    </ul> */}
                </div>
                <div className='col'>
                    <h4>Selected Appeal Terms</h4>

                    {
                        appealTerms && appealTerms.map(a => <button className='btn btn-secondary m-2' key={a} onClick={() => onRemoveAppealTerm(a)}>Remove {a}</button>)
                    }

                    <ul>
                        {
                            appealTerms && appealTerms.map(a => <li key={a}>{appealTermsOptions.filter(curAppealTerm => curAppealTerm['value'] === a)[0]['description']}</li>)
                        }
                    </ul>
                </div>
            </div>
            {
                showBrowser === true &&
                <div className='row'>
                    <div className='col'>
                        {/* <p>selected genre: {selectedGenre}</p> */}
                        <p className='text-muted'>TODO: search appeal terms by keywords/alias</p>
                        <ul>
                            {allGenresListItems}
                        </ul>
                    </div>
                    <div className='col'>
                        {/* <p>selected category: {selectedCategory}</p> */}
                        <ul>
                            {allGenreCategoriesListItems}
                        </ul>
                    </div>
                    <div className='col'>
                        {/* <p>selected appeal term: {selectedAppealTerm}</p> */}
                        <ul>
                            {allGenreCategoryAppealTermsListItems}
                        </ul>
                    </div>
                    <div className='col'>
                        {
                            selectedAppealTermObj &&
                            <>
                                <h3>{selectedAppealTermObj['value']}</h3>
                                {selectedAppealTermObj['description']}
                                <p className='text-muted'>TODO: similar appeal terms (by vector) to currently selected.</p>
                                <button className='btn btn-primary m-3' onClick={onAddAppealTerm}>Add Appeal Term "{selectedAppealTermObj['value']}"</button>
                                <hr />
                                {
                                    selectedAppealTermGenres.map(g =>
                                        <button key={'add_genre_' + g} className='btn btn-primary m-3' onClick={() => onAddGenre(g)}>Add Genre "{g}"</button>
                                    )
                                }
                            </>
                        }
                    </div>
                </div>
            }


        </>
    )
}

export default AppealTermsBrowser