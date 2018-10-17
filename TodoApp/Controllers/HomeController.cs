using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

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

        public ViewResult Details(int id)
        {
            var model = repo.GetById(id);
            return View(model);
        }

        public ViewResult Create()
        {
            return View();
        }

        [AcceptVerbs("POST")]
        public IActionResult Create(Todo todo)
        {
            repo.Create(todo);            
            return RedirectToAction("Index");
        }

        public ViewResult Delete(int id)
        {
            var model = repo.GetById(id);
            return View(model);
        }
    }
}
