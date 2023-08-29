using CLINICAL.Application.Interface.Interface;
using CLINICAL.Domain.Entities;

namespace CLINICAL.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Analisis> Analisis { get; }
            
        public UnitOfWork(IGenericRepository<Analisis> analisis)
        {
            Analisis = analisis;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}