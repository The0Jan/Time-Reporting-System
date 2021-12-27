using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NTR.Models
{
    public class UserModel
    {
        public int UserModelId { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        [Timestamp]
        public DateTime Timestamp {get; set;}
    }
}