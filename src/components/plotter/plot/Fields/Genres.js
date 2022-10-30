import React from 'react'
//import Select from 'react-select';
//import { selectDarkTheme, selectLightTheme } from '../../../../util/SelectTheme'

const Genres = (
    {
        genreOptions,
        genres,
        onGenresChange,
        mode
    }
) => {

    return (
        <>
        {
            // <div style={{ width: '100%' }}>
            //     <Select
            //         defaultValue={genreOptions.filter(o => genres && genres.indexOf(o.value) > -1)}
            //         isMulti
            //         name="genres"
            //         options={genreOptions}
            //         className="genres-multi-select"
            //         classNamePrefix="select"
            //         onChange={onGenresChange}
            //         theme={mode === 'dark' ? selectDarkTheme : selectLightTheme}
            //     />
            // </div>
        }
        <p>{genres.join(', ')}</p>
        </>
    )
}

export default Genres