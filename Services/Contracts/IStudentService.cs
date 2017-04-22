using DTO.DTOs;
using RequestModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IStudentService
    {
        Task<StudentDTO> CreateStudentAsync(RegisterStudentRequestModel model);
        Task<StudentDTO> GetStudentAsync(string studentId);
        Task<IEnumerable<StudentDTO>> GetStudentsAsync();
        Task<GroupDTO> GetGroupAsync(string studentId);
    }
}
