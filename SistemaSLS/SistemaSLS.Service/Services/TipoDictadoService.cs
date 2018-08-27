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
    public class TipoDictadoService
    {
        private readonly IBaseRepository<TipoDictado> _TipoDictadoRepository;
        private readonly ISlsContext SlsContext;

        public TipoDictadoService(ISlsContext context)
        {
            _TipoDictadoRepository = new TipoDictadoRepository(context);
            SlsContext = context;
        }

        public TipoDictadoService(IBaseRepository<TipoDictado> TipoDictadoRepository)
        {
            _TipoDictadoRepository = TipoDictadoRepository;
        }


        public async Task<List<TipoDictado>> GetAll()
        {
            return (await _TipoDictadoRepository.GetAll()).ToList();
        }



        public int SaveTipoDictado(TipoDictado emp)
        {

            _TipoDictadoRepository.Add(emp);
            SlsContext.SaveChanges();
            return 1;
        }

        public int EditTipoDictado(TipoDictado tm)
        {
            var tmToEdit = _TipoDictadoRepository.GetById(tm.IdTipoDictado);
            tmToEdit.Descripcion = tm.Descripcion;

            _TipoDictadoRepository.Update(tmToEdit);
            SlsContext.SaveChanges();
            return 1;
        }

        public void DeleteTipoDictado(int IdTipoDictado)
        {
            var TipoDictadoDB = _TipoDictadoRepository.GetById(IdTipoDictado);
            _TipoDictadoRepository.Delete(TipoDictadoDB);
            SlsContext.SaveChanges();
        }



        public TipoDictado GetById(int id)
        {
            try
            {
                return _TipoDictadoRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
