using AutoMapper;
using ProyectoLaboBackEnd.Models.Role;
using ProyectoLaboBackEnd.Models.User.Dto;
using ProyectoLaboBackEnd.Models.User;
using ProyectoLaboBackEnd.Repositories;
using System.Net;
using System.Web.Http;
using ProyectoLaboBackEnd.Models.Post.Dto;

namespace ProyectoLaboBackEnd.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;
        private readonly PostService _postService;
        private readonly IEncoderService _encoderService;

        public UserService(IUserRepository userRepo, IMapper mapper, PostService postService, IEncoderService encoderService)
        {
            _userRepo = userRepo;
            _mapper = mapper;
            _postService = postService;
            _encoderService = encoderService;
        }

        private async Task<User> GetOneByIdOrException(int id)
        {
            var user = await _userRepo.GetOne(u => u.UserId == id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }

        public async Task<List<UsersDto>> GetAll()
        {
            var lista = await _userRepo.GetAll();
            return _mapper.Map<List<UsersDto>>(lista);
        }

        public async Task<UserDto> GetById(int id)
        {
            var user = await GetOneByIdOrException(id);

            var posts = await _postService.GetAllByUserId(id);

            var mapped = _mapper.Map<UserDto>(user);

            // Mapear los objetos Post a PostsDto utilizando LINQ
            mapped.Posts = posts.Select(post => new PostsDto
            {
                PostId = post.PostId,
                Title = post.Title,
                MainContent = post.MainContent,
            }).ToList();

            return mapped;
        }

        public async Task<User> GetByUsernameOrEmail(string? username, string? email)
        {
            User user;
            if (email != null)
            {
                user = await _userRepo.GetOne(u => u.Email == email);
            }
            else
            {
                user = await _userRepo.GetOne(u => u.UserName == username);
            }

            return user;
        }

        public async Task<UserDto> Create(CreateUserDto createUserDto)
        {
            var user = _mapper.Map<User>(createUserDto);

            user.Password = _encoderService.Encode(user.Password);

            await _userRepo.Add(user);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateById(int id, UpdateUserDto updateUserDto)
        {
            var user = await GetOneByIdOrException(id);

            var updated = _mapper.Map(updateUserDto, user);

            return _mapper.Map<UserDto>(await _userRepo.Update(updated));
        }

        public async Task DeleteById(int id)
        {
            var user = await GetOneByIdOrException(id);

            await _userRepo.Delete(user);
        }

        //roles
        public async Task<User> UpdateUserRolesById(int id, List<Role> roles)
        {
            var user = await GetOneByIdOrException(id);

            user.Roles = roles;

            return await _userRepo.Update(user);
        }

        public async Task<List<Role>> GetRolesOfUserById(int id)
        {
            var user = await GetOneByIdOrException(id);

            return user.Roles.ToList();
        }
    }
}