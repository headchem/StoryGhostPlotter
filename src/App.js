import React, { useState, useEffect } from 'react'
import Header from './components/Header'
import Tasks from './components/Tasks'
import AddTask from './components/AddTask'

function App() {
  const [showAddTask, setShowAddTask] = useState(false)

  // here we define the 'tasks' var as well as the function for modifying it
  const [tasks, setTasks] = useState( // contents is the default value for this state
    [
      {
        id: 1,
        text: 'study',
        day: 'Dec 18th at 2:30pm',
        reminder: true
      },
      {
        id: 2,
        text: 'code',
        day: 'Dec 19th at 2:30pm',
        reminder: true
      },
      {
        id: 3,
        text: 'groceries',
        day: 'Dec 20th at 2:30pm',
        reminder: false
      }
    ]
  )

  // Add Task
  const addTask = (task) => {
    const newId = Math.floor(Math.random() * 100000) + 1

    const newTask = { id: newId, ...task } // copy existing task, but add the new id field

    setTasks([...tasks, newTask]) // set tasks to all the existing tasks, plus add the new one
  }

  // Delete Task
  const deleteTask = (id) => {
    console.log('delete: ', id)
    setTasks(tasks.filter((task) => task.id !== id))
  }

  // Toggle Reminder
  const toggleReminder = (id) => {
    console.log('toggle reminder: ' + id)
    setTasks(
      tasks.map(
        (task) => task.id === id ? { ...task, reminder: !task.reminder } : task
      )
    )
  }

  return (
    <div className='container'>
      <Header title="My Tasks" onAdd={() => setShowAddTask(!showAddTask)} showAdd={showAddTask} />
      { // shorthand for a boolean ternary where true shows the element, false outputs nothing
        showAddTask && <AddTask onAdd={addTask} />
      }
      {
        tasks.length > 0 ? (
          <Tasks tasks={tasks} onDelete={deleteTask} onToggle={toggleReminder} />
        ) : <p>No Tasks to show</p>
      }

    </div>
  )
}

// function App() {
//   const [data, setData] = useState('');

//   useEffect(() => {
//     (async function () {
//       const text = await( await fetch(`/api/MyWebservice`)).text();//.json();
//       //const text = 'testing123';
//       console.log('text was: ' + text);
//       console.log('React version: ' + React.version);
//       setData('React version: ' + React.version + 'testing...' + text);
//     })();
//   });

//   return <div>
//     <h1>Hello</h1>
//     {data}
//     </div>;
// }

export default App;