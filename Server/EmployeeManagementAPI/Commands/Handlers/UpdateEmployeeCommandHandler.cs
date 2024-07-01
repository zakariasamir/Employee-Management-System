using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Commands.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly EmployeeContext _context;

        public UpdateEmployeeCommandHandler(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            employee.FirstName = request.FirstName;
            employee.LastName = request.LastName;
            employee.Email = request.Email;
            employee.PhoneNumber = request.PhoneNumber;
            employee.Position = request.Position;
            employee.Department = request.Department;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
