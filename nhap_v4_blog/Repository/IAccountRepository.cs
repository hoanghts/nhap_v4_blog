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
        List<AccountDto> Get();
        AccountDto Get(int id);
        void Add(AccountDto ob);
        void Update(int id, AccountDto ob);
        void Delete(int id);
        int Count();
        DetailAccountItem CountItem(int id);
    }
}
