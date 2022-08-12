using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.classes.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string FirstName { get; set; } = null!;
        public string? OtherName { get; set; }
        public string SurName { get; set; } = null!;
        public string SecondSurName { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string TypeId { get; set; } = null!;
        public string NumberId { get; set; } = null!;
        public string? Email { get; set; }
        public DateTime DateIn { get; set; }
        public string Area { get; set; } = null!;
        public DateTime RegistrationDate { get; set; }
        public string State { get; set; } = null!;


    }
}
