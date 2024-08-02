using cstodo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cstodo
{

    public interface ITodoRepository
    {
        void Add(Todo todo);
        List<Todo> GetAll();
    }
}
