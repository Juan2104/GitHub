using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSLS.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Agenda")]
    public partial class Agenda : Auditoria
    {
        [Key]
        public int IdAgenda { get; set; }
        public string Descripcion { get; set; } 
        [ForeignKey("Ciudad")]
        public int Idciudad { get; set; } 
        public Ciudad Ciudad { get; set; } 
        [ForeignKey("Persona")]
        public int IdInstructor { get; set; } 
        public Persona Persona { get; set; } 
        public int Semana { get; set; } 
        public DateTime Desde { get; set; } 
        public DateTime Hasta { get; set; } 
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public Boolean Activo { get; set; }
        public virtual ICollection<TipoDictado> Dictado { get; set; }
        public string Dias { get; set; }
    }

}