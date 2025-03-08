import Api from "./Api"; 

export const ACTION_TYPES = {
    CREATE: 'CREATE'
}

function ContactUsService() {
    debugger
    let apiUrl='v1/ContactUs/'
    return { 
        create: newRecord => Api(apiUrl).post(newRecord) 
    }
}

export default ContactUsService;