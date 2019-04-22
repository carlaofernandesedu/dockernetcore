using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Repositorio
{
    public class TodoDAO : IAsyncCrudDAO<TodoItem> , IDisposable
    {
        private readonly TodoContext _context;

        public TodoDAO(TodoContext context)
        {
            _context =  context;
        }

        public Task<int> Create(TodoItem item)
        {
            _context.TodoItems.Add(item);
            return  _context.SaveChangesAsync();
            
        }

        public Task<int> Update(TodoItem item)
        {
            _context.TodoItems.Update(item);
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<TodoItem> Find(long id)
        {
            return _context.TodoItems.FindAsync(id);
            
        }

        public Task<List<TodoItem>> Get()
        {
            return _context.TodoItems.ToListAsync();
        }

        public void Initialize()
        {
            _context.Database.EnsureCreated();
            if (_context.TodoItems.FirstOrDefault(i => i.Name == "TodoItem 01") == null)
                _context.TodoItems.Add(new TodoItem { Name = "TodoItem 01" });

            if (_context.TodoItems.FirstOrDefault(i => i.Name == "TodoItem 02") == null)
                _context.TodoItems.Add(new TodoItem { Name = "TodoItem 02" });

            if (_context.TodoItems.FirstOrDefault(i => i.Name == "TodoItem 03") == null)
                _context.TodoItems.Add(new TodoItem { Name = "TodoItem 03" });

        }

        public Task<int> Delete(TodoItem item)
        {
            _context.TodoItems.Remove(item);
            return _context.SaveChangesAsync();
        }
    }
}
