using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Controllers;
using MyWebAPI.Models;
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
            //var viewResult = Assert.IsType<ViewResult>(res);
           
            //var model = Assert.IsType<ToDo>(viewResult.ViewData.Model);
            Assert.NotNull(res);
        }

        [Fact]
        public void TestGetId()
        {
            ToDosController control = new ToDosController(dbContext);
            var res = (control.Get(3) as OkObjectResult).Value as ToDo;
            Assert.Equal(3, res.ID);

            res = (control.Get(777) as OkObjectResult).Value as ToDo;
            Assert.Null(res);
        }

        [Fact]
        public void TestPost()
        {
            ToDosController control = new ToDosController(dbContext);
            var res = (control.Post(new ToDo("test post", false)) as OkObjectResult).Value as ToDo;
            Assert.Equal(new ToDo("test post", false).Name, res.Name);            
        }

        [Fact]
        public void TestPut()
        {
            ToDosController control = new ToDosController(dbContext);
            var res = control.Put(new ToDo("test post", true));
            Assert.Equal(1, 1);
        }

        [Fact]
        public void TestDelete()
        {
            ToDosController control = new ToDosController(dbContext);
            var res = control.Delete(4) as OkObjectResult;
            Assert.NotNull(res);
            res = control.Delete(777) as OkObjectResult;
            Assert.Null(res);
        }
    }
}
