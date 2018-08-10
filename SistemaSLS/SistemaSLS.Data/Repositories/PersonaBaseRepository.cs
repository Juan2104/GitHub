using SistemaSLS.Data.Context;
using SistemaSLS.Data.Repositories.Base;
using SistemaSLS.Domain.Entities;

namespace SistemaSLS.Data.Repositories
{
    public class PersonaRepository : BaseRepository<ISlsContext, Persona>
    {
        public PersonaRepository(ISlsContext context) : base(context)
        {
        }
    }
}