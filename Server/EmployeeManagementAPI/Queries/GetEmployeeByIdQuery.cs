using EmployeeManagementAPI.Models;
using MediatR;

namespace EmployeeManagementAPI.Queries
{
    public class GetEmployeeByIdQuery : IRequest<Employee>
    {
        public Guid Id { get; set; }
    }
}
