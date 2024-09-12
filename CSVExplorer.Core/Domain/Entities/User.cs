using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace CSVExplorer.Core.Domain.Entities
{
    [Table("Users")]
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name can't be longer than 100 characters")]
        [Column("name")]
        public string Name { get; set; }

        [Column("birth_date")]
        public DateOnly DateOfBirth { get; set; }

        [Column("is_married")] 
        public bool Married { get; set; } = false;

        [Phone(ErrorMessage = "Invalid phone number format")]
        [StringLength(15, ErrorMessage = "Phone number can't be longer than 15 characters")]
        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive number")]
        [Column("current_salary")]
        public decimal Salary { get; set; }
    }
}
