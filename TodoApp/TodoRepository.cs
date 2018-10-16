using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp
{
    public class TodoRepository : Repository<Todo>, ITodoRepository
    {
        public TodoRepository(Context db) : base(db)
        {
        }
    }
}
