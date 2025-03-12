import React from 'react';

const Button = ({ 
    onClick
    , children

    ,type='button'
    , className='bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline'
    , disabled
    ,...props }) => {
    return (
        <button 
            onClick={onClick} 
            className={` ${className}`} 
            disabled={disabled}
            type={type}
            {...props}
        >
            {children}
        </button>
    );
};


export default Button;