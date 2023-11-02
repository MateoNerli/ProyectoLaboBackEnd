using AutoMapper;
using ProyectoLaboBackEnd.Models;

namespace ProyectoLaboBackEnd.Config
{
    public class Mapping : Profile
    {

        public Mapping()
        {
            // User
            CreateMap<User, User>().ReverseMap();

            // Post
            CreateMap<Post, Post>().ReverseMap();
        }
    }
}
