﻿using CSVExplorer.Core.Domain.Entities;
using CSVExplorer.Core.RepositoryContracts;
using CSVExplorer.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CSVExplorer.Core.Services
{
    public class Service<T> : IService<T> where T : class, IBaseEntity
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _repository.GetAll().ToListAsync();
        }

        public virtual async Task<T?> FindByIdAsync(Guid id)
        {
            return await _repository.GetFirstOrDefaultAsync(entity => entity.Id == id);
        }

        public virtual async Task<T> Insert(T entity)
        {
            await _repository.Post(entity);
            await _repository.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            var updatedEntity = await _repository.GetFirstOrDefaultAsync(e => e.Id == entity.Id);

            return updatedEntity;
        }

        public virtual async Task DeleteAsync(T entity)
        {
            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }
    }
}
