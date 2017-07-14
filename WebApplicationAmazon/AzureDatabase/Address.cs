using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAmazon.AzureDatabase
{
    [Table("Address", Schema = "SalesLT")]
    public partial class Address
    {
        public Address()
        {
            CustomerAddress = new HashSet<CustomerAddress>();
            SalesOrderHeaderBillToAddress = new HashSet<SalesOrderHeader>();
            SalesOrderHeaderShipToAddress = new HashSet<SalesOrderHeader>();
        }

        [Column("AddressID")]
        public int AddressId { get; set; }
        [Required]
        [MaxLength(60)]
        public string AddressLine1 { get; set; }
        [MaxLength(60)]
        public string AddressLine2 { get; set; }
        [Required]
        [MaxLength(30)]
        public string City { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        public string StateProvince { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        public string CountryRegion { get; set; }
        [Required]
        [MaxLength(15)]
        public string PostalCode { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("Address")]
        public virtual ICollection<CustomerAddress> CustomerAddress { get; set; }
        [InverseProperty("BillToAddress")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaderBillToAddress { get; set; }
        [InverseProperty("ShipToAddress")]
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddress { get; set; }
    }
}
