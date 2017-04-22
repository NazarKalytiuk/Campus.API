using Domain.Infrastruscture.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastruscture.Repositories
{
    public class StudentBookRepository : Repository<StudentBook>, IStudentBookRepository
    {
        public StudentBookRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }
    }
}
