using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Models;
using MyWebAPI.Repositories;
using System.Collections.Generic;

namespace MyWebAPI.Services
{
    public class ToDosService
    {
        private readonly ToDosRepository _todoRepository;

        public ToDosService(ToDosRepository db) {
            _todoRepository = db;
        }

        public List<ToDo> GetToDo()
        {
            if (_todoRepository.DBNull() == null)
            {
                return null;
            }
            return _todoRepository.GetAllTodo();
        }

        public ToDo GetToDoByID(int id)
        {
            ToDo todo = _todoRepository.Find(id);
            if (_todoRepository.DBNull() == null || todo == null)
            {
                return null;
            }
            return todo;
        }

        public ToDo PostToDo([FromBody]ToDo todo)
        {
            if (todo == null || !(todo.Name is string) || todo.Name == "")
            {
                return null; ;
            }
            _todoRepository.Add(todo);
            _todoRepository.SaveDB();
            return todo;
        }

        public ToDo PutToDo([FromBody]ToDo todo)
        {
            if (todo == null || !(todo.Name is string) || _todoRepository.DBNull() == null || todo.Name == "")
            {
                return null;
            }            
            _todoRepository.Update(todo);
            _todoRepository.SaveDB();
            return todo;
        }

        public bool DeleteToDo(int id)
        {
            ToDo todo = _todoRepository.Find(id); 
            if (todo == null)
            {
                return false;
            }
            _todoRepository.Remove(todo);
            _todoRepository.SaveDB();
            return true;
        }
    }
}
