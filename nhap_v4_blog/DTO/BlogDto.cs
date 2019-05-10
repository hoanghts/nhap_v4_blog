using nhap_v4_blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nhap_v4_blog.DTO
{
    public class BlogDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class BlogFullDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<PostDto> Post { get; set; }
    }
}
