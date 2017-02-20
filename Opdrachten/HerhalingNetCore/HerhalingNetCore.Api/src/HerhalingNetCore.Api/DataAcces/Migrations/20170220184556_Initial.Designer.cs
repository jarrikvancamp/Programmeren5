using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HerhalingNetCore.Api.DataAcces.Context;

namespace HerhalingNetCore.Api.Migrations
{
    [DbContext(typeof(EntityContext))]
    [Migration("20170220184556_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HerhalingNetCore.Api.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BusNumber");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("Number");

                    b.Property<string>("PostalCode");

                    b.Property<string>("StreetName");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("HerhalingNetCore.Api.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyAddressId");

                    b.Property<string>("CompanyBtwNumber");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyAddressId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("HerhalingNetCore.Api.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BillingAddressId");

                    b.Property<int?>("DeliveryAddresId");

                    b.Property<string>("Firstname");

                    b.Property<string>("Lastname");

                    b.HasKey("Id");

                    b.HasIndex("BillingAddressId");

                    b.HasIndex("DeliveryAddresId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("HerhalingNetCore.Api.Entities.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CompanyId");

                    b.Property<int?>("CustomerId");

                    b.Property<int>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("HerhalingNetCore.Api.Entities.InvoiceLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("InvoiceId");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ProductId");

                    b.ToTable("InvoiceLines");
                });

            modelBuilder.Entity("HerhalingNetCore.Api.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<decimal>("PricePerQuantity");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("HerhalingNetCore.Api.Entities.Company", b =>
                {
                    b.HasOne("HerhalingNetCore.Api.Entities.Address", "CompanyAddress")
                        .WithMany()
                        .HasForeignKey("CompanyAddressId");
                });

            modelBuilder.Entity("HerhalingNetCore.Api.Entities.Customer", b =>
                {
                    b.HasOne("HerhalingNetCore.Api.Entities.Address", "BillingAddress")
                        .WithMany()
                        .HasForeignKey("BillingAddressId");

                    b.HasOne("HerhalingNetCore.Api.Entities.Address", "DeliveryAddres")
                        .WithMany()
                        .HasForeignKey("DeliveryAddresId");
                });

            modelBuilder.Entity("HerhalingNetCore.Api.Entities.Invoice", b =>
                {
                    b.HasOne("HerhalingNetCore.Api.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");

                    b.HasOne("HerhalingNetCore.Api.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("HerhalingNetCore.Api.Entities.InvoiceLine", b =>
                {
                    b.HasOne("HerhalingNetCore.Api.Entities.Invoice")
                        .WithMany("InvoiceLines")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("HerhalingNetCore.Api.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });
        }
    }
}
