using Common.classes.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.EmployeeService
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> Create(EmployeeCreateDTO employeeDto);
        Task<List<EmployeeDTO>> GetAll(EmployeeFilterDTO employeeFilter);
        Task<EmployeeDTO> Update(EmployeeDTO employeeDto);
    }
}
