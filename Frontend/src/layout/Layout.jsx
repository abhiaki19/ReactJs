import { Outlet } from "react-router-dom";
import Footer from "./Footer";
import Header from "./Header"; 
import { AuthContextProvider } from "../context/AuthProvider";

function Layout() {
    return (
        <div className="min-h-full flex flex-col h-screen justify-between">
            <AuthContextProvider>
            <Header />
            <main className="mb-20  mb-auto h-10">
                <Outlet />
            </main>
            <Footer />
            </AuthContextProvider>
        </div>
    );
}

export default Layout;