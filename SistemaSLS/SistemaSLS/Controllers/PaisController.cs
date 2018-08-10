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
        IMapper Mapper;


        public PaisController()
        {
            context = new SlsContext();
            PaisService = new PaisService(context);
            Mapper = ConfigureAutoMapper.MapperConfiguration.CreateMapper();
        }



        //  : Pais
        public ActionResult Index()
        {
            return View();
        }


        public async Task<JsonResult> Get()
        {
            return Json(Mapper.Map<List<PaisDTO>>(await PaisService.GetAll()), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Post(PaisDTO PaisDTO)
        {
            var result = new
            {
                PaisDTOid = PaisService.SavePais(Mapper.Map<SistemaSLS.Domain.Entities.Pais>(PaisDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(PaisDTO PaisDTO)
        {
            var result = new
            {
                PaisDTOid = PaisService.EditPais(Mapper.Map<SistemaSLS.Domain.Entities.Pais>(PaisDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int IdPais)
        {
            PaisService.DeletePais(IdPais);
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}