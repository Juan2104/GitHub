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

    public class ProvinciaController : Controller
    {
        private SlsContext context;
        private ProvinciaService ProvinciaService;
        IMapper Mapper;


        public ProvinciaController()
        {
            context = new SlsContext();
            ProvinciaService = new ProvinciaService(context);
            Mapper = ConfigureAutoMapper.MapperConfiguration.CreateMapper();
        }



        //  : Provincia
        public ActionResult Index()
        {
            return View();
        }


        public async Task<JsonResult> Get()
        {
            return Json(Mapper.Map<List<ProvinciaDTO>>(await ProvinciaService.GetAll()), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Post(ProvinciaDTO ProvinciaDTO)
        {
            var result = new
            {
                ProvinciaDTOid = ProvinciaService.SaveProvincia(Mapper.Map<SistemaSLS.Domain.Entities.Provincia>(ProvinciaDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(ProvinciaDTO ProvinciaDTO)
        {
            var result = new
            {
                ProvinciaDTOid = ProvinciaService.EditProvincia(Mapper.Map<SistemaSLS.Domain.Entities.Provincia>(ProvinciaDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int IdProvincia)
        {
            ProvinciaService.DeleteProvincia(IdProvincia);
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}