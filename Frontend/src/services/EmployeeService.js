import Api from "./Api"; 

export const ACTION_TYPES = {
    CREATE: 'CREATE',
    UPDATE: 'UPDATE',
    DELETE: 'DELETE',
    FETCH_ALL: 'FETCH_ALL'
}
function EmployeeService() {
    let apiUrl='v1/Employee/'
    return {
        fetchAll: () => Api(apiUrl).fetchAll(),
        fetchById: id => Api(apiUrl).fetchById(id),
        create: newRecord => Api(apiUrl).create(newRecord),
        update: (updateRecord) => Api(apiUrl).update(updateRecord),
        delete: id => Api(apiUrl).delete(id)
    }
} 
export default EmployeeService;