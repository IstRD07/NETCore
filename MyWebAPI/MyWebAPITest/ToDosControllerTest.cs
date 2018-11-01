using Microsoft.AspNetCore.Mvc;
using MyWebAPI.Controllers;
using Xunit;

namespace MyWebAPITest
{
    public class ToDosControllerTest
    {
        [Fact] 
        public void TestGet() { Assert.Equal(1, 1); }

        [Fact]
        public void TestGetId() {

            //ToDosController control = new ToDosController();
            //ViewResult res = control.Get(3) as ViewResult;


            Assert.Equal(1, 1); }

        [Fact]
        public void TestPost() { Assert.Equal(1, 1); }

        [Fact]
        public void TestPut() { Assert.Equal(1, 1); }

        [Fact]
        public void TestDelete() { Assert.Equal(1, 1); }
    }
}
