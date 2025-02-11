﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Contexts;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240531120548_Add Other Data")]
    partial class AddOtherData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.4.24267.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Accounts", b =>
                {
                    b.Property<int>("IdAccount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_account");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAccount"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("IdRole")
                        .HasColumnType("int")
                        .HasColumnName("FK_role");

                    b.Property<string>("Phone")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("phone");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.HasKey("IdAccount");

                    b.HasIndex("IdRole");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            IdAccount = 1,
                            Email = "msadsa@gmail.com",
                            FirstName = "Max",
                            IdRole = 1,
                            Phone = "09696262",
                            SecondName = "Valko"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Carts", b =>
                {
                    b.Property<int>("IdAccount")
                        .HasColumnType("int")
                        .HasColumnName("FK_account");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int")
                        .HasColumnName("FK_product");

                    b.Property<int>("Amount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.HasKey("IdAccount", "IdProduct");

                    b.HasIndex("IdProduct");

                    b.ToTable("Shopping_Carts");

                    b.HasData(
                        new
                        {
                            IdAccount = 1,
                            IdProduct = 1,
                            Amount = 200
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Categories", b =>
                {
                    b.Property<int>("IdCategories")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_category");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategories"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("IdCategories");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            IdCategories = 1,
                            Name = "Category 1"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Products", b =>
                {
                    b.Property<int>("PkProducts")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_product");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkProducts"));

                    b.Property<decimal>("Depth")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("depth");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("height");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("weight");

                    b.Property<decimal>("Width")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("width");

                    b.HasKey("PkProducts");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            PkProducts = 1,
                            Depth = 2.7m,
                            Height = 3.1m,
                            Name = "Milk",
                            Weight = 2.1m,
                            Width = 2.3m
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.ProductsCategories", b =>
                {
                    b.Property<int>("IdProduct")
                        .HasColumnType("int")
                        .HasColumnName("FK_product");

                    b.Property<int>("IdCategory")
                        .HasColumnType("int")
                        .HasColumnName("FK_category");

                    b.HasKey("IdProduct", "IdCategory");

                    b.HasIndex("IdCategory");

                    b.ToTable("Products_Categories");

                    b.HasData(
                        new
                        {
                            IdProduct = 1,
                            IdCategory = 1
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Roles", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_role");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRole"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("IdRole");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            IdRole = 1,
                            Name = "Someone"
                        });
                });

            modelBuilder.Entity("WebApplication1.Models.Accounts", b =>
                {
                    b.HasOne("WebApplication1.Models.Roles", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebApplication1.Models.Carts", b =>
                {
                    b.HasOne("WebApplication1.Models.Accounts", "Account")
                        .WithMany("Carts")
                        .HasForeignKey("IdAccount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Products", "Product")
                        .WithMany("Carts")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebApplication1.Models.ProductsCategories", b =>
                {
                    b.HasOne("WebApplication1.Models.Categories", "Category")
                        .WithMany("ProductsCategories")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Products", "Product")
                        .WithMany("ProductsCategories")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebApplication1.Models.Accounts", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("WebApplication1.Models.Categories", b =>
                {
                    b.Navigation("ProductsCategories");
                });

            modelBuilder.Entity("WebApplication1.Models.Products", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("ProductsCategories");
                });

            modelBuilder.Entity("WebApplication1.Models.Roles", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
