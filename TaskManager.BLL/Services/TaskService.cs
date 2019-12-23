using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.BLL.Dtos;
using TaskManager.BLL.Interfaces;
using TaskManager.DAL.Interfaces;
using TaskManager.DAL.Models;

namespace TaskManager.BLL.Services
{
    public class TaskService : ITaskService
    {
        private IMapper mapper;
        private IUnitOfWork unit;

        public TaskService(IMapper mapper, IUnitOfWork unit)
        {
            this.mapper = mapper;
            this.unit = unit;
        }

        #region CRUD Task
        public bool CreateTask(Guid projectId, TaskDto task)
        {
            var project = unit.Projects.FindByCondition(x => x.ProjectId.Equals(projectId)).FirstOrDefault();
            if (project == null)
            {
                return false;
            }

            var newTask = mapper.Map<Task>(task);
            newTask.Status = Status.Created;
            newTask.CreatedBy = unit.Employees.FindByCondition(x => x.Login.Equals(task.CreatedBy.Login)).FirstOrDefault();
            if (newTask.CreatedBy == null)
            {
                return false;
            }

            project.Tasks.ToList().Add(newTask);
            unit.Save();
            return true;
        }

        public bool UpdateTask(TaskDto task)
        {
            var updTask = unit.Tasks.FindByCondition(x => x.TaskId.Equals(task.TaskId)).FirstOrDefault();
            if (updTask == null)
            {
                return false;
            }

            updTask.Name = task.Name;
            updTask.Status = mapper.Map<Status>(task.Status);
            updTask.Deadline = task.Deadline;

            unit.Tasks.Update(updTask);
            unit.Save();
            return true;
        }
        public bool DeleteTask(TaskDto task)
        {
            var delTask = unit.Tasks.FindByCondition(x => x.TaskId.Equals(task.TaskId)).FirstOrDefault();
            if (delTask == null)
            {
                return false;
            }

            delTask.Name = task.Name;
            delTask.Status = mapper.Map<Status>(task.Status);
            delTask.Deadline = task.Deadline;

            unit.Tasks.Delete(delTask);
            unit.Save();
            return true;
        }
        #endregion

        #region CRUD Subtasks
        public bool CreateSubtask(Guid taskId, SubtaskDto subtask)
        {
            var task = unit.Tasks.FindByCondition(x => x.TaskId.Equals(taskId)).FirstOrDefault();
            if (task == null)
            {
                return false;
            }

            var newSubtask = mapper.Map<Subtask>(subtask);
            newSubtask.Status = false;
            newSubtask.ParentTask = task;

            task.Subtasks.ToList().Add(newSubtask);
            unit.Save();
            return true;
        }
        public bool UpdateSubtask(SubtaskDto subtask)
        {
            var updSubtask = unit.Subtasks.FindByCondition(x => x.SubtaskId.Equals(subtask.SubtaskId)).FirstOrDefault();
            if (updSubtask == null)
            {
                return false;
            }

            updSubtask.Name = subtask.Name;
            updSubtask.Status = subtask.Status;

            unit.Subtasks.Update(updSubtask);
            unit.Save();
            return true;
        }
        public bool DeleteSubtask(SubtaskDto subtask)
        {
            var deltSubtask = unit.Subtasks.FindByCondition(x => x.SubtaskId.Equals(subtask.SubtaskId)).FirstOrDefault();
            if (deltSubtask == null)
            {
                return false;
            }

            deltSubtask.Name = subtask.Name;
            deltSubtask.Status = subtask.Status;

            unit.Subtasks.Delete(deltSubtask);
            unit.Save();
            return true;
        }
        #endregion

        #region Get Tasks
        public TaskDto GetTaskById(Guid taskId)
        {
            var task = unit.Tasks.FindByCondition(x => x.TaskId.Equals(taskId)).FirstOrDefault();
            if (task != null)
            {
                return mapper.Map<TaskDto>(task);
            }
            else
            {
                return null;
            }
        }
        public ICollection<TaskDto> GetTasksByProjectId(Guid projectId)
        {
            var project = unit.Projects.FindByCondition(x => x.ProjectId.Equals(projectId)).FirstOrDefault();
            if (project == null)
            {
                return null;
            }

            var tasks = project.Tasks.ToList();
            return mapper.Map<ICollection<TaskDto>>(tasks);
        }
        #endregion

        #region Get Subtasks
        public ICollection<SubtaskDto> GetSubtasksByTaskId(Guid taskId)
        {
            var task = unit.Tasks.FindByCondition(x => x.TaskId.Equals(taskId)).FirstOrDefault();
            if (task == null)
            {
                return null;
            }

            var subtasks = task.Subtasks.ToList();
            return mapper.Map<ICollection<SubtaskDto>>(subtasks);
        }
        public SubtaskDto GetSubtaskById(Guid subtaskId)
        {
            var subtask = unit.Subtasks.FindByCondition(x => x.SubtaskId.Equals(subtaskId)).FirstOrDefault();
            if (subtask != null)
            {
                return mapper.Map<SubtaskDto>(subtask);
            }
            else
            {
                return null;
            }
        } 
        #endregion
    }
}
