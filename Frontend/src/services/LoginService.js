import Api from "./Api"; 

export const ACTION_TYPES = {
    login: 'Login' 
}
function LoginService() {
    let apiUrl='v1/Login/loginjwt'
    return { 
        Login: (model) => Api(apiUrl).post(model) 
    }
} 
export default LoginService;