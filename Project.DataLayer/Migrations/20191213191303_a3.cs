using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.DataLayer.Migrations
{
    public partial class a3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeographicalDistances",
                schema: "identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDateTimeOn = table.Column<DateTimeOffset>(nullable: false),
                    CreatorIp = table.Column<string>(maxLength: 45, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Calculation = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeographicalDistances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeographicalDistances_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeographicalDistances_UserId",
                schema: "identity",
                table: "GeographicalDistances",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeographicalDistances",
                schema: "identity");
        }
    }
}
