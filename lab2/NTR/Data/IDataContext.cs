using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NTR.Models;

namespace NTR.Data
{
    public interface IDataContext 
    {
        DbSet<UserModel> Users {get; set;}

    }
}