using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace nhap_v4_blog.Migrations
{
    public partial class add_propeties_model_account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Accounts",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "_Gender",
                table: "Accounts",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BaseId",
                table: "Comments",
                column: "BaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_BaseId",
                table: "Comments",
                column: "BaseId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_BaseId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BaseId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "_Gender",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Accounts",
                newName: "AccountId");

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
    }
}
