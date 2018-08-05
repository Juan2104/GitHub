namespace SistemaSLS.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Servicio")]
    public partial class Servicio
    {

        [Key]

        public int IdServicio { get; set; }

        [StringLength(50)]
        public string Nombre { get; set; }

        public int IdTipoServicio { get; set; }


        public virtual TipoServicio TipoServicio { get; set; }
    }
}
