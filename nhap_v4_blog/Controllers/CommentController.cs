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

        //
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<CommentDto>> GetAll()
        {
            return _blogRepository.GetAll();
        }

        [HttpGet]
        [Route("GetAllComment")]
        public List<Comment> GetAllComment()
        {
            return _blogRepository.GetAllComment();
        }

        [HttpGet]
        [Route("GetById/{Id}")]
        public CommentDto GetById(int Id)
        {
            return _blogRepository.GetById(Id);
        }


        [HttpGet]
        [Route("Count/{Id}")]
        public int Count(int Id)
        {
            return _blogRepository.Count(Id);
        }

        [HttpPost]
        [Route("Add")]
        public void AddBlog([FromBody] Comment bg)
        {
            _blogRepository.Add(bg);
        }

        [HttpPut]
        [Route("Update/{Id}")]
        public void UpdateBlog(int Id, [FromBody] Comment bg)
        {
            _blogRepository.UpdateById(Id, bg);
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public void DeleteById(int Id)
        {
            _blogRepository.DeleteById(Id);
        }

        // nhap

        [HttpGet]
        [Route("nhapgetall/{Id}")]
        public List<Comment> NhapGetAll(int Id)
        {
            return _blogRepository.GetAllCommentByBaseId(Id);
        }
    }
}