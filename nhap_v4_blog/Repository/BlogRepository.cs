using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_v4_blog.Models;
using Microsoft.EntityFrameworkCore;
using nhap_v4_blog.DTO;

namespace nhap_v4_blog.Repository
{
    public class BlogRepository : IBlogRepository
    {
        ClassDbContext _db;
        public BlogRepository(ClassDbContext db)
        {
            _db = db;
        }

        public void Add(Blog ob)
        {
            _db.Blogs.Add(ob);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var blog = _db.Blogs.Find(id);
            _db.Blogs.Remove(blog);
            _db.SaveChanges();
        }

        public List<BlogDto> GetAll()
        {
            return (from b in _db.Blogs
                    select new BlogDto
                    {
                        Id = b.Id,
                        Name = b.Name,
                        DateCreated = b.DateCreated
                    }).ToList();
        }

        public BlogDto GetById(int id)
        {
            return (from b in _db.Blogs
                    where b.Id == id
                    select new BlogDto
                    {
                        Id = b.Id,
                        Name = b.Name,
                        DateCreated = b.DateCreated
                    }).FirstOrDefault();
        }

        public void UpdateById(int id, Blog ob)
        {
            var blog = _db.Blogs.Find(id);
            blog.Name = ob.Name;
            blog.DateCreated = ob.DateCreated;
            blog.Post = ob.Post;
            _db.SaveChanges();
        }

        public List<Post> GetPost(int blogId)
        {
            var result = from p in _db.Posts
                         where p.BlogId == blogId
                         select p;

            return result.ToList();
        }

        public Blog GetTreePost(int blogid)
        {
            return  _db.Blogs.Include(p => p.Post)
                            .FirstOrDefault(p => p.Id == blogid);
        }
        public int Count()
        {
            return _db.Blogs.Count();
        }
        public int CountPost(int BlogId)
        {
            return _db.Posts.Where(p =>)
        }
    }
}
