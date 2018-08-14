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
    public class AgendaService
    {
        private readonly IBaseRepository<Agenda> _AgendaRepository;
        private readonly ISlsContext SlsContext;

        public AgendaService(ISlsContext context)
        {
            _AgendaRepository = new AgendaRepository(context);
            SlsContext = context;
        }

        public AgendaService(IBaseRepository<Agenda> AgendaRepository)
        {
            _AgendaRepository = AgendaRepository;
        }


        public async Task<List<Agenda>> GetAll()
        {
            return (await _AgendaRepository.GetAll()).ToList();
        }



        public int SaveAgenda(Agenda emp)
        {

            _AgendaRepository.Add(emp);
            SlsContext.SaveChanges();
            return 1;
        }

        public int EditAgenda(Agenda emp)
        {
            var empToEdit = _AgendaRepository.GetById(emp.IdAgenda);
            empToEdit.Descripcion = emp.Descripcion;
            
            //empToEdit.= mesa.Descripcion;
            //rolToEdit.ReadOnly = rol.Edit;
            //rolToEdit.Edit = rol.ReadOnly;
            //rolToEdit.EditWho = HttpContext.Current.User.Identity.Name;
            _AgendaRepository.Update(empToEdit);
            SlsContext.SaveChanges();
            return 1;
        }

        public void DeleteAgenda(int IdAgenda)
        {
            var AgendaDB = _AgendaRepository.GetById(IdAgenda);
            _AgendaRepository.Delete(AgendaDB);
            SlsContext.SaveChanges();
        }



        public Agenda GetById(int id)
        {
            try
            {
                return _AgendaRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
