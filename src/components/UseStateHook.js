import React, { useEffect, useState } from 'react';

const UseStateHook = () => {
    let courseName = 'React'
    const changeName = () =>{
        debugger
        courseName = 'Angular';
    }

    const [UserName, setUserName] = useState("Abhishek");

    const [UserInfo, setUserInfo] = useState("");
    const [state, setstate] = useState('MH');

    useEffect(() => {
        setUserInfo('UserName: '+ UserName +', State: '+ state);
    }, [UserName,state]);

    const [courseDuration, setCourseName] = useState("2 months");
    const [rollNo, setrollNo] = useState(1234);
   
    const [isActive, setisActive] = useState(false);
    const [currentDate, setcurrentDate] = useState(new Date());

    const [student, setstudent] = useState({name:'Abhishek',age:12,city:'Noida'});
    const [cityName, setcityName] = useState(['Noida','Delhi','Pune']);

    // const changeDuration = () =>{
    //     setCourseName("4 months")  //change the state value
    // }

    function changeDuration() {
        setCourseName("4 months");
      }

    // const changeRollNo = (event) =>{
    //     setrollNo(event.target.value)  //change the state value
    // }

    function changeRollNo(event) {
        setrollNo(event.target.value) 
      }

    const changeState = (event) =>{
        setstate(event.target.value)  //change the state value
    }

    const changeIsActive = (event) =>{
        setisActive(event.target.checked)  //change the state value
    }

    return (
        <>
            <div className='row'>
                <div className='col-3'>
                    <p>{courseName}</p>
                </div> 
                <div className='col-3'>
                    <p>{courseDuration}</p>
                </div> 
                <div className='col-3'>
                    <p>{rollNo}</p>
                </div> 
                <div className='col-3'>
                    <p>{state}</p>
                    <p>{isActive ? 'Active':'De-Active'}</p>
                </div> 
            </div>
            <div className='row'>
                <div className='col-3'>
                    <button className='btn btn-primary' onClick={changeName}>Change Course Name</button>
                </div> 
           
                <div className='col-3'>
                    <button className='btn btn-primary' onClick={changeDuration}>Change Duration</button>
                </div> 
          
                <div className='col-3'>
                    <input type='text' onChange={(event) => changeRollNo(event)} />
                </div> 
                <div className='col-3'>
                    <label>Name - {UserName}</label>
                    <input type='text' onChange={(e) => setUserName(e.target.value)} />
                </div> 
                
                <div className='col-3'>
                   <select onChange={(event) => changeState(event)}>
                    <option>Goa</option>
                    <option>MH</option>
                    <option>Punjab</option>
                    <option>Delhi</option>
                   </select>
                   <input type='checkbox' onChange={(event) => changeIsActive(event)}/>
                </div> 

                <div>
                    <label>User Info - {UserInfo}</label>
                </div>
            </div>
        </>
    );
};

export default UseStateHook;