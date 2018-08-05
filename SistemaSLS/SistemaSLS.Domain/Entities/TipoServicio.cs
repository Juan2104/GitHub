
namespace SistemaSLS.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoServicio")]
    public partial class TipoServicio
    {

        [Key]

        public int IdTipoServicio { get; set; }

        [StringLength(150)]
        public string Nombre { get; set; }
        [StringLength(150)]
        public string Descripcion { get; set; }

        public Boolean Valida { get; set; }
    }
}
