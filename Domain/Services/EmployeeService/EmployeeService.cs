using AutoMapper;
using Common.classes.DTO;
using Infrastructure.Database.Entities;
using Infrastructure.Repositories.EntityFramework.EmployeeEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.EmployeeService
{
    public class EmployeeService : IEmployeeService 
    {
        IEmployeeRepository _employeeRepository;
        IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeDto"></param>
        /// <returns></returns>
        public async Task<EmployeeDTO> Create(EmployeeCreateDTO employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            employee.State = "Activo";
            employee.RegistrationDate = DateTime.Now;
            employee.Email = employee.FirstName + "." + employee.SurName + "@cidenet.com.co";
            if(employee.Country== "Estados Unidos")
                employee.Email = employee.FirstName + "." + employee.SurName + "@cidenet.com.us";

            EmployeeFilterDTO employeeFilter = new EmployeeFilterDTO { Email = employee.FirstName + "." + employee.SurName };
            Expression<Func<Employee, bool>>? predicate = SetEntityFilters(employeeFilter);
            List<Employee> employees = await _employeeRepository.GetAll(predicate);
            if(employees !=null && employees.Count > 0)
            {
                int cuenta = employees.Count ;
                employee.Email = employee.FirstName + "." + employee.SurName +"."+cuenta.ToString()+ "@cidenet.com.co";
                if (employee.Country == "Estados Unidos")
                    employee.Email = employee.FirstName + "." + employee.SurName+"." + cuenta.ToString()+ "@cidenet.com.us";
            }


            employee = await _employeeRepository.Create(employee);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task<List<EmployeeDTO>> GetAll(EmployeeFilterDTO employeeFilter)
        {
            Expression < Func<Employee, bool>>? predicate = SetEntityFilters(employeeFilter);
            List<Employee> employees = await _employeeRepository.GetAll(predicate);

            return _mapper.Map<List<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO> Update(EmployeeDTO employeeDto)
        {
            Employee employee = _mapper.Map<Employee>(employeeDto);
            employee = await _employeeRepository.Update(employee);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        #region private methods
        /// <summary>
        /// Get expresion filters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>predicate</returns>
        private Expression<Func<Employee, bool>>? SetEntityFilters(EmployeeFilterDTO filter)
        {
            Expression<Func<Employee, bool>>? predicate = null;
            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.FirstName) )
                {
                    predicate = (x => x.FirstName.Contains(filter.FirstName));
                }

                if (!string.IsNullOrEmpty(filter.Email))
                {
                    predicate = (x => x.Email.Contains(filter.Email));
                }

            }

            return predicate;
        }

        #endregion
    }
}
