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
    public class EmpresaService
    {
        private readonly IBaseRepository<Empresa> _EmpresaRepository;
        private readonly ISlsContext SlsContext;

        public EmpresaService(ISlsContext context)
        {
            _EmpresaRepository = new EmpresaRepository(context);
            SlsContext = context;
        }

        public EmpresaService(IBaseRepository<Empresa> EmpresaRepository)
        {
            _EmpresaRepository = EmpresaRepository;
        }


        public async Task<List<Empresa>> GetAll()
        {
            return (await _EmpresaRepository.GetAll()).ToList();
        }



        public int SaveEmpresa(Empresa emp)
        {

            _EmpresaRepository.Add(emp);
            SlsContext.SaveChanges();
            return 1;
        }

        public int EditEmpresa(Empresa emp)
        {
            var empToEdit = _EmpresaRepository.GetById(emp.IdEmpresa);
            empToEdit.Descripcion = emp.Descripcion;
            empToEdit.IdPais = emp.IdPais;

            //empToEdit.= mesa.Descripcion;
            //rolToEdit.ReadOnly = rol.Edit;
            //rolToEdit.Edit = rol.ReadOnly;
            //rolToEdit.EditWho = HttpContext.Current.User.Identity.Name;
            _EmpresaRepository.Update(empToEdit);
            SlsContext.SaveChanges();
            return 1;
        }

        public void DeleteEmpresa(int IdEmpresa)
        {
            var EmpresaDB = _EmpresaRepository.GetById(IdEmpresa);
            _EmpresaRepository.Delete(EmpresaDB);
            SlsContext.SaveChanges();
        }



        public Empresa GetById(int id)
        {
            try
            {
                return _EmpresaRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
