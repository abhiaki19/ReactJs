import { Link } from "react-router-dom";

function About() {
    return (
      <div className="mx-auto max-w-7xl px-4 py-10 sm:px-6 sm:py-10 lg:px-8">
            <h2 className="mb-1 text-2xl tracking-tight text-gray-900">About Us</h2> 
         <Link to='/home'>Go to home page</Link>
      </div>
    );
  }
  
  export default About;
  