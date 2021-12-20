import Select, { components } from 'react-select'
import CreatableSelect from 'react-select/creatable';
const Placeholder = (props) => {
    return <components.Placeholder {...props} />;
};

const LogLineSelect = ({ width, isMultiSelect, onFocusChange, placeholder, options, value, onChange }) => {
    return (
        <div className='logLineSelect' style={{ width: width }} onFocus={onFocusChange}>
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
                    />
                    :
                    <CreatableSelect
                        isMulti
                        menuPlacement="auto"
                        menuPosition="fixed"
                        components={{ Placeholder }}
                        placeholder={placeholder}
                        defaultValue={value.map(keyword => ({ 'label': keyword, 'value': keyword }))}
                        onChange={onChange}
                    />
            }
        </div>
    )
}

export default LogLineSelect