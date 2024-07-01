using EmployeeManagementAPI.Commands;
using FluentValidation;

namespace EmployeeManagementAPI.Validator
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Email).NotEmpty().EmailAddress().MaximumLength(50);
            RuleFor(x => x.PhoneNumber).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Position).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Department).NotEmpty().MaximumLength(20);
        }
    }
}