import { useState } from 'react'

const AddTask = ({ onAdd }) => {
    const [text, setText] = useState('')
    const [day, setDay] = useState('')
    const [reminder, setReminder] = useState(false)

    const onSubmit = (e) => {
        e.preventDefault() // don't submit the page

        if (!text) {
            alert('Please add a task')
            return
        }

        if (!day) {
            alert('Please add a day')
            return
        }

        onAdd({text, day, reminder})

        // clear state in this component to reset for next use
        setText('')
        setDay('')
        setReminder(false)
    }

    return (
        <form onSubmit={onSubmit}>
            <div>
                <label>Task</label>
                <input
                    type="text"
                    placeholder="Add Task"
                    value={text}
                    onChange={(e) => setText(e.target.value)}
                />
            </div>
            <div>
                <label>Day & Time</label>
                <input type="text" placeholder="Day" value={day} onChange={(e) => setDay(e.target.value)} />
            </div>
            <div>
                <label>Set Reminder</label>
                <input type="checkbox" checked={reminder} value={reminder} onChange={(e) => setReminder(e.currentTarget.checked)} />
            </div>
            <input type="submit" value="Save Task" />
        </form>
    )
}

export default AddTask
