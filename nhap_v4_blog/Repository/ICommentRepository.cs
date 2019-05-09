using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_v4_blog.Models;
using nhap_v4_blog.DTO;

namespace nhap_v4_blog.Repository
{
    public interface ICommentRepository 
    {
        List<CommentFullDto> GetAllComment();
        CommentFullDto GetById(int id);
        void Add(CommentFullDto ob);
        void UpdateById(int id, CommentFullDto ob);
        void DeleteById(int id);
        void DeleteAllChildComment(int commentid);
        List<CommentFullDto> GetFullComment(int baseid);
        int CountAllComment();
        int CountFullComment(int id);

    }
}
