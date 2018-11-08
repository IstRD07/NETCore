using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Repositories
{
    public class ToDosRepository
    {

        private readonly ToDosContext db;

        public ToDosRepository(ToDosContext context)
        {
            db = context; //?? throw new ArgumentNullException(nameof(context));

            if (!db.ToDos.Any())
            {
                db.ToDos.Add(new ToDo("Task 1"));
                db.ToDos.Add(new ToDo("Task 2"));
                db.ToDos.Add(new ToDo("Task 3"));
                db.ToDos.Add(new ToDo("Task 4"));
                db.ToDos.Add(new ToDo("Task 5"));
                db.SaveChanges();
            }
        }

        public ToDo Add(ToDo todo)
        {
            return db.ToDos.Add(todo).Entity;
        }

        public ToDo Update(ToDo todo) {
            return db.ToDos.Update(todo).Entity;
        }

        public ToDo Remove(ToDo todo)
        {
            return db.ToDos.Remove(todo).Entity;
        }

        public void SaveDB() {
            db.SaveChanges();
        }

        public List<ToDo> DBNull() {
            if (!db.ToDos.AsNoTracking().Any()) {
                return null;
            } return db.ToDos.AsNoTracking().ToList();
        }

        public List<ToDo> GetAllTodo() {
            return db.ToDos.ToList();
        }

        public ToDo Find(int id) {
            return db.ToDos.AsNoTracking().FirstOrDefault(x => x.ID == id);
        }

        public async Task<ToDo> FindAsync(int id)
        {
            var todo = await db.ToDos
                .Where(t => t.ID == id)
                .SingleOrDefaultAsync();

            return todo;
        }

        
    }
}
