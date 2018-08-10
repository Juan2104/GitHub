using SistemaSLS.Data.Context;
using SistemaSLS.Data.Repositories.Base;
using SistemaSLS.Domain.Entities;

namespace SistemaSLS.Data.Repositories
{
    public class ProvinciaRepository : BaseRepository<ISlsContext, Provincia>
    {
        public ProvinciaRepository(ISlsContext context) : base(context)
        {
        }
    }
}
