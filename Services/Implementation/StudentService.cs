using Services.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using RequestModels;
using Domain.Infrastruscture.Contracts;
using DTO.DTOs;
using AutoMapper;
using JetBrains.Annotations;

namespace Services.Implementation
{
    [UsedImplicitly]
    public class StudentService : IStudentService
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public async Task<StudentDTO> CreateStudentAsync(RegisterStudentRequestModel model)
        {
            var user = await _userService.CreateAsync(model);
            var student = new Student() { Id = user.Id, Name = "Name" };
            var studentDto = Mapper.Map<Student, StudentDTO>(student);
            _unitOfWork.Students.Add(student);
            await _unitOfWork.SaveAsync();
            return studentDto;
        }


        public async Task<StudentDTO> GetStudentAsync(string studentId)
        {
            var student = await _unitOfWork.Students.Get(studentId);
            var studentDto = Mapper.Map<Student, StudentDTO>(student);
            return studentDto;
        }

        public async Task<IEnumerable<StudentDTO>> GetStudentsAsync()
        {
            var students = await _unitOfWork.Students.Get();
            var users = Mapper.Map<IEnumerable<Student>, List<StudentDTO>>(students);
            return users;
        }

        public async Task<GroupDTO> GetGroupAsync(string studentId)
        {
            var student = await _unitOfWork.Students.Get(studentId);
            var group = await _unitOfWork.Groups.Get(student.Group.Id);
            var groupDto = Mapper.Map<Group, GroupDTO>(group);
            return groupDto;
        }
    }
}
