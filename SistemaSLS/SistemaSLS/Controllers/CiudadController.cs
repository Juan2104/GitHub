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

    public class CiudadController : Controller
    {
        private SlsContext context;
        private CiudadService CiudadService;
        IMapper Mapper;


        public CiudadController()
        {
            context = new SlsContext();
            CiudadService = new CiudadService(context);
            Mapper = ConfigureAutoMapper.MapperConfiguration.CreateMapper();
        }



        //  : Ciudad
        public ActionResult Index()
        {
            return View();
        }


        public async Task<JsonResult> Get()
        {
            return Json(Mapper.Map<List<CiudadDTO>>(await CiudadService.GetAll()), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Post(CiudadDTO CiudadDTO)
        {
            var result = new
            {
                CiudadDTOid = CiudadService.SaveCiudad(Mapper.Map<SistemaSLS.Domain.Entities.Ciudad>(CiudadDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(CiudadDTO CiudadDTO)
        {
            var result = new
            {
                CiudadDTOid = CiudadService.EditCiudad(Mapper.Map<SistemaSLS.Domain.Entities.Ciudad>(CiudadDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int IdCiudad)
        {
            CiudadService.DeleteCiudad(IdCiudad);
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}