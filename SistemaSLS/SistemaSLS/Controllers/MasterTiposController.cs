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
    public class MasterTiposController : Controller
    {
        private SlsContext context;
        private TipoMonedaService TipoMonedaService;
        IMapper Mapper;

        public MasterTiposController()
        {
            context = new SlsContext();
            TipoMonedaService = new TipoMonedaService(context);
            Mapper = ConfigureAutoMapper.MapperConfiguration.CreateMapper();
        }

        // GET: MasterTipos
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetInit()
        {
            var result = new
            {
                TipoMoneda = Mapper.Map<List<TipoMonedaDTO>>(TipoMonedaService.GetAll())
            };
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        public JsonResult SaveTipoMoneda(TipoMonedaDTO TipoMoneda)
        {
            TipoMonedaService.SaveTipoMoneda(Mapper.Map<TipoMoneda>(TipoMoneda));
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditTipoMoneda(TipoMonedaDTO TipoMoneda)
        {
            TipoMonedaService.EditTipoMoneda(Mapper.Map<TipoMoneda>(TipoMoneda));
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteTipoMoneda(int IdTipoMoneda)
        {
            TipoMonedaService.DeleteTipoMoneda(IdTipoMoneda);
            return Json("", JsonRequestBehavior.AllowGet);
        }



    }
}