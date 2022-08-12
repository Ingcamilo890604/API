using AutoMapper;
using Common.classes.DTO;
using Infrastructure.Database.Entities;

namespace EmployeesApi.Extensions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Employee, EmployeeDTO>().ReverseMap();
            CreateMap<Employee, EmployeeCreateDTO>().ReverseMap();


        }
    }
}
