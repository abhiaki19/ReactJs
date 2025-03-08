import { useState, useEffect } from "react";
import { useDispatch } from "react-redux";
import { useSelector } from "react-redux";
import { addTeam,removeTeam,updateTeam,fetchTeamsAsync,saveTeamsAsync } from "../slice/TeamSlice";

function Team() {
    const dispatch = useDispatch();
    const loading = useSelector((state) => state.loading);
    const [showForm, setShowForm] = useState(false);
    const [id, setId] = useState(0);
    const [teamName, setTeamName] = useState('');
    const [description, setDescription] = useState('');
    const [isActive, setIsActive] = useState(false);
    const teams = useSelector((state) => state.teamReducer.team);

    useEffect(() => {
        dispatch(fetchTeamsAsync());
    }, [dispatch], [loading]);
 

    const handleSave = () => {
        let team = {
            id: id,
            teamName: teamName,
            description:description,
            isActive: isActive
        }
        if(id!==0){
            dispatch(updateTeam(team));
            clear();
        }else{ 
            team.id=-( teams.length + 1);
            dispatch(addTeam(team));
            clear();
        } 
    }

    const handleEdit = (team) => {
        setShowForm(true);
        setId(team.id);
        setTeamName(team.teamName);
        setDescription(team.description);
        setIsActive(team.isActive);
    }

    const handleDelete = (team) => {
        if (window.confirm("Are you sure to delete this Team") === true) {
            dispatch(removeTeam(team));
        }
    }

    const clear = () => {
        setId(0);
        setTeamName('');
        setDescription('');
        setIsActive(false);
        setShowForm(false);
    }

    const handleSaveTeamTable = () => {
        dispatch(saveTeamsAsync(teams)).then(x=>   dispatch(fetchTeamsAsync()));
    }


    return (
        <div className="mx-auto max-w-7xl px-4 py-10 sm:px-6 sm:py-10 lg:px-8">
            <div className={showForm ? undefined : 'hidden'}  >
            <h2 className="mb-1 text-2xl tracking-tight text-gray-900">Team Details</h2>
            <form >
                <div className="space-y-12">
                    <div className="border-b border-gray-900/10 pb-12">
                        <h2 className="mb-10 text-base/7 font-semibold text-gray-900">New Team Information</h2>

                        <div className=" grid grid-cols-1 gap-x-6 gap-y-8 sm:grid-cols-6">
                            <div className="sm:col-span-3">
                                <label htmlFor="team-name" className="block text-sm/6 font-medium text-gray-900">Team name</label>
                                <div className="mt-2">
                                    <input type="text" required
                                        value={teamName}
                                        onChange={(e) => setTeamName(e.target.value)}
                                        name="team-name"
                                        id="team-name"
                                        autoComplete="team-name"
                                        className="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6" />
                                </div>
                            </div>
                            <div className="sm:col-span-3">
                                <label htmlFor="Description" className="block text-sm/6 font-medium text-gray-900">Description</label>
                                <div className="mt-2">
                                <textarea  rows="4"
                                 className="block p-2.5 w-full text-sm  rounded-lg border   focus:ring-blue-500 focus:border-blue-500    dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                                 value={description}
                                        onChange={(e) => setDescription(e.target.value)}
                                        name="Description"
                                        id="Description"
                                        autoComplete="Description"
                                        >


                                 </textarea>
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
                    <button type="button" onClick={handleSave} className="rounded-md bg-indigo-600 px-3 py-2 text-sm font-semibold text-white shadow-xs hover:bg-indigo-500 focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600">Save as Draft</button>
                </div>
            </form>
            </div>

            <div className="relative overflow-x-auto">
                    <button type="button" onClick={(e) => setShowForm(true)}  className={showForm ? 'hidden':'float-right px-3 py-2 text-xs font-medium text-center inline-flex items-center text-white bg-blue-700 rounded-lg hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800'}>Add New Team</button>
                <h2 className="mb-10 text-2xl tracking-tight text-gray-900">Team List
</h2>
                

                <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
                    <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
                        <tr>
                            <th scope="col" className="px-6 py-3">
                                Team Name
                            </th>
                            <th scope="col" className="px-6 py-3">
                            Description
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
                            teams.map(
                                item =>
                                    <tr key={item.id} className="bg-white border-b dark:bg-gray-800 dark:border-gray-700 border-gray-200">
                                        <th scope="row" className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">
                                            {item.teamName}
                                        </th>
                                        <td className="px-6 py-4"> {item.description}</td>
                                        <td className="px-6 py-4"> {item.isActive ? "True" : "False"}</td>
                                        <td className="px-6 py-4">
                                            <button onClick={() => handleEdit(item)} className="btn btn-info">Edit </button>
                                            <button style={{ marginLeft: "10px" }} onClick={() => handleDelete(item)} className="btn btn-danger">Delete </button>
                                        </td>
                                    </tr>
                            )

                        }


                    </tbody>
                </table>
            </div>
            <div className="relative overflow-x-auto mt-6">
            <button type="button"  onClick={(e) => handleSaveTeamTable(true)}  className={showForm ? 'hidden':"focus:outline-none text-white bg-red-700 hover:bg-red-800 focus:ring-4 focus:ring-red-300 font-medium rounded-lg text-sm px-5 py-2.5 me-2 mb-2 dark:bg-red-600 dark:hover:bg-red-700 dark:focus:ring-red-900 float-right"}> 
            Save Team Table</button>

                        </div>
          
        </div>
    );
}

export default Team;