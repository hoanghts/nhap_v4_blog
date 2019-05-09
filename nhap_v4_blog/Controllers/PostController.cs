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
        public void Add([FromBody] PostDto bg)
        {
            _blogRepository.Add(bg);
        }

        [HttpPut]
        [Route("Update/{Id}")]
        public void Update(int Id, [FromBody] PostDto bg)
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
        [Route("GetComment/{PostId}")]
        public List<Comment> GetComment(int PostId)
        {
            return _blogRepository.GetComment(PostId);
        }

        [HttpGet]
        [Route("GetAllChildComment/{PostId}")]
        public List<CommentFullDto> GetAllChildComment(int PostId)
        {
            return _blogRepository.GetAllChildComment(PostId);
        }

        [HttpGet]
        [Route("Count")]
        public int Count()
        {
            return _blogRepository.Count();
        }

        [HttpGet]
        [Route("CountComment/{PostId}")]
        public int CountComment(int PostId)
        {
            return _blogRepository.CountComment(PostId);
        }
    }
}