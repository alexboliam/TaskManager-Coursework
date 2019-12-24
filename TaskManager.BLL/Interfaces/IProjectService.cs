using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.BLL.Dtos;

namespace TaskManager.BLL.Interfaces
{
    public interface IProjectService
    {
        ICollection<ProjectDto> GetProjectsByEmployeeLogin(string login);
        ProjectDto GetProjectByProjectId(Guid projectId);
        TeamDto GetTeamByProjectId(Guid projectId);

        bool CreateProject(ProjectDto project);
        void UpdateProjectStatuses(ProjectDto project);

    }
}
