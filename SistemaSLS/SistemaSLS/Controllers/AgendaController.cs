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

    public class AgendaController : Controller
    {
        private SlsContext context;
        private AgendaService AgendaService;
        IMapper Mapper;


        public AgendaController()
        {
            context = new SlsContext();
            AgendaService = new AgendaService(context);
            Mapper = ConfigureAutoMapper.MapperConfiguration.CreateMapper();
        }



        //  : Agenda
        public ActionResult Index()
        {
            return View();
        }


        public async Task<JsonResult> Get()
        {
            return Json(Mapper.Map<List<AgendaDTO>>(await AgendaService.GetAll()), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Post(AgendaDTO AgendaDTO)
        {
            var result = new
            {
                AgendaDTOid = AgendaService.SaveAgenda(Mapper.Map<SistemaSLS.Domain.Entities.Agenda>(AgendaDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(AgendaDTO AgendaDTO)
        {
            var result = new
            {
                AgendaDTOid = AgendaService.EditAgenda(Mapper.Map<SistemaSLS.Domain.Entities.Agenda>(AgendaDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int IdAgenda)
        {
            AgendaService.DeleteAgenda(IdAgenda);
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}