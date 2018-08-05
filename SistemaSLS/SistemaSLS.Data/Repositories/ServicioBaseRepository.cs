using SistemaSLS.Data.Context;
using SistemaSLS.Data.Repositories.Base;
using SistemaSLS.Domain.Entities;

namespace SistemaSLS.Data.Repositories
{
    public class ServicioRepository : BaseRepository<ISlsContext, Servicio>
    {
        public ServicioRepository(ISlsContext context) : base(context)
        {
        }
    }
}