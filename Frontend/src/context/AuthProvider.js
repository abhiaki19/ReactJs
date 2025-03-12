import React, { createContext, useEffect, useState } from "react";

export const AuthContext = createContext();

export const AuthContextProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [isAuthenticated, setIsAuthenticated] = useState(false);

     useEffect(() => {
        const userData = localStorage.getItem('userData');
        if (userData) {
            setUser(JSON.parse(userData));
            setIsAuthenticated(true);
        }
     }, [])

    const login = (userData) => {
        localStorage.setItem('userData', JSON.stringify(userData))
        // Authenticate user and set user information and authentication status
        setUser(userData);
        setIsAuthenticated(true);
    };

    const logout = () => {
        // Remove user information and set authentication status to false
        setUser(null);
        setIsAuthenticated(false);
        localStorage.removeItem('userData');
    };

    const getCurrentUser = () => {
        // Get current user information
        return JSON.parse(localStorage.getItem('userData'));
    }

    return (
        <AuthContext.Provider value={{ user, isAuthenticated, getCurrentUser, login, logout }}>
            {children}
        </AuthContext.Provider>
    );
};
