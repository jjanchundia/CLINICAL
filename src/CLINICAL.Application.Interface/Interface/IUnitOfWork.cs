using CLINICAL.Domain.Entities;

namespace CLINICAL.Application.Interface.Interface
{
    //IDisposable proporciona un mecanismo para poder liberar recursos
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Analisis> Analisis { get; }
    }
}