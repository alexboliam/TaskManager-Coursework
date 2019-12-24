using System;
using System.Collections.Generic;
using TaskManager.BLL.Dtos;

namespace TaskManager.BLL.Interfaces
{
    public interface ITaskService
    {
        ICollection<TaskDto> GetTasksByProjectId(Guid projectId);
        TaskDto GetTaskById(Guid taskId);

        bool CreateTask(Guid projectId, TaskDto task);
        bool UpdateTask(TaskDto task);
        bool DeleteTask(TaskDto task);

        ICollection<SubtaskDto> GetSubtasksByTaskId(Guid taskId);
        SubtaskDto GetSubtaskById(Guid subtaskId);
        bool CreateSubtask(Guid taskId, SubtaskDto subtask);
        bool UpdateSubtask(SubtaskDto subtask);
        bool DeleteSubtask(SubtaskDto subtask);

        IEnumerable<EmployeeTaskDto> GetWorkersByTaskId(Guid taskId);

    }
}
