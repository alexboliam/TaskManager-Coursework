using TaskManager.DAL.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.DAL.Repositories
{
    internal class SubtaskRepository : RepositoryBase<Subtask>, ISubtaskRepository
    {
        public SubtaskRepository(TaskManagerContext context) : base(context)
        {
        }
    }
}
