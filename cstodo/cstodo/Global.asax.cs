using cstodo.Controllers;
using cstodo.Entities;
using cstodo.Repositories;
using cstodo.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace cstodo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // Khởi tạo kết nối MongoDB
            var client = new MongoClient("mongodb://localhost:27017/");
            var database = client.GetDatabase("todo_task");
            var todoCollection = database.GetCollection<Todo>("todos");

            // Thiết lập Dependency Resolver
            DependencyResolver.SetResolver(new MyDependencyResolver(todoCollection));
        }
    }

    public class MyDependencyResolver : IDependencyResolver
    {
        private IMongoCollection<Todo> todoCollection;

        public MyDependencyResolver(IMongoCollection<Todo> todoCollection)
        {
            this.todoCollection = todoCollection;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(TodoController))
            {
                var repository = new TodoRepository(todoCollection);
                var addTodo = new AddTodo(repository);
                var getAllTodos = new GetAllTodos(repository);
                return new TodoController(addTodo, getAllTodos);
            }
            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return Enumerable.Empty<object>();
        }
    }

}
