using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interface
{
    public interface IAnalisisRepository
    {
        Task<IEnumerable<Analisis>> ListAnalisis();
    }
}