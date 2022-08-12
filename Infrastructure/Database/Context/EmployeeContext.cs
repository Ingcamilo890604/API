using Infrastructure.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.Context
{
    public class EmployeeContext : DbContext
    {

        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {
        }

  
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public DbSet<Employee> Employee { get; set; } = null!;
    }
}
