using ProyectoLaboBackEnd.Models;
using ProyectoLaboBackEnd.Models.Role;

namespace ProyectoLaboBackEnd.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<Role> Update(Role entity);
    }
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        private readonly proyectolabo4Context _db;

        public RoleRepository(proyectolabo4Context db) : base(db)
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
