using AutoMapper;
using TaskManager.BLL.Dtos;
using TaskManager.DAL.Models;

namespace TaskManager.PL.MapperProfiles
{
    public class BLLMapperProfile : Profile
    {
        public BLLMapperProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap().PreserveReferences();
            CreateMap<Project, ProjectDto>().ReverseMap().PreserveReferences();
            CreateMap<Task, TaskDto>().ReverseMap().PreserveReferences();
            CreateMap<Subtask, SubtaskDto>().ReverseMap().PreserveReferences();
            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<EmployeeTeam, EmployeeTeamDto>().ReverseMap().PreserveReferences();
            CreateMap<EmployeeProject, EmployeeProjectDto>().ReverseMap().PreserveReferences();
            CreateMap<Team, TeamDto>().ReverseMap().PreserveReferences();
            
        }
    }
}
