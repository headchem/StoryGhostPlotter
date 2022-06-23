import React from 'react'
import LogLineSelect from '../LogLineSelect'
import { selectDarkTheme, selectLightTheme } from '../../../../util/SelectTheme'

const Keywords = (
    {
        keywords,
        onKeywordsChange,
        //onFocusChange,
        mode
    }
) => {

    return (
        <div style={{ width: '100%' }}>
            <LogLineSelect
                selectTheme={mode === 'dark' ? selectDarkTheme : selectLightTheme}
                placeholder='Keywords'
                isMultiSelect={true}
                //onFocusChange={() => onFocusChange('keywords')}
                value={keywords}
                onChange={onKeywordsChange}
            />
        </div>
    )
}

export default Keywords