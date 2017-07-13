using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAmazon.Database
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Contact { get; set; }
        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Address { get; set; }
        [Column("CreatedDT", TypeName = "date")]
        public DateTime CreatedDt { get; set; }
        [Column("modifiedDT", TypeName = "date")]
        public DateTime ModifiedDt { get; set; }
    }
}
