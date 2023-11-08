using AutoMapper;
using ProyectoLaboBackEnd.Models.Post;
using ProyectoLaboBackEnd.Models.User;
using ProyectoLaboBackEnd.Models.Post.Dto;
using ProyectoLaboBackEnd.Models.User.Dto;
using ProyectoLaboBackEnd.Models.Comment.Dto;
using ProyectoLaboBackEnd.Models.Comment;
using ProyectoLaboBackEnd.Models.Community.Dto;
using ProyectoLaboBackEnd.Models.Community;

namespace ProyectoLaboBackEnd.Config
{
    public class Mapping : Profile
    {

        public Mapping()
        {
            // User
            CreateMap<User, UsersDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<CreateUserDto, User>().ReverseMap();
            // no mapear los null en el update
            CreateMap<UpdateUserDto, User>().ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));

            // Post
            CreateMap<Post, PostsDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<CreatePostDto, Post>().ReverseMap();
            // no mapear los null en el update
            CreateMap<UpdatePostDto, Post>().ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));

            //Comment
            CreateMap<Comment, CommentsDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<CreateCommentsDto, Comment>().ReverseMap();
            // no mapear los null en el update
            CreateMap<UpdateCommentsDto, Comment>().ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));

            //Community
            CreateMap<Community, CommunitysDto>().ReverseMap();
            CreateMap<Community, CommunityDto>().ReverseMap();
            CreateMap<CreateCommunityDto, Community>().ReverseMap();
            // no mapear los null en el update
            CreateMap<UpdateCommunityDto, Community>().ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));
            //esto sirve para convertir datos de entrada y salida entre objetos de dominio y objetos de transferencia de datos.
        }
    }
}
