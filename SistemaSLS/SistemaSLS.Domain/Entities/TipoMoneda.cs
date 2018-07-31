
namespace SistemaSLS.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoMoneda")]
    public partial class TipoMoneda
    {
        [Key]
        public int IdTipoMoneda { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        
        public decimal Cambio { get; set; }

        public DateTime Fecha { get; set; }
        
    }
}
