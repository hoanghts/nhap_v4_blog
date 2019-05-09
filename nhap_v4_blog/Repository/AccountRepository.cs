using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using nhap_v4_blog.DTO;
using nhap_v4_blog.Models;

namespace nhap_v4_blog.Repository
{
    public class AccountRepository : IAccountRepository
    {
        ClassDbContext _db;
        private readonly IMapper _mapper;
        public AccountRepository(ClassDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public void Add(AccountDto ob)
        {
            _db.Accounts.Add(_mapper.Map<Account>(ob));
            _db.SaveChanges();
        }

        public int Count()
        {
            return _db.Accounts.Count();
        }

        public DetailAccountItem CountItem(int id)
        {
            DetailAccountItem detail = new DetailAccountItem();
            detail.numberBlog = getDetailBlogByAccount(id);
            detail.numberPost = getDetailPostByAccount(id);
            detail.numberComment = getDetailCommentByAccount(id);
            return detail;
        }

        public void DeleteById(int id)
        {
            _db.Remove(_db.Accounts.Find(id));
            _db.SaveChanges();
        }

        public List<AccountDto> GetAll()
        {
            return (from a in _db.Accounts
                    select new AccountDto
                    {
                        Id = a.Id,
                        Name = a.Name,
                        Age = a.Age,
                        Email = a.Email,
                        _Gender = a._Gender
                    }).ToList();
        }

        public AccountDto GetById(int id)
        {
            return (from a in _db.Accounts
                   where a.Id == id
                   select new AccountDto
                   {
                       Id = a.Id,
                       Name = a.Name,
                       Age = a.Age,
                       Email = a.Email,
                       _Gender = a._Gender
                   }).FirstOrDefault();
        }

        public void UpdateById(int id, AccountDto ac)
        {
            var re = _db.Accounts.Find(id);
            re.Id = ac.Id;
            re.Name = ac.Name;
            re.Age = ac.Age;
            re.Email = ac.Email;
            re._Gender = ac._Gender;
            _db.SaveChanges();
        }

        //
        public numberDetail getDetailBlogByAccount(int AccountId)
        {
            numberDetail result = new numberDetail();
            List<string> resultListId = new List<string>();

            var buf = _db.Blogs.Where(b => b.AccountId == AccountId);
            result.number = buf.Count();
            foreach (var item in buf.ToList())
            {
                resultListId.Add(item.Name);
            }
            result.Detail = resultListId;
            return result;
        }
        public numberDetail getDetailPostByAccount(int AccountId)
        {
            numberDetail result = new numberDetail();
            List<string> resultListId = new List<string>();

            var buf = _db.Posts.Where(b => b.AccountId == AccountId);
            result.number = buf.Count();
            foreach (var item in buf.ToList())
            {
                resultListId.Add(item.Title);
            }
            result.Detail = resultListId;
            return result;
        }
        public numberDetail getDetailCommentByAccount(int AccountId)
        {
            numberDetail result = new numberDetail();
            List<string> resultListId = new List<string>();

            var buf = _db.Comments.Where(b => b.AccountId == AccountId);
            result.number = buf.Count();
            foreach (var item in buf.ToList())
            {
                resultListId.Add(item.Content);
            }
            result.Detail = resultListId;
            return result;
        }
    }
}
