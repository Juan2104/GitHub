using SistemaSLS.Data.Context;
using SistemaSLS.Data.Repositories.Base;
using SistemaSLS.Domain.Entities;

namespace SistemaSLS.Data.Repositories
{
    public class CiudadRepository : BaseRepository<ISlsContext, Ciudad>
    {
        public CiudadRepository(ISlsContext context) : base(context)
        {
        }
    }
}
