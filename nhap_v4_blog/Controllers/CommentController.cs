using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nhap_v4_blog.Models;
using nhap_v4_blog.Repository;
using nhap_v4_blog.DTO;

namespace nhap_v4_blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentRepository _blogRepository;
        public CommentController(ICommentRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }


        //[HttpGet]
        //[Route("GetAllComment")]
        //public List<CommentFullDto> GetAllComment()
        //{
        //    return _blogRepository.GetAllComment();
        //}

        [HttpGet]
        [Route("{Id}")]
        public CommentDto Get(int Id)
        {
            return _blogRepository.Get(Id);
        }


        [HttpGet]
        [Route("Count")]
        public int Count()
        {
            return _blogRepository.Count();
        }

        [HttpGet]
        [Route("CountFullComment/{Id}")]
        public int CountFullComment(int Id)
        {
            return _blogRepository.CountFullComment(Id);
        }

        [HttpPost]
        [Route("")]
        public void Add([FromBody] CommentDto bg)
        {
            _blogRepository.Add(bg);
        }

        [HttpPut]
        [Route("{Id}")]
        public void Update(int Id, [FromBody] CommentDto bg)
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
        [Route("GetFullComment/{Id}")]
        public List<CommentFullDto> GetFullComment(int Id)
        {
            return _blogRepository.GetFullComment(Id);
        }
    }
}