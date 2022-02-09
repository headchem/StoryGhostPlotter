import React, { useState, useEffect } from 'react'

import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

//import ToDoHome from './components/todo/ToDoHome'
import PlotHome from './components/plotter/plot/PlotHome'
import Header from './components/Header'
import Footer from './components/Footer'
import About from './components/About'
import Admin from './components/Admin'
import UserHome from './components/plotter/user/UserHome'

import * as PromptArea from './util/PromptArea'

function App() {

    const [sequences, setSequences] = useState(
        [
            {
                sequenceName: 'Opening Image',
                text: '',
                isLocked: false,
                isReadOnly: false,
                allowed: ['Opening Image']
            }
        ]
    )

    const updateSequenceText = (sequenceName, text) => {
        setSequences(
            sequences.map(
                (sequence) => sequence.sequenceName === sequenceName ? { ...sequence, text: text } : sequence
            )
        )
    }

    const updateSequenceName = (sequenceName, newSequenceName) => {
        setSequences(
            sequences.map(
                (sequence) => sequence.sequenceName === sequenceName ? { ...sequence, sequenceName: newSequenceName } : sequence
            )
        )
    }

    // given all the existing sequences, choose the approporiate next sequence name. For example, if we already have [Opening Image, Theme Stated] then the best next sequence would be 'Setup'
    const getNewSequenceName = (existingSequences) => {
        const curSequenceName = existingSequences.at(-1).sequenceName

        return getAllowedNextSequenceNames(curSequenceName, existingSequences)[0]
    }

    // given all the existing sequences, choose the allowed next sequences. For example, if we already have [Opening Image] then the allowed next sequences can only be [Setup, Theme Stated]. If we start with [Opening Image, Setup] then the only allowed next sequences are [Theme Stated, Catalyst]
    const getAllowedNextSequenceNames = (curSequenceName, existingSequences) => {
        const existingSequenceNames = new Set(existingSequences.map((seq) => seq.sequenceName))
        let allowedSequenceNames = []

        switch (curSequenceName) {
            case 'Opening Image':
                allowedSequenceNames = ['Setup', 'Theme Stated']
                break;
            case 'Setup':
                allowedSequenceNames = ['Theme Stated', 'Catalyst']
                break;
            case 'Theme Stated':
                allowedSequenceNames = ['Setup', 'Setup (Continued)', 'B Story', 'Catalyst', 'Debate (Continued)']
                break;
            case 'Setup (Continued)':
                allowedSequenceNames = ['Catalyst']
                break;
            case 'Catalyst':
                allowedSequenceNames = ['B Story', 'Debate', 'Theme Stated']
                break;
            case 'Debate':
                allowedSequenceNames = ['Break Into Two', 'B Story', 'Theme Stated']
                break;
            case 'B Story':
                allowedSequenceNames = ['Theme Stated', 'Debate', 'Setup', 'Setup (Continued)', 'Fun And Games', 'Break Into Two']
                break;
            case 'Debate (Continued)':
                allowedSequenceNames = ['Break Into Two']
                break;
            case 'Break Into Two':
                allowedSequenceNames = ['Fun And Games', 'B Story']
                break;
            case 'Fun And Games':
                allowedSequenceNames = ['Midpoint', 'First Pinch Point']
                break;
            case 'First Pinch Point':
                allowedSequenceNames = ['Midpoint']
                break;
            case 'Midpoint':
                allowedSequenceNames = ['Bad Guys Close In']
                break;
            case 'Bad Guys Close In':
                allowedSequenceNames = ['All Hope Is Lost', 'Second Pinch Point']
                break;
            case 'Second Pinch Point':
                allowedSequenceNames = ['All Hope Is Lost']
                break;
            case 'All Hope Is Lost':
                allowedSequenceNames = ['Dark Night Of The Soul']
                break;
            case 'Dark Night Of The Soul':
                allowedSequenceNames = ['Break Into Three']
                break;
            case 'Break Into Three':
                allowedSequenceNames = ['Climax']
                break;
            case 'Climax':
                allowedSequenceNames = ['Cooldown']
                break;
            case 'Cooldown':
                allowedSequenceNames = []
                break;
            default:
                console.error('unhandled fallthrough case for allowed next sequences');
        }

        // filter out '___ (Continued)' entries if the original hasn't been used yet
        if (!existingSequenceNames.has('Setup')) {
            allowedSequenceNames = allowedSequenceNames.filter(seqName => seqName !== 'Setup (Continued)')
        }
        if (!existingSequenceNames.has('Debate')) {
            allowedSequenceNames = allowedSequenceNames.filter(seqName => seqName !== 'Debate (Continued)')
        }

        allowedSequenceNames = allowedSequenceNames.filter(seqName => !existingSequenceNames.has(seqName))

        return allowedSequenceNames;
    }

    // IMPORTANT! When updating properties in sequences, you MUST update all of the properties in a single call to setSequences. If you do then one after the other, some changes will get overridden because the update is asynchronous and it starts from the same unaltered state as the baseline before making the property change. That baseline probably hasn't been updated if you call setSequences(firstChange) then setSequences(secondChange) one after the other
    const moveToNextSequence = (curSequenceName) => {
        const allowedNext = getAllowedNextSequenceNames(curSequenceName, sequences)

        const newSequence = {
            sequenceName: getNewSequenceName(sequences),
            text: '',
            isLocked: false,
            isReadOnly: false,
            allowed: allowedNext
        }

        let newSequences = sequences.map(
            (sequence) => sequence.sequenceName === curSequenceName ? { ...sequence, isLocked: true, isReadOnly: false } : { ...sequence, isReadOnly: true }
        )

        newSequences.push(newSequence)

        setSequences(
            newSequences
        )
    }

    const moveToPrevSequence = (curSequenceName) => {
        let newSequences = sequences.map(
            (sequence) => sequence.sequenceName === curSequenceName ? { ...sequence, isLocked: false, isReadOnly: false } : sequence
        )

        newSequences = newSequences.filter((sequence) => sequence.sequenceName !== sequences.at(-1).sequenceName)

        if (newSequences.length > 1) {
            newSequences.at(-2).isReadOnly = false
        } else {
            newSequences.at(-1).isReadOnly = false
        }

        setSequences(newSequences)
    }

    const [userInfo, setUserInfo] = useState();

    useEffect(() => {
        (async () => {
            setUserInfo(await getUserInfo());
        })();
    }, []);

    async function getUserInfo() {
        try {
            const response = await fetch('/.auth/me');
            const payload = await response.json();
            console.log(payload);
            const { clientPrincipal } = payload;
            return clientPrincipal;
        } catch (error) {
            console.error('No profile could be found');
            return undefined;
        }
    }

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
                url = '/api/LogLine/GenreDescription?genre=' + genre
            } else if (curFocusElName === 'problem template' && problemTemplate !== '') {
                url = '/api/LogLine/ProblemTemplateDescription?problemTemplate=' + problemTemplate
            } else if (curFocusElName === 'hero archetype' && heroArchetype !== '') {
                url = '/api/LogLine/ArchetypeDescription?archetype=' + heroArchetype
            } else if (curFocusElName === 'enemy archetype' && enemyArchetype !== '') {
                url = '/api/LogLine/ArchetypeDescription?archetype=' + enemyArchetype
            } else if (curFocusElName === 'primal stakes' && primalStakes !== '') {
                url = '/api/LogLine/PrimalStakesDescription?primalStakes=' + primalStakes
            } else if (curFocusElName === 'dramatic question' && dramaticQuestion !== '') {
                url = '/api/LogLine/DramaticQuestionDescription?dramaticQuestion=' + dramaticQuestion
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



    // const onGenreChange = (inputValue, { action, prevInputValue }) => { // optional method signature if we ever need the previous value from the dropdown
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
            <Header userInfo={userInfo} />

            <main className="flex-shrink-0 mt-5">
                <div className="container mt-5">
                    {/* A <Routes> looks through its children <Route>s and renders the first one that matches the current URL. */}
                    <Routes>
                        <Route path="/" element={<About />} />
                        <Route path="/plots" element={
                            <>
                                {userInfo &&
                                    <>
                                        <UserHome userInfo={userInfo} />
                                    </>
                                }
                                {
                                    !userInfo &&
                                    <>
                                        <p>You must log in to access your plots</p>
                                    </>
                                }

                            </>
                        } />
                        <Route path="/plot" element={
                            <>
                                {userInfo && (
                                    <>
                                        <PlotHome
                                            userInfo={userInfo}
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

                                            sequences={sequences}

                                            //addSequence={addSequence}
                                            //deleteSequence={deleteSequence}
                                            updateSequenceText={updateSequenceText}
                                            //updateSequenceLocked={updateSequenceLocked}
                                            updateSequenceName={updateSequenceName}
                                            moveToNextSequence={moveToNextSequence}
                                            moveToPrevSequence={moveToPrevSequence}
                                        />
                                    </>
                                )}
                                {
                                    !userInfo &&
                                    <>
                                        <p>You must log in to access this page</p>
                                    </>
                                }
                            </>

                        } />
                        {/* <Route path="/todo" element={<ToDoHome />} /> */}

                        {userInfo && userInfo.userRoles.includes('admin') &&
                            <Route path="/admin" element={<Admin />} />
                        }
                    </Routes>
                </div>
            </main>
            <Footer />
        </Router>
    )

}

export default App;