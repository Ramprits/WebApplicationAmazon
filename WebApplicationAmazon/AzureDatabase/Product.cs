﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAmazon.AzureDatabase
{
    [Table("Product", Schema = "SalesLT")]
    public partial class Product
    {
        public Product()
        {
            SalesOrderDetail = new HashSet<SalesOrderDetail>();
        }

        [Column("ProductID")]
        public int ProductId { get; set; }
        [Required]
        [Column(TypeName = "Name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(25)]
        public string ProductNumber { get; set; }
        [MaxLength(15)]
        public string Color { get; set; }
        [Column(TypeName = "money")]
        public decimal StandardCost { get; set; }
        [Column(TypeName = "money")]
        public decimal ListPrice { get; set; }
        [MaxLength(5)]
        public string Size { get; set; }
        [Column(TypeName = "decimal")]
        public decimal? Weight { get; set; }
        [Column("ProductCategoryID")]
        public int? ProductCategoryId { get; set; }
        [Column("ProductModelID")]
        public int? ProductModelId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime SellStartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? SellEndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DiscontinuedDate { get; set; }
        public byte[] ThumbNailPhoto { get; set; }
        [MaxLength(50)]
        public string ThumbnailPhotoFileName { get; set; }
        [Column("rowguid")]
        public Guid Rowguid { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ModifiedDate { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetail { get; set; }
        [ForeignKey("ProductCategoryId")]
        [InverseProperty("Product")]
        public virtual ProductCategory ProductCategory { get; set; }
        [ForeignKey("ProductModelId")]
        [InverseProperty("Product")]
        public virtual ProductModel ProductModel { get; set; }
    }
}
