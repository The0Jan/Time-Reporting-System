import React, {useState} from 'react';
import {Button, Table } from 'react-bootstrap';
import ActivitiesCreate  from './ActivitiesCreate';
import ActivitiesEdit  from './ActivitiesEdit';

export  function Activities() {
    const [activities, setActivities] = useState([]);
    const [cur_date, setDate] = useState('')
    const [cur_activity, setActive] = useState(0)
    const [submitted_time, setSubTime] = useState(0)

    const [isOpen, setIsOpen] = useState(false);

    function getActivities(date){

        setDate(date);
        refresh(date);
    }

    function refresh(date){
        fetch(`api/activity/${date}`)
        .then((response) => response.json())
        .then((data) => [setActivities(data), count_time(data)]);
    }

    function count_time(data){
        let total_time = 0;
        for (var activity in data){
            total_time = total_time + parseInt(data[activity].time);
        }
        setSubTime(total_time);
    }

    function remove(activityId){
        fetch(`api/activity/delete/${activityId}`, {method:'POST'})
        .then(() => refresh(cur_date));
    }

    const togglePopup = (activity) => {
        setActive(activity.activityId);
        setIsOpen(!isOpen);
    }

    const togglePopoff = () => {
        setIsOpen(!isOpen);
        refresh(cur_date);
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
            <ActivitiesCreate given_date = {cur_date} handleRefresh = {refresh} />
            </tbody>
        </Table>
        <h3>Submitted time today: {submitted_time}</h3>
    </>
    );
    
}