using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementAPI.Queries.Handlers
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, Employee>
    {
        private readonly EmployeeContext _context;

        public GetEmployeeByIdQueryHandler(EmployeeContext context)
        {
            _context = context;
        }

        public async Task<Employee> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);

            if (employee == null)
            {
                throw new Exception("Employee not found");
            }

            return employee;
        }
    }
}
