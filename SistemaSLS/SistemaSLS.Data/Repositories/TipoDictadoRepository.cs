using SistemaSLS.Data.Context;
using SistemaSLS.Data.Repositories.Base;
using SistemaSLS.Domain.Entities;

namespace SistemaSLS.Data.Repositories
{
    public class TipoDictadoRepository : BaseRepository<ISlsContext, TipoDictado>
    {
        public TipoDictadoRepository(ISlsContext context) : base(context)
        {
        }
    }
}
