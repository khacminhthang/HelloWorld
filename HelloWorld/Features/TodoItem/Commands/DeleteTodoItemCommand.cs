
namespace HelloWorld.Features.TodoItem.Commands
{
    public class DeleteTodoItemCommand : TodoItemCommand
    {
        public long Id { get; set; }
        public DeleteTodoItemCommand(long id)
        {
            this.Id = id;
        }
    }
}
