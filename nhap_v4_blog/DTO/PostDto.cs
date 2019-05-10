using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nhap_v4_blog.DTO
{
    public class PostDto
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int AccountId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class PostFullDto
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int AccountId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<CommentDto> Comments { get; set; }
    }
    public class PostFullDto_1
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int AccountId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<CommentFullDto> Comments { get; set; }
    }
}
