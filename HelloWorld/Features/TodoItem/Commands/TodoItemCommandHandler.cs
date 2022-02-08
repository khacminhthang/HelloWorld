using AutoMapper;
using HelloWorld.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorld.Features.TodoItem.Commands
{
    public class TodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, bool>,
                                        IRequestHandler<UpdateTodoItemCommand, bool>,
                                        IRequestHandler<DeleteTodoItemCommand, bool>
    {

        private readonly TodoContext _context;
        private readonly IMapper mapper;

        public TodoItemCommandHandler(TodoContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = mapper.Map<Models.TodoItem>(request);

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
        {

            var todoItem = await _context.TodoItems.FindAsync(request.Id);
            if (todoItem == null)
            {
                return false;
            }
            todoItem.Name = request.Name;
            todoItem.IsComplete = request.IsComplete;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
        {
            var todoItem = await _context.TodoItems.FindAsync(request.Id);

            if (todoItem == null)
            {
                return false;
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
