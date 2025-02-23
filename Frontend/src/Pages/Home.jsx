import { useState, useEffect } from "react";
import EmployeeService from "../services/EmployeeService";

function Home() {

    const [showForm, setShowForm] = useState(false);
    const [id, setId] = useState(0);
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [isActive, setIsActive] = useState(false);
    const [lstEmployee, setLstEmployee] = useState([]);

    useEffect(() => {
        fetchEmployeeList();
    }, [])

    const fetchEmployeeList = () => {

        EmployeeService().fetchAll().then(res => {
            if (res.status === 200 && res.data.data != null) {
                setLstEmployee(res.data.data);
            }
        }, err => console.log(err.response.data.error.message));
    }

    const save = () => {
        let employee = {
            id: id,
            firstName: firstName,
            lastName: lastName,
            email: email,
            username: username,
            password: password,
            isActive: isActive
        }
        if (id > 0) {
            EmployeeService().update(employee).then(res => {
                if (res.status === 200 && res.data != null) {
                    alert(res.data.message);
                    if (res.data.success) {
                        fetchEmployeeList();
                        clear();
                    }
                }
            }, err => console.log(err.response.data.error.message));
        } else {
            EmployeeService().create(employee).then(res => {
                if (res.status === 200 && res.data != null) {
                    alert(res.data.message);
                    if (res.data.success) {
                        fetchEmployeeList();
                        clear();
                    }
                }
            }, err => console.log(err.response.data.error.message));
        }
    }

    const handleEdit = (id) => {
        setShowForm(true);
        EmployeeService().fetchById(id).then(res => {
            if (res.status === 200 && res.data.data != null) {
                setFirstName(res.data.data.firstName);
                setLastName(res.data.data.lastName);
                setEmail(res.data.data.email);
                setUsername(res.data.data.username);
                setPassword(res.data.data.password);
                setIsActive(res.data.data.isActive);
                setId(id);
            }
        }, err => console.log(err.response.data.error.message));
    }

    const handleDelete = (id) => {
        if (window.confirm("Are you sure to delete this employee") === true) {
            EmployeeService().delete(id).then(res => {
                if (res.status === 200 && res.data != null) {
                    alert(res.data.message);
                    fetchEmployeeList();
                }
            }, err => console.log(err.response.data.error.message));
        }
    }

    const clear = () => {
        setId(0);
        setLastName('');
        setEmail('');
        setUsername('');
        setPassword('');
        setIsActive(false);
        setShowForm(false);
    }

    return (
        <div className="mx-auto max-w-7xl px-4 py-10 sm:px-6 sm:py-10 lg:px-8">
            <div className={showForm ? undefined : 'hidden'}  >
            <h2 className="mb-1 text-2xl tracking-tight text-gray-900">Employee Details</h2>
            <form >
                <div className="space-y-12">
                    <div className="border-b border-gray-900/10 pb-12">
                        <h2 className="mb-10 text-base/7 font-semibold text-gray-900">Personal Information</h2>

                        <div className=" grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
                            <div className="sm:col-span-3">
                                <label htmlFor="first-name" className="block text-sm/6 font-medium text-gray-900">First name</label>
                                <div className="mt-2">
                                    <input type="text"
                                        value={firstName}
                                        onChange={(e) => setFirstName(e.target.value)}
                                        name="first-name"
                                        id="first-name"
                                        autoComplete="first-name"
                                        className="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6" />
                                </div>
                            </div>

                            <div className="sm:col-span-3">
                                <label htmlFor="lastname" className="block text-sm/6 font-medium text-gray-900">
                                    Last name
                                </label>
                                <div className="mt-2">
                                    <input
                                        id="lastname"
                                        name="lastname"
                                        type="text"
                                        autoComplete="last-name"
                                        value={lastName}
                                        onChange={(e) => setLastName(e.target.value)}
                                        className="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
                                    />
                                </div>
                            </div>

                            <div className="sm:col-span-3">
                                <label htmlFor="Email" className="block text-sm/6 font-medium text-gray-900">Email</label>
                                <div className="mt-2">
                                    <input type="text"
                                        name="Email"
                                        id="Email"
                                        autoComplete="Email"
                                        value={email}
                                        onChange={(e) => setEmail(e.target.value)}
                                        className="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6" />
                                </div>
                            </div>

                            <div className="sm:col-span-3">
                                <label htmlFor="Username" className="block text-sm/6 font-medium text-gray-900">
                                    Username
                                </label>
                                <div className="mt-2">
                                    <input
                                        id="Username"
                                        name="Username"
                                        type="text"
                                        autoComplete="Username"
                                        value={username}
                                        onChange={(e) => setUsername(e.target.value)}
                                        className="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
                                    />
                                </div>
                            </div>
                            <div className="sm:col-span-3">
                                <label htmlFor="password" className="block text-sm/6 font-medium text-gray-900">Password</label>
                                <div className="mt-2">
                                    <input type="password"
                                        name="password"
                                        id="password"
                                        value={password}
                                        onChange={(e) => setPassword(e.target.value)}
                                        className="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6" />
                                </div>
                            </div>

                            <div className="sm:col-span-3">
                                <label htmlFor="IsActive" className="block text-sm/6 font-medium text-gray-900">
                                    Is Active
                                </label>
                                <div className="mt-2">
                                    <input
                                        type="checkbox"
                                        id="IsActive"
                                        name="IsActive"
                                        checked={isActive}
                                        onChange={() => { setIsActive((prev) => !prev) }}
                                    />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div className="mt-6 flex items-center justify-end gap-x-6">
                    <button type="button" onClick={clear} className="text-sm/6 font-semibold text-gray-900">Cancel</button>
                    <button type="button" onClick={save} className="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-xs hover:bg-indigo-500 focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Save</button>
                </div>
            </form>
            </div>

            <div className="mt-10 relative overflow-x-auto">
                    <button type="button" onClick={(e) => setShowForm(true)} className=" float-right px-3 py-2 text-xs font-medium text-center inline-flex items-center text-white bg-blue-700 rounded-lg hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Add New Employee</button>
                <h2 className="mb-10 text-2xl tracking-tight text-gray-900">Employee List
</h2>
                

                <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
                    <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                        <tr>
                            <th scope="col" className="px-6 py-3">
                                First Name
                            </th>
                            <th scope="col" className="px-6 py-3">
                                Last Name
                            </th>
                            <th scope="col" className="px-6 py-3">
                                Email
                            </th>
                            <th scope="col" className="px-6 py-3">
                                Username
                            </th>
                            <th scope="col" className="px-6 py-3">
                                Active
                            </th>
                            <th scope="col" className="px-6 py-3">
                                Action
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            lstEmployee.map(
                                item =>
                                    <tr key={item.id} className="bg-white border-b dark:bg-gray-800 dark:border-gray-700 border-gray-200">
                                        <th scope="row" className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                                            {item.firstName}
                                        </th>

                                        <td className="px-6 py-4"> {item.lastName}</td>
                                        <td className="px-6 py-4"> {item.email}</td>
                                        <td className="px-6 py-4"> {item.username}</td>
                                        <td className="px-6 py-4"> {item.isActive ? "True" : "False"}</td>
                                        <td className="px-6 py-4">
                                            <button onClick={() => handleEdit(item.id)} className="btn btn-info">Edit </button>
                                            <button style={{ marginLeft: "10px" }} onClick={() => handleDelete(item.id)} className="btn btn-danger">Delete </button>
                                        </td>
                                    </tr>
                            )

                        }


                    </tbody>
                </table>
            </div>

        </div>
    );
}

export default Home;