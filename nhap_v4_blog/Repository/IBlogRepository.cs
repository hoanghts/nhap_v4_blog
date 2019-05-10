using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_v4_blog.Models;
using nhap_v4_blog.DTO;

namespace nhap_v4_blog.Repository
{
    public interface IBlogRepository
    {
        List<BlogDto> Get();
        BlogDto Get(int Id);
        void Add(BlogDto Id);
        void Update(int Id, BlogDto ob);
        void Delete(int Id);
        //
        List<PostDto> GetPost(int BlogId);
        //BlogFullDto GetFullPost(int BlogId);
        int Count();
        int CountPost(int BlogId);
    }
}
