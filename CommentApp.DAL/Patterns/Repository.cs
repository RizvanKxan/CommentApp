﻿using CommentApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CommentApp.DAL.Patterns
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly AppDbContext _db;
        public Repository(AppDbContext context)
        {
            _db = context;
        }
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            try
            {
                var newEntity = await _db.Set<TEntity>().AddAsync(entity);
                await Save();
                return newEntity.Entity;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _db.Set<TEntity>().Remove(entity);
            await Save();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _db.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _db.Set<TEntity>().Update(entity);
            await Save();
            return entity;
        }
    }
}
