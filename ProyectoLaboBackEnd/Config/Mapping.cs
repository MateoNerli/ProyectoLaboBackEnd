using AutoMapper;
using ProyectoLaboBackEnd.Models.Post;
using ProyectoLaboBackEnd.Models.User;
using ProyectoLaboBackEnd.Models.Post.Dto;
using ProyectoLaboBackEnd.Models.User.Dto;

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

            //esto sirve para convertir datos de entrada y salida entre objetos de dominio y objetos de transferencia de datos.
        }
    }
}
