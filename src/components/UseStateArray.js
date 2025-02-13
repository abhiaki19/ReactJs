import React, { useState } from 'react';

const UseStateArray = () => {
     const [cityList, setcityList] = useState(['Noida ' ,'Delhi ' ,'Pune ']);
     const [cityName, setcityName] = useState("");

     const changeCity = (event)=> {
        setcityName(event.target.value);
     }

     const addCity = ()=> {
        setcityList(oldlist => [...oldlist, cityName])
     }

    return (
        <div className='container'>
            <div className='row'>
                <p>{cityList}</p>
                <div className='col-3'>
                    <input type='text' className='form-control' onChange={(event) => changeCity(event)} />
                </div>
                <div className='col-3'>
                    <input type='button' onClick={addCity} className='btn btn-success' value='Add City' />
                </div>
            </div>
            
        </div>
    );
};

export default UseStateArray;