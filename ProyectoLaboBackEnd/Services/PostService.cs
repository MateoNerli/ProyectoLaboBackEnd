using AutoMapper;
using System.Net;
using System.Web.Http;
using ProyectoLaboBackEnd.Repositories;
using ProyectoLaboBackEnd.Models.Post;
using ProyectoLaboBackEnd.Models.Post.Dto;

namespace ProyectoLaboBackEnd.Services
{
    public class PostService
    {
        private readonly IPostRepository _postRepo;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepo, IMapper mapper)
        {
            _postRepo = postRepo;
            _mapper = mapper;
        }

        private async Task<Post> GetOneByIdOrException(int id)
        {
            var post = await _postRepo.GetOne(u => u.UserId == id);

            if (post == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return post;
        }

        public async Task<List<PostsDto>> GetAll()
        {
            var lista = await _postRepo.GetAll();
            return _mapper.Map<List<PostsDto>>(lista);
        }

        // Traer todos los posts de un usuario
        public async Task<List<PostsDto>> GetAllByUserId(int userId)
        {
            var lista = await _postRepo.GetAll(u => u.UserId == userId);
            return _mapper.Map<List<PostsDto>>(lista);
        }

        public async Task<PostDto> GetById(int id)
        {
            var post = await GetOneByIdOrException(id);

            return _mapper.Map<PostDto>(post);
        }

        public async Task<PostDto> Create(CreatePostDto createPostDto)
        {
            var post = _mapper.Map<Post>(createPostDto);

            await _postRepo.Add(post);

            return _mapper.Map<PostDto>(post);
        }

        public async Task<PostDto> UpdateById(int id, UpdatePostDto updatePostDto)
        {
            var post = await GetOneByIdOrException(id);

            var updated = _mapper.Map(updatePostDto, post);

            return _mapper.Map<PostDto>(await _postRepo.Update(updated));
        }

        public async Task DeleteById(int id)
        {
            var post = await GetOneByIdOrException(id);

            await _postRepo.Delete(post);
        }
    }
}