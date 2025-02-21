import { Outlet } from "react-router-dom";
import Footer from "./Footer";
import Header from "./Header";

function Layout() {
    return (
        <div class="min-h-full flex flex-col h-screen justify-between">
            <Header /> 
            <main class="mb-20  mb-auto h-10"> 
                <Outlet /> 
            </main>
         <Footer /> 

      </div>
    );
  }
  
  export default Layout;