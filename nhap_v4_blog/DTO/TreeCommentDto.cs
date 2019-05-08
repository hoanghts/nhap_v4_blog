using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nhap_v4_blog.DTO
{
    public class TreeCommentDto
    {
        public int Id { get; set; }
        public int? BaseId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }

        public int PostId { get; set; }
        public ICollection<TreeCommentDto> TreeCommentDtos { get; set; }


    }
}
