using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repositorio
{
    public class TodoDAO : IAsyncCrudDAO<TodoItem>
    {
        private readonly TodoContext _context;

        public TodoDAO(TodoContext context)
        {
            _context =  context;
        }

        public void Create(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();
            
        }

        public Task<TodoItem> Find(int id)
        {
            return _context.TodoItems.FindAsync(id);
            
        }

        public Task<List<TodoItem>> Get()
        {
            return _context.TodoItems.ToListAsync();
        }
    }
}
