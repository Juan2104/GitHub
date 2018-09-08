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

    public class EmpresaController : Controller
    {
        private SlsContext context;
        private EmpresaService EmpresaService;
        IMapper Mapper;


        public EmpresaController()
        {
            context = new SlsContext();
            EmpresaService = new EmpresaService(context);
            Mapper = ConfigureAutoMapper.MapperConfiguration.CreateMapper();
        }



        //  : Empresa
        public ActionResult Index()
        {
            return View();
        }


        public async Task<JsonResult> Get()
        {
            return Json(Mapper.Map<List<EmpresaDTO>>(await EmpresaService.GetAll()), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Post(EmpresaDTO EmpresaDTO)
        {
            var result = new
            {
                EmpresaDTOid = EmpresaService.SaveEmpresa(Mapper.Map<SistemaSLS.Domain.Entities.Empresa>(EmpresaDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(EmpresaDTO EmpresaDTO)
        {
            var result = new
            {
                EmpresaDTOid = EmpresaService.EditEmpresa(Mapper.Map<SistemaSLS.Domain.Entities.Empresa>(EmpresaDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int IdEmpresa)
        {
            EmpresaService.DeleteEmpresa(IdEmpresa);
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}