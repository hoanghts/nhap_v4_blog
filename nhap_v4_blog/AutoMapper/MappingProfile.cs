
using AutoMapper;
using nhap_v4_blog.Models;
using nhap_v4_blog.DTO;

namespace nhap_v4_blog.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentFullDto>();
            CreateMap<CommentFullDto, Comment>();
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
            CreateMap<Post, PostFullDto>();
            CreateMap<PostFullDto, Post>();

            CreateMap<Blog, BlogDto>();
            CreateMap<BlogDto, Blog>();
            CreateMap<Blog, BlogFullDto>();
            CreateMap<BlogFullDto, Blog>();

            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();
        }
    }
}
