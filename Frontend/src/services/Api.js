import axios from "axios"
import config from "../conf/Config"


const axiosInstance = axios.create({
    baseURL: config.apiUrl, // Replace with your API base URL
  });

//const baseUrl = config.apiUrl;


axiosInstance.interceptors.request.use(
    (config) => {
      const userData = localStorage.getItem('userData');
      if (userData) {
        const token = JSON.parse(userData).token;
        config.headers['Authorization'] = `Bearer ${token}`;
      }
      return config;
    },
    (error) => {
      return Promise.reject(error);
    }
  );

function Api(apiName) { 
    debugger
return {
    
            fetchAll: () => axiosInstance.get(apiName),
            fetchById: id => axiosInstance.get(apiName + id),
            post: newRecord => axiosInstance.post(apiName, newRecord),
            put: (updateRecord) => axiosInstance.put(apiName , updateRecord),
            delete: id => axiosInstance.delete(apiName + id)
        }
    
}

export default Api;