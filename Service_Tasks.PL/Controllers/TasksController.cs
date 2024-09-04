using Microsoft.AspNetCore.Mvc;
using Service_Tasks.BLL.Models;
using Service_Tasks.BLL.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Service_Tasks.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private TasksService _tasksService;

        public TasksController(TasksService tasksService)
        {
            _tasksService = tasksService;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public ActionResult<IEnumerable<TaskDTO>> Get()
        {
            var result = _tasksService.GetAllTaskDTOs();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<TaskDTO>> Get(int id)
        {
            var result = _tasksService.GetByIdTaskDTOs(id);
            return Ok(result);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public ActionResult<TaskDTO> Post([FromBody] TaskDTO value)
        {
            var result = _tasksService.AddNewTaskDTO(value);
            return Ok(result);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult<TaskDTO> Put(int id, [FromBody] TaskDTO value)
        {
            var result = _tasksService.RenameTaskDTO(value);
            return Ok(result);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            var result = _tasksService.DeleteTaskDTO(id);
            return Ok(result);
        }
    }
}
