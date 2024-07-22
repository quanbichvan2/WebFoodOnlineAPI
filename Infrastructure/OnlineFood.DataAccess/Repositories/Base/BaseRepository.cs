using Domain.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using OnlineFood.UseCase.Contracts.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFood.Repository.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
        // baseRepo là cổng (thằng nào cũng cần để đi qua) , mục đích làm để tránh sự phụ thuộc
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<TEntity> set;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            set = context.Set<TEntity>();
        }
        public async Task<TEntity> CreateEntity(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> DeleteEntity(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<TEntity> GetEntityById(Guid id)
        {
            return null;
        }
        public async Task<TEntity> GetListPagination(IQueryable<TEntity> query, int page, int pageSize)
        {
            throw new NotImplementedException();
            // cái này chưa xử lý để lại
        }
        public async Task<TEntity> UpdateEntity(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        // get all thieu
    }
}
