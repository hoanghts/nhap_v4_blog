using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_v4_blog.Models;
using Microsoft.EntityFrameworkCore;
using nhap_v4_blog.DTO;
using AutoMapper;

namespace nhap_v4_blog.Repository
{
    public class BlogRepository : IBlogRepository
    {
        ClassDbContext _db;
        IPostRepository _postRe;
        private readonly IMapper _mapper;
        public BlogRepository(ClassDbContext db, IPostRepository postRe, IMapper mapper)
        {
            _db = db;
            _postRe = postRe;
            _mapper = mapper;
        }

        public void Add(BlogDto ob)
        {
            _db.Blogs.Add(_mapper.Map<Blog>(ob));
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var blog = _db.Blogs.Find(id);
            if (blog != null) _db.Blogs.Remove(blog);
            var post = _db.Posts.Where(p => p.BlogId == id).ToList();
            if (post != null)
            {
                foreach (var item in post)
                {
                    _postRe.DeleteById(item.Id);
                }
            }
            _db.SaveChanges();
        }

        public List<BlogDto> GetAll()
        {
            return (from b in _db.Blogs
                    select new BlogDto
                    {
                        Id = b.Id,
                        AccountId = b.AccountId,
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
                        AccountId = b.AccountId,
                        Name = b.Name,
                        DateCreated = b.DateCreated
                    }).FirstOrDefault();
        }

        public void UpdateById(int id, BlogDto ob)
        {
            var blog = _db.Blogs.Find(id);
            blog.AccountId = ob.AccountId;
            blog.Name = ob.Name;
            blog.DateCreated = ob.DateCreated;
            _db.SaveChanges();
        }

        public List<Post> GetPost(int blogId)
        {
            var result = from p in _db.Posts
                         where p.BlogId == blogId
                         select p;

            return result.ToList();
        }

        public BlogDto GetTreePost(int blogid)
        {
            var re =  _db.Blogs.Include(p => p.Post)
                            .FirstOrDefault(p => p.Id == blogid);
            return _mapper.Map<BlogDto>(re);
        }
        public int Count()
        {
            return _db.Blogs.Count();
        }
        public int CountPost(int BlogId)
        {
            return _db.Posts.Where(p => p.BlogId == BlogId).Count();
        }
    }
}
