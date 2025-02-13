import React from 'react';

const Databinding = () => {
    const className = "ReactJs";
    const rollNo = "1234";
    const isActive = true;
    const date = new Date();
    const student = {
        name: 'Abhishek',
        city: 'Noida',
        state: 'UP'
    }
    const cityList = ['Noida', 'Delhi', 'Pune']

    return (
        <div>
            <h2>This is my Databinding page.</h2>
<input type='text' value={className} />
            <table>
                <tr>
                    <td>className</td>
                    <td>rollNo</td>
                    <td>isActive</td>
                    <td>Date</td>
                </tr>
                <tr>
                    <td>{className}</td>
                    <td>{rollNo}</td>
                    <td>{isActive ? 'Active' : 'De-Active'}</td>
                    <td>{date.toString()}</td>
                </tr>
                <tr>
                    <td>
                        {student.name}
                    </td>
                    <td>
                        {student.city}
                    </td>
                    <td>
                        {student.state}
                    </td>
                </tr>
                <tr>
                    <td>
                        {cityList.toString()}
                    </td>
                </tr>
            </table>
        </div>
    );
};

export default Databinding;