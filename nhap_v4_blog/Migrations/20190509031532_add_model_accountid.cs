using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace nhap_v4_blog.Migrations
{
    public partial class add_model_accountid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Posts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Blogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 5, 9, 10, 15, 32, 510, DateTimeKind.Local).AddTicks(3823));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 5, 9, 10, 15, 32, 510, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 5, 9, 10, 15, 32, 511, DateTimeKind.Local).AddTicks(4808));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 5, 9, 10, 15, 32, 511, DateTimeKind.Local).AddTicks(5201));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2019, 5, 9, 10, 15, 32, 511, DateTimeKind.Local).AddTicks(1338));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2019, 5, 9, 10, 15, 32, 511, DateTimeKind.Local).AddTicks(2097));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Blogs");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 5, 9, 9, 29, 8, 20, DateTimeKind.Local).AddTicks(9813));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 5, 9, 9, 29, 8, 21, DateTimeKind.Local).AddTicks(4546));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 5, 9, 9, 29, 8, 22, DateTimeKind.Local).AddTicks(1389));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 5, 9, 9, 29, 8, 22, DateTimeKind.Local).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2019, 5, 9, 9, 29, 8, 21, DateTimeKind.Local).AddTicks(7415));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2019, 5, 9, 9, 29, 8, 21, DateTimeKind.Local).AddTicks(8161));
        }
    }
}
