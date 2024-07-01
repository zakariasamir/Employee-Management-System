using EmployeeManagementAPI.Commands;
using FluentValidation;

namespace EmployeeManagementAPI.Validator
{
    public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
    {
        public DeleteEmployeeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .Must(id => id != Guid.Empty)
                .WithMessage("Invalid Employee ID format.");
        }
    }
}
