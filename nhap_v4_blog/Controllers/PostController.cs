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
    public class PostController : ControllerBase
    {
        IPostRepository _blogRepository;
        public PostController(IPostRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        //
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<PostDto>> GetAll()
        {
            return _blogRepository.GetAll();
        }

        [HttpGet]
        [Route("GetById/{Id}")]
        public PostDto GetById(int Id)
        {
            return _blogRepository.GetById(Id);
        }

        [HttpPost]
        [Route("Add")]
        public void AddBlog([FromBody] Post bg)
        {
            _blogRepository.Add(bg);
        }

        [HttpPut]
        [Route("Update/{Id}")]
        public void UpdateBlog(int Id, [FromBody] Post bg)
        {
            _blogRepository.UpdateById(Id, bg);
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public void DeleteById(int Id)
        {
            _blogRepository.DeleteById(Id);
        }
    }
}