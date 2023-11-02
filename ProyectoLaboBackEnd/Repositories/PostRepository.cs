using ProyectoLaboBackEnd.Models;
using ProyectoLaboBackEnd.Models.Post;
using ProyectoLaboBackEnd.Services;

namespace ProyectoLaboBackEnd.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Post> Update(Post entity);
    }

    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly ProyectoLaboBackEndContext _db;

        public PostRepository(ProyectoLaboBackEndContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Post> Update(Post entity)
        {
            _db.Posts.Update(entity);
            await Save();
            return entity;
        }
    }
}
