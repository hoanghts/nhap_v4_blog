using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nhap_v4_blog.Repository;
using nhap_v4_blog.Models;
using nhap_v4_blog.DTO;

namespace nhap_v4_blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        IBlogRepository _blogRepository;
        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        //
        [HttpGet]
        [Route("")]
        public ActionResult<List<BlogDto>> GetAll()
        {
            return _blogRepository.Get();
        }

        [HttpGet]
        [Route("{Id}")]
        public BlogDto Get(int Id)
        {
            return _blogRepository.Get(Id);
        }

        [HttpPost]
        [Route("Add")]
        public void AddBlog([FromBody] BlogDto bg)
        {
             _blogRepository.Add(bg);
        }

        [HttpPut]
        [Route("{Id}")]
        public void Update(int Id, [FromBody] BlogDto bg)
        {
            _blogRepository.Update(Id, bg);
        }

        [HttpDelete]
        [Route("{Id}")]
        public void Delete(int Id)
        {
            _blogRepository.Delete(Id);
        }

        [HttpGet]
        [Route("GetPost/{Id}")]
        public List<PostDto> GetPost(int Id)
        {
            return _blogRepository.GetPost(Id);
        }

        //[HttpGet]
        //[Route("GetFullPost/{BlogId}")]
        //public BlogFullDto GetFullPost(int BlogId)
        //{
        //    return _blogRepository.GetFullPost(BlogId);
        //}

        [HttpGet]
        [Route("CountPost/{Id}")]
        public int CountPost(int Id)
        {
            return _blogRepository.CountPost(Id);
        }

        [HttpGet]
        [Route("Count")]
        public int Count()
        {
            return _blogRepository.Count();
        }
    }
}