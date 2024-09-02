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

        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<TaskDTO>> Get()
        {
            var result = _tasksService.GetAllTaskDTOs();
            return Ok(result);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
