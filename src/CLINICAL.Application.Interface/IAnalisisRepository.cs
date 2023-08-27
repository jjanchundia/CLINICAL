using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interface
{
    public interface IAnalisisRepository
    {
        Task<IEnumerable<Analisis>> ListAnalisis();
        Task<Analisis> AnalisisById(int id);
        Task<bool> AnalisisRegister(Analisis analisis);
        Task<bool> AnalisisUpdate(Analisis analisis);
        Task<bool> AnalisisRemove(int id);
    }
}