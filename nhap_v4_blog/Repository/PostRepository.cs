using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_v4_blog.Repository;
using nhap_v4_blog.Models;
using nhap_v4_blog.DTO;

namespace nhap_v4_blog.Repository
{
    public class PostRepository : IPostRepository
    {
        ClassDbContext _db;
        public PostRepository(ClassDbContext db)
        {
            _db = db;
        }
        public void Add(Post ob)
        {
            _db.Posts.Add(ob);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var post = _db.Posts.Find(id);
            _db.Posts.Remove(post);
            _db.SaveChanges();
        }

        public List<PostDto> GetAll()
        {
            return (from b in _db.Posts
                    select new PostDto
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Content = b.Content,
                        BlogId = b.BlogId,
                        DateCreated = b.DateCreated
                    }).ToList();
        }

        public List<Comment> GetAllComment(int PostId)
        {
            return (from c in _db.Comments
                    where c.PostId == PostId
                    select c).ToList();
        }

        public PostDto GetById(int id)
        {
            return (from b in _db.Posts
                  where b.Id == id
                  select new PostDto
                  {
                      Id = b.Id,
                      Title = b.Title,
                      Content = b.Content,
                      BlogId = b.BlogId,
                      DateCreated = b.DateCreated
                  }).FirstOrDefault();
        }

        public void UpdateById(int id, Post ob)
        {
            var post = _db.Posts.Find(id);
            post.Title = ob.Title;
            post.Content = ob.Content;
            post.BlogId = ob.BlogId;
            post.DateCreated = ob.DateCreated;
            post.Comments = ob.Comments;
            _db.SaveChanges();
        }

        //
    }
}
