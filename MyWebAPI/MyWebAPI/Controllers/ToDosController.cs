﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ToDosController : Controller
    {
        ToDosContext db;

        public ToDosController(ToDosContext context) {
            this.db = context;
            if (!db.ToDos.Any()) {
                db.ToDos.Add(new ToDo("Task 1"));
                db.ToDos.Add(new ToDo("Task 2"));
                db.ToDos.Add(new ToDo("Task 3"));
                db.ToDos.Add(new ToDo("Task 4"));
                db.ToDos.Add(new ToDo("Task 5"));
                db.SaveChanges();
            }
        }

        public ToDosController()
        {
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<ToDo> Get()
        {
            return db.ToDos.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ToDo todo = db.ToDos.FirstOrDefault(x => x.ID == id);
            return new ObjectResult(todo);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]ToDo todo)
        {
            if (todo == null)
            {
                return BadRequest();
            }
            db.ToDos.Add(todo);
            db.SaveChanges();
            return Ok(todo);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put([FromBody]ToDo todo)
        {
            if (todo == null)
            {
                return BadRequest();
            }
            if (!db.ToDos.Any(x => x.ID == todo.ID))
            {
                return NotFound();
            }

            db.Update(todo);
            db.SaveChanges();
            return Ok(todo);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ToDo todo = db.ToDos.FirstOrDefault(x => x.ID == id);
            if (todo == null)
            {
                return NotFound();
            }
            db.ToDos.Remove(todo);
            db.SaveChanges();
            return Ok(todo);
        }
    }
}