using AutoMapper;
using SistemaSLS.Data.Context;
using SistemaSLS.Service.Services;
using SistemaSLS.Utils;
using SistemaSLS.Domain.Entities;
using SistemaSLS.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
namespace SistemaSLS.Controllers
{

    public class TipoMonedaController : Controller
    {
        private SlsContext context;
        private TipoMonedaService TipoMonedaService;
        IMapper Mapper;


        public TipoMonedaController()
        {
            context = new SlsContext();
            TipoMonedaService = new TipoMonedaService(context);
            Mapper = ConfigureAutoMapper.MapperConfiguration.CreateMapper();
        }



        //  : TipoMoneda
        public ActionResult Index()
        {
            return View();
        }


        public async Task<JsonResult> Get()
        {
            return Json(Mapper.Map<List<TipoMonedaDTO>>(await TipoMonedaService.GetAll()), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Post(TipoMonedaDTO TipoMonedaDTO)
        {
            var result = new
            {
                TipoMonedaDTOid = TipoMonedaService.SaveTipoMoneda(Mapper.Map<SistemaSLS.Domain.Entities.TipoMoneda>(TipoMonedaDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(TipoMonedaDTO TipoMonedaDTO)
        {
            var result = new
            {
                TipoMonedaDTOid = TipoMonedaService.EditTipoMoneda(Mapper.Map<SistemaSLS.Domain.Entities.TipoMoneda>(TipoMonedaDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int IdTipoMoneda)
        {
            TipoMonedaService.DeleteTipoMoneda(IdTipoMoneda);
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}