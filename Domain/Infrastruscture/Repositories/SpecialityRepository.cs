using Domain.Infrastruscture.Contracts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Infrastruscture.Repositories
{
    public class SpecialityRepository : Repository<Speciality>, ISpecialityRepository
    {
        public SpecialityRepository(ApplicationDbContext dbContext) : base(dbContext)
        { }
    }
}
