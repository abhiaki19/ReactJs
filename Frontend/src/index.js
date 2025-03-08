import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './App';
import './index.css';
import { createBrowserRouter, createRoutesFromElements, Route, RouterProvider } from 'react-router-dom';
import Layout from './layout/Layout';
import Home from './pages/Home';
import Login from './pages/Login';
import About from './pages/About';
import ContactUs from './pages/ContactUs';
import Team from './pages/Team';
import { Provider } from 'react-redux';
import store from './store/store';

const root = ReactDOM.createRoot(document.getElementById('root'));


// const route = createBrowserRouter(createRoutesFromElements(
// <Route path='/' element={<Layout />}>
// <Route path='/' element={<Home />}></Route> 
// <Route path='home' element={<Home />}></Route>
// <Route path='about' element={<About />}></Route>
// </Route>));



const route = createBrowserRouter ([{path: '/', element: <Layout />,
  children:[
            {path: 'home', element: <Home />},
            {path: '', element: <Home />},
            {path: 'login', element: <Login />},
            {path: 'about', element: <About />},
            {path: 'team', element: <Team />},
            {path: 'contact', element: <ContactUs />}
          ]
}]);


root.render(
  <React.StrictMode>
    {/* <App /> */}
    <Provider store={store}>
      <RouterProvider router={route} />
</Provider>


  </React.StrictMode>
);
 
