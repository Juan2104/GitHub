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

    public class TipoServicioController : Controller
    {
        private SlsContext context;
        private TipoServicioService TipoServicioService;
        IMapper Mapper;


        public TipoServicioController()
        {
            context = new SlsContext();
            TipoServicioService = new TipoServicioService(context);
            Mapper = ConfigureAutoMapper.MapperConfiguration.CreateMapper();
        }



        //  : TipoServicio
        public ActionResult Index()
        {
            return View();
        }


        public async Task<JsonResult> Get()
        {
            return Json(Mapper.Map<List<TipoServicioDTO>>(await TipoServicioService.GetAll()), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Post(TipoServicioDTO TipoServicioDTO)
        {
            var result = new
            {
                TipoServicioDTOid = TipoServicioService.SaveTipoServicio(Mapper.Map<SistemaSLS.Domain.Entities.TipoServicio>(TipoServicioDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(TipoServicioDTO TipoServicioDTO)
        {
            var result = new
            {
                TipoServicioDTOid = TipoServicioService.EditTipoServicio(Mapper.Map<SistemaSLS.Domain.Entities.TipoServicio>(TipoServicioDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int IdTipoServicio)
        {
            TipoServicioService.DeleteTipoServicio(IdTipoServicio);
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}