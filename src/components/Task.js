import { FaTimes } from 'react-icons/fa'

const Task = ({ task, onDelete, onToggle }) => {
    return (
        <div
            className={`task ${task.reminder ? 'reminder' : ''}`} // dynamically add a class with a ternary expression
            style={task.reminder === true ? { border: '1px solid red' } : {}} // dynamically add inline style with ternary expression
            onDoubleClick={() => onToggle(task.id)}
        >
            <h3>{task.text} <FaTimes onClick={() => onDelete(task.id)} style={{ color: 'red', cursor: 'pointer' }} /></h3>
            <p>{task.day}</p>
        </div>
    )
}

export default Task
