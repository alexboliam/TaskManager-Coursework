using AutoMapper;
using TaskManager.BLL.Dtos;
using TaskManager.DAL.Models;

namespace TaskManager.PL.MapperProfiles
{
    public class BLLMapperProfile : Profile
    {
        public BLLMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Task, TaskDto>().ReverseMap();
            CreateMap<Subtask, SubtaskDto>().ReverseMap();
            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<EmployeeProject, EmployeeProjectDto>().ReverseMap();
            CreateMap<Team, TeamDto>().ReverseMap();
        }
    }
}
