using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Globalization;


namespace NTR.Models
{
    public class ProjectManagmentModel
    {

        public ProjectManagmentModel(){}
        public ProjectManagmentModel(string user){
            Entities.Project_List project_List = Entities.Project_List.load();
            this.my_projects = new List<Entities.Activity>();
            this.SelectedProject = "Not Yet Selected";

            for (int i = 0; i < project_List.activities.Count ; i++)
            {
                if (Equals(project_List.activities[i].manager,user))
                {
                    this.my_projects.Add(project_List.activities[i]);
                }
            }
        }

        public ProjectManagmentModel(string user, string project, DateTime date, string member){
            Entities.Project_List project_List = Entities.Project_List.load();
            this.my_projects = new List<Entities.Activity>();

            this.SelectedUser = member;
            this.SelectedMonth = date;
            this.SelectedProject = project;
            for (int i = 0; i < project_List.activities.Count ; i++)
            {
                if (Equals(project_List.activities[i].manager,user))
                {
                    this.my_projects.Add(project_List.activities[i]);
                }
            }
            this.SelectedUserActivities = Entities.Report.json_load(member, date);
            this.SelectedUserReportedTime = this.time_reported();

            for(int i=0; i<SelectedUserActivities.accepted.Count; i++)
            {
                if(Equals(SelectedUserActivities.accepted[i].code, this.SelectedProject))
                {
                    this.SelectedUserAcceptedTime= SelectedUserActivities.accepted[i].time;
                }
            }
            for(int i=0; i<this.my_projects.Count; i++)
            {
                if(Equals(this.my_projects[i].code, this.SelectedProject))
                {
                    this.Budget = this.my_projects[i].budget;
                    this.Active = this.my_projects[i].active;
                }
            }
        }

        public List<string> users
        {
            get
            {
                var json = System.IO.File.ReadAllText("baza/users.json");
                var list_of_users = System.Text.Json.JsonSerializer.Deserialize<List<String>>(json); 

                return list_of_users;  
            }
        }
        public List<Entities.Activity> my_projects{get; set;}
        public string SelectedProject{get; set;}
        public DateTime SelectedMonth{get; set;}
        public string SelectedUser{get; set;}
        public Entities.Report SelectedUserActivities{get; set;}

        public int SelectedUserReportedTime{get; set;}
        public int SelectedUserAcceptedTime{get; set;}
        public int Budget{get; set;}
        public bool Active{get; set;}
        public int time_reported()
        {
            int time_reported = 0;
            for(int i=0; i<SelectedUserActivities.entries.Count; i++)
            {
                if(Equals(SelectedUserActivities.entries[i].code, this.SelectedProject))
                {
                    time_reported += SelectedUserActivities.entries[i].time;
                }
            }

            return time_reported;
        }

    }
}