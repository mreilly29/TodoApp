using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Controllers
{
    public class HomeController : Controller
    {
        private ITodoRepository repo;

        public HomeController(ITodoRepository repo)
        {
            this.repo = repo;
        }

        public ViewResult Index()
        {
            var model = repo.GetAll();
            return View(model);
        }
    }
}
