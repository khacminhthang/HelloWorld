using AutoMapper;
using HelloWorld.Features.TodoItem.Commands;

namespace HelloWorld.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TodoItemDTO, TodoItem>();
            CreateMap<TodoItem, TodoItemDTO>();
            CreateMap<CreateTodoItemCommand, TodoItemDTO>();
            CreateMap<CreateTodoItemCommand, TodoItem>();
        }
    }
}
