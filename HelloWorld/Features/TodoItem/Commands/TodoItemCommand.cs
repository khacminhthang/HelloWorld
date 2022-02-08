using MediatR;

namespace HelloWorld.Features.TodoItem.Commands
{
    public class TodoItemCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
