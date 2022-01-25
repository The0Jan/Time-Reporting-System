import React, {useEffect, useState} from 'react';
import {Form, Button } from 'react-bootstrap';

export  function Login(props) {
    const [users, setUsers] = useState([]);
    const [name, setName] = useState();

    useEffect(() => {
       fetch('api/home')
       .then((response) => response.json())
       .then((data) => setUsers(data));
    }, []);

    function loginUser(){
        fetch(`api/home/${name}/login`, {method:'POST'})
        .then(props.location.state);
    }

    return (
        <div>
            <h1>Logging</h1>

            <Form.Group className="mb-3">
                <Form.Label>User name</Form.Label>
                <Form.Select value={name} onChange={evt => setName(evt.target.value)} required>
                    <option value="" hidden>Select...</option>)
                    {users.map(user =>
                        <option key={user.userId} value={user.userId}>{user.first_Name}</option>)
                    }
                </Form.Select>
            </Form.Group>
            <Button onClick={loginUser} variant="primary">Select User</Button>
        </div>
    );
    
}