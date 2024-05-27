﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace DAO;

public partial class DIAMOND_DBContext : DbContext
{
    //Dependency injection.You can view it in program.cs
    public DIAMOND_DBContext(DbContextOptions<DIAMOND_DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CartProduct> CartProducts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Cover> Covers { get; set; }

    public virtual DbSet<CoverMetalType> CoverMetalTypes { get; set; }

    public virtual DbSet<CoverSize> CoverSizes { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DeliveryStaff> DeliveryStaffs { get; set; }

    public virtual DbSet<Diamond> Diamonds { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<FavoriteProduct> FavoriteProducts { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<MetalType> MetalTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductOrder> ProductOrders { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<SaleStaff> SaleStaffs { get; set; }

    public virtual DbSet<Shipping> Shippings { get; set; }

    public virtual DbSet<ShippingMethod> ShippingMethods { get; set; }

    public virtual DbSet<Size> Sizes { get; set; }

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.AddressId).HasName("PK__Address__26A111ADB6D440A7");

            entity.ToTable("Address");

            entity.Property(e => e.AddressId).HasColumnName("addressId");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.CusId).HasColumnName("cusId");
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("state");
            entity.Property(e => e.Street)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("street");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("zipCode");

            entity.HasOne(d => d.Cus).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.CusId)
                .HasConstraintName("FK__Address__cusId__6754599E");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Cart__415B03B880701DD2");

            entity.ToTable("Cart");

            entity.Property(e => e.CartId).HasColumnName("cartId");
            entity.Property(e => e.CusId).HasColumnName("cusId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Cus).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CusId)
                .HasConstraintName("FK__Cart__cusId__60A75C0F");
        });

        modelBuilder.Entity<CartProduct>(entity =>
        {
            entity.HasKey(e => new { e.CartId, e.ProductId }).HasName("PK__CartProd__F38A0EAEA9757FCB");

            entity.ToTable("CartProduct");

            entity.Property(e => e.CartId).HasColumnName("cartId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Cart).WithMany(p => p.CartProducts)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CartProdu__cartI__6383C8BA");

            entity.HasOne(d => d.Product).WithMany(p => p.CartProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CartProdu__produ__6477ECF3");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__23CAF1D86C70D34E");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CategoryName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<Cover>(entity =>
        {
            entity.HasKey(e => e.CoverId).HasName("PK__Cover__B192A2E004B9F3FE");

            entity.ToTable("Cover");

            entity.Property(e => e.CoverId).HasColumnName("coverId");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.CoverName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("coverName");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.SubCategoryId).HasColumnName("subCategoryId");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unitPrice");

            entity.HasOne(d => d.Category).WithMany(p => p.Covers)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Cover__categoryI__3F466844");

            entity.HasOne(d => d.SubCategory).WithMany(p => p.Covers)
                .HasForeignKey(d => d.SubCategoryId)
                .HasConstraintName("FK__Cover__subCatego__3E52440B");
        });

        modelBuilder.Entity<CoverMetalType>(entity =>
        {
            entity.HasKey(e => new { e.MetalTypeId, e.CoverId }).HasName("PK__CoverMet__D817F579995FC56B");

            entity.ToTable("CoverMetalType");

            entity.Property(e => e.MetalTypeId).HasColumnName("metalTypeId");
            entity.Property(e => e.CoverId).HasColumnName("coverId");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Cover).WithMany(p => p.CoverMetalTypes)
                .HasForeignKey(d => d.CoverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CoverMeta__cover__48CFD27E");

            entity.HasOne(d => d.MetalType).WithMany(p => p.CoverMetalTypes)
                .HasForeignKey(d => d.MetalTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CoverMeta__metal__47DBAE45");
        });

        modelBuilder.Entity<CoverSize>(entity =>
        {
            entity.HasKey(e => new { e.SizeId, e.CoverId }).HasName("PK__CoverSiz__4EA8CF79111243D7");

            entity.ToTable("CoverSize");

            entity.Property(e => e.SizeId).HasColumnName("sizeId");
            entity.Property(e => e.CoverId).HasColumnName("coverId");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Cover).WithMany(p => p.CoverSizes)
                .HasForeignKey(d => d.CoverId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CoverSize__cover__44FF419A");

            entity.HasOne(d => d.Size).WithMany(p => p.CoverSizes)
                .HasForeignKey(d => d.SizeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CoverSize__sizeI__440B1D61");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CusId).HasName("PK__Customer__BA9897F3E7290075");

            entity.ToTable("Customer");

            entity.Property(e => e.CusId).HasColumnName("cusId");
            entity.Property(e => e.CusFirstName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cusFirstName");
            entity.Property(e => e.CusLastName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cusLastName");
            entity.Property(e => e.CusPhoneNum)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cusPhoneNum");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Customers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Customer__userId__534D60F1");

            entity.HasMany(d => d.Vouchers).WithMany(p => p.Cus)
                .UsingEntity<Dictionary<string, object>>(
                    "CustomerVoucher",
                    r => r.HasOne<Voucher>().WithMany()
                        .HasForeignKey("VoucherId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CustomerV__vouch__7F2BE32F"),
                    l => l.HasOne<Customer>().WithMany()
                        .HasForeignKey("CusId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CustomerV__cusId__7E37BEF6"),
                    j =>
                    {
                        j.HasKey("CusId", "VoucherId").HasName("PK__Customer__35CBAF6D750E4F96");
                        j.ToTable("CustomerVoucher");
                        j.IndexerProperty<int>("CusId").HasColumnName("cusId");
                        j.IndexerProperty<int>("VoucherId").HasColumnName("voucherId");
                    });
        });

        modelBuilder.Entity<DeliveryStaff>(entity =>
        {
            entity.HasKey(e => e.DeliveryStaffId).HasName("PK__Delivery__F78B04343C3E1432");

            entity.ToTable("DeliveryStaff");

            entity.Property(e => e.DeliveryStaffId).HasColumnName("deliveryStaffId");
            entity.Property(e => e.ManagerId).HasColumnName("managerId");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Manager).WithMany(p => p.DeliveryStaffs)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK__DeliveryS__manag__5DCAEF64");

            entity.HasOne(d => d.User).WithMany(p => p.DeliveryStaffs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__DeliveryS__userI__5CD6CB2B");
        });

        modelBuilder.Entity<Diamond>(entity =>
        {
            entity.HasKey(e => e.DiamondId).HasName("PK__Diamond__F848E6C097C3667D");

            entity.ToTable("Diamond");

            entity.Property(e => e.DiamondId).HasColumnName("diamondId");
            entity.Property(e => e.CaratWeight)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("caratWeight");
            entity.Property(e => e.Clarity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clarity");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("color");
            entity.Property(e => e.Cut)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cut");
            entity.Property(e => e.DiamondName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("diamondName");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Shape)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("shape");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.FavoriteId).HasName("PK__favorite__876A64D5EE8B3E2E");

            entity.ToTable("favorite");

            entity.Property(e => e.FavoriteId).HasColumnName("favoriteId");
            entity.Property(e => e.CusId).HasColumnName("cusId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Cus).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.CusId)
                .HasConstraintName("FK__favorite__cusId__05D8E0BE");
        });

        modelBuilder.Entity<FavoriteProduct>(entity =>
        {
            entity.HasKey(e => new { e.FavoriteId, e.ProductId }).HasName("PK__favorite__35BB69C36866859D");

            entity.ToTable("favoriteProduct");

            entity.Property(e => e.FavoriteId).HasColumnName("favoriteId");
            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Favorite).WithMany(p => p.FavoriteProducts)
                .HasForeignKey(d => d.FavoriteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__favoriteP__favor__08B54D69");

            entity.HasOne(d => d.Product).WithMany(p => p.FavoriteProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__favoriteP__produ__09A971A2");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.ManagerId).HasName("PK__Manager__47E0141FEA51B6EA");

            entity.ToTable("Manager");

            entity.Property(e => e.ManagerId).HasColumnName("managerId");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.User).WithMany(p => p.Managers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Manager__userId__5629CD9C");
        });

        modelBuilder.Entity<MetalType>(entity =>
        {
            entity.HasKey(e => e.MetalTypeId).HasName("PK__MetalTyp__C30EDF5718EBED23");

            entity.ToTable("MetalType");

            entity.Property(e => e.MetalTypeId).HasColumnName("metalTypeId");
            entity.Property(e => e.MetalTypeName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("metalTypeName");
            entity.Property(e => e.MetalTypeValue)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("metalTypeValue");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__0809335D94850C89");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.CusId).HasColumnName("cusId");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("orderDate");
            entity.Property(e => e.ShippingMethodId).HasColumnName("shippingMethodId");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("totalAmount");

            entity.HasOne(d => d.Cus).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CusId)
                .HasConstraintName("FK__Order__cusId__6C190EBB");

            entity.HasOne(d => d.ShippingMethod).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShippingMethodId)
                .HasConstraintName("FK__Order__shippingM__6D0D32F4");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__2D10D16A49A1FB73");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.CoverId).HasColumnName("coverId");
            entity.Property(e => e.DiamondId).HasColumnName("diamondId");
            entity.Property(e => e.MetalTypeId).HasColumnName("metalTypeId");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Pp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PP");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unitPrice");

            entity.HasOne(d => d.Cover).WithMany(p => p.Products)
                .HasForeignKey(d => d.CoverId)
                .HasConstraintName("FK__Product__coverId__4E88ABD4");

            entity.HasOne(d => d.Diamond).WithMany(p => p.Products)
                .HasForeignKey(d => d.DiamondId)
                .HasConstraintName("FK__Product__diamond__4D94879B");

            entity.HasOne(d => d.MetalType).WithMany(p => p.Products)
                .HasForeignKey(d => d.MetalTypeId)
                .HasConstraintName("metalTypeId");

            entity.HasOne(d => d.Size).WithMany(p => p.Products)
                .HasForeignKey(d => d.SizeId)
                .HasConstraintName("sizeId");
        });

        modelBuilder.Entity<ProductOrder>(entity =>
        {
            entity.HasKey(e => new { e.ProductId, e.OrderId }).HasName("PK__ProductO__ED90425F6A8CC7C4");

            entity.ToTable("ProductOrder");

            entity.Property(e => e.ProductId).HasColumnName("productId");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.ProductOrders)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductOr__order__70DDC3D8");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductOrders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductOr__produ__6FE99F9F");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Review__2ECD6E04EFEFE6E2");

            entity.ToTable("Review");

            entity.Property(e => e.ReviewId).HasColumnName("reviewId");
            entity.Property(e => e.CusId).HasColumnName("cusId");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.Review1)
                .HasColumnType("text")
                .HasColumnName("review");
            entity.Property(e => e.ReviewDate).HasColumnName("reviewDate");

            entity.HasOne(d => d.Cus).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CusId)
                .HasConstraintName("FK__Review__cusId__787EE5A0");
        });

        modelBuilder.Entity<SaleStaff>(entity =>
        {
            entity.HasKey(e => e.SaleStaffId).HasName("PK__SaleStaf__71872E4C0DA38967");

            entity.ToTable("SaleStaff");

            entity.Property(e => e.SaleStaffId).HasColumnName("saleStaffId");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.ManagerId).HasColumnName("managerId");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Manager).WithMany(p => p.SaleStaffs)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK__SaleStaff__manag__59FA5E80");

            entity.HasOne(d => d.User).WithMany(p => p.SaleStaffs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__SaleStaff__userI__59063A47");
        });

        modelBuilder.Entity<Shipping>(entity =>
        {
            entity.HasKey(e => e.ShippingId).HasName("PK__Shipping__EDF80BCA0F0031A3");

            entity.ToTable("Shipping");

            entity.Property(e => e.ShippingId).HasColumnName("shippingId");
            entity.Property(e => e.DeliveryStaffId).HasColumnName("deliveryStaffId");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.SaleStaffId).HasColumnName("saleStaffId");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.DeliveryStaff).WithMany(p => p.Shippings)
                .HasForeignKey(d => d.DeliveryStaffId)
                .HasConstraintName("FK__Shipping__delive__75A278F5");

            entity.HasOne(d => d.Order).WithMany(p => p.Shippings)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Shipping__orderI__73BA3083");

            entity.HasOne(d => d.SaleStaff).WithMany(p => p.Shippings)
                .HasForeignKey(d => d.SaleStaffId)
                .HasConstraintName("FK__Shipping__saleSt__74AE54BC");
        });

        modelBuilder.Entity<ShippingMethod>(entity =>
        {
            entity.HasKey(e => e.ShippingMethodId).HasName("PK__Shipping__E405E8565ABB665B");

            entity.ToTable("ShippingMethod");

            entity.Property(e => e.ShippingMethodId).HasColumnName("shippingMethodId");
            entity.Property(e => e.Cost)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cost");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.MethodName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("methodName");
        });

        modelBuilder.Entity<Size>(entity =>
        {
            entity.HasKey(e => e.SizeId).HasName("PK__Size__55B1E55701AF8BEB");

            entity.ToTable("Size");

            entity.Property(e => e.SizeId).HasColumnName("sizeId");
            entity.Property(e => e.SizeName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sizeName");
            entity.Property(e => e.SizeValue)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("sizeValue");
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.SubCategoryId).HasName("PK__SubCateg__F8206469D697E391");

            entity.ToTable("SubCategory");

            entity.Property(e => e.SubCategoryId).HasColumnName("subCategoryId");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.SubCategoryName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("subCategoryName");

            entity.HasOne(d => d.Category).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__SubCatego__categ__3B75D760");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__CB9A1CFFC4E022F6");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("status");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.VoucherId).HasName("PK__Voucher__F53389E93BB9D44F");

            entity.ToTable("Voucher");

            entity.Property(e => e.VoucherId).HasColumnName("voucherId");
            entity.Property(e => e.CusId).HasColumnName("cusId");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.ExpDate).HasColumnName("expDate");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.CusNavigation).WithMany(p => p.VouchersNavigation)
                .HasForeignKey(d => d.CusId)
                .HasConstraintName("FK__Voucher__cusId__7B5B524B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}