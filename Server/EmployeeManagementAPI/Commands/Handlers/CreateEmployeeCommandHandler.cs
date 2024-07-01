using EmployeeManagementAPI.Commands;
using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using MediatR;

namespace EmployeeManagementAPI.Commands.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly EmployeeContext _context;

        public CreateEmployeeCommandHandler(EmployeeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Position = request.Position,
                Department = request.Department
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }
    }
}
