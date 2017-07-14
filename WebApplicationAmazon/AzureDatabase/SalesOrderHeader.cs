﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAmazon.AzureDatabase
{
    [Table("SalesOrderHeader", Schema = "SalesLT")]
    public partial class SalesOrderHeader
    {
        public SalesOrderHeader()
        {
            SalesOrderDetail = new HashSet<SalesOrderDetail>();
        }

        [Column("SalesOrderID")]
        public int SalesOrderId { get; set; }
        public byte RevisionNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DueDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ShipDate { get; set; }
        public byte Status { get; set; }
        [Column(TypeName = "Flag")]
        public bool OnlineOrderFlag { get; set; }
        [Required]
        [MaxLength(25)]
        public string SalesOrderNumber { get; set; }
        [Column(TypeName = "OrderNumber")]
        public string PurchaseOrderNumber { get; set; }
        [Column(TypeName = "AccountNumber")]
        public string AccountNumber { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("ShipToAddressID")]
        public int? ShipToAddressId { get; set; }
        [Column("BillToAddressID")]
        public int? BillToAddressId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShipMethod { get; set; }
        [Column(TypeName = "varchar(15)")]
        public string CreditCardApprovalCode { get; set; }
        [Column(TypeName = "money")]
        public decimal SubTotal { get; set; }
        [Column(TypeName = "money")]
        public decimal TaxAmt { get; set; }
        [Column(TypeName = "money")]
        public decimal Freight { get; set; }
        [Column(TypeName = "money")]
        public decimal TotalDue { get; set; }
        public string Comment { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("SalesOrder")]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
        [ForeignKey("BillToAddressId")]
        [InverseProperty("SalesOrderHeaderBillToAddress")]
        public virtual Address BillToAddress { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("SalesOrderHeader")]
        public virtual Customer Customer { get; set; }
        [ForeignKey("ShipToAddressId")]
        [InverseProperty("SalesOrderHeaderShipToAddress")]
        public virtual Address ShipToAddress { get; set; }
    }
}
