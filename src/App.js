import React, { useState } from 'react'

import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import ToDoHome from './components/todo/ToDoHome'
import Main from './components/plotter/Main'
import Header from './components/Header'
import Footer from './components/Footer'
import About from './components/About'

function App() {

    // here we define the 'tasks' var as well as the function for modifying it
    const [logLine, setLogLine] = useState( // contents is the default value for this state
        {
            curFocusElName: '',
            setting: '',
            problemTemplate: '',
            keywords: [],
            heroArchetype: '',
            enemyArchetype: '',
            primalStakes: '',
            dramaticQuestion: ''
        }
    )

    const setFocus = (elName) => {
        let newLogLine = {...logLine}
        newLogLine.curFocusElName = elName

        setLogLine(newLogLine)
    }

    // const setSetting = (inputValue, { action, prevInputValue }) => { // optional method signature if we ever need the previous value from the dropdown
    const setSetting = (inputValue) => {
        let newLogLine = { ...logLine }
        newLogLine.setting = inputValue.value
        setLogLine(newLogLine)
    }

    const setProblemTemplate = (inputValue) => {
        let newLogLine = { ...logLine }
        newLogLine.problemTemplate = inputValue.value
        setLogLine(newLogLine)
    }

    const setKeywords = (inputValue) => {
        let newLogLine = { ...logLine }
        newLogLine.keywords = inputValue.map(el => el.value)

        setLogLine(newLogLine)
    }

    const setHeroArchetype = (inputValue) => {
        let newLogLine = { ...logLine }
        newLogLine.heroArchetype = inputValue.value
        setLogLine(newLogLine)
    }

    const setEnemyArchetype = (inputValue) => {
        let newLogLine = { ...logLine }
        newLogLine.enemyArchetype = inputValue.value
        setLogLine(newLogLine)
    }

    const setPrimalStakes = (inputValue) => {
        let newLogLine = { ...logLine }
        newLogLine.primalStakes = inputValue.value
        setLogLine(newLogLine)
    }

    const setDramaticQuestion = (inputValue) => {
        let newLogLine = { ...logLine }
        newLogLine.dramaticQuestion = inputValue.value
        setLogLine(newLogLine)
    }

    

    return (
        <Router>
            <Header />

            {/* A <Routes> looks through its children <Route>s and renders the first one that matches the current URL. */}
            <Routes>
                <Route path="/" element={
                    <Main
                        logLine={logLine}
                        onFocusChange={setFocus}
                        onSettingChange={setSetting}
                        onProblemTemplateChange={setProblemTemplate}
                        onKeywordChange={setKeywords}
                        onHeroArchetypeChange={setHeroArchetype}
                        onEnemyArchetypeChange={setEnemyArchetype}
                        onPrimalStakesChange={setPrimalStakes}
                        onDramaticQuestionChange={setDramaticQuestion}
                    />
                } />
                <Route path="/about" element={<About />} />
                <Route path="/todo" element={<ToDoHome />} />
            </Routes>

            <Footer />
        </Router>
    )

}

export default App;