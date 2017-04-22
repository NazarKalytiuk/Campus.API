using System.Data.Entity;
using Domain;
using Domain.Infrastruscture.Configuration;
using Domain.Infrastruscture.Contracts;
using Domain.Infrastruscture.Repositories;
using Ninject.Modules;
using Services.Contracts;
using Services.Implementation;

namespace Api.Configuration
{
    public class NinjectConfiguration : NinjectModule
    {
        public override void Load()
        {
            Bind<IDatabaseInitializer<ApplicationDbContext>>().To<ApplicationDbInitializer>().InSingletonScope();
            Bind<ApplicationDbContext>().To<ApplicationDbContext>().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();

            Bind<IDepartmentRepository>().To<DepartmentRepository>().InSingletonScope();
            Bind<IFacultyRepository>().To<FacultyRepository>().InSingletonScope();
            Bind<IGroupRepository>().To<GroupRepository>().InSingletonScope();
            Bind<ISpecialityRepository>().To<SpecialityRepository>().InSingletonScope();
            Bind<IStudentBookNoteRepository>().To<StudentBookNoteRepository>().InSingletonScope();
            Bind<IStudentBookRepository>().To<StudentBookRepository>().InSingletonScope();
            Bind<IStudentRepository>().To<StudentRepository>().InSingletonScope();
            Bind<ITeacherRepository>().To<TeacherRepository>().InSingletonScope();
            Bind<IUserRepository>().To<UserRepository>().InSingletonScope();

            Bind<IStudentService>().To<StudentService>().InSingletonScope();
            Bind<IUserService>().To<UserService>().InSingletonScope();
            Bind<IGroupService>().To<GroupService>().InSingletonScope();
        }
    }
}