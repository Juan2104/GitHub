
namespace SistemaSLS.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Pais")]
    public partial class Pais
    {

        [Key]

        public int IdPais { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Provincia> Provincia { get; set; }

    }
}
