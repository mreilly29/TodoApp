using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Models;

namespace TodoApp
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> GetAll();
        Todo GetById(int id);
    }
}
