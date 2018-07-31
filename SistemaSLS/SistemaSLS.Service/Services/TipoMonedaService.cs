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
    public class TipoMonedaService
    {
        private readonly IBaseRepository<TipoMoneda> _TipoMonedaRepository;
        private readonly ISlsContext SlsContext;

        public TipoMonedaService(ISlsContext context)
        {
            _TipoMonedaRepository = new TipoMonedaRepository(context);
            SlsContext = context;
        }

        public TipoMonedaService(IBaseRepository<TipoMoneda> TipoMonedaRepository)
        {
            _TipoMonedaRepository = TipoMonedaRepository;
        }


        public async Task<List<TipoMoneda>> GetAll()
        {
           return (await _TipoMonedaRepository.GetAll()).ToList();
        }



        public int SaveTipoMoneda(TipoMoneda emp)
        {

            _TipoMonedaRepository.Add(emp);
            SlsContext.SaveChanges();
            return 1;
        }

        public int EditTipoMoneda(TipoMoneda tm)
        {
            var tmToEdit = _TipoMonedaRepository.GetById(tm.IdTipoMoneda);
            tmToEdit.Nombre = tm.Nombre;
            tmToEdit.Cambio = tm.Cambio;
            tmToEdit.Fecha = tm.Fecha;

            _TipoMonedaRepository.Update(tmToEdit);
            SlsContext.SaveChanges();
            return 1;
        }

        public void DeleteTipoMoneda(int IdTipoMoneda)
        {
            var TipoMonedaDB = _TipoMonedaRepository.GetById(IdTipoMoneda);
            _TipoMonedaRepository.Delete(TipoMonedaDB);
            SlsContext.SaveChanges();
        }



        public TipoMoneda GetById(int id)
        {
            try
            {
                return _TipoMonedaRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
