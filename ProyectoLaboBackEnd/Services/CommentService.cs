using AutoMapper;
using System.Net;
using System.Web.Http;
using ProyectoLaboBackEnd.Repositories;
using ProyectoLaboBackEnd.Models.Comment;
using ProyectoLaboBackEnd.Models.Comment.Dto;

namespace ProyectoLaboBackEnd.Services
{
    public class CommentService
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepo, IMapper mapper)
        {
            _commentRepo = commentRepo;
            _mapper = mapper;
        }
        private async Task<Comment> GetOneByIdOrException(int id)
        {
            var post = await _commentRepo.GetOne(u => u.UserId == id);

            if (post == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return post;
        }

        public async Task<List<CommentsDto>> GetAll()
        {
            var lista = await _commentRepo.GetAll();
            return _mapper.Map<List<CommentsDto>>(lista);
        }

        public async Task<List<CommentsDto>> GetAllByUserId(int userId)
        {
            var lista = await _commentRepo.GetAll(u => u.UserId == userId);
            return _mapper.Map<List<CommentsDto>>(lista);
        }

        public async Task<CommentDto> GetById(int id)
        {
            var post = await GetOneByIdOrException(id);

            return _mapper.Map<CommentDto>(post);
        }

        public async Task<CommentDto> Create(CreateCommentsDto createPostDto)
        {
            var post = _mapper.Map<Comment>(createPostDto);

            await _commentRepo.Add(post);

            return _mapper.Map<CommentDto>(post);
        }

        public async Task<CommentDto> UpdateById(int id, UpdateCommentsDto updatePostDto)
        {
            var post = await GetOneByIdOrException(id);

            var updated = _mapper.Map(updatePostDto, post);

            return _mapper.Map<CommentDto>(await _commentRepo.Update(updated));
        }

        public async Task DeleteById(int id)
        {
            var comment = await GetOneByIdOrException(id);

            await _commentRepo.Delete(comment);
        }

        public async Task<List<CommentDto>> GetCommentsForPost(int postId)
        {
            var comments = await _commentRepo.GetCommentsForPost(postId);
            return _mapper.Map<List<CommentDto>>(comments);
        }
    }
}