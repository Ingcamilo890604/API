using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.classes.DTO
{
    public class EmployeeFilterDTO
    {
        public string? FirstName { get; set; } 
        public string? OtherName { get; set; }
        public string? SurName { get; set; }
        public string? SecondSurName { get; set; }
        public string? Country { get; set; } 
        public string? TypeId { get; set; } 
        public string? NumberId { get; set; } 
        public string? State { get; set; } 
        public string? Email { get; set; }

    }
}

