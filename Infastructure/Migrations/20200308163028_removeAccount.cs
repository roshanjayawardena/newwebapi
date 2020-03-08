using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infastructure.Migrations
{
    public partial class removeAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    AccountType = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    OwnerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.AccountId);
                });
        }
    }
}
