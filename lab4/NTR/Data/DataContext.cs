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
        public DbSet<NTR.Models.User> Users { get; set; }
        public DbSet<NTR.Models.Project> Projects { get; set; }
        public DbSet<NTR.Models.Subcode> Subcodes { get; set; }
        public DbSet<NTR.Models.Activity> Activities { get; set; }
        public DbSet<NTR.Models.ProjectPartake> ProjectPartakes { get; set; }

        public DataContext()
        {
        }
    }
}