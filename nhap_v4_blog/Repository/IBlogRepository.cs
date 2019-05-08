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
        void Add(Blog ob);
        void UpdateById(int id, Blog ob);
        void DeleteById(int id);
        //
        List<Post> GetPost(int blogId);
        Blog GetTreePost(int blogid);
        int Count();
        int CountPost(int BlogId);
    }
}
