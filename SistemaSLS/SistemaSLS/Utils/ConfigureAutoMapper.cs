using AutoMapper;
using SistemaSLS.Domain.DTOs;
using SistemaSLS.Domain.Entities;

namespace SistemaSLS.Utils
{
    public class ConfigureAutoMapper
    {
        public static MapperConfiguration MapperConfiguration;

        public static void ConfigureMapping()
        {
            MapperConfiguration = new MapperConfiguration(
          cfg => {
              cfg.CreateMap<TipoPersona, TipoPersonaDTO>().ReverseMap();
              cfg.CreateMap<TipoMoneda, TipoMonedaDTO>().ReverseMap();
              cfg.CreateMap<TipoServicio, TipoServicioDTO>().ReverseMap();
              cfg.CreateMap<Servicio, ServicioDTO>().ReverseMap();
              cfg.CreateMap<Persona, PersonaDTO>().ReverseMap();
              cfg.CreateMap<Pais, PaisDTO>().ReverseMap();
              cfg.CreateMap<Provincia, ProvinciaDTO>().ReverseMap();
              cfg.CreateMap<Ciudad, CiudadDTO>().ReverseMap();
          });
        }
    }
}