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
        public void AddBlog([FromBody] BlogDto bg)
        {
             _blogRepository.Add(bg);
        }

        [HttpPut]
        [Route("Update/{Id}")]
        public void UpdateBlog(int Id, [FromBody] BlogDto bg)
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
        [Route("GetPost/{Id}")]
        public List<Post> GetPost(int Id)
        {
            return _blogRepository.GetPost(Id);
        }

        [HttpGet]
        [Route("GetTreePost/{blogid}")]
        public BlogDto GetTreePost(int blogid)
        {
            return _blogRepository.GetTreePost(blogid);
        }

        [HttpGet]
        [Route("CountPost/{BlogId}")]
        public int CountPost(int BlogId)
        {
            return _blogRepository.CountPost(BlogId);
        }

        [HttpGet]
        [Route("Count")]
        public int Count()
        {
            return _blogRepository.Count();
        }
    }
}