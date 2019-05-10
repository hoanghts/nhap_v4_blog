using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_v4_blog.Repository;
using nhap_v4_blog.Models;
using nhap_v4_blog.DTO;
using AutoMapper;

namespace nhap_v4_blog.Repository
{
    public class PostRepository : IPostRepository
    {
        ClassDbContext _db;
        ICommentRepository _cmRe;
        private readonly IMapper _mapper;
        public PostRepository(ClassDbContext db, ICommentRepository cmRe, IMapper mapper)
        {
            _db = db;
            _cmRe = cmRe;
            _mapper = mapper;
        }
        public void Add(PostDto ob)
        {
            _db.Posts.Add(_mapper.Map<Post>(ob));
            _db.SaveChanges();
        }

        public void Delete(int Id)
        {
            var post = _db.Posts.Find(Id);
            if (post != null) _db.Posts.Remove(post);

            var comment = _db.Comments.Where(cm => cm.PostId == Id).ToList();
            if (comment != null) _db.Comments.RemoveRange(comment);
            _db.SaveChanges();
        }

        //public List<PostDto> Get()
        //{
        //    return (from b in _db.Posts
        //            select new PostDto
        //            {
        //                Id = b.Id,
        //                AccountId = b.AccountId,
        //                Title = b.Title,
        //                Content = b.Content,
        //                BlogId = b.BlogId,
        //                DateCreated = b.DateCreated
        //            }).ToList();
        //}

        public List<CommentDto> GetComment(int Id)
        {
            var re = (from c in _db.Comments
                    where (c.PostId == Id && c.BaseId == null)
                    select c).ToList();
            return _mapper.Map<List<CommentDto>>(re);
        }
        //public List<CommentFullDto> GetAllChildComment(int PostId)
        //{
        //    List<CommentFullDto> result = new List<CommentFullDto>();
        //    List<CommentFullDto> buffer = new List<CommentFullDto>();
        //    var re = (from c in _db.Comments
        //               where (c.PostId == PostId && c.BaseId == null)
        //               select c).ToList();
        //    int count = 0;
        //    foreach (var item in re)
        //    {
        //        result.Add(_mapper.Map<CommentFullDto>(item));
        //        buffer = _cmRe.GetFullComment(item.Id);
        //        result[count].SubComments = buffer;
        //        count++;
        //    }
        //    return result;
        //}

        public PostDto Get(int Id)
        {
            return (from b in _db.Posts
                  where b.Id == Id
                    select new PostDto
                  {
                      Id = b.Id,
                      AccountId = b.AccountId,
                      Title = b.Title,
                      Content = b.Content,
                      BlogId = b.BlogId,
                      DateCreated = b.DateCreated
                  }).FirstOrDefault();
        }

        public void Update(int Id, PostDto ob)
        {
            var post = _db.Posts.Find(Id);
            post.AccountId = ob.AccountId;
            post.Title = ob.Title;
            post.Content = ob.Content;
            post.BlogId = ob.BlogId;
            post.DateCreated = ob.DateCreated;
            _db.SaveChanges();
        }

        public int Count()
        {
            return _db.Posts.Count();
        }

        public int CountComment(int Id)
        {
            return _db.Comments.Where(p => p.PostId == Id).Count();
        }
        //
    }
}
