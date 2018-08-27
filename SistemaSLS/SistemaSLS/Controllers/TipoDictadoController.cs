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

    public class TipoDictadoController : Controller
    {
        private SlsContext context;
        private TipoDictadoService TipoDictadoService;
        IMapper Mapper;


        public TipoDictadoController()
        {
            context = new SlsContext();
            TipoDictadoService = new TipoDictadoService(context);
            Mapper = ConfigureAutoMapper.MapperConfiguration.CreateMapper();
        }



        //  : TipoDictado
        public ActionResult Index()
        {
            return View();
        }


        public async Task<JsonResult> Get()
        {
            return Json(Mapper.Map<List<TipoDictadoDTO>>(await TipoDictadoService.GetAll()), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Post(TipoDictadoDTO TipoDictadoDTO)
        {
            var result = new
            {
                TipoDictadoDTOid = TipoDictadoService.SaveTipoDictado(Mapper.Map<SistemaSLS.Domain.Entities.TipoDictado>(TipoDictadoDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(TipoDictadoDTO TipoDictadoDTO)
        {
            var result = new
            {
                TipoDictadoDTOid = TipoDictadoService.EditTipoDictado(Mapper.Map<SistemaSLS.Domain.Entities.TipoDictado>(TipoDictadoDTO))
            };

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int IdTipoDictado)
        {
            TipoDictadoService.DeleteTipoDictado(IdTipoDictado);
            return Json("", JsonRequestBehavior.AllowGet);
        }

    }
}