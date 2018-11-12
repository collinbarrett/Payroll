using Microsoft.EntityFrameworkCore.Migrations;

namespace Payroll.Infrastructure.Migrations
{
    public partial class AddEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Employees",
                table => new
                {
                    Id = table.Column<int>().Annotation("Sqlite:Autoincrement", true),
                    PersonId = table.Column<int>(),
                    Salary = table.Column<decimal>()
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

            migrationBuilder.CreateIndex(
                "IX_Employees_PersonId",
                "Employees",
                "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Employees");
        }
    }
}