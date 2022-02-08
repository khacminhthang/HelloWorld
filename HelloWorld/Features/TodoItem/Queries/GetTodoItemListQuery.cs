using HelloWorld.Models;
using MediatR;
using System.Collections.Generic;

namespace HelloWorld.Features.TodoItem.Queries
{
    public class GetTodoItemListQuery : IRequest<IEnumerable<TodoItemDTO>>
    {
    }
}
