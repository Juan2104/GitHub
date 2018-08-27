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

    public class PersonaController : Controller
    {
        private SlsContext context;
        private PersonaService PersonaService;
        IMapper Mapper;


        public PersonaController()
        {
            context = new SlsContext();
            PersonaService = new PersonaService(context);
            Mapper = ConfigureAutoMapper.MapperConfiguration.CreateMapper();
        }



        //  : Persona
        public ActionResult Index()
        {
            return View();
        }


        public async Task<JsonResult> Get()
        {
            return Json(Mapper.Map<List<PersonaDTO>>(await PersonaService.GetAll()), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Post(PersonaDTO PersonaDTO)
        {
            var result = new
            {
                PersonaDTOid = PersonaService.SavePersona(Mapper.Map<SistemaSLS.Domain.Entities.Persona>(PersonaDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(PersonaDTO PersonaDTO)
        {
            var result = new
            {
                PersonaDTOid = PersonaService.EditPersona(Mapper.Map<SistemaSLS.Domain.Entities.Persona>(PersonaDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int IdPersona)
        {
            PersonaService.DeletePersona(IdPersona);
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}