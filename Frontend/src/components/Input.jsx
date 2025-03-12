import React, { useId } from 'react';

const Input = React.forwardRef (function Input({ label, type = 'text',className="",...props},ref) {
    const id=useId();
    return (
        <div className="w-full">
            {label &&
            <label className="inline-block mb-1 pl-1" htmlFor={id}>
                {label}
            </label>}
            <input
                className={`border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline ${className}`}
                id={id}
                type={type}
                ref={ref}
                {...props}
            />
        </div>
    );
});

export default Input;