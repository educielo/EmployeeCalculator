using Microsoft.EntityFrameworkCore;
using Sprout.Exam.Business.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Services
{
    public interface IService<T> where T : DataEntity
    {
        Task<T> CreateAsync(T Entity);
        IQueryable<T> Filter(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(int id);
        Task Delete (T EntityIn);
        Task Update( T EntityIn);
    }
    public class Service<T> : IService<T> where T : DataEntity
    {
        private readonly SproutDBContext _context;
        private readonly DbSet<T> _dbSet;
        public Service(SproutDBContext context)
        {
            var dbContext = context as SproutDBContext;

            if (dbContext == null)
            {
                Debug.WriteLine("DbSet Not Loaded");
            }
            else
            {
                _context = context;
                _dbSet = dbContext.Set<T>();
            }
        }
        public async Task<T> CreateAsync(T Entity)
        {
            _dbSet.Add(Entity);
            try
            {
                await _context.SaveChangesAsync();
                return Entity;
            }
            catch (Exception ex)
            {

            }
            return Entity;
        }
        public async Task Delete(T EntityIn)
        {
            _dbSet.Remove(EntityIn);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsQueryable();
        }

        public async Task<T> FindAsync(int id)
        {
           return await _dbSet.FindAsync(id);
        }
        public async Task Update(T EntityIn)
        {
            _dbSet.Update(EntityIn);
            await _context.SaveChangesAsync();
        }
    }
}
