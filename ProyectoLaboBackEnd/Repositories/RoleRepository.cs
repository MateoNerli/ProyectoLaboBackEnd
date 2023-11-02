using ProyectoLaboBackEnd.Models;
using ProyectoLaboBackEnd.Models.Role;
using ProyectoLaboBackEnd.Services;

namespace ProyectoLaboBackEnd.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> Update(Role entity);
    }
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly ProyectoLaboBackEndContext _db;

        public RoleRepository(ProyectoLaboBackEndContext db) : base(db)
        {
            _db = db;
        }
        public async Task<Role> Update(Role entity)
        {
            _db.Roles.Update(entity);
            await Save();
            return entity;
        }
    }
}
