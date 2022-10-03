using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExamDB.Migrations
{
    public partial class InvoiceChangeTotalDatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "invoices",
                type: "NUMERIC(10,2)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "NUMERIC(10,2)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InvoiceDate",
                table: "invoices",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "DATETIME");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Total",
                table: "invoices",
                type: "NUMERIC(10,2)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(double),
                oldType: "NUMERIC(10,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "InvoiceDate",
                table: "invoices",
                type: "DATETIME",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);
        }
    }
}
