import { useState, useEffect } from "react";
import ContactUsService from "../services/ContactUsService";

function ContactUs() {
    const [id, setId] = useState(0);
    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [email, setEmail] = useState('');
    const [message, setMessage] = useState('');
    const [isActiveforNewsletter, setIsActiveforNewsletter] = useState(false);


    const save = () => {
        debugger
        let contatUs = {
            id: id,
            firstName: firstName,
            lastName: lastName,
            email: email,
            message: message, 
            isActiveforNewsletter: isActiveforNewsletter
        } 

        ContactUsService().create(contatUs).then(res => {
                debugger
                if (res.status === 200 && res.data != null) {
                    alert(res.data.message);
                    if (res.data.success) { 
                       // clear();
                    }
                }
        }, err => {alert(err.response.data.error.message); console.log(err.response.data.error.message)});
        
    }
    
    const clear = () => {
        setId(0);
        setFirstName('');
        setLastName('');
        setEmail('');
        setMessage(''); 
        setIsActiveforNewsletter(false); 
    }

    return (
      <div className="mx-auto max-w-7xl px-4 py-10 sm:px-6 sm:py-10 lg:px-8">
            <h2 className="mb-1 text-2xl tracking-tight text-gray-900">Contact Us</h2> 
            <div  className="relative bg-white overflow-hidden">
     
            <div className=" mx-auto p-5">
    <div className="grid grid-cols-1 md:grid-cols-12 border">
        <div className="bg-gray-900 md:col-span-4 p-10 text-white">
            <p className="mt-4 text-sm leading-7 font-regular uppercase">
                Contact
            </p>
            <h3 className="text-3xl sm:text-4xl leading-normal font-extrabold tracking-tight">
                Get In <span className="text-indigo-600">Touch</span>
            </h3>
            <p className="mt-4 leading-7 text-gray-200">
                Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the
                industry's standard dummy text ever since the 1500s.
            </p>

            <div className="flex items-center mt-5">
                 
                <span className="text-sm">House #14, Street #12, Darulaman Road, Kabul, Afghanistan.</span>
            </div>
            <div className="flex items-center mt-5">
               
                <span className="text-sm">+93 749 99 65 50</span>
            </div>
            <div className="flex items-center mt-5">
                 
                <span className="text-sm">24/7</span>
            </div>

        </div>
        <form className="md:col-span-8 p-10">
            <div className="flex flex-wrap -mx-3 mb-6">
                <div className="w-full md:w-1/2 px-3 mb-6 md:mb-0">
                    <label className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
                        for="grid-first-name">
                        First Name
                    </label>
                    <div className="mt-2">
                                    <input type="text" required
                                        value={firstName}
                                        onChange={(e) => setFirstName(e.target.value)}
                                        name="first-name"
                                        id="first-name"
                                        autoComplete="first-name"
                                        className="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6" />
                                </div>
                    {/* <input
                        className="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
                        id="grid-first-name" type="text" placeholder="Jane"/>
                    <p className="text-red-500 text-xs italic">Please fill out this field.</p> */}
                </div>
                <div className="w-full md:w-1/2 px-3">
                    <label className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
                        for="grid-last-name">
                        Last Name
                    </label>
                    <div className="mt-2">
                                    <input required
                                        id="lastname"
                                        name="lastname"
                                        type="text"
                                        autoComplete="last-name"
                                        value={lastName}
                                        onChange={(e) => setLastName(e.target.value)}
                                        className="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
                                    />
                                </div>
                    {/* <input
                        className="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"
                        id="grid-last-name" type="text" placeholder="Doe"/> */}
                </div>
            </div>
            <div className="flex flex-wrap -mx-3 mb-6">
                <div className="w-full px-3">
                    <label className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
                        for="grid-password">
                        Email Address
                    </label>
                    <div className="mt-2">
                                    <input type="text"
                                        name="Email" required
                                        id="Email"
                                        autoComplete="Email"
                                        value={email}
                                        onChange={(e) => setEmail(e.target.value)}
                                        className="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6" />
                                </div>
                </div>
            </div>

            <div className="flex flex-wrap -mx-3 mb-6">
                <div className="w-full px-3">
                    <label className="block uppercase tracking-wide text-gray-700 text-xs font-bold mb-2"
                        for="grid-password">
                        Your Message
                    </label>
                    <textarea rows="10"
                    name="Message" required
                    id="Message"
                    autoComplete="Message"
                    value={message}
                    onChange={(e) => setMessage(e.target.value)}
                        className="block w-full rounded-md bg-white px-3 py-1.5 text-base text-gray-900 outline outline-1 -outline-offset-1 outline-gray-300 placeholder:text-gray-400 focus:outline focus:outline-2 focus:-outline-offset-2 focus:outline-indigo-600 sm:text-sm/6"></textarea>
                </div>
                <div className="mt-10 flex justify-between w-full px-3">
                    <div className="md:flex md:items-center">
                        <label className="block text-gray-500 font-bold">
                            {/* <input className="mr-2 leading-tight" type="checkbox"/> */}
                            <input
                                        type="checkbox"
                                        id="IsActiveforNewsletter"  
                                        name="IsActiveforNewsletter"
                                        checked={isActiveforNewsletter}
                                        onChange={() => { setIsActiveforNewsletter((prev) => !prev) }}
                                    />
                            <span className="text-sm">
                                Send me your newsletter!
                            </span>
                        </label>
                    </div>
                    <button
                    onClick={save}
                        className="shadow bg-indigo-600 hover:bg-indigo-400 focus:shadow-outline focus:outline-none text-white font-bold py-2 px-6 rounded"
                        type="submit">
                        Send Message
                    </button>
                </div>

            </div>

        </form>

    </div>
</div>
</div>
      </div>
    );
  }
  
  export default ContactUs;
  