using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Infrastruscture.Contracts;
using Domain.Models;
using DTO.DTOs;
using JetBrains.Annotations;
using Services.Contracts;

namespace Services.Implementation
{
    [UsedImplicitly]
    public class GroupService : IGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GroupDTO> CreateAsync(GroupDTO group)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<GroupDTO, Group>());
            var g = Mapper.Map<GroupDTO, Group>(group);
            _unitOfWork.Groups.Add(g);
            return group;
        }

        public async Task DeleteAsync(string id)
        {
            var group = await _unitOfWork.Groups.Get(id);
            if (group == null)
            {
                return;
            }
            _unitOfWork.Groups.Delete(group);
        }

        public async Task<GroupDTO> GetAsync(string id)
        {
            var group = await _unitOfWork.Groups.Get(id);
            Mapper.Initialize(cfg => cfg.CreateMap<Group, GroupDTO>());
            var g = Mapper.Map<Group, GroupDTO>(group);
            return g;
        }

        public async Task<IEnumerable<GroupDTO>> GetAsync()
        {
            var group = await _unitOfWork.Groups.Get();
            Mapper.Initialize(cfg => cfg.CreateMap<Group, GroupDTO>());
            var g = Mapper.Map<IEnumerable<Group>, IEnumerable<GroupDTO>>(group);
            return g;
        }

        public async Task<TeacherDTO> GetCuratorAsync(string id)
        {
            var group = await _unitOfWork.Groups.Get(id);
            var curator = await _unitOfWork.Teachers.Get(group.Curator.Id);
            Mapper.Initialize(cfg => cfg.CreateMap<Teacher, TeacherDTO>());
            var g = Mapper.Map<Teacher, TeacherDTO>(curator);
            return g;
        }

        public async Task<DepartmentDTO> GetDepartmentAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<StudentDTO> GetMonitorAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentDTO>> GetStudentsAsync(string id)
        {
            var students = await _unitOfWork.Students.Get();
            Mapper.Initialize(cfg => cfg.CreateMap<Student, StudentDTO>().ForMember("GroupId", dto => dto.MapFrom(d => d.Group.Id)));
            var users = Mapper.Map<IEnumerable<Student>, List<StudentDTO>>(students);
            return users;
        }
    }
}
