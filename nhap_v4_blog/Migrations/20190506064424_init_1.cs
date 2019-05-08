using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace nhap_v4_blog.Migrations
{
    public partial class init_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    BlogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Blogs_BlogId",
                        column: x => x.BlogId,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BaseId = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    PostId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "DateCreated", "Name" },
                values: new object[] { 1, new DateTime(2019, 5, 6, 13, 44, 23, 877, DateTimeKind.Local).AddTicks(1572), "Nhac Mr.Siro" });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "DateCreated", "Name" },
                values: new object[] { 2, new DateTime(2019, 5, 6, 13, 44, 23, 877, DateTimeKind.Local).AddTicks(6338), "Nhac Binh Minh Vu" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "BlogId", "Content", "DateCreated", "Title" },
                values: new object[] { 10, 1, "Đừng khóc nếu không yêu anh em sẽ hạnh phúc Rất đau nhưng anh phải lạnh lùng Phải làm em tin rằng anh đã ko còn... như ngày xưa nữa Từ đó... dù cho bên ai cũng không hạnh phúc Nhận ra trong anh tình yêu ấy ko thể thay đổi Một ký ức đã từng rất đẹp, đã kết thúc khi em về bên ai Tìm đc nhau khó thế nào Điều gì đau lòng hơn mất em... ", new DateTime(2019, 5, 6, 13, 44, 23, 877, DateTimeKind.Local).AddTicks(9345), "Cam nhan bai hat \"Tim duoc nhau kho the nao\" " });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "BlogId", "Content", "DateCreated", "Title" },
                values: new object[] { 11, 1, "Chuyện hai chúng ta bây giờ khác rồi Thật lòng anh không muốn ai phải bối rốiSợ em nhìn thấy nên anh đành phải lẳng lặng đứng xaChuyện tình thay đổi nên bây giờ trở thành người thứ baTrách ai bây giờ ? Trách mình thôi!", new DateTime(2019, 5, 6, 13, 44, 23, 878, DateTimeKind.Local).AddTicks(104), "Cam nhan bai hat \"Buc tranh tu nuoc mat\" " });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BaseId", "Content", "DateCreated", "PostId" },
                values: new object[] { 1, null, "Bai hat kha hay", new DateTime(2019, 5, 6, 13, 44, 23, 878, DateTimeKind.Local).AddTicks(1810), 10 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BaseId", "Content", "DateCreated", "PostId" },
                values: new object[] { 2, null, "Bai hat cung tam tam", new DateTime(2019, 5, 6, 13, 44, 23, 878, DateTimeKind.Local).AddTicks(2202), 11 });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BlogId",
                table: "Posts",
                column: "BlogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Blogs");
        }
    }
}
