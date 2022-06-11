import Select, { components } from 'react-select'
import CreatableSelect from 'react-select/creatable';
const Placeholder = (props) => {
    return <components.Placeholder {...props} />;
};

const LogLineSelect = (
    {
        selectTheme,
        width,
        isMultiSelect,
        onFocusChange,
        placeholder,
        options,
        value,
        onChange
    }
) => {

    const multiValues = !value ? null : value.map(keyword => ({ 'label': keyword, 'value': keyword }))

    return (
        <div className='logLineSelectMulti' style={{ width: width }} onFocus={onFocusChange}>
            {
                isMultiSelect === false ?
                    <Select
                        menuPlacement="auto"
                        menuPosition="fixed"
                        components={{ Placeholder }}
                        placeholder={placeholder}
                        options={options}
                        defaultInputValue={value}
                        onChange={onChange}
                        theme={selectTheme}
                    />
                    :
                    <CreatableSelect
                        isMulti
                        menuPlacement="auto"
                        menuPosition="fixed"
                        components={{ Placeholder }}
                        placeholder={placeholder}
                        defaultValue={multiValues}
                        value={multiValues}
                        onChange={onChange}
                        theme={selectTheme}
                    />
            }
        </div>
    )
}

export default LogLineSelect