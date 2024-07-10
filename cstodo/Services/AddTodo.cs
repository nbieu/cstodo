using cstodo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cstodo.Services
{
    public class AddTodo
    {
        private ITodoRepository todoRepository;

        public AddTodo(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }
        public void Excute(Todo todo)
        {
            todoRepository.Add(todo);
        }
    }
}