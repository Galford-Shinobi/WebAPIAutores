﻿using WebAPIAutores.Common.Entities;
using WebAPIAutores.Common.Responses;

namespace WebAPIAutores.Common.Applications.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : ClaseBase
    {
        Task<GenericResponse<TEntity>> GetByIdAsync(int id);

        Task<IReadOnlyList<TEntity>> GetAllAsync();

        Task<GenericResponse<TEntity>> AddAsync(TEntity entity);

        Task<GenericResponse<TEntity>> UpdateAsync(TEntity entity);

        void AddEntity(TEntity Entity);

        void UpdateEntity(TEntity Entity);

        void DeleteEntity(TEntity Entity);
    }
}
