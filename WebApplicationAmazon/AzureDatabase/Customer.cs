using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAmazon.AzureDatabase
{
    [Table("Customer", Schema = "SalesLT")]
    public partial class Customer
    {
        public Customer()
        {
            CustomerAddress = new HashSet<CustomerAddress>();
            SalesOrderHeader = new HashSet<SalesOrderHeader>();
        }

        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column(TypeName = "NameStyle")]
        public bool NameStyle { get; set; }
        [MaxLength(8)]
        public string Title { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        public string FirstName { get; set; }
        [Column(TypeName = "Name")]
        public string MiddleName { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        public string LastName { get; set; }
        [MaxLength(10)]
        public string Suffix { get; set; }
        [MaxLength(128)]
        public string CompanyName { get; set; }
        [MaxLength(256)]
        public string SalesPerson { get; set; }
        [MaxLength(50)]
        public string EmailAddress { get; set; }
        [Column(TypeName = "Phone")]
        public string Phone { get; set; }
        [Required]
        [Column(TypeName = "varchar(128)")]
        public string PasswordHash { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string PasswordSalt { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeader { get; set; }
    }
}
