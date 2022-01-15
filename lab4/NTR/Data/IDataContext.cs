using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NTR.Models;

namespace NTR.Data
{
    public interface IDataContext 
    {
        DbSet<User> Users {get; set;}
        DbSet<Project> Projects {get; set;}
        DbSet<Subcode> Subcodes {get; set;}
        DbSet<Activity> Activities {get; set;}
        DbSet<ProjectPartake> ProjectPartakes {get; set;}

    }
}