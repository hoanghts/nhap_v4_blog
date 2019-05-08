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
        [Route("GetAll")]
        public ActionResult<List<BlogDto>> GetAll()
        {
            return _blogRepository.GetAll();
        }

        [HttpGet]
        [Route("GetById/{Id}")]
        public BlogDto GetById(int Id)
        {
            return _blogRepository.GetById(Id);
        }

        [HttpPost]
        [Route("Add")]
        public void AddBlog([FromBody] Blog bg)
        {
             _blogRepository.Add(bg);
        }

        [HttpPut]
        [Route("Update/{Id}")]
        public void UpdateBlog(int Id, [FromBody] Blog bg)
        {
            _blogRepository.UpdateById(Id, bg);
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public void DeleteById(int Id)
        {
            _blogRepository.DeleteById(Id);
        }

        [HttpGet]
        [Route("GetAllPost/{Id}")]
        public List<Post> GetAllPostByBlogId(int Id)
        {
            return _blogRepository.GetAllByPerentId(Id);
        }

        [HttpGet]
        [Route("GetAll_Post/{blogId}")]
        public Blog GetAllBlog_Post(int blogid)
        {
            return _blogRepository.GetAllBLog_Post(blogid);
        }

    }
}