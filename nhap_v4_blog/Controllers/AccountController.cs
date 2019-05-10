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
        public DetailAccountItem CountItem(int Id)
        {
            return _re.CountItem(Id);
        }

        [HttpDelete]
        [Route("{Id}")]
        public void Delete(int Id)
        {
            _re.Delete(Id);
        }

        [HttpGet]
        [Route("")]
        public List<AccountDto> Get()
        {
            return _re.Get();
        }

        [HttpGet]
        [Route("{Id}")]
        public AccountDto Get(int Id)
        {
            return _re.Get(Id);
        }

        [HttpPut]
        [Route("{Id}")]
        public void Update(int Id, [FromBody] AccountDto ob)
        {
            _re.Update(Id, ob);
        }
    }
}