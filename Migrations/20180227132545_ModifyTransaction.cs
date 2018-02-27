using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TCN.Migrations
{
    public partial class ModifyTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinAmount",
                table: "Transactions",
                newName: "MinLimit");

            migrationBuilder.RenameColumn(
                name: "MaxAmount",
                table: "Transactions",
                newName: "MaxLimit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MinLimit",
                table: "Transactions",
                newName: "MinAmount");

            migrationBuilder.RenameColumn(
                name: "MaxLimit",
                table: "Transactions",
                newName: "MaxAmount");
        }
    }
}
