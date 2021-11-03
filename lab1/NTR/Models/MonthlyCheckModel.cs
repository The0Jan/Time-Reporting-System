using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace NTR.Models {
    public class MonthlyCheckModel{
        
        public MonthlyCheckModel(){}
        public MonthlyCheckModel(string user, string date)
        {
            DateTime date_formatted = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            ActivitiesForDayModel activity = new ActivitiesForDayModel(user,date_formatted);
            this.checks = new List<Entities.Check>();
            this.acceptedChecks = new List<Entities.Check>();


            for (int i =0; i < activity.Activities.entries.Count; i++)
            {
                if(i != 0)
                {
                    for (int j=0; j<this.checks.Count; j++)
                    {
                        if(Equals(this.checks[j].code, activity.Activities.entries[i].code ))
                        {
                            this.checks[j].time += activity.Activities.entries[i].time;
                            break;
                        }
                        else if(j == (this.checks.Count-1))
                        {
                            this.checks.Add(make_to_check(activity.Activities.entries[i]));
                        }
                    }
                }
                else
                {
                    this.checks.Add(make_to_check(activity.Activities.entries[i]));
                }
            }
            for (int i =0; i < activity.Activities.accepted.Count; i++)
            {
                if(i!= 0)
                {
                    for (int j=0; j<this.acceptedChecks.Count; j++)
                    {
                        if(Equals(this.acceptedChecks[j].code, activity.Activities.accepted[i].code ))
                        {
                            this.acceptedChecks[j].time += activity.Activities.accepted[i].time;
                            break;
                        }
                        else if(j == this.acceptedChecks.Count-1)
                        {
                            this.acceptedChecks.Add(make_to_acceptedCheck(activity.Activities.accepted[i]));
                        }
                    }
                }
                else
                {
                    this.acceptedChecks.Add(make_to_acceptedCheck(activity.Activities.accepted[i]));
                }
            }

        }


        public List<Entities.Check> checks {get; set;}

        public List<Entities.Check> acceptedChecks {get; set;}

        public static Entities.Check make_to_check(Entities.Entry entry)
        {
            Entities.Check check = new Entities.Check();
            check.code = entry.code;
            check.time = entry.time;
            
            return check;
        }
        public static Entities.Check make_to_acceptedCheck(Entities.AcceptedEntry acc_entry)
        {
            Entities.Check check = new Entities.Check();
            check.code = acc_entry.code;
            check.time = acc_entry.time;

            return check;
        }
    }
}