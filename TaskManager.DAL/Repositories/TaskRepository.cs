using TaskManager.DAL.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.DAL.Repositories
{
    internal class TaskRepository : RepositoryBase<Task>, ITaskRepository
    {
        public TaskRepository(TaskManagerContext context) : base(context)
        {
        }
    }
}
