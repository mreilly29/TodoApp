using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using TodoApp.Controllers;
using TodoApp.Models;
using Xunit;

namespace TodoApp.Tests
{
    public class HomeControllerTests
    {
        private ITodoRepository repo;
        private HomeController underTest;

        public HomeControllerTests()
        {
            repo = Substitute.For<ITodoRepository>();
            underTest = new HomeController(repo);
        }

        [Fact]
        public void Index_Returns_A_View()
        {
            var result = underTest.Index();

            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Index_Passes_Todos_To_View()
        {
            var expectedModel = new List<Todo>();
            repo.GetAll().Returns(expectedModel);
            

            var result = underTest.Index();
            var model = result.Model;

            //assert SAME OBJECT(same instance) not if the values are equal. You want SAME THING!
            Assert.Same(expectedModel, model);
            //assert that All Todos were passed into View.
        }
        [Fact]
        public void Details_Gets_Correct_Todo()
        {
            var id = 1;

            underTest.Details(id);

            repo.Received().GetById(id);
        }
        [Fact]
        public void Details_Returns_A_View()
        {

            var id = 1;
            var result = underTest.Details(id);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Details_Returns_Correct_View()
        {

            var id = 1;
            var expectedModel = new Todo();
            repo.GetById(id).Returns(expectedModel);

            var result = underTest.Details(id);
            var model = result.Model;

            Assert.Same(expectedModel, model);
        }
    }
}
