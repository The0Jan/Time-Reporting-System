import React, {useEffect, useState } from 'react';
import {Form, Button, Table } from 'react-bootstrap';



export default function ActivitiesCreate(props){
    const [projects, setProject] = useState([]);
    const [subcodes, setSubcode] = useState([]);

    const [projectName, setProjectName] = useState("");
    const [subcodeName, setSubcodeName] = useState("");
    const [description, setDesc] = useState("");
    const [time, setTime] = useState(1);

    useEffect(() => {
        fetch('api/activity/projects')
        .then((response) => response.json())
        .then((data) => setProject(data));
     }, []);


    function SelectProject(project_code){
        fetch(`api/activity/subcodes/${project_code}`)
        .then((response) => response.json())
        .then((data) => setSubcode(data));
        setProjectName(project_code);
    }

    function Clear(){
        setProjectName('');
        setSubcodeName('');
        setTime(0);
        setDesc('');
    }

    function Create(){
        const requestOptions = {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({
                ActivityId: null,
                Date:props.given_date,
                Time: time,
                Description: description,
                Frozen: false,
                UserId: null,
                ProjectCode: projectName,
                SubcodeName: subcodeName
            })
        };
        fetch(`api/activity/create`, requestOptions)
        .then(props.handleRefresh);
        Clear();
    }
    return(
        <>
        <tr>
            <td>
                <Form.Select value={projectName} onChange ={evt => SelectProject(evt.target.value)} required>
                    <option value="" hidden>Wybierz projekt</option>)

                    {projects.map(project =>
                            <option key={project.projectCode} value={project.projectCode}>{project.title}</option>)
                    }                
                </Form.Select>
            </td>
            <td>
                <Form.Select value={subcodeName} onChange ={evt => setSubcodeName(evt.target.value)} required>
                    <option value="" hidden>Wybierz projekt</option>)

                    {subcodes.map(subcode =>
                            <option key={subcode.name} value={subcode.name}>{subcode.name}</option>)
                    }                
                </Form.Select>            
            </td>
            <td>
                <Form.Control type="number" value={time} min={1} onChange={evt => setTime(Number(evt.target.value))} required/>  
            </td>
            <td>
                <Form.Control as="textarea" value={description}  onChange={evt => setDesc(evt.target.value)} />  
            </td>
            <td>
            </td>
            <td>
                <Button variant="success" onClick={() => Create()}>Create</Button>
                <Button variant="info" onClick={() => Clear}>Clear</Button>
            </td>
        </tr>
        </>
    );
}