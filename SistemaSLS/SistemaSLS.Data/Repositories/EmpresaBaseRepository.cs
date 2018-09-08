using SistemaSLS.Data.Context;
using SistemaSLS.Data.Repositories.Base;
using SistemaSLS.Domain.Entities;

namespace SistemaSLS.Data.Repositories
{
    public class EmpresaRepository : BaseRepository<ISlsContext, Empresa>
    {
        public EmpresaRepository(ISlsContext context) : base(context)
        {
        }
    }
}
