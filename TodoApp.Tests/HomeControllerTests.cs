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
        [Fact]
        public void Index_Returns_A_View()
        {
            var repo = Substitute.For<ITodoRepository>();
            var underTest = new HomeController(repo);

            var result = underTest.Index();

            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public void Index_Passes_Todos_To_View()
        {
            var expectedModel = new List<Todo>();
            var repo = Substitute.For<ITodoRepository>();
            repo.GetAll().Returns(expectedModel);

            var underTest = new HomeController(repo);

            var result = underTest.Index();
            var model = result.Model;

            //assert SAME OBJECT(same instance) not if the values are equal. You want SAME THING!
            Assert.Same(expectedModel, model);
            //assert that All Todos were passed into View.
        }
    }
}
