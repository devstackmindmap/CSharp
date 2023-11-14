using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebEFConcurrency.Migrations
{
    public partial class AlterTableUser2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "user");

            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "user",
                type: "longblob",
                rowVersion: true,
                nullable: false)
                .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.ComputedColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "user");

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "user",
                type: "longblob",
                nullable: false);
        }
    }
}
