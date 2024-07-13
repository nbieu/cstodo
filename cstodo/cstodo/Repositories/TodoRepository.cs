using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cstodo.Entities;
using MongoDB.Driver;

namespace cstodo.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IMongoCollection<Todo> collection;

        public TodoRepository(IMongoCollection<Todo> database)
        {
            collection = database;
        }
        public void Add(Todo todo)
        {
            collection.InsertOne(todo);
        }
        public List<Todo> GetAll()
        {
            return collection.Find(_ => true).ToList();
        }
    }
}