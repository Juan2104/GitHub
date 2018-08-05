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

    public class ServicioController : Controller
    {
        private SlsContext context;
        private ServicioService ServicioService;
        IMapper Mapper;


        public ServicioController()
        {
            context = new SlsContext();
            ServicioService = new ServicioService(context);
            Mapper = ConfigureAutoMapper.MapperConfiguration.CreateMapper();
        }



        //  : Servicio
        public ActionResult Index()
        {
            return View();
        }


        public async Task<JsonResult> Get()
        {
            return Json(Mapper.Map<List<ServicioDTO>>(await ServicioService.GetAll()), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Post(ServicioDTO ServicioDTO)
        {
            var result = new
            {
                ServicioDTOid = ServicioService.SaveServicio(Mapper.Map<SistemaSLS.Domain.Entities.Servicio>(ServicioDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(ServicioDTO ServicioDTO)
        {
            var result = new
            {
                ServicioDTOid = ServicioService.EditServicio(Mapper.Map<SistemaSLS.Domain.Entities.Servicio>(ServicioDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int IdServicio)
        {
            ServicioService.DeleteServicio(IdServicio);
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}