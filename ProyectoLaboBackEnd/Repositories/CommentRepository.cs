using Microsoft.EntityFrameworkCore;
using ProyectoLaboBackEnd.Models;
using ProyectoLaboBackEnd.Models.Comment;

namespace ProyectoLaboBackEnd.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<Comment> Update(Comment entity);
        Task<List<Comment>> GetCommentsForPost(int postId);
    }

    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly proyectolabo4Context _db;

        public CommentRepository(proyectolabo4Context db) : base(db)
        {
            _db = db;
        }
        public async Task<Comment> Update(Comment entity)
        {
            _db.Comments.Update(entity);
            await Save();
            return entity;
        }
        public async Task<List<Comment>> GetCommentsForPost(int postId)
        {
            return await _db.Comments
                .Where(c => c.PostId == postId)
                .ToListAsync();
        }

    }
}
