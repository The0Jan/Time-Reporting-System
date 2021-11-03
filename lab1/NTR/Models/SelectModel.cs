using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace NTR.Models {
    public class SelectModel 
    {

        public SelectModel() {}
        public IEnumerable<SelectListItem> Users
        {
            get
            {
                var json = System.IO.File.ReadAllText("baza/users.json");
                var list_of_users = System.Text.Json.JsonSerializer.Deserialize<List<String>>(json); 
                var selection_list = new List<SelectListItem>();
                list_of_users.ForEach(g => selection_list.Add(new SelectListItem(g,g)));
                
                return selection_list;           
            }
        }
    }
}