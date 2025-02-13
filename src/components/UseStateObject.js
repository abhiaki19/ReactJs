import React, { useState } from 'react';

const UseStateObject = () => {

    const [studentobj, setstudentObj] = useState({
        name:'Abhishek',
        city:'Noida',
        state:'UP'
    });

    const changeName = (event) => {
        setstudentObj(oldobj => ({...oldobj, name:event.target.value}))
    }
    const changeCity = (event) => {
        setstudentObj(oldobj => ({...oldobj, city:event.target.value}))
    }
    const changeState = (event) => {
        setstudentObj(oldobj => ({...oldobj, state:event.target.value}))
    }

    

    return (
        <div className='container'>
            <p>{JSON.stringify(studentobj)}</p>
            <div className='row'>
                <div className='col-4'>
                    <label>Name</label>
                    <input type='text' className='form-control' onChange={(event) => changeName(event)} />
                </div>
            </div>
            <div className='row'>
                <div className='col-4'>
                    <label>City</label>
                    <input type='text' className='form-control' onChange={(event) => changeCity(event)} />
                </div> 
                <div className='col-4'>
                    <label>State</label>
                    <input type='text' className='form-control' onChange={(event) => changeState(event)} />
                </div>
            </div>
        </div>
    );
};

export default UseStateObject;