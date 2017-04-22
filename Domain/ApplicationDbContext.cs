using Domain.Infrastruscture.Configuration;
using Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Domain
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentBook> StudentBooks { get; set; }
        //public DbSet<StudentBookNote> StudentBookNotes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        //public DbSet<Subject> Subjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Speciality> Specialities { get; set; }

        public ApplicationDbContext(IDatabaseInitializer<ApplicationDbContext> databaseInitializer)
            : base("name=Campus", throwIfV1Schema: false)
        {
            //AppDomain.CurrentDomain.SetData("DataDirectory", "C:\\Users\\Nazar\\Desktop\\auth2");
            Database.SetInitializer(databaseInitializer);
        }
        public ApplicationDbContext() : base("name=Campus", throwIfV1Schema: false)
		{
            //AppDomain.CurrentDomain.SetData("DataDirectory", "C:\\Users\\Nazar\\Desktop\\auth2");
            Database.SetInitializer(new ApplicationDbInitializer());
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
