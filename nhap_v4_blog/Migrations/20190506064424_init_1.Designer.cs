﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using nhap_v4_blog;

namespace nhap_v4_blog.Migrations
{
    [DbContext(typeof(ClassDbContext))]
    [Migration("20190506064424_init_1")]
    partial class init_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("nhap_v4_blog.Models.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("nhap_v4_blog.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Blogs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2019, 5, 6, 13, 44, 23, 877, DateTimeKind.Local).AddTicks(1572),
                            Name = "Nhac Mr.Siro"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2019, 5, 6, 13, 44, 23, 877, DateTimeKind.Local).AddTicks(6338),
                            Name = "Nhac Binh Minh Vu"
                        });
                });

            modelBuilder.Entity("nhap_v4_blog.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BaseId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("PostId");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Bai hat kha hay",
                            DateCreated = new DateTime(2019, 5, 6, 13, 44, 23, 878, DateTimeKind.Local).AddTicks(1810),
                            PostId = 10
                        },
                        new
                        {
                            Id = 2,
                            Content = "Bai hat cung tam tam",
                            DateCreated = new DateTime(2019, 5, 6, 13, 44, 23, 878, DateTimeKind.Local).AddTicks(2202),
                            PostId = 11
                        });
                });

            modelBuilder.Entity("nhap_v4_blog.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 10,
                            BlogId = 1,
                            Content = "Đừng khóc nếu không yêu anh em sẽ hạnh phúc Rất đau nhưng anh phải lạnh lùng Phải làm em tin rằng anh đã ko còn... như ngày xưa nữa Từ đó... dù cho bên ai cũng không hạnh phúc Nhận ra trong anh tình yêu ấy ko thể thay đổi Một ký ức đã từng rất đẹp, đã kết thúc khi em về bên ai Tìm đc nhau khó thế nào Điều gì đau lòng hơn mất em... ",
                            DateCreated = new DateTime(2019, 5, 6, 13, 44, 23, 877, DateTimeKind.Local).AddTicks(9345),
                            Title = "Cam nhan bai hat \"Tim duoc nhau kho the nao\" "
                        },
                        new
                        {
                            Id = 11,
                            BlogId = 1,
                            Content = "Chuyện hai chúng ta bây giờ khác rồi Thật lòng anh không muốn ai phải bối rốiSợ em nhìn thấy nên anh đành phải lẳng lặng đứng xaChuyện tình thay đổi nên bây giờ trở thành người thứ baTrách ai bây giờ ? Trách mình thôi!",
                            DateCreated = new DateTime(2019, 5, 6, 13, 44, 23, 878, DateTimeKind.Local).AddTicks(104),
                            Title = "Cam nhan bai hat \"Buc tranh tu nuoc mat\" "
                        });
                });

            modelBuilder.Entity("nhap_v4_blog.Models.Comment", b =>
                {
                    b.HasOne("nhap_v4_blog.Models.Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("nhap_v4_blog.Models.Post", b =>
                {
                    b.HasOne("nhap_v4_blog.Models.Blog")
                        .WithMany("Post")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
