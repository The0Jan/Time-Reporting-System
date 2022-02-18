# RTS


## Lab 1 - .net MVC without database (using JSON to store data)
Main screen:

 - Displays the activities of the active (or any other) day. Counts the reported time
 - Has watch/add/change/delete buttons. For closed months, you can only view
 - Has the ability to change the day

Input screen

 - The user can add or delete activity
 - When reporting an activity, you can indicate the project to which the activity has been carried out
 - You cannot assign the activity to a closed project
 - After choosing a project (optionally) you can choose a subcategory within this project
 - For an activity you specify the time spent (in minutes)
 - Activity has a description field, where you can optionally enter additional textual information

Menu Dialog
 - User can create a monthly summary of his activities divided into projects (that is sum of time for each project)
 - User can approve the month - after approval user can not modify the entries for days of this month
 - User can create a new project - then the user becomes its owner
 - The project owner can browse the list of participants in his project, and if the participant has approved the month, the owner can determine the value of time which he accepts (it can be different from the one shown)
 - The project owner can modify the time accepted until he closes a project.manager can modify his acceptance for any month until he closes a project
 - Project owner sees project budget remaining after subtracting accepted time (budget can be negative ...)
 - The user can see the time that has been accepted by the project owners

## Lab 2 - .net MVC with database, migrations and concurency checking
Same functionalities as lab 1 but using a database and with concurency

## Lab 4 - .net + React with database
Main screen:

 - Displays the activities of the active (or any other) day. Counts the reported time
 - Has watch/add/change/delete buttons. For closed months, you can only view
 - Has the ability to change the day

Input screen

 - The user can add or delete activity
 - When reporting an activity, you can indicate the project to which the activity has been carried out
 - You cannot assign the activity to a closed project
 - After choosing a project (optionally) you can choose a subcategory within this project
 - For an activity you specify the time spent (in minutes)
 - Activity has a description field, where you can optionally enter additional textual information


### Launching 
#### Database
```
docker-compose up
dotnet ef database update
```


#### Development 

```bash
dotnet run
```

#### Production 

```bash
dotnet publish -c Production
cd bin/Production/net6.0/publish
./NTR.exe
```