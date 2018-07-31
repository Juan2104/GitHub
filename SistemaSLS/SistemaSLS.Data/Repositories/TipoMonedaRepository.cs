using SistemaSLS.Data.Context;
using SistemaSLS.Data.Repositories.Base;
using SistemaSLS.Domain.Entities;

namespace SistemaSLS.Data.Repositories
{
    public class TipoMonedaRepository : BaseRepository<ISlsContext, TipoMoneda>
    {
        public TipoMonedaRepository(ISlsContext context) : base(context)
        {
        }
    }
}
