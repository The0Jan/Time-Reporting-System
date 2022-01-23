import React, {useEffect, useState } from 'react';
import {Form, Button, Table } from 'react-bootstrap';
import ActivitiesCreate  from './ActivitiesCreate';
import ActivitiesEdit  from './ActivitiesEdit';

export  function Activities() {
    const [activities, setActivities] = useState([]);
    const [cur_date, setDate] = useState('')
    const [cur_activity, setActive] = useState(0)

    const [isOpen, setIsOpen] = useState(false);

    function getActivities(date){
        fetch(`api/activity/${date}`)
        .then((response) => response.json())
        .then((data) => setActivities(data));

        setDate(date);
    }

    function refresh(){
        fetch(`api/activity/${cur_date}`)
        .then((response) => response.json())
        .then((data) => setActivities(data));
    }

    function remove(activityId){
        fetch(`api/activity/delete/${activityId}`, {method:'POST'})
        .then(() => refresh());
    }

    const togglePopup = (activity) => {
        setActive(activity.activityId);
        setIsOpen(!isOpen);
    }

    const togglePopoff = () => {
        setIsOpen(!isOpen);
        refresh();
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
                    <Button onClick={() => togglePopup(activity)} variant="warning">Edit</Button>
                    {isOpen && <ActivitiesEdit activityId={cur_activity} handleClose={togglePopoff}/>}
                </td>
            </tr>
            )}
            <ActivitiesCreate given_date = {cur_date} handleRefresh = {refresh}/>
            </tbody>
        </Table>

    </>
    );
    
}