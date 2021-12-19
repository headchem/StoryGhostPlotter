import PropTypes from 'prop-types'
import Button from './Button'

//const Header = (props) => {
const Header = ({ title, onAdd, showAdd }) => { // destructure props into named vars this way
    
    return (
        <header>
            <h1 style={headingStyle}>{title}</h1>
            <Button text={showAdd ? 'Close' : 'Add'} color={showAdd ? 'red' : 'green'} onClick={onAdd} />
        </header>
    )
}

Header.defaultProps = {
    title: 'no title prop was specified'
}

Header.propTypes = {
    //title: PropTypes.string // example of not required
    title: PropTypes.string.isRequired
}

const headingStyle = {
    color: 'Teal',
    backgroundColor: 'LightSteelBlue'
}

export default Header