using ProyectoLaboBackEnd.Models;
using ProyectoLaboBackEnd.Services;

namespace ProyectoLaboBackEnd.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Post> Update(Post entity);
    }

    public class PostRepository : Repository<Post>, IPostRepository
    {
        private readonly proyectolabo4Context _db;

        public PostRepository(proyectolabo4Context db) : base(db)
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
