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
        //List<CommentFullDto> Get();
        CommentDto Get(int Id);
        void Add(CommentDto ob);
        void Update(int Id, CommentDto ob);
        void Delete(int Id);
        //void DeleteAllChildComment(int CommentId);
        List<CommentFullDto> GetFullComment(int Id);
        int Count();
        int CountFullComment(int Id);

    }
}
