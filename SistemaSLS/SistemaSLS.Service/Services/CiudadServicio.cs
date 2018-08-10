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
    public class CiudadService
    {
        private readonly IBaseRepository<Ciudad> _CiudadRepository;
        private readonly ISlsContext SlsContext;

        public CiudadService(ISlsContext context)
        {
            _CiudadRepository = new CiudadRepository(context);
            SlsContext = context;
        }

        public CiudadService(IBaseRepository<Ciudad> CiudadRepository)
        {
            _CiudadRepository = CiudadRepository;
        }


        public async Task<List<Ciudad>> GetAll()
        {
            return (await _CiudadRepository.GetAll()).ToList();
        }



        public int SaveCiudad(Ciudad emp)
        {

            _CiudadRepository.Add(emp);
            SlsContext.SaveChanges();
            return 1;
        }

        public int EditCiudad(Ciudad emp)
        {
            var empToEdit = _CiudadRepository.GetById(emp.IdCiudad);
            empToEdit.Descripcion = emp.Descripcion;
            empToEdit.IdProvincia = emp.IdProvincia;

            //empToEdit.= mesa.Descripcion;
            //rolToEdit.ReadOnly = rol.Edit;
            //rolToEdit.Edit = rol.ReadOnly;
            //rolToEdit.EditWho = HttpContext.Current.User.Identity.Name;
            _CiudadRepository.Update(empToEdit);
            SlsContext.SaveChanges();
            return 1;
        }

        public void DeleteCiudad(int IdCiudad)
        {
            var CiudadDB = _CiudadRepository.GetById(IdCiudad);
            _CiudadRepository.Delete(CiudadDB);
            SlsContext.SaveChanges();
        }



        public Ciudad GetById(int id)
        {
            try
            {
                return _CiudadRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
