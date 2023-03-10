using CustomerWebApplication.Interfaces;
using CustomerWebApplication.Models.UtilityModels;
using CustomerWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebApplication.Controllers
{
    [ApiController]
    public class TasksController : ControllerBase
    {

        private ITasksData _tasksData;

        public TasksController(ITasksData TasksData)
        {
            _tasksData = TasksData;
        }

        // GET: api/<TasksController>
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetTasks()
        {
            var tasks = _tasksData.GetTasks();
            return Ok(tasks);
        }

        // GET api/<TasksController>/5
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetTaskById(Guid id)
        {
            var task = _tasksData.GetTasks(id);
            if (task != null)
            {
                return Ok(task);
            }

            return NotFound($"Task with Id: {id} was not found");
        }

        // POST api/<TasksController>
        [HttpPost]
        [Route("api/[controller]/create")]
        public IActionResult AddTask(Tasks task)
        {
            _tasksData.AddTask(task);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host +
                HttpContext.Request.Path + "/" + task.Id, task);
        }

        // PUT api/<TasksController>/5
        [HttpPut]
        [Route("api/[controller]/{id}/edit")]
        public IActionResult EditTask(Guid id, Tasks task)
        {
            var existingTask = _tasksData.GetTasks(id);
            if (existingTask != null)
            {
                task.TaskId = existingTask.TaskId;
                _tasksData.EditTask(task);
            }

            return Ok("Task Has Been Updated Successfully");
        }

        // DELETE api/<TasksController>/5
        [HttpDelete]
        [Route("api/[controller]/{taskId}/delete")]
        public IActionResult Delete(Guid taskId)
        {
            var task = _tasksData.GetTasks(taskId);
            if (task != null)
            {
                _tasksData.DeleteTask(task);
                return Ok();
            }
            return NotFound($"Task with Id: {taskId} was not found");
        }

        //Assigned Task
        [HttpPost]
        [Route("api/[controller]/{taskId}/assignedTo")]
        public IActionResult AssignedTask([FromBody] AssignedTo value)
        {
            if (value.TaskId.ToString() != null && value.WorkerId.ToString() != null)
            {
                _tasksData.AssignedTaskTo(value);
                return Ok($"Task Has Beesn Assigned To {value.WorkerId}");
            }
            return NotFound($"Task with Id: {value.TaskId} was not found");
        }

    }



    /*: Controller
{
    public IActionResult Index()
    {
        return View();
    }
}*/

}
