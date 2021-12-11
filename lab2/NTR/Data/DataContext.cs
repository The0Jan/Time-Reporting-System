using Microsoft.EntityFrameworkCore;
using NTR.Models;

namespace NTR.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<NTR.Models.UserModel> Users { get; set; }
        public DbSet<NTR.Models.ProjectModel> Projects { get; set; }
        public DbSet<NTR.Models.ActivityModel> Activities { get; set; }
        public DbSet<NTR.Models.SubcodeModel> Subcodes { get; set; }

    }
}