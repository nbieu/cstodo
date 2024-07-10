using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cstodo.Entities;

namespace cstodo.Services
{
    public class GetAllTodos
    {
        private ITodoRepository todoRepository;

        public GetAllTodos(ITodoRepository todoRepository)
        {
            this.todoRepository = todoRepository;
        }
        public List<Todo> Excute()
        {
            return todoRepository.GetAll();
        }
    }
}