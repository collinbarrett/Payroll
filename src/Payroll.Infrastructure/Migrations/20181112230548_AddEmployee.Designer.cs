﻿// <auto-generated />

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payroll.Infrastructure.Migrations
{
    [DbContext(typeof(PayrollContext))]
    [Migration("20181112230548_AddEmployee")]
    partial class AddEmployee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("Payroll.Core.Entities.Employee", b =>
            {
                b.Property<int>("Id").ValueGeneratedOnAdd();

                b.Property<int>("PersonId");

                b.Property<decimal>("Salary");

                b.HasKey("Id");

                b.HasIndex("PersonId");

                b.ToTable("Employees");
            });

            modelBuilder.Entity("Payroll.Core.Entities.Person", b =>
            {
                b.Property<int>("Id").ValueGeneratedOnAdd();

                b.Property<string>("FirstName");

                b.Property<string>("LastName");

                b.HasKey("Id");

                b.ToTable("Persons");
            });

            modelBuilder.Entity("Payroll.Core.Entities.Employee", b =>
            {
                b.HasOne("Payroll.Core.Entities.Person", "Person")
                    .WithMany()
                    .HasForeignKey("PersonId")
                    .OnDelete(DeleteBehavior.Cascade);
            });
#pragma warning restore 612, 618
        }
    }
}