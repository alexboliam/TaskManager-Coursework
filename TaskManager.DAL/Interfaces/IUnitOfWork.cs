

namespace TaskManager.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        IProjectRepository Projects { get; }
        ITaskRepository Tasks { get; }
        ISubtaskRepository Subtasks { get; }
        ITeamRepository Teams { get; }
        IEmployeeTeamsRepository EmployeeTeams { get; }
        IEmployeeTasksRepository EmployeeTasks { get; }

        void Save();
    }
}
