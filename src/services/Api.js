import axios from "axios"

const baseUrl = "https://localhost:7116/api/"


function Api(apiName) { 
return {
    
            fetchAll: () => axios.get(baseUrl + apiName),
            fetchById: id => axios.get(baseUrl + apiName + id),
            create: newRecord => axios.post(baseUrl + apiName, newRecord),
            update: (updateRecord) => axios.put(baseUrl + apiName , updateRecord),
            delete: id => axios.delete(baseUrl + apiName + id)
        }
    
}

export default Api;