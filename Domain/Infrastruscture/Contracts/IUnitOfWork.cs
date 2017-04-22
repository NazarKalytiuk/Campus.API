using Domain.Infrastruscture.Interaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastruscture.Contracts
{
    public interface IUnitOfWork
    {
        IDepartmentRepository Departments { get; }
        IFacultyRepository Faculties { get; }
        IGroupRepository Groups { get; }
        ISpecialityRepository Specialities { get; }
        IStudentBookNoteRepository StudentBookNotes { get; }
        IStudentBookRepository StudentBooks { get; }
        IStudentRepository Students { get; }
        ITeacherRepository Teachers { get; }

        ApplicationUserManager UserManager { get; }
        ApplicationRoleManager RoleManager { get; }

        Task<int> SaveAsync();
        void Dispose();
        void Dispose(bool disposing);
    }
}
