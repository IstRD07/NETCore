using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //List<ToDo> data = new List<ToDo> {
        //        new ToDo(1),
        //        new ToDo(2,"ToDo 2"),
        //        new ToDo(3,"ToDo 3"),
        //        new ToDo(4,"ToDo 4"),
        //        new ToDo(5,"ToDo 5",true),
        //        new ToDo(6,"ToDo 6",true),
        //        new ToDo(7,"ToDo 7",true)
        //    };

        //// GET api/values
        //[HttpGet]
        //public ActionResult<List<ToDo>> Get()
        //{
        //    return data;
        //}
     
        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<ToDo> Get(int id)
        //{
        //    return data.Find(x => x.id == id);
        //}

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
