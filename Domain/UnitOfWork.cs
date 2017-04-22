using Domain.Infrastruscture.Contracts;
using Domain.Infrastruscture.Interaction;
using Domain.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        public ApplicationDbContext Db { get; set; }
        public UnitOfWork(ApplicationDbContext db,
            IDepartmentRepository departments,
            IFacultyRepository faculties,
            IGroupRepository groups,
            ISpecialityRepository specialities,
            IStudentBookNoteRepository studentBookNotes,
            IStudentBookRepository studentBooks,
            IStudentRepository students,
            ITeacherRepository teachers)
        {
            Db = db;
            Departments = departments;
            Faculties = faculties;
            Groups = groups;
            Specialities = specialities;
            StudentBookNotes = studentBookNotes;
            StudentBooks = studentBooks;
            Students = students;
            Teachers = teachers;

        }
        public IDepartmentRepository Departments { get; }
        public IFacultyRepository Faculties { get; }
        public IGroupRepository Groups { get; }
        public ISpecialityRepository Specialities { get; }
        public IStudentBookNoteRepository StudentBookNotes { get; }
        public IStudentBookRepository StudentBooks { get; }
        public IStudentRepository Students { get; }
        public ITeacherRepository Teachers { get; }

        public ApplicationUserManager UserManager => new ApplicationUserManager(new UserStore<ApplicationUser>(Db));

        public ApplicationRoleManager RoleManager => new ApplicationRoleManager(new RoleStore<ApplicationRole>(Db));

        public async Task<int> SaveAsync()
        {
            return await Db.SaveChangesAsync();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
