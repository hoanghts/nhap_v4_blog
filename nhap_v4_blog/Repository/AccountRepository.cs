using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
            detail.Blog = getDetailBlogByAccount(id);
            detail.Post = getDetailPostByAccount(id);
            detail.Comment = getDetailCommentByAccount(id);
            return detail;
        }

        public void Delete(int id)
        {
            _db.Remove(_db.Accounts.Find(id));
            _db.SaveChanges();
        }

        public List<AccountDto> Get()
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

        public AccountDto Get(int id)
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

        public void Update(int id, AccountDto ac)
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
        public Detail getDetailBlogByAccount(int AccountId)
        {
            Detail result = new Detail();
            List<int> resultListId = new List<int>();
            List<string> resultListName = new List<string>();
            var buf = _db.Blogs.Where(b => b.AccountId == AccountId).ToList();
            foreach (var item in buf)
            {
                resultListId.Add(item.Id);
                resultListName.Add(item.Name);
            }
            result.Id = resultListId;
            result.Content = resultListName;
            return result;
        }
        public Detail getDetailPostByAccount(int AccountId)
        {
            Detail result = new Detail();
            List<int> resultListId = new List<int>();
            List<string> resultListName = new List<string>();
            var buf = _db.Posts.Where(b => b.AccountId == AccountId).ToList();
            foreach (var item in buf)
            {
                resultListId.Add(item.Id);
                resultListName.Add(item.Title);
            }
            result.Id = resultListId;
            result.Content = resultListName;
            return result;
        }
        public Detail getDetailCommentByAccount(int AccountId)
        {
            Detail result = new Detail();
            List<int> resultListId = new List<int>();
            List<string> resultListName = new List<string>();
            var buf = _db.Comments.Where(b => b.AccountId == AccountId).ToList();
            foreach (var item in buf)
            {
                resultListId.Add(item.Id);
                resultListName.Add(item.Content);
            }
            result.Id = resultListId;
            result.Content = resultListName;
            return result;
        }
    }
}
