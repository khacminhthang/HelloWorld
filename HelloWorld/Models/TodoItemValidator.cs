using FluentValidation;

namespace HelloWorld.Models
{
    public class TodoItemValidator : AbstractValidator<TodoItemDTO>
    {
        public TodoItemValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Tên không được để trống");
        }
    }
}
