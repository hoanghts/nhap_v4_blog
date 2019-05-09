﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using nhap_v4_blog.Models;
using nhap_v4_blog.DTO;

namespace nhap_v4_blog.Repository
{
    public interface IPostRepository
    {
        List<PostDto> GetAll();
        PostDto GetById(int id);
        void Add(PostDto ob);
        void UpdateById(int id, PostDto ob);
        void DeleteById(int id);
        //
        List<Comment> GetComment(int PostId);
        List<CommentFullDto> GetAllChildComment(int PostId);
        int Count();
        int CountComment(int PostId);
    }
}
