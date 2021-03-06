using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NTR.Models;

namespace NTR.Data
{
    public interface IDataContext 
    {
        DbSet<UserModel> Users {get; set;}
        DbSet<ProjectModel> Projects {get; set;}
        DbSet<SubcodeModel> Subcodes {get; set;}
        DbSet<ActivityModel> Activities {get; set;}
        DbSet<ProjectPartake> ProjectPartakes {get; set;}

    }
}