﻿// <auto-generated />
using InvoiceCalendar.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace InvoiceCalendar.Migrations
{
    [DbContext(typeof(MyDatabaseContext))]
    partial class MyDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("InvoiceCalendar.Models.Invoice", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("OwnerID");

                    b.Property<double>("Price");

                    b.Property<int>("Status");

                    b.HasKey("ID");

                    b.ToTable("Invoice");
                });
#pragma warning restore 612, 618
        }
    }
}
