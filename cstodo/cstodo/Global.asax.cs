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

            // Khởi tạo TodoSqlRepository cho SQL Server
            string sqlServerConnectionString = "Server=LAPTOP-FD3P69GF;Database=TODO;Integrated Security=True;";
            ITodoRepository todoRepository = new TodoSqlRepository(sqlServerConnectionString);

            // Khởi tạo TodoFileRepository
            string csvFilePath = "E:\\ChuBieu\\cstodo\\cstodo\\todo_task.todos.csv";
            ITodoRepository csvRepository = new TodoFileRepository(csvFilePath);

            // Thiết lập Dependency Resolver
            DependencyResolver.SetResolver(new MyDependencyResolver(todoCollection, todoRepository, csvRepository));
        }

        public class MyDependencyResolver : IDependencyResolver
        {
            private IMongoCollection<Todo> todoCollection;
            private ITodoRepository todoRepository;
            private ITodoRepository csvRepository;

            public MyDependencyResolver(IMongoCollection<Todo> todoCollection, ITodoRepository todoRepository, ITodoRepository csvRepository)
            {
                this.todoCollection = todoCollection;
                this.todoRepository = todoRepository;
                this.csvRepository = csvRepository;
            }

            public object GetService(Type serviceType)
            {
                if (serviceType == typeof(TodoController))
                {
                    //var repository = new TodoRepository(todoCollection);
                    //var addTodo = new AddTodo(repository);
                    //var getAllTodos = new GetAllTodos(repository);
                    var repository = csvRepository;
                    return new TodoController(repository);
                    //return new TodoController(addTodo, getAllTodos, todoRepository);
                }
                return null;
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return Enumerable.Empty<object>();
            }
        }

    }
}
