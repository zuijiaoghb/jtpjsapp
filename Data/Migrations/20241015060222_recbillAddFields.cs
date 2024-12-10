using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jtpjsapp.Migrations
{
    /// <inheritdoc />
    public partial class recbillAddFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RecBillModels",
                keyColumn: "OwnerID",
                keyValue: null,
                column: "OwnerID",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerID",
                table: "RecBillModels",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddTime",
                table: "RecBillModels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "RecBillModels",
                type: "decimal(14,2)",
                precision: 14,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Company",
                table: "RecBillModels",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Endorser",
                table: "RecBillModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "IsMotherTicket",
                table: "RecBillModels",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifyTime",
                table: "RecBillModels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "TransferAmount",
                table: "RecBillModels",
                type: "decimal(14,2)",
                precision: 14,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddTime",
                table: "RecBillModels");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "RecBillModels");

            migrationBuilder.DropColumn(
                name: "Company",
                table: "RecBillModels");

            migrationBuilder.DropColumn(
                name: "Endorser",
                table: "RecBillModels");

            migrationBuilder.DropColumn(
                name: "IsMotherTicket",
                table: "RecBillModels");

            migrationBuilder.DropColumn(
                name: "ModifyTime",
                table: "RecBillModels");

            migrationBuilder.DropColumn(
                name: "TransferAmount",
                table: "RecBillModels");

            migrationBuilder.AlterColumn<string>(
                name: "OwnerID",
                table: "RecBillModels",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
