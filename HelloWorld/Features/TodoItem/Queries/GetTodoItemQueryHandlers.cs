using AutoMapper;
using HelloWorld.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HelloWorld.Features.TodoItem.Queries
{
    public class GetTodoItemQueryHandlers : IRequestHandler<GetTodoItemListQuery, IEnumerable<TodoItemDTO>>,
                                            IRequestHandler<GetTodoItemByIdQuery, TodoItemDTO>
    {
        private readonly TodoContext _context;
        private readonly IMapper mapper;

        public GetTodoItemQueryHandlers(TodoContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TodoItemDTO>> Handle(GetTodoItemListQuery request, CancellationToken cancellationToken)
        {
            return await _context.TodoItems
                                    .Select(x => mapper.Map<TodoItemDTO>(x))
                                    .ToListAsync();
        }

        public async Task<TodoItemDTO> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
        {
            var todoItem = await _context.TodoItems.FindAsync(request.Id);

            return mapper.Map<TodoItemDTO>(todoItem);
        }
    }
}

