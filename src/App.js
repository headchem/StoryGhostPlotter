import React, { useState, useEffect } from 'react'

import { BrowserRouter as Router, Routes, Route } from "react-router-dom";
import { ToastContainer } from 'react-toastify';

import PlotHome from './components/plotter/plot/PlotHome'
import PlotView from './components/plotter/plot/PlotView'
import Header from './components/Header'
import Footer from './components/Footer'
import About from './components/About'
import Admin from './components/Admin'
import UserHome from './components/plotter/user/UserHome'

import 'react-toastify/dist/ReactToastify.css';

function App() {

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
            const { clientPrincipal } = payload;
            return clientPrincipal;
        } catch (error) {
            console.error('No profile could be found');
            return undefined;
        }
    }

    const [mode, setMode] = useState(() => {
        const initialState = window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches ? "dark" : "light"
        return initialState;
    });

    useEffect(() => {
        const modeMe = (e) => {
            setMode(e.matches ? "dark" : "light");
        }
        window.matchMedia('(prefers-color-scheme: dark)').addEventListener('change', modeMe);
        return window.matchMedia('(prefers-color-scheme: dark)').removeEventListener('change', modeMe);
    }, []);


    return (
        <Router>
            <div className="d-none d-md-block">
                <ToastContainer
                    theme={mode}
                    style={{ width: "250px" }}
                />
            </div>

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
                                {userInfo &&
                                    <PlotHome
                                        userInfo={userInfo}
                                        mode={mode}
                                    />
                                }
                                {
                                    !userInfo &&
                                    <>
                                        <p>You must log in to access this page</p>
                                    </>
                                }
                            </>

                        } />
                        <Route path="/view" element={
                            <>
                                <PlotView userInfo={userInfo} />
                            </>

                        } />

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