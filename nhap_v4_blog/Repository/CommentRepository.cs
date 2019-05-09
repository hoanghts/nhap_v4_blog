using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_v4_blog.Models;
using nhap_v4_blog.DTO;
using AutoMapper;

namespace nhap_v4_blog.Repository
{
    public class CommentRepository : ICommentRepository
    {
        ClassDbContext _db;
        private readonly IMapper _mapper;
        public CommentRepository(ClassDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public void Add(CommentFullDto ob)
        {
            _db.Comments.Add(_mapper.Map<Comment>(ob));
            _db.SaveChanges();
        }
        public void DeleteById(int id)
        {
            var comment = _db.Comments.Find(id);
            if (comment != null) _db.Comments.Remove(comment);
            _db.SaveChanges();
        }

        public void DeleteAllChildComment(int commentid)
        {
            var re = (from cm in _db.Comments
                      where cm.BaseId == commentid
                      select cm).ToList();
            if (re.Count > 0)
            {
                foreach (var item in re)
                {
                    int countBuf = 0;
                    List<Comment> listBuf = new List<Comment>() { item };
                    while (countBuf < listBuf.Count)
                    {
                        Comment cmBuf = listBuf[countBuf];
                        var reBuf = (from cm in _db.Comments
                                     where cm.BaseId == cmBuf.Id
                                     select cm).ToList();
                        
                        listBuf.AddRange(reBuf);
                        _db.Comments.Remove(cmBuf);
                        countBuf++;
                    }
                }
                var comment = _db.Comments.Find(commentid);
                _db.Comments.Remove(comment);
                _db.SaveChanges();
            }
            
        }
        public List<CommentFullDto> GetFullComment(int baseid)
        {
            List<CommentFullDto> re = new List<CommentFullDto>();
            GetAllChildComment(baseid, ref re);
            return re;
        } 

        public CommentFullDto GetById(int id)
        {
            var cmdto = _mapper.Map<CommentFullDto>(_db.Comments.Find(id));
            return cmdto;
        }


        public void UpdateById(int id, CommentFullDto ob)
        {
            var cm = _mapper.Map<Comment>(ob);
            var comment = _db.Comments.Find(id);
            comment.AccountId = cm.AccountId;
            comment.Content = cm.Content;
            comment.PostId = cm.PostId;
            comment.DateCreated = cm.DateCreated;
            comment.BaseId = cm.BaseId;
            _db.SaveChanges();
        }
        //
        public List<CommentFullDto> GetAllComment()
        {
            var re = _db.Comments.ToList();
            return CreateDTOList(re);
        }

        public int CountAllComment()
        {
            return  _db.Comments.Count();
        }
        /// <summary>
        /// Tu id cua 1 comment dem tat ca so comment con
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CountFullComment(int id)
        {
            int result = 0;
            var re = (from cm in _db.Comments
                      where cm.BaseId == id
                      select cm).ToList();
            result = result + re.Count;
            foreach (var item in re)
            {
                int countBuf = 0;
                List<Comment> listBuf = new List<Comment>() { item };
                while (countBuf < listBuf.Count)
                {
                    Comment cmBuf = listBuf[countBuf];
                    var reBuf = (from cm in _db.Comments
                                 where cm.BaseId == cmBuf.Id
                                 select cm).ToList();
                    result = result + reBuf.Count;
                    listBuf.AddRange(reBuf);
                    countBuf++;
                }
            }
            return result;
        }

        // Function phu
        //public CommentFullDto CreateDTO(Comment cur)
        //{
        //    CommentFullDto tmp = new CommentFullDto();
        //    tmp.Id = cur.Id;
        //    tmp.PostId = cur.PostId;
        //    tmp.AccountId = cur.AccountId;
        //    tmp.BaseId = cur.BaseId;
        //    tmp.Content = cur.Content;
        //    tmp.DateCreated = cur.DateCreated;
        //    return tmp;
        //}
        public List<CommentFullDto> CreateDTOList(IList<Comment> listCmt)
        {
            if (listCmt == null) return null;
            List<CommentFullDto> result = new List<CommentFullDto>(listCmt.Count);
            foreach (Comment cmt in listCmt)
            {
                result.Add(_mapper.Map<CommentFullDto>(cmt));
            }
            return result;
        }
       
        public void GetAllChildComment(int baseid, ref List<CommentFullDto> listresult)
        {
            List<CommentFullDto> buffer = new List<CommentFullDto>();
            var parent = _db.Comments.Find(baseid);
            if (parent != null)
            {
                listresult.Add(_mapper.Map<CommentFullDto>(parent));
                var re = (from cm in _db.Comments
                          where cm.BaseId == baseid
                          select cm).ToList();
                foreach (Comment item in re)
                {
                    buffer.Add(getChildComment(item));
                }
                listresult[0].SubComments = buffer;
            }
            
        }
        public CommentFullDto getChildComment(Comment cmm)
        {
            List<Comment> buf = new List<Comment> { cmm };
            List<CommentFullDto> result = CreateDTOList(buf);
            int count = 0;
            while (count < buf.Count)
            {
                Comment bufCm = buf[count];
                var re = (from cm in _db.Comments
                          where cm.BaseId == bufCm.Id
                          select cm).ToList();
                if (re.Count() > 0)
                {
                    buf.AddRange(re);
                    result[count].SubComments = CreateDTOList(re);
                    result.AddRange(result[count].SubComments);
                }
                count++;
            }
            return result[0];
        }
    }
}
