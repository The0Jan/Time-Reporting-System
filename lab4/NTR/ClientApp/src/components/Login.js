import React, {useEffect, useState } from 'react';
import {Form, Button } from 'react-bootstrap';

export  function Login() {
    const [users, setUsers] = useState([]);
    const [name, setName] = useState();

    useEffect(() => {
       fetch('api/home')
       .then((response) => response.json())
       .then((data) => setUsers(data));
    }, []);



    function loginUser(){
        fetch(`api/home/${name}/login`, {method:'POST'});
    }

    return (
        <div>
            <h1>Logowanie</h1>

            <Form.Group className="mb-3">
                <Form.Label>Nazwa użytkownika</Form.Label>
                <Form.Select value={name} onChange={evt => setName(evt.target.value)} required>
                    <option value="" hidden>Wybierz...</option>)
                    {users.map(user =>
                        <option key={user.userId} value={user.userId}>{user.first_Name}</option>)
                    }
                </Form.Select>
            </Form.Group>
            <Button onClick={loginUser} variant="primary">Zaloguj się</Button>
        </div>
    );
    
}