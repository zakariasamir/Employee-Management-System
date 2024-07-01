using AutoMapper;
using EmployeeManagementAPI.Commands;
using EmployeeManagementAPI.Dto;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<CreateEmployeeCommand, Employee>();
        }
    }
}
