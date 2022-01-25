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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User{ UserId = 1, First_Name = "kowalski"},
            new User{ UserId = 2, First_Name = "szeregowy"},
            new User{ UserId = 3, First_Name = "rico"}
        );

        modelBuilder.Entity<Project>().HasData(
            new Project{ ProjectCode = "ARG", UserId = 1, Title = "ARGUS-15", Active=true, Budget=1000},
            new Project{ ProjectCode = "BARK", UserId = 1, Title = "BARKUS-16", Active=true, Budget=1000},
            new Project{ ProjectCode = "SMARK", UserId = 2, Title = "SMARKUS-17", Active=true, Budget=1000},
            new Project{ ProjectCode = "DARK", UserId = 3, Title = "DARKUS-18", Active=false, Budget=1000}
        );

        modelBuilder.Entity<Subcode>().HasData(
            new Subcode{ Name = "refactor", ProjectCode = "ARG"},
            new Subcode{ Name = "debugging", ProjectCode = "ARG"},
            new Subcode{ Name = "lunch-break", ProjectCode = "ARG"},
            new Subcode{ Name = "testing", ProjectCode = "ARG"},
            new Subcode{ Name = "compiling", ProjectCode = "BARK"},
            new Subcode{ Name = "deploying", ProjectCode = "BARK"},
            new Subcode{ Name = "consulting", ProjectCode = "BARK"},
            new Subcode{ Name = "programming", ProjectCode = "SMARK"},
            new Subcode{ Name = "downtime", ProjectCode = "DARK"}
        );

        modelBuilder.Entity<Activity>().HasData(
            new Activity{ ActivityId = 1, Date = DateTime.Parse("2022-01-26"), Time = 100, Description = "Fun Times", Frozen=false, UserId =1 , ProjectCode = "ARG", SubcodeName = "refactor"},
            new Activity{ ActivityId = 2, Date =  DateTime.Parse("2022-01-26"), Time = 100, Description = "Funnier Times", Frozen=false, UserId =1 , ProjectCode = "ARG", SubcodeName = "debugging"},
            new Activity{ ActivityId = 3, Date =  DateTime.Parse("2022-01-26"), Time = 100, Description = "Funniest Times", Frozen=false, UserId =1 , ProjectCode = "ARG", SubcodeName = "debugging"},
            new Activity{ ActivityId = 4, Date =  DateTime.Parse("2022-01-26"), Time = 100, Description = "Funnnos Timos", Frozen=false, UserId =1 , ProjectCode = "ARG", SubcodeName = "lunch-break"},
            new Activity{ ActivityId = 5, Date =  DateTime.Parse("2022-01-26"), Time = 100, Description = "Funmosity Timosity", Frozen=false, UserId =1 , ProjectCode = "BARK", SubcodeName = "deploying"},
            new Activity{ ActivityId = 6, Date =  DateTime.Parse("2022-01-26"), Time = 100, Description = "Programming in C", Frozen=false, UserId =1 , ProjectCode = "SMARK", SubcodeName = "programming"},
            new Activity{ ActivityId = 7, Date =  DateTime.Parse("2022-01-26"), Time = 100, Description = "Programming in C#", Frozen=false, UserId =1 , ProjectCode = "SMARK", SubcodeName = "programming"},
            new Activity{ ActivityId = 8, Date =  DateTime.Parse("2022-01-26"), Time = 100, Description = "Waiting", Frozen=false, UserId =1 , ProjectCode = "BARK", SubcodeName = "compiling"},
            new Activity{ ActivityId = 9, Date =  DateTime.Parse("2022-01-26"), Time = 100, Description = "Done waiting", Frozen=false, UserId =1 , ProjectCode = "BARK", SubcodeName = "compiling"},
            new Activity{ ActivityId = 10, Date = DateTime.Parse("2022-01-26"), Time = 100, Description = "Boss came", Frozen=false, UserId =1 , ProjectCode = "BARK", SubcodeName = "consulting"}
        );

        modelBuilder.Entity<ProjectPartake>().HasData(
            new ProjectPartake{ ProjectPartakeId = 1, SubmittedTime = 400, AcceptedTime = 0, Year = 2022, Month = 1, Submitted=false,  ProjectCode = "ARG",  UserId =1},
            new ProjectPartake{ ProjectPartakeId = 2, SubmittedTime = 400, AcceptedTime = 120, Year = 2022, Month = 1, Submitted=false,  ProjectCode = "BARK",  UserId =1},
            new ProjectPartake{ ProjectPartakeId = 3, SubmittedTime = 200, AcceptedTime = 200, Year = 2022, Month = 1, Submitted=false,  ProjectCode = "SMARK",  UserId =1}

        );
    }
    }
}