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
        List<BlogDto> GetAll();
        BlogDto GetById(int id);
        void Add(BlogDto ob);
        void UpdateById(int id, BlogDto ob);
        void DeleteById(int id);
        //
        List<Post> GetPost(int blogId);
        BlogDto GetTreePost(int blogid);
        int Count();
        int CountPost(int BlogId);
    }
}
