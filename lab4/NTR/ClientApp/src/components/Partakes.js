import React, {useEffect, useState} from 'react';
import {Form, Table} from 'react-bootstrap';

export default function Partakes(){
    const [projects, setProject] = useState([]);
    const [projectName, setProjectName] = useState("");
    const [partakings, setPartakings] = useState([]);

    useEffect(() => {
        fetch('api/activity/projects')
        .then((response) => response.json())
        .then((data) => setProject(data));
    }, []);

    function getPartakings(project_code){
        setProjectName(project_code);
        fetch(`api/activity/partakings/${project_code}`)
        .then((response) => response.json())
        .then((data) => setPartakings(data));
    }

    return(
        <>
        <h1>Project Partakings</h1>
            <Form.Select value={projectName} onChange ={evt => getPartakings(evt.target.value)} required>
                <option value="" hidden>Wybierz projekt</option>    
                {projects.map(project =>
                        <option key={project.projectCode} value={project.projectCode}>{project.title}</option>)
                }                
            </Form.Select>
            <Table>
            <thead>
                    <tr>
                        <th>Year</th>
                        <th>Month</th>
                        <th>Submitted Time</th>
                        <th>Accepted Time</th>
                    </tr>
            </thead>
            <tbody>
            {partakings.map(partake =>
            <tr key = {partake.projectPartakeid}>
                <td>{partake.year}</td>
                <td>{partake.month}</td>
                <td>{partake.submittedTime}</td>
                <td>{partake.acceptedTime}</td>
            </tr>
            )}
            </tbody>
        </Table>
        </>
    );
}