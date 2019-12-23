using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.BLL.Dtos;

namespace TaskManager.BLL.Interfaces
{
    public interface IProjectService
    {
        IEnumerable<ProjectDto> GetProjectsByEmployeeLogin(string login);
    }
}
