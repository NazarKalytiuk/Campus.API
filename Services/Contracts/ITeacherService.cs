using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.DTOs;

namespace Services.Contracts
{
    public interface ITeacherService
    {
        Task<TeacherDTO> CreateTeacherAsync();
        Task<IEnumerable<TeacherDTO>> GeTeachersAsync();
        Task<TeacherDTO> GetTeacherAsync(string id);
    }
}
