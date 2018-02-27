using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TCN.Migrations
{
    public partial class ApplyConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionFx_TransactionFxId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionFx",
                table: "TransactionFx");

            migrationBuilder.RenameTable(
                name: "TransactionFx",
                newName: "TransactionFxs");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TransactionFxs",
                type: "varchar(3)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TransactionCoins",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionFxs",
                table: "TransactionFxs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionFxs_TransactionFxId",
                table: "Transactions",
                column: "TransactionFxId",
                principalTable: "TransactionFxs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_TransactionFxs_TransactionFxId",
                table: "Transactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TransactionFxs",
                table: "TransactionFxs");

            migrationBuilder.RenameTable(
                name: "TransactionFxs",
                newName: "TransactionFx");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TransactionFx",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(3)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TransactionCoins",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TransactionFx",
                table: "TransactionFx",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_TransactionFx_TransactionFxId",
                table: "Transactions",
                column: "TransactionFxId",
                principalTable: "TransactionFx",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
