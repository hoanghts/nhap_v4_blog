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
        List<CommentDto> GetAll();
        CommentDto GetById(int id);
        void Add(Comment ob);
        void UpdateById(int id, Comment ob);
        void DeleteById(int id);
        //
        List<Comment> GetAllCommentByBaseId(int baseid);
        List<Comment> GetAllComment();
        int Count(int baseid);
    }
}
