import { use, useContext,useState } from "react";
import { AuthContext } from "../context/AuthProvider";
import { useLocation, useNavigate } from "react-router-dom";
import LoginService from "../services/LoginService";

function Login() {

  const navigate = useNavigate();
  const location = useLocation();

const {login} = useContext(AuthContext);
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [error, setError] = useState('');
   
    const handleLoginClick = () => {
        if (username !== '' && password !== '') {

          LoginService().Login({Username:username,Password:password}).then(res => {
            if (res.status === 200 && res.data != null) {
                 
                if (res.data.success) {
                  localStorage.setItem('userData', JSON.stringify(res.data.data))
                  login({username: username});
                  navigate(
                    location.state ||
                      `/home`,
                    { replace: true }
                  );
                }else{
                  setError(res.data.message);
            }
          }
        }, err => console.log(err.response.data.error.message)); 
    } else {
            setError('Invalid username or password');
        }
  }
    return (
      <div className="mx-auto max-w-7xl px-4 py-10 sm:px-6 sm:py-10 lg:px-8">
            <h2 className="mb-1 text-2xl tracking-tight text-gray-900">Login</h2> 
            <form className="w-1/3 mx-auto ">
            <div className={error!=""?"flex items-center p-4 mb-4 text-sm text-red-800 rounded-lg bg-red-50 dark:bg-gray-800 dark:text-red-400":"hidden"} role="alert">
  <svg className="shrink-0 inline w-4 h-4 me-3" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="currentColor" viewBox="0 0 20 20">
    <path d="M10 .5a9.5 9.5 0 1 0 9.5 9.5A9.51 9.51 0 0 0 10 .5ZM9.5 4a1.5 1.5 0 1 1 0 3 1.5 1.5 0 0 1 0-3ZM12 15H8a1 1 0 0 1 0-2h1v-3H8a1 1 0 0 1 0-2h2a1 1 0 0 1 1 1v4h1a1 1 0 0 1 0 2Z"/>
  </svg>
  <span className="sr-only">Info</span>
  <div>
    <span className="font-medium">Error!</span> {error}
  </div>
</div>
                <div className="mb-4">
                    <label className="block font-semibold text-gray-700 mb-2" for="email">
                        Email Address
                    </label>
                    <input
                        className="border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        id="username" type="text" placeholder="Enter your Username"
                        value={username}
                          onChange={(e) => setUsername(e.target.value)}
                          />
                </div>
                <div className="mb-4">
                    <label className="block font-semibold text-gray-700 mb-2" for="password">
                        Password
                    </label>
                    <input
                        className="border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline"
                        id="password" type="password" placeholder="Enter your password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)} />
                    <a className="text-gray-600 hover:text-gray-800" href="#">Forgot your password?</a>
                </div>
                <div className="mb-6">
                    <button
                        className="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline"
                        type="button"
                        onClick={() => handleLoginClick()}
                        >
                        Login
                    </button>
                </div>
            </form>
      </div>
    );
 
  }
  
  export default Login;
  