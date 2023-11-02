using AutoMapper;
using System.Net;
using System.Web.Http;
using ProyectoLaboBackEnd.Repositories;
using ProyectoLaboBackEnd.Models.Post;

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

        public async Task<List<Post>> GetAll()
        {
            var lista = await _postRepo.GetAll();
            return _mapper.Map<List<Post>>(lista);
        }

        // Traer todos los posts de un usuario
        public async Task<List<Post>> GetAllByUserId(int userId)
        {
            var lista = await _postRepo.GetAll(u => u.UserId == userId);
            return _mapper.Map<List<Post>>(lista);
        }

        public async Task<Post> GetById(int id)
        {
            var post = await _postRepo.GetOne(u => u.PostId == id);

            if (post == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return _mapper.Map<Post>(post);
        }

        public async Task<Post> Create(Post createPostDto)
        {
            var post = _mapper.Map<Post>(createPostDto);

            await _postRepo.Add(post);

            return _mapper.Map<Post>(post);
        }

        public async Task<Post> UpdateById(int id, Post updatePostDto)
        {
            var post = await _postRepo.GetOne(u => u.PostId == id);

            if (post == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            var updated = _mapper.Map(updatePostDto, post);

            return _mapper.Map<Post>(await _postRepo.Update(updated));
        }

        public async Task DeleteById(int id)
        {
            var post = await _postRepo.GetOne(u => u.PostId == id);

            if (post == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            await _postRepo.Delete(post);
        }
    }
}