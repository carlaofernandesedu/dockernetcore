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

        [HttpGet]
        public async Task<AcionResultTodoItem GetTodoItem(long id)
        {
            TodoItem result = null; 
            using (var repo = new TodoDAO(_context))
            {
                result = await repo.Find(id);
            }

            return result ?? NotFound;


        }

    }
}
