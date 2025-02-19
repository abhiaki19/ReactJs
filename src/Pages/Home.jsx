import { Link, Links } from "react-router-dom";

function Home() {
    return (
      <div className="App">
         <h1>Home</h1> 

          <Link to='/about'>Go to about page</Link>
      </div>
    );
  }
  
  export default Home;