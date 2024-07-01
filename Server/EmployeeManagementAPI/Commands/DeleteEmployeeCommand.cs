using MediatR;

namespace EmployeeManagementAPI.Commands
{
    public class DeleteEmployeeCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
