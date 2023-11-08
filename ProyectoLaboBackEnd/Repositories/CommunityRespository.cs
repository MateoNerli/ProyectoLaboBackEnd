using Microsoft.EntityFrameworkCore;
using ProyectoLaboBackEnd.Models;
using ProyectoLaboBackEnd.Models.Community;

namespace ProyectoLaboBackEnd.Repositories
{
    public interface ICommunityRepository : IRepository<Community>
    {
        Task<Community> Update(Community entity);
    }

    public class CommunityRepository : Repository<Community>, ICommunityRepository
    {
        private readonly proyectolabo4Context _db;

        public CommunityRepository(proyectolabo4Context db) : base(db)
        {
            _db = db;
        }
        public async Task<Community> Update(Community entity)
        {
            _db.Communities.Update(entity);
            await Save();
            return entity;
        }
    }
}