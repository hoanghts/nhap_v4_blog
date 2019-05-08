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
        List<PostDto> GetAll();
        PostDto GetById(int id);
        void Add(Post ob);
        void UpdateById(int id, Post ob);
        void DeleteById(int id);
        //
        List<Comment> GetAllComment(int PostId);
    }
}
