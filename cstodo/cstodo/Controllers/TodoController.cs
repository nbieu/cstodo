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

<<<<<<< HEAD

        //public TodoController(AddTodo addTodo, GetAllTodos getAllTodos, ITodoRepository todoRepository)
        //{
        //    this.addTodo = addTodo;
        //    this.getAllTodos = getAllTodos;
        //    this.todoRepository = todoRepository;
        //}
        public TodoController(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
=======
        public TodoController(AddTodo addTodo, GetAllTodos getAllTodos)
        {
            this.addTodo = addTodo;
            this.getAllTodos = getAllTodos;
>>>>>>> d290c544dfaca1125b35904bb8fc89c4ee03741b
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