import React, { useState, useEffect } from 'react'

import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

//import ToDoHome from './components/todo/ToDoHome'
import PlotHome from './components/plotter/plot/PlotHome'
import PlotView from './components/plotter/plot/PlotView'
import Header from './components/Header'
import Footer from './components/Footer'
import About from './components/About'
import Admin from './components/Admin'
import UserHome from './components/plotter/user/UserHome'

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
                                {userInfo &&
                                    <PlotHome
                                        userInfo={userInfo}
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