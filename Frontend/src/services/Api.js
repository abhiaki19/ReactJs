import axios from "axios"
import config from "../conf/Config"

const baseUrl = config.apiUrl;


function Api(apiName) { 
    debugger
return {
    
            fetchAll: () => axios.get(baseUrl + apiName),
            fetchById: id => axios.get(baseUrl + apiName + id),
            post: newRecord => axios.post(baseUrl + apiName, newRecord),
            put: (updateRecord) => axios.put(baseUrl + apiName , updateRecord),
            delete: id => axios.delete(baseUrl + apiName + id)
        }
    
}

export default Api;