using System;
namespace SistemaSLS.Domain.DTOs
{
    public partial class PersonaDTO
    {

        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public int IdTipoPersona { get; set; }
        public int IdEmpresa { get; set; }
        public int IdPais { get; set; }
        public string TelefonoPersonal { get; set; }
        public string TelefonoLaboral { get; set; }
        public string EmailPersonal { get; set; }
        public string EmailLaboral { get; set; }
        public Boolean Eliminado { get; set; }
        public string Movil { get; set; }
        public string Supervisor { get; set; }

    }
}
