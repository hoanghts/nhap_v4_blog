using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_v4_blog.Models;

namespace nhap_v4_blog.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T ob);
        void UpdateById(int id, T ob);
        void DeleteById(int id);
    }
}
