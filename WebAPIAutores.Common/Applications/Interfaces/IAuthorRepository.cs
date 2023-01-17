using WebAPIAutores.Common.Entities;
using WebAPIAutores.Common.Responses;

namespace WebAPIAutores.Common.Applications.Interfaces
{
    public interface IAuthorRepository
    {
        Task<GenericResponse<Autor>> GetAuthorByIdAsync(int id);
        Task<IReadOnlyList<Autor>> GetAuthorsAsync();
        Task<GenericResponse<Autor>> GetAllAuthorsAsync();
        Task<GenericResponse<Autor>> AddAsync(Autor entity);
        Task<GenericResponse<Autor>> UpdateAsync(Autor entity);
        Task<GenericResponse<Autor>> DeleteAsync(Autor entity);
        Task<GenericResponse<Autor>> RecordExistsAsync(Autor entity);
    }
}
