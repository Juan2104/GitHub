using SistemaSLS.Data.Context;
using SistemaSLS.Data.Repositories.Base;
using SistemaSLS.Domain.Entities;

namespace SistemaSLS.Data.Repositories
{
    public class TipoServicioRepository : BaseRepository<ISlsContext, TipoServicio>
    {
        public TipoServicioRepository(ISlsContext context) : base(context)
        {
        }
    }
}
