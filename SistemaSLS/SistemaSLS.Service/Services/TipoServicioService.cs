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
    public class TipoServicioService
    {
        private readonly IBaseRepository<TipoServicio> _TipoServicioRepository;
        private readonly ISlsContext SlsContext;

        public TipoServicioService(ISlsContext context)
        {
            _TipoServicioRepository = new TipoServicioRepository(context);
            SlsContext = context;
        }

        public TipoServicioService(IBaseRepository<TipoServicio> TipoServicioRepository)
        {
            _TipoServicioRepository = TipoServicioRepository;
        }


        public async Task<List<TipoServicio>> GetAll()
        {
            return (await _TipoServicioRepository.GetAll()).ToList();
        }



        public int SaveTipoServicio(TipoServicio emp)
        {

            _TipoServicioRepository.Add(emp);
            SlsContext.SaveChanges();
            return 1;
        }

        public int EditTipoServicio(TipoServicio tm)
        {
            var tmToEdit = _TipoServicioRepository.GetById(tm.IdTipoServicio);
            tmToEdit.Nombre = tm.Nombre;            
            tmToEdit.Descripcion = tm.Descripcion;
            tmToEdit.Valida = tm.Valida;

            _TipoServicioRepository.Update(tmToEdit);
            SlsContext.SaveChanges();
            return 1;
        }

        public void DeleteTipoServicio(int IdTipoServicio)
        {
            var TipoServicioDB = _TipoServicioRepository.GetById(IdTipoServicio);
            _TipoServicioRepository.Delete(TipoServicioDB);
            SlsContext.SaveChanges();
        }



        public TipoServicio GetById(int id)
        {
            try
            {
                return _TipoServicioRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
