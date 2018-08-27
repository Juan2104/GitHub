using SistemaSLS.Data.Context;
using SistemaSLS.Data.Repositories.Base;
using SistemaSLS.Domain.Entities;

namespace SistemaSLS.Data.Repositories
{
    public class PaisRepository : BaseRepository<ISlsContext, Pais>
    {
        public PaisRepository(ISlsContext context) : base(context)
        {
        }
    }
}
