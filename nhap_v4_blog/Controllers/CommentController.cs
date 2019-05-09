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


        [HttpGet]
        [Route("GetAllComment")]
        public List<CommentFullDto> GetAllComment()
        {
            return _blogRepository.GetAllComment();
        }

        [HttpGet]
        [Route("GetById/{Id}")]
        public CommentFullDto GetById(int Id)
        {
            return _blogRepository.GetById(Id);
        }


        [HttpGet]
        [Route("CountAllComment")]
        public int CountAllComment()
        {
            return _blogRepository.CountAllComment();
        }

        [HttpGet]
        [Route("CountFullComment/{Id}")]
        public int CountFullComment(int Id)
        {
            return _blogRepository.CountFullComment(Id);
        }

        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] CommentFullDto bg)
        {
            _blogRepository.Add(bg);
        }

        [HttpPut]
        [Route("Update/{Id}")]
        public void UpdateById(int Id, [FromBody] CommentFullDto bg)
        {
            _blogRepository.UpdateById(Id, bg);
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public void DeleteById(int Id)
        {
            _blogRepository.DeleteById(Id);
        }

        [HttpDelete]
        [Route("DeleteAllChildComment/{Id}")]
        public void DeleteAllChildComment(int Id)
        {
            _blogRepository.DeleteAllChildComment(Id);
        }

        // nhap

        [HttpGet]
        [Route("GetFullComment/{Id}")]
        public List<CommentFullDto> GetFullComment(int Id)
        {
            return _blogRepository.GetFullComment(Id);
        }
    }
}