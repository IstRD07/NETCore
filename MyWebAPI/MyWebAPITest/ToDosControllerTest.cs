using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Controllers;
using MyWebAPI.Models;
using MyWebAPI.Services;
using MyWebAPI.Repositories;
using System.Linq;

using System.Net.Http;
using System.Text;
using Xunit;

namespace MyWebAPITest
{
    public class ToDosControllerTest
    {
        ToDosContext dbContext;
        readonly ToDosController control;

        public ToDosControllerTest()
        {
            string con = "Server=(localdb)\\mssqllocaldb;Database=todosdb;Trusted_Connection=True;MultipleActiveResultSets=true";
            var options = new DbContextOptionsBuilder<ToDosContext>()
                .UseSqlServer(con).Options;
            dbContext = new ToDosContext(options);
            control = new ToDosController(new ToDosService(new ToDosRepository(dbContext)));
        }

        [Fact]
        public void TestGet()
        {
            var res = control.Get();      
            Assert.NotNull(res);
        }

        [Fact]
        public void TestGetId()
        {
            int id = dbContext.ToDos.LastOrDefault().ID;
            ToDo res = (control.Get(id) as OkObjectResult).Value as ToDo;
            Assert.Equal(id, res.ID);
            res = (control.Get(++id) as ToDo);
            Assert.Null(res);
            
        }

        [Fact]
        public void TestPost()
        {
            var res = (control.Post(new ToDo("test post", false)) as OkObjectResult).Value as ToDo;
            Assert.NotNull(res);
        }

        [Fact]
        public void TestPut()
        {
            int id = dbContext.ToDos.AsNoTracking().FirstOrDefault().ID;
            var res = (control.Put(new ToDo { ID = id, Name = "last id test put", Status = false }) as ObjectResult).Value as ToDo;
            Assert.NotNull(res);
        }

        [Fact]
        public void TestDelete()
        {
            int id = dbContext.ToDos.AsNoTracking().LastOrDefault().ID;
            var res = control.Delete(id) as OkObjectResult;
            Assert.NotNull(res);
            res = control.Delete(++id) as OkObjectResult;
            Assert.Null(res);
        }
    }
}
