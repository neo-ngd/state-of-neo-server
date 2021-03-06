﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace StateOfNeo.Data.Migrations
{
    public partial class AddDecimalPrecision1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SystemFee",
                table: "Transactions",
                type: "decimal(18, 9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetworkFee",
                table: "Transactions",
                type: "decimal(18, 9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "TransactedAssets",
                type: "decimal(18, 9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "RegisterTransactions",
                type: "decimal(18, 9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Gas",
                table: "InvocationTransactions",
                type: "decimal(18, 9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TimeInSeconds",
                table: "Blocks",
                type: "decimal(18, 9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "AddressBalances",
                type: "decimal(18, 9)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SystemFee",
                table: "Transactions",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 9)");

            migrationBuilder.AlterColumn<decimal>(
                name: "NetworkFee",
                table: "Transactions",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 9)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "TransactedAssets",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 9)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "RegisterTransactions",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 9)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Gas",
                table: "InvocationTransactions",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 9)");

            migrationBuilder.AlterColumn<decimal>(
                name: "TimeInSeconds",
                table: "Blocks",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 9)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Balance",
                table: "AddressBalances",
                type: "decimal(18, 6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18, 9)");
        }
    }
}
