using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplicationAmazon.AzureDatabase
{
    public partial class DhanaifruitsdbContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerAddress> CustomerAddress { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductDescription> ProductDescription { get; set; }
        public virtual DbSet<ProductModel> ProductModel { get; set; }
        public virtual DbSet<ProductModelProductDescription> ProductModelProductDescription { get; set; }
        public virtual DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
        public virtual DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=dhanaifruitsdb.database.windows.net;Initial Catalog=DhanaiFruitsDB;Persist Security Info=True;User ID=DhanaiFruitsDB;Password=allen@1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Address_rowguid")
                    .IsUnique();

                entity.HasIndex(e => e.StateProvince)
                    .HasName("IX_Address_StateProvince");

                entity.HasIndex(e => new { e.AddressLine1, e.AddressLine2, e.City, e.StateProvince, e.PostalCode, e.CountryRegion })
                    .HasName("IX_Address_AddressLine1_AddressLine2_City_StateProvince_PostalCode_CountryRegion");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.EmailAddress)
                    .HasName("IX_Customer_EmailAddress");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Customer_rowguid")
                    .IsUnique();

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("getdate()");

                entity.Property(e => e.NameStyle).HasDefaultValueSql("0");

                entity.Property(e => e.Rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.AddressId })
                    .HasName("PK_CustomerAddress_CustomerID_AddressID");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_CustomerAddress_rowguid")
                    .IsUnique();

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("AK_Product_Name")
                    .IsUnique();

                entity.HasIndex(e => e.ProductNumber)
                    .HasName("AK_Product_ProductNumber")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_Product_rowguid")
                    .IsUnique();

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductCategory_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductCategory_rowguid")
                    .IsUnique();

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<ProductDescription>(entity =>
            {
                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductDescription_rowguid")
                    .IsUnique();

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<ProductModel>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("AK_ProductModel_Name")
                    .IsUnique();

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductModel_rowguid")
                    .IsUnique();

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<ProductModelProductDescription>(entity =>
            {
                entity.HasKey(e => new { e.ProductModelId, e.ProductDescriptionId, e.Culture })
                    .HasName("PK_ProductModelProductDescription_ProductModelID_ProductDescriptionID_Culture");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_ProductModelProductDescription_rowguid")
                    .IsUnique();

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rowguid).HasDefaultValueSql("newid()");
            });

            modelBuilder.Entity<SalesOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.SalesOrderId, e.SalesOrderDetailId })
                    .HasName("PK_SalesOrderDetail_SalesOrderID_SalesOrderDetailID");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_SalesOrderDetail_ProductID");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_SalesOrderDetail_rowguid")
                    .IsUnique();

                entity.Property(e => e.SalesOrderDetailId).ValueGeneratedOnAdd();

                entity.Property(e => e.LineTotal)
                    .HasComputedColumnSql("isnull(([UnitPrice]*((1.0)-[UnitPriceDiscount]))*[OrderQty],(0.0))")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("getdate()");

                entity.Property(e => e.Rowguid).HasDefaultValueSql("newid()");

                entity.Property(e => e.UnitPriceDiscount).HasDefaultValueSql("0.0");
            });

            modelBuilder.Entity<SalesOrderHeader>(entity =>
            {
                entity.HasKey(e => e.SalesOrderId)
                    .HasName("PK_SalesOrderHeader_SalesOrderID");

                entity.HasIndex(e => e.CustomerId)
                    .HasName("IX_SalesOrderHeader_CustomerID");

                entity.HasIndex(e => e.Rowguid)
                    .HasName("AK_SalesOrderHeader_rowguid")
                    .IsUnique();

                entity.HasIndex(e => e.SalesOrderNumber)
                    .HasName("AK_SalesOrderHeader_SalesOrderNumber")
                    .IsUnique();

                entity.Property(e => e.SalesOrderId).HasDefaultValueSql("NEXT VALUE FOR [SalesLT].[SalesOrderNumber]");

                entity.Property(e => e.Freight).HasDefaultValueSql("0.00");

                entity.Property(e => e.ModifiedDate).HasDefaultValueSql("getdate()");

                entity.Property(e => e.OnlineOrderFlag).HasDefaultValueSql("1");

                entity.Property(e => e.OrderDate).HasDefaultValueSql("getdate()");

                entity.Property(e => e.RevisionNumber).HasDefaultValueSql("0");

                entity.Property(e => e.Rowguid).HasDefaultValueSql("newid()");

                entity.Property(e => e.SalesOrderNumber)
                    .HasComputedColumnSql("isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID],(0)),N'*** ERROR ***')")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Status).HasDefaultValueSql("1");

                entity.Property(e => e.SubTotal).HasDefaultValueSql("0.00");

                entity.Property(e => e.TaxAmt).HasDefaultValueSql("0.00");

                entity.Property(e => e.TotalDue)
                    .HasComputedColumnSql("isnull(([SubTotal]+[TaxAmt])+[Freight],(0))")
                    .ValueGeneratedOnAddOrUpdate();
            });

            modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");
        }
    }
}