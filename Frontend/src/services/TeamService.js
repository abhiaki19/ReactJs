import Api from "./Api"; 

export const ACTION_TYPES = {
    CREATE: 'CREATE',
    UPDATE: 'UPDATE',
    DELETE: 'DELETE',
    FETCH_ALL: 'FETCH_ALL'
}
function TeamService() {
    let apiUrl='v1/Team/'
    return {
        fetchAll: () => Api(apiUrl).fetchAll(),
        fetchById: id => Api(apiUrl).fetchById(id),
        create: newRecord => Api(apiUrl).post(newRecord),
        update: (updateRecord) => Api(apiUrl).put(updateRecord),
        delete: id => Api(apiUrl).delete(id)
    }
} 
export default TeamService;