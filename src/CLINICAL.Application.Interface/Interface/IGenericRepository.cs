
namespace CLINICAL.Application.Interface.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(string storeProcedure);
        Task<T> GetByIdAsync(string storeProcedure, object parameters);
        Task<bool> ExecuteAsync(string storeProcedure, object parameters);
    }
}