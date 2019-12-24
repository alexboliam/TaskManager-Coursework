using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskManager.BLL.Dtos;
using TaskManager.BLL.Interfaces;
using TaskManager.PL.Models;

namespace TaskManager.PL.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        ITaskService taskService;
        IMapper mapper;

        public TasksController(ITaskService taskService, IMapper mapper)
        {
            this.taskService = taskService;
            this.mapper = mapper;
        }

        #region Tasks stuff
        [HttpGet("{taskId}")]
        public IActionResult GetTaskById(Guid taskId)
        {
            try
            {
                var task = taskService.GetTaskById(taskId);
                if (task != null)
                {
                    return Ok(mapper.Map<TaskResponse>(task));
                }
                else
                {
                    return StatusCode(404, "Requested task was not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("project/{projectId}")]
        public IActionResult GetTasksByProjectId(Guid projectId)
        {
            try
            {
                var tasks = taskService.GetTasksByProjectId((Guid)projectId);
                if (tasks != null)
                {
                    return Ok(mapper.Map<ICollection<TaskResponse>>(tasks));
                }
                else
                {
                    return StatusCode(404, "Requested project was not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost("project/{projectId}")]
        public IActionResult CreateTask(Guid projectId, [FromBody] TaskRequest task)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                var newTask = mapper.Map<TaskDto>(task);
                var added = taskService.CreateTask(projectId, newTask);
                return StatusCode(201, "Task was created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{taskId}")]
        public IActionResult UpdateTask(Guid taskId, [FromBody] TaskRequest task)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                var newTask = mapper.Map<TaskDto>(task);
                newTask.TaskId = taskId;
                var updated = taskService.UpdateTask(newTask);
                if (updated)
                {
                    return StatusCode(201, "Task was updated");
                }
                else
                {
                    return StatusCode(404, "Task not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{taskId}")]
        public IActionResult DeleteTask(Guid taskId, [FromBody] TaskRequest task)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                var delTask = mapper.Map<TaskDto>(task);
                delTask.TaskId = taskId;
                var updated = taskService.DeleteTask(delTask);
                if (updated)
                {
                    return StatusCode(201, "Task was deleted");
                }
                else
                {
                    return StatusCode(404, "Task not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{taskId}/workers")]
        public IActionResult GetWorkersByTaskId(Guid taskId)
        {
            try
            {
                var workers = taskService.GetWorkersByTaskId(taskId);

                if (workers != null)
                {
                    return Ok(mapper.Map<ICollection<EmployeeTaskResponse>>(workers));
                }
                else
                {
                    return StatusCode(404, "Requested task was not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error. " + ex.Message);
            }
        }
        #endregion

        #region Subtasks stuff
        [HttpPost("{taskId}/subtasks")]
        public IActionResult CreateSubtask(Guid taskId, [FromBody] SubtaskRequest subtask)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                var newSubtask = mapper.Map<SubtaskDto>(subtask);
                var added = taskService.CreateSubtask(taskId, newSubtask);
                return StatusCode(201, "Subtask was created");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("subtasks/{subtaskId}")]
        public IActionResult GetSubtaskById(Guid subtaskId)
        {
            try
            {
                var subtask = taskService.GetTaskById(subtaskId);
                if (subtask != null)
                {
                    return Ok(mapper.Map<SubtaskResponse>(subtask));
                }
                else
                {
                    return StatusCode(404, "Requested subtask was not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{taskId}/subtasks")]
        public IActionResult GetSubtasksByTaskId(Guid taskId)
        {
            try
            {
                var subtasks = taskService.GetSubtasksByTaskId((Guid)taskId);
                if (subtasks != null)
                {
                    return Ok(mapper.Map<ICollection<SubtaskResponse>>(subtasks));
                }
                else
                {
                    return StatusCode(404, "Requested task was not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("subtasks/{subtaskId}")]
        public IActionResult UpdateSubtask(Guid subtaskId, [FromBody] SubtaskRequest subtask)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                var newSubtask = mapper.Map<SubtaskDto>(subtask);
                newSubtask.SubtaskId = subtaskId;
                var updated = taskService.UpdateSubtask(newSubtask);
                if (updated)
                {
                    return StatusCode(201, "Subtask was updated");
                }
                else
                {
                    return StatusCode(404, "Subtask not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("subtasks/{subtaskId}")]
        public IActionResult DeleteSubtask(Guid subtaskId, [FromBody] SubtaskRequest subtask)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model is not valid");
            }

            try
            {
                var delSubtask = mapper.Map<SubtaskDto>(subtask);
                delSubtask.SubtaskId = subtaskId;
                var deleted = taskService.UpdateSubtask(delSubtask);
                if (deleted)
                {
                    return StatusCode(201, "Subtask was deleted");
                }
                else
                {
                    return StatusCode(404, "Subtask not found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        } 
        #endregion

    }
}