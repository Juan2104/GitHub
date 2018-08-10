using SistemaSLS.Data.Repositories.Base;
using SistemaSLS.Data.Context;
using SistemaSLS.Data.Repositories;
using SistemaSLS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSLS.Service.Services
{
   public class TipoPersonaService
    {
        private readonly IBaseRepository<TipoPersona> _TipoPersonaRepository;
        private readonly ISlsContext SlsContext;

        public TipoPersonaService(ISlsContext context)
        {
            _TipoPersonaRepository = new TipoPersonaRepository(context);
            SlsContext = context;
        }

        public TipoPersonaService(IBaseRepository<TipoPersona> TipoPersonaRepository)
        {
            _TipoPersonaRepository = TipoPersonaRepository;
        }


        public async Task<List<TipoPersona>> GetAll()
        {
            return (await _TipoPersonaRepository.GetAll()).ToList();
        }



        public int Save(TipoPersona emp)
        {

            _TipoPersonaRepository.Add(emp);
            SlsContext.SaveChanges();
            return 1;
        }

        public int Edit(TipoPersona emp)
        {
            var empToEdit = _TipoPersonaRepository.GetById(emp.IdTipoPersona);
            empToEdit.descripcion = emp.descripcion;

            //empToEdit.= mesa.Descripcion;
            //rolToEdit.ReadOnly = rol.Edit;
            //rolToEdit.Edit = rol.ReadOnly;
            //rolToEdit.EditWho = HttpContext.Current.User.Identity.Name;
            _TipoPersonaRepository.Update(empToEdit);
            SlsContext.SaveChanges();
            return 1;
        }

        public void Delete(int IdTipoPersona)
        {
            var TipoPersonaDB = _TipoPersonaRepository.GetById(IdTipoPersona);
            _TipoPersonaRepository.Delete(TipoPersonaDB);
            SlsContext.SaveChanges();
        }



        public TipoPersona GetById(int id)
        {
            try
            {
                return _TipoPersonaRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
