using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cstodo.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using MongoDB.Bson;

namespace cstodo.Repositories
{
    public class TodoSqlRepository : ITodoRepository
    {
        private string _con;

        public TodoSqlRepository(string con)
        {
            _con = con;
        }
        public void Add(Todo todo)
        {
            using (var connection = new SqlConnection(_con))
            {
                connection.Open();
                string query = "Insert into dbo.Todos( title, status) values ( @Title, @Status)";
                //string query = "Insert into db.Todos(id, title, status) values (@Id, @Title, @Status)";
                SqlCommand cmd = new SqlCommand(query, connection);
                //cmd.Parameters.AddWithValue("@Id", todo.Id);
                cmd.Parameters.AddWithValue("@Title", todo.title);
                cmd.Parameters.AddWithValue("@Status", todo.status);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Todo> GetAll()
        {
            List<Todo> todos = new List<Todo>();
            using (var connection = new SqlConnection(_con))
            {
                connection.Open();
                string query = "Select title, status from dbo.Todos";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Todo todo = new Todo()
                    {
                        //Id = ObjectId.GenerateNewId(),
                        title = reader.GetString(reader.GetOrdinal("title")),
                        status = reader.GetString(reader.GetOrdinal("status"))
                    };
                    todos.Add(todo);
                }
            }
            return todos;
        }
    }
}