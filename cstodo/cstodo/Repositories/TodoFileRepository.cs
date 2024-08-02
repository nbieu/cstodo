using cstodo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cstodo;
using System.IO;

namespace cstodo.Repositories
{
    public class TodoFileRepository : ITodoRepository
    {
        private readonly string filePath;

        public TodoFileRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public void Add(Todo todo)
        {
            var csvLine = $"{todo.title},{todo.status}";
            File.AppendAllText(this.filePath, csvLine + Environment.NewLine);
        }

        public List<Todo> GetAll()
        {
            var todos = new List<Todo>();

            if (File.Exists(this.filePath))
            {
                var lines = File.ReadAllLines(this.filePath);
                foreach (var line in lines)
                {
                    var values = line.Split(',');

                    if (values.Length == 2)
                    {
                        var todo = new Todo
                        {
                            title = values[0],
                            status = values[1]
                        };
                        todos.Add(todo);
                    }
                }
            }

            return todos;
        }
    }
}