using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TCN.Migrations
{
    public partial class ChangeTransactionToTrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Transactions_TransactionId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "TransactionCoins");

            migrationBuilder.DropTable(
                name: "TransactionFxs");

            migrationBuilder.DropIndex(
                name: "IX_Photos_TransactionId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "TransactionId",
                table: "Photos");

            migrationBuilder.AddColumn<int>(
                name: "TradeId",
                table: "Photos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TradeCoins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeCoins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TradeFxs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeFxs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    MaxLimit = table.Column<int>(nullable: false),
                    MinLimit = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    TradeCoinId = table.Column<int>(nullable: false),
                    TradeFxId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trades_TradeCoins_TradeCoinId",
                        column: x => x.TradeCoinId,
                        principalTable: "TradeCoins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trades_TradeFxs_TradeFxId",
                        column: x => x.TradeFxId,
                        principalTable: "TradeFxs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trades_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_TradeId",
                table: "Photos",
                column: "TradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_TradeCoinId",
                table: "Trades",
                column: "TradeCoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_TradeFxId",
                table: "Trades",
                column: "TradeFxId");

            migrationBuilder.CreateIndex(
                name: "IX_Trades_UserId",
                table: "Trades",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Trades_TradeId",
                table: "Photos",
                column: "TradeId",
                principalTable: "Trades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_Trades_TradeId",
                table: "Photos");

            migrationBuilder.DropTable(
                name: "Trades");

            migrationBuilder.DropTable(
                name: "TradeCoins");

            migrationBuilder.DropTable(
                name: "TradeFxs");

            migrationBuilder.DropIndex(
                name: "IX_Photos_TradeId",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "TradeId",
                table: "Photos");

            migrationBuilder.AddColumn<int>(
                name: "TransactionId",
                table: "Photos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TransactionCoins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionCoins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionFxs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionFxs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeletedAt = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LastUpdatedAt = table.Column<DateTime>(nullable: false),
                    MaxLimit = table.Column<int>(nullable: false),
                    MinLimit = table.Column<int>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    TransactionCoinId = table.Column<int>(nullable: false),
                    TransactionFxId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionCoins_TransactionCoinId",
                        column: x => x.TransactionCoinId,
                        principalTable: "TransactionCoins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionFxs_TransactionFxId",
                        column: x => x.TransactionFxId,
                        principalTable: "TransactionFxs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Photos_TransactionId",
                table: "Photos",
                column: "TransactionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionCoinId",
                table: "Transactions",
                column: "TransactionCoinId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionFxId",
                table: "Transactions",
                column: "TransactionFxId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_UserId",
                table: "Transactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_Transactions_TransactionId",
                table: "Photos",
                column: "TransactionId",
                principalTable: "Transactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
