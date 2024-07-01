using EmployeeManagementAPI.Queries;
using FluentValidation;

namespace EmployeeManagementAPI.Validator
{
    public class GetEmployeeByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
    {
        public GetEmployeeByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .Must(id => id != Guid.Empty)
                .WithMessage("Invalid Employee ID format.");
        }
    }
}

