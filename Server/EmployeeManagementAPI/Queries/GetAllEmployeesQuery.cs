using EmployeeManagementAPI.Models;
using MediatR;

namespace EmployeeManagementSystem.Application.Queries
{
    public class GetAllEmployeesQuery : IRequest<List<Employee>>
    {
    }
}
