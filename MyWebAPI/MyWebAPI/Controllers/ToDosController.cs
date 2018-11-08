using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using MyWebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ToDosController : Controller
    {
        private readonly ToDosService _todoService;

        public ToDosController(ToDosService todoService)
        {
            _todoService = todoService;
        }
            // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var res = _todoService.GetToDo();
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == default(int))
            {
                return BadRequest();
            }
            var res = _todoService.GetToDoByID(id);
            if (res == null)
            {
                return NotFound();
            }            
            return Ok(res);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]ToDo todo)
        {
            var res = _todoService.PostToDo(todo);
            if (res == null)
            {
                return BadRequest();
            }            
            return Ok(res);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put([FromBody]ToDo todo)
        {
            var res = _todoService.PutToDo(todo);
            if (res == null) {
                return BadRequest();
            }
            return Ok(todo);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == default(int))
            {
                return BadRequest();
            }
            var res = _todoService.DeleteToDo(id);            
            if (res == false)
            {
                return BadRequest();
            }                      
            return Ok(res);
        }
    }
}
