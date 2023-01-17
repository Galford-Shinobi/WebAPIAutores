using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using WebAPIAutores.Common.Applications.Interfaces;
using WebAPIAutores.Common.DataBase;
using WebAPIAutores.Common.Entities;
using WebAPIAutores.Common.Responses;

namespace WebAPIAutores.Common.Applications.Logic
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AuthorRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<GenericResponse<Autor>> AddAsync(Autor entity)
        {
            try
            {
                _applicationDbContext.Autores.Add(entity);
                await SaveAllAsync();

                return new GenericResponse<Autor> { 
                 IsSuccess= true,
                 Result= entity
                };
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    return new GenericResponse<Autor>
                    {
                        IsSuccess = false,
                        ErrorMessage = dbUpdateException.InnerException.Message,
                    };
                }
                else
                {
                    return new GenericResponse<Autor>
                    {
                        IsSuccess = false,
                        ErrorMessage = dbUpdateException.InnerException.Message,
                    };
                }
            }
            catch (Exception exception)
            {
                return new GenericResponse<Autor> {
                 IsSuccess= false,
                 ErrorMessage= exception.Message
                };
            }
        }

        public async Task<GenericResponse<Autor>> DeleteAsync(Autor entity)
        {
            try
            {
               var objectAut = await _applicationDbContext
                    .Autores.FirstOrDefaultAsync(a => a.Id.Equals(entity.Id));

                if (objectAut == null) {
                    return new GenericResponse<Autor>
                    {
                        IsSuccess = false,
                        ErrorMessage = "there is no information in the system",
                    };
                }

                _applicationDbContext.Autores.Remove(objectAut);

                await SaveAllAsync();

                return new GenericResponse<Autor>
                {
                    IsSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    return new GenericResponse<Autor>
                    {
                        IsSuccess = false,
                        ErrorMessage = dbUpdateException.InnerException.Message,
                    };
                }
                else
                {
                    return new GenericResponse<Autor>
                    {
                        IsSuccess = false,
                        ErrorMessage = dbUpdateException.InnerException.Message,
                    };
                }
            }
            catch (Exception exception)
            {
                return new GenericResponse<Autor>
                {
                    IsSuccess = false,
                    ErrorMessage = exception.Message
                };
            }
        }

        public async Task<GenericResponse<Autor>> GetAllAuthorsAsync()
        {
            try
            {

                var ListResult = await _applicationDbContext.Autores.ToListAsync();

                if (ListResult == null)
                {
                    return new GenericResponse<Autor>
                    {
                        IsSuccess = false,
                        ErrorMessage = "no information required",
                    };
                }

                return new GenericResponse<Autor>
                {
                    IsSuccess = true,
                    ListResults = ListResult,
                    MyReadOnlyList = ListResult.AsReadOnly()
                };
            }
            catch (Exception exception)
            {
                 return new GenericResponse<Autor> { 
                    IsSuccess = false,
                    ErrorMessage = exception.Message    
                 };
            }
        }

        public async Task<GenericResponse<Autor>> GetAuthorByIdAsync(int id)
        {
            try
            {
                var OnlyObject = await _applicationDbContext
                    .Autores.FirstOrDefaultAsync(x => x.Id == id);
                if (OnlyObject == null)
                {
                    return new GenericResponse<Autor>
                    {
                        IsSuccess = false,
                        ErrorMessage = "no information required",
                    };
                }
                return new GenericResponse<Autor>
                {
                    IsSuccess = true,
                    Result = OnlyObject
                };
            }
            catch (Exception exception)
            {
                return new GenericResponse<Autor>
                {
                    IsSuccess = false,
                    ErrorMessage = exception.Message
                };
            }
        }

        public async Task<IReadOnlyList<Autor>> GetAuthorsAsync()
        {
            try
            {
                var ListObject = await _applicationDbContext.Autores.ToListAsync();
                return ListObject.AsReadOnly();
            }
            catch (Exception)
            {
                return  null;
            }
        }

        public async Task<GenericResponse<Autor>> RecordExistsAsync(Autor entity)
        {
            try
            {
                var exist = await _applicationDbContext
                    .Autores.FirstOrDefaultAsync(e => e.Nombre == entity.Nombre);

                if (exist != null)
                {
                    return new GenericResponse<Autor>
                    {
                        IsSuccess = true,
                        ErrorMessage = "The record exists in the system"
                    };
                }
                return new GenericResponse<Autor>
                {
                    IsSuccess = false,
                    ErrorMessage = " The record no exists in the system"
                };

            }
            catch (Exception exception)
            {
                return new GenericResponse<Autor> { 
                   IsSuccess= false,
                   ErrorMessage = exception.Message 
                };
            }
        }

        public async Task<GenericResponse<Autor>> UpdateAsync(Autor entity)
        {
            try
            {
                _applicationDbContext.Autores.Update(entity);
                await SaveAllAsync();

                return new GenericResponse<Autor>
                {
                    IsSuccess = true,
                    Result = entity
                };
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                {
                    return new GenericResponse<Autor>
                    {
                        IsSuccess = false,
                        ErrorMessage = dbUpdateException.InnerException.Message,
                    };
                }
                else
                {
                    return new GenericResponse<Autor>
                    {
                        IsSuccess = false,
                        ErrorMessage = dbUpdateException.InnerException.Message,
                    };
                }
            }
            catch (Exception exception)
            {
                return new GenericResponse<Autor>
                {
                    IsSuccess = false,
                    ErrorMessage = exception.Message
                };
            }
        }

        private async Task<bool> SaveAllAsync()
        {
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }
    }
}
