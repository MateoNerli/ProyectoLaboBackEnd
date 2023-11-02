using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using ProyectoLaboBackEnd.Models;
using ProyectoLaboBackEnd.Services;

namespace ProyectoLaboBackEnd.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task Add(User user);
        Task<User> Update(User entity);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly proyectolabo4Context _db;

        public UserRepository(proyectolabo4Context db) : base(db)
        {
            _db = db;
        }
        public async Task<User> Update(User entity)
        {
            _db.Users.Update(entity);
            await Save();
            return entity;
        }

        public new async Task<User> GetOne(Expression<Func<User, bool>>? filter = null)
        {
            IQueryable<User> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter).Include(u => u.Roles);
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}

