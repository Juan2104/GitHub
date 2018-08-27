using SistemaSLS.Data.Context;
using SistemaSLS.Data.Repositories.Base;
using SistemaSLS.Domain.Entities;

namespace SistemaSLS.Data.Repositories
{
    public class AgendaRepository : BaseRepository<ISlsContext, Agenda>
    {
        public AgendaRepository(ISlsContext context) : base(context)
        {
        }
    }
}
