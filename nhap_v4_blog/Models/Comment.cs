using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nhap_v4_blog.Models
{
    public class Comment
    {
        public Comment()
        {
            SubComments = new List<Comment>();
        }
        public int Id { get; set; }
        public int? BaseId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }

        public int PostId { get; set; }

        [ForeignKey("BaseId")]
        public virtual ICollection<Comment> SubComments { get; set; }
    }
}
