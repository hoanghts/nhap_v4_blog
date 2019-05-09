using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nhap_v4_blog.Repository;
using nhap_v4_blog.DTO;
using nhap_v4_blog.Models;

namespace nhap_v4_blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IAccountRepository _re;
        public AccountController(IAccountRepository re)
        {
            _re = re;
        }

        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] AccountDto ob)
        {
            _re.Add(ob);
        }

        [HttpGet]
        [Route("Count")]
        public int Count()
        {
           return _re.Count();
        }

        [HttpGet]
        [Route("DetailAccountItem")]
        public DetailAccountItem CountItem(int id)
        {
            return _re.CountItem(id);
        }

        [HttpDelete]
        [Route("DeleteById/{id}")]
        public void DeleteById(int id)
        {
            _re.DeleteById(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public List<AccountDto> GetAll()
        {
            return _re.GetAll();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public AccountDto GetById(int id)
        {
            return _re.GetById(id);
        }

        [HttpPut]
        [Route("UpdateById/{id}")]
        public void UpdateById(int id,[FromBody] AccountDto ob)
        {
            _re.UpdateById(id, ob);
        }
    }
}