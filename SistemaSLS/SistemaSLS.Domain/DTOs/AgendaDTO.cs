using System;
namespace SistemaSLS.Domain.DTOs
{
    public partial class AgendaDTO
    {
        public int IdAgenda { get; set; }

        public string CodigoAgenda { get { return IdAgenda.ToString().PadLeft(5,'0'); } }

        public string Descripcion { get; set; }
 
        public int IdCiudad { get; set; }

        public CiudadDTO Ciudad { get; set; }

        public int Semana { get; set; }

        public DateTime Desde { get; set; }

        public DateTime Hasta { get; set; }

        public string HoraInicio { get; set; }
        public string Dias { get; set; }

        public bool Lunes { get { return (Dias ?? "").ToString().Contains("1"); } }
        public bool Martes { get { return (Dias ?? "").ToString().Contains("1"); } }
        public bool Miercoles { get { return (Dias ?? "").ToString().Contains("1"); } }
        public bool Jueves { get { return (Dias ?? "").ToString().Contains("1"); } }
        public bool Viernes { get { return (Dias ?? "").ToString().Contains("1"); } }

    }
}

