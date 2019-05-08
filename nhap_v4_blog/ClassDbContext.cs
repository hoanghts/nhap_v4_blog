using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using nhap_v4_blog.Models;

namespace nhap_v4_blog
{
    public class ClassDbContext : DbContext
    {
        public ClassDbContext(DbContextOptions<ClassDbContext> options) : base(options)
        { }
            // DbSet
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Blog
            modelBuilder.Entity<Blog>().HasData(new Blog
            {
                Id = 1,
                Name = "Nhac Mr.Siro",
                DateCreated = DateTime.Now,
            }, new Blog
            {
                Id = 2,
                Name = "Nhac Binh Minh Vu",
                DateCreated = DateTime.Now,
            });

            // Post
            modelBuilder.Entity<Post>().HasData(new Post
            {
                Id = 10,
                Title = "Cam nhan bai hat \"Tim duoc nhau kho the nao\" ",
                Content = "Đừng khóc nếu không yêu anh em sẽ hạnh phúc " +
                            "Rất đau nhưng anh phải lạnh lùng Phải làm em tin rằng anh đã ko còn... " +
                            "như ngày xưa nữa Từ đó... dù cho bên ai cũng không hạnh phúc " +
                            "Nhận ra trong anh tình yêu ấy ko thể thay đổi Một ký ức đã từng rất đẹp, " +
                            "đã kết thúc khi em về bên ai Tìm đc nhau khó thế nào Điều gì đau lòng hơn mất em... ",
                DateCreated = DateTime.Now,
                BlogId = 1
            }, new Post
            {
                Id = 11,
                Title = "Cam nhan bai hat \"Buc tranh tu nuoc mat\" ",
                Content = "Chuyện hai chúng ta bây giờ khác rồi " +
                            "Thật lòng anh không muốn ai phải bối rối" +
                            "Sợ em nhìn thấy nên anh đành phải lẳng lặng đứng xa" +
                            "Chuyện tình thay đổi nên bây giờ trở thành người thứ ba" +
                            "Trách ai bây giờ ? Trách mình thôi!",
                DateCreated = DateTime.Now,
                BlogId = 1
            });

            // Comment
            modelBuilder.Entity<Comment>().HasData(new Comment
            {
                Id = 1,
                Content = "Bai hat kha hay",
                PostId = 10,
                DateCreated = DateTime.Now,

            }, new Comment
            {
                Id = 2,
                Content = "Bai hat cung tam tam",
                PostId = 11,
                DateCreated = DateTime.Now,

            });
        }
        
    }
}
