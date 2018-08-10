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
    public class PersonaService
    {
        private readonly IBaseRepository<Persona> _PersonaRepository;
        private readonly ISlsContext SlsContext;

        public PersonaService(ISlsContext context)
        {
            _PersonaRepository = new PersonaRepository(context);
            SlsContext = context;
        }

        public PersonaService(IBaseRepository<Persona> PersonaRepository)
        {
            _PersonaRepository = PersonaRepository;
        }


        public async Task<List<Persona>> GetAll()
        {
            return (await _PersonaRepository.GetAll()).ToList();
        }



        public int SavePersona(Persona emp)
        {

            _PersonaRepository.Add(emp);
            SlsContext.SaveChanges();
            return 1;
        }

        public int EditPersona(Persona tm)
        {
            var tmToEdit = _PersonaRepository.GetById(tm.IdPersona);
            tmToEdit.Nombre = tm.Nombre;
            tmToEdit.Apellido = tm.Apellido;
            tmToEdit.Dni = tm.Dni;
            tmToEdit.IdTipoPersona = tm.IdTipoPersona;
            tmToEdit.IdEmpresa = tm.IdEmpresa;
            tmToEdit.TelefonoPersonal = tm.TelefonoPersonal;
            tmToEdit.TelefonoLaboral = tm.TelefonoLaboral;
            tmToEdit.EmailLaboral = tm.EmailLaboral;
            tmToEdit.EmailPersonal = tm.EmailPersonal;
            tmToEdit.Eliminado = tm.Eliminado;
            tmToEdit.Movil = tm.Movil;
            tmToEdit.Supervisor = tm.Supervisor;


            _PersonaRepository.Update(tmToEdit);
            SlsContext.SaveChanges();
            return 1;
        }

        public void DeletePersona(int IdPersona)
        {
            var PersonaDB = _PersonaRepository.GetById(IdPersona);
            _PersonaRepository.Delete(PersonaDB);
            SlsContext.SaveChanges();
        }



        public Persona GetById(int id)
        {
            try
            {
                return _PersonaRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}