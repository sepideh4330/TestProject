using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.DataLayer.Migrations
{
    public partial class a4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Calculation",
                schema: "identity",
                table: "GeographicalDistances",
                nullable: false,
                oldClrType: typeof(long));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Calculation",
                schema: "identity",
                table: "GeographicalDistances",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
