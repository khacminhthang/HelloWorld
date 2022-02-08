using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloWorld.Models;
using MediatR;
using HelloWorld.Features.TodoItem.Queries;
using HelloWorld.Features.TodoItem.Commands;

namespace HelloWorld.Controllers
{
    [Route("api/todoitems")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TodoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
        {
            var result = await _mediator.Send(new GetTodoItemListQuery());

            return Ok(result);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        {
            GetTodoItemByIdQuery query = new GetTodoItemByIdQuery() { Id = id };

            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // PUT: api/TodoItems/5
        [HttpPut]
        public async Task<ActionResult> PutTodoItem(UpdateTodoItemCommand updateTodoItemCommand)
        {
            var result = await _mediator.Send(updateTodoItemCommand);
            return NoContent();
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult> PostTodoItem(CreateTodoItemCommand createTodoItemCommand)
        {

            if (!ModelState.IsValid)
                return BadRequest(new { Errors = ModelState });

            var result = await _mediator.Send(createTodoItemCommand);

            return NoContent();
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var result = await _mediator.Send(new DeleteTodoItemCommand(id));
            return NoContent();
        }
    }
}
