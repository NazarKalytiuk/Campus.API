using Domain.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Infrastruscture.Interaction;

namespace Domain.Infrastruscture.Configuration
{
    public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>, IDatabaseInitializer<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            var user1 = new ApplicationUser() { Email = "SergRomanchuk1@gmail.com", UserName = "SergRomanchuk1@gmail.com" };
            var user2 = new ApplicationUser() { Email = "SergRomanchuk2@gmail.com", UserName = "SergRomanchuk2@gmail.com" };
            var user3 = new ApplicationUser() { Email = "SergRomanchuk3@gmail.com", UserName = "SergRomanchuk3@gmail.com" };
            var user4 = new ApplicationUser() { Email = "SergRomanchuk4@gmail.com", UserName = "SergRomanchuk4@gmail.com" };

            var user5 = new ApplicationUser() {Email = "katin@mail.com", UserName = "katin@mail.com"};

            var result = userManager.Create(user1, "Pass-1");
            result = userManager.Create(user2, "Pass-2");
            result = userManager.Create(user3, "Pass-3");
            result = userManager.Create(user4, "Pass-4");
            result = userManager.Create(user5, "Pass-5");

            context.SaveChanges();

            var group1 = new Group() { Name = "GroupName1" };
            context.Groups.Add(group1);

            context.SaveChanges();

            var student1 = new Student() { Id = user1.Id, Name = "StudentName1", Group = group1};
            var student2 = new Student() { Id = user2.Id, Name = "StudentName2" };
            var student3 = new Student() { Id = user3.Id, Name = "StudentName3" };
            var student4 = new Student() { Id = user4.Id, Name = "StudentName4" };

            var teacher1 = new Teacher() {Id = user5.Id, Name = "Katin"};

            context.Teachers.Add(teacher1);

            context.Students.AddRange(new[] { student1, student2, student3, student4 });

            context.SaveChanges();

            group1.Monitor = student1;
            Speciality s = new Speciality() { Code = "6.0.0583", Name = "Програмна інженерія"};
            context.Specialities.Add(s);
            context.SaveChanges();
            group1.Speciality = s;
            group1.Curator = teacher1;
            context.SaveChanges();

            StudentBook studentBook = new StudentBook() {Number = "IT-4112"};
            context.StudentBooks.Add(studentBook);
            context.SaveChanges();
            student1.StudentBook = studentBook;
            context.SaveChanges();

            Department d = new Department() {Name = "АУТС"};
            d.Groups.Add(group1);
            context.Departments.Add(d);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
