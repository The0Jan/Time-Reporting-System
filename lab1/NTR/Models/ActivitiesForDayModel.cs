using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
namespace NTR.Models {
    public class ActivitiesForDayModel {

        public ActivitiesForDayModel(string user_name) {
            this.SelectedDate = DateTime.Today.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.Activities = Entities.Report.load(user_name, DateTime.Today);

        }

        public ActivitiesForDayModel(string user_name, DateTime date) {
            this.SelectedDate = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            this.Activities = Entities.Report.load(user_name, date);

        }

        public string SelectedDate;

        public Entities.Report Activities;
    }
}