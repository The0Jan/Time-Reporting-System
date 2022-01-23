import React, {useEffect, useState } from 'react';
import {Form, Button, Table } from 'react-bootstrap';

import './style.css';

export default function  ActivitiesEdit(props){
    const [projectCode, setProject] = useState("");
    const [subcodeName, setSubcode] = useState("");
    const [description, setDesc] = useState("");
    const [time, setTime] = useState(0);

    const [subcodes, setSubcodes] = useState([]);


    useEffect(() => {
        fetch(`api/activity/activity/${props.activityId}`)
        .then((response) => response.json())
        .then(
        (data) => [setProject(data.projectCode), 
        setSubcode(data.subcodeName),
        setDesc(data.description), 
        setTime(data.time),
        fetch(`api/activity/subcodes/${data.projectCode}`)
        .then((response) => response.json())
        .then((get_sub) => setSubcodes(get_sub))]);
     }, []);

    
    function Update(){
        const requestOptions = {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({
                ActivityId: props.activityId,
                Time: time,
                Description: description,
                SubcodeName: subcodeName
            })
        };
        fetch(`api/activity/update`, requestOptions)
        .then(props.handleClose);
    }


  return (
    <div className="popup-box">
    <div className="box">
        <span className="close-icon" onClick={props.handleClose}>x</span>
        <Table>
            <thead>
                    <tr>
                        <th>Project Code</th>
                        <th>Project Subcode</th>
                        <th>Time</th>
                        <th>Description</th>
                        <th>Option</th>
                    </tr>
            </thead>
            <tbody>
        <tr>
            <td>
                {projectCode}
            </td>
            <td>
                <Form.Select value={subcodeName} onChange ={evt => setSubcode(evt.target.value)} required>
                    <option value={subcodeName} defaultValue={subcodeName}>{subcodeName}</option>)

                    {subcodes.map(subcode_m =>
                            <option key={subcode_m.name} value={subcode_m.name}>{subcode_m.name}</option>)
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
                <Button variant="success" onClick={() => Update()}>Update</Button>
            </td>
        </tr>
        </tbody>
        </Table>
    </div>
    </div>
  );
};
 
