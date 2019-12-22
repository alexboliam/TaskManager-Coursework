using AutoMapper;
using TaskManager.BLL.Dtos;
using TaskManager.PL.Models;

namespace TaskManager.PL.MapperProfiles
{
    public class PLMapperProfile : Profile
    {
        public PLMapperProfile()
        {
            CreateMap<EmployeeDto, EmployeeResponse>().ReverseMap();
            CreateMap<ProjectDto, ProjectResponse>().ReverseMap();
            CreateMap<TaskRequest, TaskDto>()
                     .ForPath(dto => dto.CreatedBy.Login, rq => rq.MapFrom(r => r.LoginOfCreatedBy));
            CreateMap<SubtaskRequest, SubtaskDto>()
                     .ForPath(dto => dto.ParentTask.TaskId, rq => rq.MapFrom(r => r.ParentTaskId));
            CreateMap<StatusDto, StatusResponse>().ReverseMap();
            CreateMap<EmployeeDto, EmployeeResponse>().ReverseMap();
            CreateMap<EmployeeProjectDto, EmployeeProjectResponse>().ReverseMap();
            CreateMap<TeamDto, TeamResponse>().ReverseMap();
        }
    }
}
