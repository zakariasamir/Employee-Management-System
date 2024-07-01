using EmployeeManagementAPI.Commands;
using EmployeeManagementAPI.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
    {
        private readonly EmployeeContext _context;

        public DeleteEmployeeCommandHandler(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
