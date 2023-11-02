using AutoMapper;
using System.Net;
using System.Web.Http;
using ProyectoLaboBackEnd.Models;
using ProyectoLaboBackEnd.Repositories;

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

        public async Task<List<User>> GetAll()
        {
            var lista = await _userRepo.GetAll();
            return _mapper.Map<List<User>>(lista);
        }

        public async Task<User> GetById(int id)
        {
            var user = await _userRepo.GetOne(u => u.UserId == id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var posts = await _postService.GetAllByUserId(id);

            var mapped = _mapper.Map<User>(user);

            mapped.Posts = posts;

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

        public async Task<User> Create(User newUser)
        {
            var user = _mapper.Map<User>(newUser);

            user.Password = _encoderService.Encode(user.Password);

            await _userRepo.Add(user);

            return _mapper.Map<User>(user);
        }

        public async Task<User> UpdateById(int id, Post updateUserDto)
        {
            var user = await _userRepo.GetOne(u => u.UserId == id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var updated = _mapper.Map(updateUserDto, user);

            return _mapper.Map<User>(await _userRepo.Update(updated));
        }

        public async Task DeleteById(int id)
        {
            var user = await _userRepo.GetOne(u => u.UserId == id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            await _userRepo.Delete(user);
        }

        //roles
        public async Task<User> UpdateUserRolesById(int id, List<Role> roles)
        {
            var user = await _userRepo.GetOne(u => u.UserId == id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            user.Roles = roles;

            return await _userRepo.Update(user);
        }

        public async Task<List<Role>> GetRolesOfUserById(int id)
        {
            var user = await _userRepo.GetOne(u => u.UserId == id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user.Roles.ToList();
        }
    }
}