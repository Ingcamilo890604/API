using Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.EntityFramework.EmployeeEntity
{
    public interface IEmployeeRepository
    {
        Task<Employee> Create(Employee employee);
        Task<List<Employee>> GetAll(Expression<Func<Employee, bool>>? predicate);
        Task<Employee> Update(Employee employee);
    }
}
