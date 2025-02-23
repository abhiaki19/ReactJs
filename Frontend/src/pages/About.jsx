import { Link } from "react-router-dom";

function About() {
    return (
      <div className="App">
         <h1>About us</h1> 
         <Link to='/home'>Go to home page</Link>
      </div>
    );
  }
  
  export default About;
  