using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace nhap_v4_blog.Migrations
{
    public partial class add_propety_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Comments",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 5, 7, 9, 51, 19, 308, DateTimeKind.Local).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 5, 7, 9, 51, 19, 309, DateTimeKind.Local).AddTicks(933));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 5, 7, 9, 51, 19, 310, DateTimeKind.Local).AddTicks(361));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 5, 7, 9, 51, 19, 310, DateTimeKind.Local).AddTicks(743));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2019, 5, 7, 9, 51, 19, 309, DateTimeKind.Local).AddTicks(6941));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2019, 5, 7, 9, 51, 19, 309, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentId",
                table: "Comments",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentId",
                table: "Comments",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 5, 6, 13, 44, 23, 877, DateTimeKind.Local).AddTicks(1572));

            migrationBuilder.UpdateData(
                table: "Blogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 5, 6, 13, 44, 23, 877, DateTimeKind.Local).AddTicks(6338));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2019, 5, 6, 13, 44, 23, 878, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateCreated",
                value: new DateTime(2019, 5, 6, 13, 44, 23, 878, DateTimeKind.Local).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateCreated",
                value: new DateTime(2019, 5, 6, 13, 44, 23, 877, DateTimeKind.Local).AddTicks(9345));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateCreated",
                value: new DateTime(2019, 5, 6, 13, 44, 23, 878, DateTimeKind.Local).AddTicks(104));
        }
    }
}
