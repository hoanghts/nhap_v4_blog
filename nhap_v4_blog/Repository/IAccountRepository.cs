using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_v4_blog.DTO;
using nhap_v4_blog.Models;

namespace nhap_v4_blog.Repository
{
    public interface IAccountRepository
    {
        List<AccountDto> GetAll();
        AccountDto GetById(int id);
        void Add(AccountDto ob);
        void UpdateById(int id, AccountDto ob);
        void DeleteById(int id);
        int Count();
        DetailAccountItem CountItem(int id);
    }
}
