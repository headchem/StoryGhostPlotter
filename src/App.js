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
            genre: '',
            problemTemplate: '',
            keywords: [],
            heroArchetype: '',
            enemyArchetype: '',
            primalStakes: '',
            dramaticQuestion: '',

            descIsLoading: false,
            genreDescObj: null,
            problemTemplateDescObj: null,
            heroArchetypeDescObj: null,
            enemyArchetypeDescObj: null,
            primalStakesDescObj: null,
            dramaticQuestionDescObj: null,
        }
    )

    const setFocus = (elName) => {
        let newLogLine = { ...logLine }
        newLogLine.curFocusElName = elName

        setLogLine(newLogLine)
    }


    const loadDescObj = async (propType, newPropVal) => {
        if (newPropVal === '') return

        let newLogLine = { ...logLine }

        let url = ''

        if (propType === 'genre') {
            url = '/api/GenreDescription?genre=' + newPropVal
        } else if (propType === 'problem template') {
            url = '/api/ProblemTemplateDescription?problemTemplate=' + newPropVal
        } else if (propType === 'hero archetype' || propType === 'enemy archetype') {
            url = '/api/ArchetypeDescription?archetype=' + newPropVal
        } else if (propType === 'primal stakes') {
            url = '/api/PrimalStakesDescription?primalStakes=' + newPropVal
        } else if (propType === 'dramatic question') {
            url = '/api/DramaticQuestionDescription?dramaticQuestion=' + newPropVal
        }

        fetch(url).then(function (response) {
            if (response.ok) {
                return response.json();
            }
            return Promise.reject(response);
        }).then(function (data) {
            if (propType === 'genre') {
                newLogLine.genreDescObj = data
            } else if (propType === 'problem template') {
                newLogLine.problemTemplateDescObj = data
            } else if (propType === 'hero archetype') {
                newLogLine.heroArchetypeDescObj = data
            } else if (propType === 'enemy archetype') {
                newLogLine.enemyArchetypeDescObj = data
            } else if (propType === 'primal stakes') {
                newLogLine.primalStakesDescObj = data
            } else if (propType === 'dramatic question') {
                newLogLine.dramaticQuestionDescObj = data
            }
        }).catch(function (error) {
            console.warn(error);
        }).finally(function () {
            newLogLine.descIsLoading = false
            setLogLine(newLogLine)
        });
    }

    // const setGenre = (inputValue, { action, prevInputValue }) => { // optional method signature if we ever need the previous value from the dropdown
    const setGenre = (inputValue) => {
        let newLogLine = { ...logLine }

        newLogLine.descIsLoading = true
        newLogLine.genre = inputValue.value

        setLogLine(newLogLine)
        loadDescObj('genre', newLogLine.genre)
    }

    const setProblemTemplate = (inputValue) => {
        let newLogLine = { ...logLine }

        newLogLine.descIsLoading = true
        newLogLine.problemTemplate = inputValue.value

        setLogLine(newLogLine)
        loadDescObj('problem template', newLogLine.problemTemplate)
    }

    const setKeywords = (inputValue) => {
        let newLogLine = { ...logLine }
        newLogLine.keywords = inputValue.map(el => el.value)

        setLogLine(newLogLine)
    }

    const setHeroArchetype = (inputValue) => {
        let newLogLine = { ...logLine }

        newLogLine.descIsLoading = true
        newLogLine.heroArchetype = inputValue.value

        setLogLine(newLogLine)
        loadDescObj('hero archetype', newLogLine.heroArchetype)
    }

    const setEnemyArchetype = (inputValue) => {
        let newLogLine = { ...logLine }

        newLogLine.descIsLoading = true
        newLogLine.enemyArchetype = inputValue.value

        setLogLine(newLogLine)
        loadDescObj('enemy archetype', newLogLine.enemyArchetype)
    }

    const setPrimalStakes = (inputValue) => {
        let newLogLine = { ...logLine }

        newLogLine.descIsLoading = true
        newLogLine.primalStakes = inputValue.value

        setLogLine(newLogLine)
        loadDescObj('primal stakes', newLogLine.primalStakes)
    }

    const setDramaticQuestion = (inputValue) => {
        let newLogLine = { ...logLine }

        newLogLine.descIsLoading = true
        newLogLine.dramaticQuestion = inputValue.value

        setLogLine(newLogLine)
        loadDescObj('dramatic question', newLogLine.dramaticQuestion)
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
                        onGenreChange={setGenre}
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