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
    public class ServicioService
    {
        private readonly IBaseRepository<Servicio> _ServicioRepository;
        private readonly ISlsContext SlsContext;

        public ServicioService(ISlsContext context)
        {
            _ServicioRepository = new ServicioRepository(context);
            SlsContext = context;
        }

        public ServicioService(IBaseRepository<Servicio> ServicioRepository)
        {
            _ServicioRepository = ServicioRepository;
        }


        public async Task<List<Servicio>> GetAll()
        {
            return (await _ServicioRepository.GetAll()).ToList();
        }



        public int SaveServicio(Servicio emp)
        {

            _ServicioRepository.Add(emp);
            SlsContext.SaveChanges();
            return 1;
        }

        public int EditServicio(Servicio tm)
        {
            var tmToEdit = _ServicioRepository.GetById(tm.IdServicio);
            tmToEdit.Nombre = tm.Nombre;
            tmToEdit.IdTipoServicio = tm.IdTipoServicio;            

            _ServicioRepository.Update(tmToEdit);
            SlsContext.SaveChanges();
            return 1;
        }

        public void DeleteServicio(int IdServicio)
        {
            var ServicioDB = _ServicioRepository.GetById(IdServicio);
            _ServicioRepository.Delete(ServicioDB);
            SlsContext.SaveChanges();
        }



        public Servicio GetById(int id)
        {
            try
            {
                return _ServicioRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
