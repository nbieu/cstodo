using cstodo.Entities;
using cstodo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cstodo.Controllers
{
    public class TodoController : Controller
    {
        private AddTodo addTodo;
        private GetAllTodos getAllTodos;

        public TodoController(AddTodo addTodo, GetAllTodos getAllTodos)
        {
            this.addTodo = addTodo;
            this.getAllTodos = getAllTodos;
        }

        public ActionResult Index()
        {
            var todos = getAllTodos.Excute();
            return View(todos);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Todo todo)
        {
            if(ModelState.IsValid)
            {
                addTodo.Excute(todo);
                return RedirectToAction("Index");
            }
           return View(todo);
        }

    }
}