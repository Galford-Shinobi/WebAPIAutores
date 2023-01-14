using WebAPIAutores.Common.Applications.Interfaces;
using WebAPIAutores.Common.DataBase;
using WebAPIAutores.Common.Entities;
using WebAPIAutores.Common.Responses;

namespace WebAPIAutores.Common.Applications.Logic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : ClaseBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<GenericResponse<TEntity>> AddAsync(TEntity entity)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public void AddEntity(TEntity Entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(TEntity Entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public Task<GenericResponse<TEntity>> GetByIdAsync(int id)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public Task<GenericResponse<TEntity>> UpdateAsync(TEntity entity)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        public void UpdateEntity(TEntity Entity)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }

        private async Task<bool> SaveAllAsync()
        {
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }
    }
}
