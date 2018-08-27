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

    public class PaisController : Controller
    {
        private SlsContext context;
        private PaisService PaisService;
        private ProvinciaService ProvinciaService;
        IMapper Mapper;


        public PaisController()
        {
            context = new SlsContext();
            PaisService = new PaisService(context);
            ProvinciaService = new ProvinciaService(context);
            Mapper = ConfigureAutoMapper.MapperConfiguration.CreateMapper();
        }



        //  : Pais
        public ActionResult Index()
        {
            return View();
        }


        //public async Task<JsonResult> Get()
        //{
        //    return Json(Mapper.Map<List<PaisDTO>>(await PaisService.GetAll()), JsonRequestBehavior.AllowGet);
        //}

        public async Task<JsonResult> Get()
        {
            var result = new
            {
                Pais = Mapper.Map<List<PaisDTO>>(await PaisService.GetAll()),
                Provincia = Mapper.Map<List<ProvinciaDTO>>(await ProvinciaService.GetAll())
            };

            return Json(result, JsonRequestBehavior.AllowGet);
            
        }


        public JsonResult SavePais(PaisDTO PaisDTO)
        {
            var result = new
            {
                PaisDTOid = PaisService.SavePais(Mapper.Map<SistemaSLS.Domain.Entities.Pais>(PaisDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdatePais(PaisDTO PaisDTO)
        {
            var result = new
            {
                PaisDTOid = PaisService.EditPais(Mapper.Map<SistemaSLS.Domain.Entities.Pais>(PaisDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePais(int IdPais)
        {
            PaisService.DeletePais(IdPais);
            return Json("", JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveProvincia(ProvinciaDTO ProvinciaDTO)
        {
            var result = new
            {
                ProvinciaDTOid = ProvinciaService.SaveProvincia(Mapper.Map<SistemaSLS.Domain.Entities.Provincia>(ProvinciaDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateProvincia(ProvinciaDTO ProvinciaDTO)
        {
            var result = new
            {
                ProvinciaDTOid = ProvinciaService.EditProvincia(Mapper.Map<SistemaSLS.Domain.Entities.Provincia>(ProvinciaDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteProvincia(int IdProvincia)
        {
            ProvinciaService.DeleteProvincia(IdProvincia);
            return Json("", JsonRequestBehavior.AllowGet);
        }


    }
}