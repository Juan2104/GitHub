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
    public class PaisService
    {
        private readonly IBaseRepository<Pais> _PaisRepository;
        private readonly ISlsContext SlsContext;

        public PaisService(ISlsContext context)
        {
            _PaisRepository = new PaisRepository(context);
            SlsContext = context;
        }

        public PaisService(IBaseRepository<Pais> PaisRepository)
        {
            _PaisRepository = PaisRepository;
        }


        public async Task<List<Pais>> GetAll()
        {
            return (await _PaisRepository.GetAll()).ToList();
        }



        public int SavePais(Pais emp)
        {

            _PaisRepository.Add(emp);
            SlsContext.SaveChanges();
            return 1;
        }

        public int EditPais(Pais emp)
        {
            var empToEdit = _PaisRepository.GetById(emp.IdPais);
            empToEdit.Descripcion = emp.Descripcion;

            //empToEdit.= mesa.Descripcion;
            //rolToEdit.ReadOnly = rol.Edit;
            //rolToEdit.Edit = rol.ReadOnly;
            //rolToEdit.EditWho = HttpContext.Current.User.Identity.Name;
            _PaisRepository.Update(empToEdit);
            SlsContext.SaveChanges();
            return 1;
        }

        public void DeletePais(int IdPais)
        {
            var PaisDB = _PaisRepository.GetById(IdPais);
            _PaisRepository.Delete(PaisDB);
            SlsContext.SaveChanges();
        }



        public Pais GetById(int id)
        {
            try
            {
                return _PaisRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
