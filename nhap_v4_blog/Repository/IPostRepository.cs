using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_v4_blog.Models;
using nhap_v4_blog.DTO;

namespace nhap_v4_blog.Repository
{
    public interface IPostRepository
    {
        //List<PostDto> Get();
        PostDto Get(int Id);
        void Add(PostDto ob);
        void Update(int Id, PostDto ob);
        void Delete(int Id);
        //
        List<CommentDto> GetComment(int Id);
        //List<CommentFullDto> GetAllChildComment(int PostId);
        int Count();
        int CountComment(int Id);
    }
}
