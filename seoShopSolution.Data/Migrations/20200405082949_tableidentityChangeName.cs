using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace seoShopSolution.Data.Migrations
{
    public partial class tableidentityChangeName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(name: "Users", schema: "dbo", newName: "AppUsers", newSchema: "dbo");
            migrationBuilder.RenameTable(name: "Roles", schema: "dbo", newName: "AppRoles", newSchema: "dbo");
        }
    }
}
