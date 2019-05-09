using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace nhap_v4_blog.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public int AccountId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        
        public ICollection<Comment> Comments { get; set; }
    }
}
