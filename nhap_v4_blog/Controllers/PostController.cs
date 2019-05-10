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
        //[HttpGet]
        //[Route("")]
        //public ActionResult<List<PostDto>> Get()
        //{
        //    return _blogRepository.Get();
        //}

        [HttpGet]
        [Route("{Id}")]
        public PostDto Get(int Id)
        {
            return _blogRepository.Get(Id);
        }

        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] PostDto bg)
        {
            _blogRepository.Add(bg);
        }

        [HttpPut]
        [Route("{Id}")]
        public void Update(int Id, [FromBody] PostDto bg)
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
        [Route("GetComment/{Id}")]
        public List<CommentDto> GetComment(int Id)
        {
            return _blogRepository.GetComment(Id);
        }

        //[HttpGet]
        //[Route("GetAllChildComment/{PostId}")]
        //public List<CommentFullDto> GetAllChildComment(int PostId)
        //{
        //    return _blogRepository.GetAllChildComment(PostId);
        //}

        [HttpGet]
        [Route("Count")]
        public int Count()
        {
            return _blogRepository.Count();
        }

        [HttpGet]
        [Route("CountComment/{Id}")]
        public int CountComment(int Id)
        {
            return _blogRepository.CountComment(Id);
        }
    }
}