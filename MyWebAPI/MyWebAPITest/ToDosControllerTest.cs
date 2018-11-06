using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Controllers;
using MyWebAPI.Models;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;

namespace MyWebAPITest
{
    public class ToDosControllerTest
    {
        ToDosContext dbContext;

        public ToDosControllerTest()
        {
            string con = "Server=(localdb)\\mssqllocaldb;Database=todosdb;Trusted_Connection=True;MultipleActiveResultSets=true";
            var options = new DbContextOptionsBuilder<ToDosContext>()
                .UseSqlServer(con).Options;
                //.UseInMemoryDatabase(databaseName: "todosdb")
                // .Options;
            dbContext = new ToDosContext(options);
        }

        [Fact]
        public void TestGet()
        {
            ToDosController control = new ToDosController(dbContext);
            var res = control.Get();      
            Assert.NotNull(res);
        }

        [Fact]
        public void TestGetId()
        {
            ToDosController control = new ToDosController(dbContext);
            int id = dbContext.ToDos.LastOrDefault().ID;
            ToDo res = (control.Get(id) as OkObjectResult).Value as ToDo;
            Assert.Equal(id, res.ID);
            res = (control.Get(++id) as OkObjectResult).Value as ToDo;
            Assert.Null(res);
        }

        [Fact]
        public void TestPost()
        {
            ToDosController control = new ToDosController(dbContext);            
            var res = (control.Post(new ToDo("test post", false)) as OkObjectResult).Value as ToDo;            
            Assert.NotNull(res);          
        }

        [Fact]
        public void TestPut()
        {
            ToDosController control = new ToDosController(dbContext);            
            var res = (control.Put(new ToDo { ID = 7, Name = "test put", Status = false }) as ObjectResult).Value as ToDo;
            Assert.NotNull(res);
        }

        [Fact]
        public void TestDelete()
        {
            ToDosController control = new ToDosController(dbContext);
            int id = dbContext.ToDos.LastOrDefault().ID;
            var res = control.Delete(id) as OkObjectResult;
            Assert.NotNull(res);
            res = control.Delete(++id) as OkObjectResult;
            Assert.Null(res);
        }
    }
}
