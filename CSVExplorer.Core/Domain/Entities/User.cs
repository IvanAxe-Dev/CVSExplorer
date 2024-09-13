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
        [Column("name")]
        public string Name { get; set; }

        [Column("birth_date")]
        public DateOnly DateOfBirth { get; set; }

        [Column("is_married")] 
        public bool Married { get; set; } = false;

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        [Column("current_salary")]
        public decimal Salary { get; set; }
    }
}
