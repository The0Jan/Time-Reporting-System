import React, {useEffect, useState } from 'react';
import {Form, Button, Table } from 'react-bootstrap';
import ActivitiesCreate  from './ActivitiesCreate';

export  function Activities() {
    const [activities, setActivities] = useState([]);
    const [cur_date, setDate] = useState('')

    function getActivities(date){
        console.log(date);
        fetch(`api/activity/${date}`)
        .then((response) => response.json())
        .then((data) => setActivities(data));

        setDate(date);
    }

    function remove(activityId){
        fetch(`api/activity/delete/${activityId}`, {method:'POST'})

        getActivities(cur_date);
    }


    function update(activityId){
        console.log(activityId);
        
    }

    return (
        <>
        <h1> Activities for:
            <input type ="date" name ="CurrentDate"  onChange={evt => getActivities(evt.target.value)}/>
        </h1>


        <Table>
            <thead>
                    <tr>
                        <th>Project Code</th>
                        <th>Project Subcode</th>
                        <th>Time</th>
                        <th>Description</th>
                        <th>Delete/Edit</th>
                    </tr>
            </thead>
            <tbody>

            {activities.map(activity =>
            <tr key = {activity.activityId}>
                <td>{activity.projectCode}</td>
                <td>{activity.subcodeName}</td>
                <td>{activity.time}</td>
                <td>{activity.description}</td>
                <td>
                    <Button onClick={() => remove(activity.activityId)} variant="danger">Delete</Button>
                    
                    <Button onClick={() => update(activity.activityId)} variant="warning">Edit</Button>
                </td>
            </tr>
            )}
            <ActivitiesCreate given_date = {cur_date} />

            </tbody>
        </Table>
    </>
    );
    
}