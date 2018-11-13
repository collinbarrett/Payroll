using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Payroll.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Persons",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateCreatedUtc = table.Column<DateTime>("TIMESTAMP", nullable: false,
                        defaultValueSql: "current_timestamp()"),
                    DateModifiedUtc = table.Column<DateTime>("TIMESTAMP", nullable: false,
                        defaultValueSql: "current_timestamp() ON UPDATE current_timestamp()"),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Persons", x => x.Id); });

            migrationBuilder.CreateTable(
                "Employees",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateCreatedUtc = table.Column<DateTime>("TIMESTAMP", nullable: false,
                        defaultValueSql: "current_timestamp()"),
                    DateModifiedUtc = table.Column<DateTime>("TIMESTAMP", nullable: false,
                        defaultValueSql: "current_timestamp() ON UPDATE current_timestamp()"),
                    PersonId = table.Column<int>(),
                    Salary = table.Column<decimal>(nullable: false, defaultValue: 52000m),
                    BenefitsDeduction = table.Column<decimal>(nullable: false, defaultValue: 1000m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        "FK_Employees_Persons_PersonId",
                        x => x.PersonId,
                        "Persons",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Dependents",
                table => new
                {
                    Id = table.Column<int>()
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateCreatedUtc = table.Column<DateTime>("TIMESTAMP", nullable: false,
                        defaultValueSql: "current_timestamp()"),
                    DateModifiedUtc = table.Column<DateTime>("TIMESTAMP", nullable: false,
                        defaultValueSql: "current_timestamp() ON UPDATE current_timestamp()"),
                    EmployeeId = table.Column<int>(),
                    PersonId = table.Column<int>(),
                    BenefitsDeduction = table.Column<decimal>(nullable: false, defaultValue: 500m)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.Id);
                    table.ForeignKey(
                        "FK_Dependents_Employees_EmployeeId",
                        x => x.EmployeeId,
                        "Employees",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Dependents_Persons_PersonId",
                        x => x.PersonId,
                        "Persons",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                "IX_Dependents_EmployeeId",
                "Dependents",
                "EmployeeId");

            migrationBuilder.CreateIndex(
                "IX_Dependents_PersonId",
                "Dependents",
                "PersonId");

            migrationBuilder.CreateIndex(
                "IX_Employees_PersonId",
                "Employees",
                "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Dependents");

            migrationBuilder.DropTable(
                "Employees");

            migrationBuilder.DropTable(
                "Persons");
        }
    }
}