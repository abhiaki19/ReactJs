import React from 'react';

const Eventbinding = () => {
const showAlter = () => {
    alert("Welcome to EventBinding Concept");
}

const showMessage = (msg) => {
    alert(msg);
}

const onCityChange = () => {
    alert('City Change');
}

const onTextChange = () => {
    alert('Text Change');
}

const onNameChange = (event) => {
    console.log(event.target.value);
}

    return (
        <div>
            <button onClick={showAlter}>Show Alert </button>
            <button onClick={ () => showAlter() }>Show Alert 2</button>

            <button onClick={ () => showMessage('Btn 1') }>Show Btn 1 Msg</button>
            <button onClick={ () => showMessage('Btn 2') }>Show Btn 2 Msg</button>

            <select onChange={onCityChange}>
                <option>Noida</option>
                <option>Delhi</option>
                <option>Pune</option>
            </select>

            <input type='text' onChange={onTextChange} /> <br/><br/>

            <input type='text' onChange={ (event) => onNameChange(event)} />
        </div>
    );
};

export default Eventbinding;