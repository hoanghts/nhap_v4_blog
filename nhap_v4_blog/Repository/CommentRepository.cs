using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_v4_blog.Models;
using nhap_v4_blog.DTO;

namespace nhap_v4_blog.Repository
{
    public class CommentRepository : ICommentRepository
    {
        ClassDbContext _db;
        public CommentRepository(ClassDbContext db)
        {
            _db = db;
        }
        public void Add(Comment ob)
        {
            _db.Comments.Add(ob);
            _db.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var comment = _db.Comments.Find(id);
            _db.Comments.Remove(comment);
            _db.SaveChanges();
        }

        public List<CommentDto> GetAll()
        {
            return (from b in _db.Comments
                    select new CommentDto
                    {
                        Id = b.Id,
                        BaseId = b.BaseId,
                        Content = b.Content,
                        PostId = b.PostId,
                        DateCreated = b.DateCreated
                    }).ToList();
        }

        public List<Comment> GetAllCommentByBaseId(int baseid)
        {
            List<Comment> re = new List<Comment>();
            layHetComment(baseid, ref re);
            return re;
            //return GetAllCommentById(baseid);
        }

        public CommentDto GetById(int id)
        {
            return (from b in _db.Comments
                    where b.Id == id
                    select new CommentDto
                    {
                        Id = b.Id,
                        BaseId = b.BaseId,
                        Content = b.Content,
                        PostId = b.PostId,
                        DateCreated = b.DateCreated
                    }).FirstOrDefault();
        }


        public void UpdateById(int id, Comment ob)
        {
            var comment = _db.Comments.Find(id);
            comment.Content = ob.Content;
            comment.PostId = ob.PostId;
            comment.DateCreated = ob.DateCreated;
            comment.BaseId = ob.BaseId;
            _db.SaveChanges();
        }
        //
        public List<Comment> GetAllComment()
        {
            return _db.Comments.ToList();
        }

        public int Count(int baseid)
        {
            int count = _db.Comments.Where(c => c.Id == baseid).Count();
            if (count == 0)
            {
                return 0;
            }
            return _db.Comments.Where(c => c.BaseId == baseid).Count() + 1;
        }
        /// <summary>
        /// ham de quy, lay ra list cac comment tu 1 id comment goc.
        /// </summary>
        /// <param name="baseid"></param>
        /// <param name="listcm"></param>
        public void layHetComment(int baseid,ref List<Comment> listcm)
        {
            var re = (from cm in _db.Comments
                     where cm.BaseId == baseid
                     select cm).ToList();
            if (re.Count() > 0)
            {
                //listcm.AddRange(re.ToList());
                foreach (var item in re)
                {
                    listcm.Add(item);
                    layHetComment(item.Id, ref listcm);

                }
            }
        }
        
        public int CountComment(int baseid)
        {
            return (from cm in _db.Comments
                    where cm.BaseId == baseid
                    select cm).Count();
        }
        public List<Comment> GetChildComment(int baseid)
        {
            return (from cm in _db.Comments
                    where cm.BaseId == baseid
                    select cm).ToList();
        }

        public List<Comment> GetAllCommentById(int baseid)
        {
            int countcm;

            List<Comment> listcm = new List<Comment>();
            List<Comment> listresult = new List<Comment>();
            
            do
            {
                countcm = CountComment(baseid);
                listcm = GetChildComment(baseid);
                listresult.AddRange(listcm);
                foreach (var item in listcm)
                { baseid = item.Id; }
            } while (countcm > 0);
            return listresult;
        }
    }
}
