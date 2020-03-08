using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infastructure.Migrations
{
    public partial class removeOwnerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "owner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "owner",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_owner", x => x.OwnerId);
                });
        }
    }
}
