using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVExplorer.Core.Domain.Entities;

namespace CSVExplorer.Core.DTOs
{
    public class UserResponseDto : BaseEntity
    {
        public string Name { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public bool Married { get; set; } 

        public string PhoneNumber { get; set; }

        public decimal Salary { get; set; }
    }
}
