using Domain.Models;
using DTO.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IGroupService
    {
        Task<GroupDTO> GetAsync(string id);
        Task<IEnumerable<GroupDTO>> GetAsync();
        Task<GroupDTO> CreateAsync(GroupDTO group);
        Task DeleteAsync(string id);
        Task<TeacherDTO> GetCuratorAsync(string id);
        Task<StudentDTO> GetMonitorAsync(string id);
        Task<DepartmentDTO> GetDepartmentAsync(string id);
        Task<IEnumerable<StudentDTO>> GetStudentsAsync(string id);
    }
}
