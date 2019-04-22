using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoApi.Models;
using TodoApi.Repositorio;

namespace TodoApi.Controllers
{
    [Route("api/controller")]
    [ApiController]

    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;
        public TodoController(TodoContext context)
        {
            _context = context;
            using (var repo = new TodoDAO(_context))
            {
                repo.Initialize();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            using (var repo = new TodoDAO(_context))
            {
                return await repo.Get();
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            TodoItem result = null;
            using (var repo = new TodoDAO(_context))
            {
                result = await repo.Find(id);
            }

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return result;
            }

        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem item)
        {
            using (var repo = new TodoDAO(_context))
            {
                await repo.Create(item);
            }

            return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem item)
        {
            if (id != item.Id)
                return BadRequest();

            using (var repo = new TodoDAO(_context))
            {
                await repo.Update(item);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            using (var repo = new TodoDAO(_context))
            {
                var todoItem = await repo.Find(id);
                if (todoItem == null)
                    return NotFound();

                await repo.Delete(todoItem);

                return NoContent();
            }

                
        }
    }
}
