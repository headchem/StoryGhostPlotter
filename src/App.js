import React, { useState, useEffect } from 'react'

import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

import ToDoHome from './components/todo/ToDoHome'
import Main from './components/plotter/Main'
import Header from './components/Header'
import Footer from './components/Footer'
import About from './components/About'
import Admin from './components/Admin'

import * as PromptArea from './util/PromptArea'

function App() {

    const [curFocusElName, setCurFocusElName] = useState('')
    const [genre, setGenre] = useState('')
    const [problemTemplate, setProblemTemplate] = useState('')
    const [keywords, setKeywords] = useState([])
    const [heroArchetype, setHeroArchetype] = useState('')
    const [enemyArchetype, setEnemyArchetype] = useState('')
    const [primalStakes, setPrimalStakes] = useState('')
    const [dramaticQuestion, setDramaticQuestion] = useState('')

    const [descIsLoading, setDescIsLoading] = useState(false)
    const [genreDescObj, setGenreDescObj] = useState(null)
    const [problemTemplateDescObj, setProblemTemplateDescObj] = useState(null)
    const [heroArchetypeDescObj, setHeroArchetypeDescObj] = useState(null)
    const [enemyArchetypeDescObj, setEnemyArchetypeDescObj] = useState(null)
    const [primalStakesDescObj, setPrimalStakesDescObj] = useState(null)
    const [dramaticQuestionDescObj, setDramaticQuestionDescObj] = useState(null)

    const [logLineIncomplete, setLogLineIncomplete] = useState(true)

    const [orphanSummaryStatus, setOrphanSummaryStatus] = useState(PromptArea.Status.UNAVAILABLE)
    const [orphanSummary, setOrphanSummary] = useState('')
    const [orphanComplete, setOrphanComplete] = useState(false)
    const [orphanFull, setOrphanFull] = useState('')

    const [wandererSummaryStatus, setWandererSummaryStatus] = useState(PromptArea.Status.UNAVAILABLE)
    const [wandererSummary, setWandererSummary] = useState('')
    const [wandererComplete, setWandererComplete] = useState(false)
    const [wandererFull, setWandererFull] = useState('')

    const [warriorSummaryStatus, setWarriorSummaryStatus] = useState(PromptArea.Status.UNAVAILABLE)
    const [warriorSummary, setWarriorSummary] = useState('')
    const [warriorComplete, setWarriorComplete] = useState(false)
    const [warriorFull, setWarriorFull] = useState('')

    const [martyrSummaryStatus, setMartyrSummaryStatus] = useState(PromptArea.Status.UNAVAILABLE)
    const [martyrSummary, setMartyrSummary] = useState('')
    const [martyrFull, setMartyrFull] = useState('')


    const onFocus = (elName) => {
        setCurFocusElName(elName)
    }

    // any time the properties we are listening to change (at the bottom of the useEffect method) we call this block
    useEffect(() => {
        
        const loadDescObj = async () => {
            let url = ''

            if (curFocusElName === 'genre' && genre !== '') {
                url = '/api/GenreDescription?genre=' + genre
            } else if (curFocusElName === 'problem template' && problemTemplate !== '') {
                url = '/api/ProblemTemplateDescription?problemTemplate=' + problemTemplate
            } else if (curFocusElName === 'hero archetype' && heroArchetype !== '') {
                url = '/api/ArchetypeDescription?archetype=' + heroArchetype
            } else if (curFocusElName === 'enemy archetype' && enemyArchetype !== '') {
                url = '/api/ArchetypeDescription?archetype=' + enemyArchetype
            } else if (curFocusElName === 'primal stakes' && primalStakes !== '') {
                url = '/api/PrimalStakesDescription?primalStakes=' + primalStakes
            } else if (curFocusElName === 'dramatic question' && dramaticQuestion !== '') {
                url = '/api/DramaticQuestionDescription?dramaticQuestion=' + dramaticQuestion
            }

            if (url !== '') {
                setDescIsLoading(true)

                fetch(url)
                .then(function (response) {
                    if (response.ok) {
                        return response.json();
                    }
                    return Promise.reject(response);
                }).then(function (data) {

                    if (curFocusElName === 'genre') {
                        setGenreDescObj(data)
                    } else if (curFocusElName === 'problem template') {
                        setProblemTemplateDescObj(data)
                    } else if (curFocusElName === 'hero archetype') {
                        setHeroArchetypeDescObj(data)
                    } else if (curFocusElName === 'enemy archetype') {
                        setEnemyArchetypeDescObj(data)
                    } else if (curFocusElName === 'primal stakes') {
                        setPrimalStakesDescObj(data)
                    } else if (curFocusElName === 'dramatic question') {
                        setDramaticQuestionDescObj(data)
                    }
                }).catch(function (error) {
                    console.warn(error);
                }).finally(function () {
                    setDescIsLoading(false)
                });
            }
        }

        const checkLogLineIsComplete = async () => {
            // if any of the Log Line fields are still incomplete, call setLogLineIncomplete(true)
            if (genre === '' || problemTemplate === '' || keywords.length === 0 || heroArchetype === '' || enemyArchetype === '' || primalStakes === '' || dramaticQuestion === '') {
                setLogLineIncomplete(true)
                return
            }

            setLogLineIncomplete(false)
            setOrphanSummaryStatus(PromptArea.Status.AVAILABLE)
        }

        loadDescObj()
        checkLogLineIsComplete()
        // even though we use 'curFocusElName' in this method, we don't want to trigger reloading whenever it changes, hence the linter hint below to get this to build in prod...
        // eslint-disable-next-line react-hooks/exhaustive-deps
    }, [genre, problemTemplate, keywords, heroArchetype, enemyArchetype, primalStakes, dramaticQuestion]);



    // const setGenre = (inputValue, { action, prevInputValue }) => { // optional method signature if we ever need the previous value from the dropdown
    const onGenreChange = (inputValue) => {
        setGenre(inputValue.value)
    }

    const onProblemTemplateChange = (inputValue) => {
        setProblemTemplate(inputValue.value)
    }

    const onKeywordsChange = (inputValue) => {
        setKeywords(inputValue.map(el => el.value))
    }

    const onHeroArchetypeChange = (inputValue) => {
        setHeroArchetype(inputValue.value)
    }

    const onEnemyArchetypeChange = (inputValue) => {
        setEnemyArchetype(inputValue.value)
    }

    const onPrimalStakesChange = (inputValue) => {
        setPrimalStakes(inputValue.value)
    }

    const onDramaticQuestionChange = (inputValue) => {
        setDramaticQuestion(inputValue.value)
    }



    return (
        <Router>
            <Header />

            <main className="flex-shrink-0 mt-5">
                <div className="container mt-5">
                    {/* A <Routes> looks through its children <Route>s and renders the first one that matches the current URL. */}
                    <Routes>
                        <Route path="/" element={
                            <Main
                                genre={genre}
                                problemTemplate={problemTemplate}
                                keywords={keywords}
                                heroArchetype={heroArchetype}
                                enemyArchetype={enemyArchetype}
                                primalStakes={primalStakes}
                                dramaticQuestion={dramaticQuestion}

                                curFocusElName={curFocusElName}

                                onFocusChange={onFocus}
                                onGenreChange={onGenreChange}
                                onProblemTemplateChange={onProblemTemplateChange}
                                onKeywordChange={onKeywordsChange}
                                onHeroArchetypeChange={onHeroArchetypeChange}
                                onEnemyArchetypeChange={onEnemyArchetypeChange}
                                onPrimalStakesChange={onPrimalStakesChange}
                                onDramaticQuestionChange={onDramaticQuestionChange}

                                descIsLoading={descIsLoading}
                                genreDescObj={genreDescObj}
                                problemTemplateDescObj={problemTemplateDescObj}
                                heroArchetypeDescObj={heroArchetypeDescObj}
                                enemyArchetypeDescObj={enemyArchetypeDescObj}
                                primalStakesDescObj={primalStakesDescObj}
                                dramaticQuestionDescObj={dramaticQuestionDescObj}

                                logLineIncomplete={logLineIncomplete}

                                orphanSummaryStatus={orphanSummaryStatus}
                                orphanSummary={orphanSummary}
                                setOrphanSummary={setOrphanSummary}
                                orphanFull={orphanFull}
                                setOrphanFull={setOrphanFull}

                                wandererSummaryStatus={wandererSummaryStatus}
                                setWandererSummaryStatus={setWandererSummaryStatus}
                                wandererSummary={wandererSummary}
                                setWandererSummary={setWandererSummary}
                                wandererFull={wandererFull}
                                setWandererFull={setWandererFull}
                                orphanComplete={orphanComplete}
                                setOrphanComplete={setOrphanComplete}

                                warriorSummaryStatus={warriorSummaryStatus}
                                setWarriorSummaryStatus={setWarriorSummaryStatus}
                                warriorSummary={warriorSummary}
                                setWarriorSummary={setWarriorSummary}
                                warriorFull={warriorFull}
                                setWarriorFull={setWarriorFull}
                                wandererComplete={wandererComplete}
                                setWandererComplete={setWandererComplete}

                                martyrSummaryStatus={martyrSummaryStatus}
                                setMartyrSummaryStatus={setMartyrSummaryStatus}
                                martyrSummary={martyrSummary}
                                setMartyrSummary={setMartyrSummary}
                                martyrFull={martyrFull}
                                setMartyrFull={setMartyrFull}
                                warriorComplete={warriorComplete}
                                setWarriorComplete={setWarriorComplete}
                            />
                        } />
                        <Route path="/about" element={<About />} />
                        <Route path="/todo" element={<ToDoHome />} />
                        <Route path="/admin" element={<Admin />} />
                    </Routes>
                </div>
            </main>
            <Footer />
        </Router>
    )

}

export default App;