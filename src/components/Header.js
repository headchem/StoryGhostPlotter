import React from 'react';
import { Link } from "react-router-dom";

const Header = ({ userInfo }) => {
    //const providers = ['twitter', 'github', 'aad'];
    //const providers = ['aad'];
    const providers = { 'aad': 'Microsoft' }
    const redirect = window.location.pathname;


    return (
        <header>
            <nav className="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
                <div className="container-fluid">
                    <Link className="navbar-brand" to="/">Story Ghost</Link>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarCollapse">
                        <ul className="navbar-nav me-auto mb-2 mb-md-0">
                            <li className="nav-item">
                                <Link className="nav-link" to="/">Home</Link>
                            </li>
                            <li className="nav-item">
                                <Link className="nav-link" to="/plots">My Plots</Link>
                            </li>
                            {
                                userInfo && userInfo.userRoles.includes('admin') &&
                                <li className="nav-item">
                                    <Link className="nav-link" to="/admin">Admin</Link>
                                </li>
                            }

                            {
                                !userInfo &&
                                <div className="dropdown">
                                    <button className="btn btn-secondary dropdown-toggle" type="button" id="dropdownMenuButtonAuth" data-bs-toggle="dropdown" aria-expanded="false">
                                        Log In
                                    </button>
                                    <ul className="dropdown-menu" aria-labelledby="dropdownMenuButtonAuth">
                                        {
                                            Object.keys(providers).map((providerKey) => (
                                                <li key={providerKey}>
                                                    <a className="dropdown-item" href={`/.auth/login/${providerKey}?post_login_redirect_uri=${redirect}`}>
                                                        {providers[providerKey]}
                                                    </a>
                                                </li>
                                            ))}
                                    </ul>
                                </div>
                            }
                            {
                                userInfo &&
                                <li className="nav-item">
                                    <a className="nav-link" href={`/.auth/logout?post_logout_redirect_uri=${redirect}`}>Logout {userInfo.userDetails}</a>
                                </li>
                            }


                        </ul>
                    </div>
                </div>
            </nav>
        </header >
    )
}

export default Header