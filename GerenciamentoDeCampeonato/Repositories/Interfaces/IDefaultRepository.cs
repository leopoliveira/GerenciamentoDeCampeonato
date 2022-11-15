using GerenciamentoDeCampeonato.Models.Entities;

namespace GerenciamentoDeCampeonato.Repositories.Interfaces
{
    public interface IDefaultRepository<TEntity> where TEntity : DefaultEntity 
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<List<TEntity>> GetAllAsync();

        Task<int> CreateOrEditAsync(TEntity entity);

        Task<int> DeleteByIdAsync(TEntity entity);
    }
}
