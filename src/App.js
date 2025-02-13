import logo from './logo.svg';
import './App.css';
import Employee from './components/Employee';
import Databinding from './components/Databinding';
import Eventbinding from './components/Eventbinding';
import UseStateHook from './components/UseStateHook';
import UseStateObject from './components/UseStateObject';
import UseStateArray from './components/UseStateArray';
import ConditionRender from './components/ConditionRender';

function App() {
  return (
    <div className="App">
       <h1>Welcome to React js Application</h1>
       {/* <Employee />
       <Databinding></Databinding> 

       <Eventbinding></Eventbinding>*/}
       <UseStateHook></UseStateHook>

       {/* <UseStateObject></UseStateObject> */}

       <UseStateArray/>

       {/* <ConditionRender /> */}
    </div>
  );
}

export default App;
