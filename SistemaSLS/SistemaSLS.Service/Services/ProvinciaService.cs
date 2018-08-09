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
    public class ProvinciaService
    {
        private readonly IBaseRepository<Provincia> _ProvinciaRepository;
        private readonly ISlsContext SlsContext;

        public ProvinciaService(ISlsContext context)
        {
            _ProvinciaRepository = new ProvinciaRepository(context);
            SlsContext = context;
        }

        public ProvinciaService(IBaseRepository<Provincia> ProvinciaRepository)
        {
            _ProvinciaRepository = ProvinciaRepository;
        }


        public async Task<List<Provincia>> GetAll()
        {
            return (await _ProvinciaRepository.GetAll()).ToList();
        }



        public int SaveProvincia(Provincia emp)
        {

            _ProvinciaRepository.Add(emp);
            SlsContext.SaveChanges();
            return 1;
        }

        public int EditProvincia(Provincia emp)
        {
            var empToEdit = _ProvinciaRepository.GetById(emp.IdProvincia);
            empToEdit.Descripcion = emp.Descripcion;
            empToEdit.IdPais = emp.IdPais;

            //empToEdit.= mesa.Descripcion;
            //rolToEdit.ReadOnly = rol.Edit;
            //rolToEdit.Edit = rol.ReadOnly;
            //rolToEdit.EditWho = HttpContext.Current.User.Identity.Name;
            _ProvinciaRepository.Update(empToEdit);
            SlsContext.SaveChanges();
            return 1;
        }

        public void DeleteProvincia(int IdProvincia)
        {
            var ProvinciaDB = _ProvinciaRepository.GetById(IdProvincia);
            _ProvinciaRepository.Delete(ProvinciaDB);
            SlsContext.SaveChanges();
        }



        public Provincia GetById(int id)
        {
            try
            {
                return _ProvinciaRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
