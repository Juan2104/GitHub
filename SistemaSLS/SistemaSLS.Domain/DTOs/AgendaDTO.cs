using System;
namespace SistemaSLS.Domain.DTOs
{
    public partial class AgendaDTO
    {
        public int IdAgenda { get; set; }
        public string Descripcion { get; set; }
 
        public int IdCiudad { get; set; }

        public int Semana { get; set; }

        public DateTime Desde { get; set; }

        public DateTime Hasta { get; set; }

        public string Hora { get; set; }
    }
}

