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
 
    public class TipoPersonaController : Controller
    {
        private SlsContext context;
        private TipoPersonaService TipoPersonaService;
        IMapper Mapper;


        public TipoPersonaController()
        {
            context = new SlsContext();
            TipoPersonaService = new TipoPersonaService(context);
            Mapper = ConfigureAutoMapper.MapperConfiguration.CreateMapper();
        }



        //  : TipoPersona
        public ActionResult Index()
        {
            return View();
        }


        public async Task<JsonResult> Get()
        {
            return Json(Mapper.Map<List<TipoPersonaDTO>>(await TipoPersonaService.GetAll()), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Post(TipoPersonaDTO TipoPersonaDTO)
        {
            var result = new
            {
                TipoPersonaDTOid = TipoPersonaService.Save(Mapper.Map<SistemaSLS.Domain.Entities.TipoPersona>(TipoPersonaDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(TipoPersonaDTO TipoPersonaDTO)
        {
            var result = new
            {
                TipoPersonaDTOid = TipoPersonaService.Edit(Mapper.Map<SistemaSLS.Domain.Entities.TipoPersona>(TipoPersonaDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int IdTipoPersona)
        {
            TipoPersonaService.Delete(IdTipoPersona);
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}