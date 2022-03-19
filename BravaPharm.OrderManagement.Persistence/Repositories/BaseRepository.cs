
using BravaPharm.OrderManagement.Application.Interfaces.Persistence;
using BravaPharm.OrderManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BravaPharm.OrderManagement.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly BravaPharmDbContext _bravaPharmDbContext;

        public BaseRepository(BravaPharmDbContext bravaPharmDbContext)
        {
            _bravaPharmDbContext = bravaPharmDbContext;
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _bravaPharmDbContext.Set<T>().AddAsync(entity);
            await _bravaPharmDbContext.SaveChangesAsync();
            return entity;
          
        }

        public async Task DeleteAsync(T entity)
        {
            _bravaPharmDbContext.Set<T>().Remove(entity);
            await _bravaPharmDbContext.SaveChangesAsync();

        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _bravaPharmDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _bravaPharmDbContext.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _bravaPharmDbContext.Set<T>().Update(entity);
            await _bravaPharmDbContext.SaveChangesAsync();
            return entity;

        }
    }
}
