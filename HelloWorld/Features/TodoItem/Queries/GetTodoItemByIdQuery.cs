using HelloWorld.Models;
using MediatR;

namespace HelloWorld.Features.TodoItem.Queries
{
    public class GetTodoItemByIdQuery : IRequest<TodoItemDTO>
    {
        public long Id { get; set; }
    }
}
