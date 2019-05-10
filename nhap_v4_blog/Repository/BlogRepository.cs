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

        public void Delete(int Id)
        {
            var blog = _db.Blogs.Find(Id);
            if (blog != null) _db.Blogs.Remove(blog);
            var post = _db.Posts.Where(p => p.BlogId == Id).ToList();
            if (post != null)
            {
                foreach (var item in post)
                {
                    _postRe.Delete(item.Id);
                }
            }
            _db.SaveChanges();
        }

        public List<BlogDto> Get()
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

        public BlogDto Get(int Id)
        {
            return _mapper.Map<BlogDto>(_db.Blogs.Find(Id));
        }

        public void Update(int Id, BlogDto ob)
        {
            var blog = _db.Blogs.Find(Id);
            blog.AccountId = ob.AccountId;
            blog.Name = ob.Name;
            blog.DateCreated = ob.DateCreated;
            _db.SaveChanges();
        }

        public List<PostDto> GetPost(int BlogId)
        {
            var result = from p in _db.Posts
                         where p.BlogId == BlogId
                         select p;

            return _mapper.Map<List<PostDto>>(result.ToList());
        }

        //public BlogFullDto GetFullPost(int BlogId)
        //{
        //    var re =  _db.Blogs.Include(p => p.Post)
        //                    .FirstOrDefault(p => p.Id == BlogId);
        //    return _mapper.Map<BlogFullDto>(re);
        //}
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
