import React from 'react'
//import Select from 'react-select';
//import { selectDarkTheme, selectLightTheme } from '../../../../util/SelectTheme'

const AppealTerms = (
    {
        genres,
        appealTermsOptions,
        appealTerms,
        onAppealTermsChange,
        mode
    }
) => {

    //const filteredAppealTermsOptions = appealTermsOptions.filter(opt => opt.genres.indexOf('general') > -1 || genres.some(g => opt.genres.includes(g)))
    //    .map(function (x) {
    //        return { value: x.value, label: '(' + x.genres.sort().join(', ') + ') ' + x.label + ' - ' + x.description, genres: x.genres, categories: x.categories }
    //    }).sort((a, b) => (a.label > b.label) ? 1 : -1)

    return (
        <>
            <div style={{ width: '100%' }}>
                {/* <Select
                    defaultValue={appealTermsOptions.filter(o => appealTerms && appealTerms.indexOf(o.value) > -1)}
                    isMulti
                    name="appealTerms"
                    options={filteredAppealTermsOptions}
                    className="appeal-terms-multi-select"
                    classNamePrefix="select"
                    onChange={onAppealTermsChange}
                    theme={mode === 'dark' ? selectDarkTheme : selectLightTheme}
                /> */}
                <p>{appealTerms && appealTerms.join(', ')}</p>
            </div>
        </>
    )
}

export default AppealTerms