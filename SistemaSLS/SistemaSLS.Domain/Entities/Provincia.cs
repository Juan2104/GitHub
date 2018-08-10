
namespace SistemaSLS.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Provincia")]
    public partial class Provincia
    {
        [Key]
        public int IdProvincia { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("Pais")]
        public int IdPais { get; set; }

        public Pais Pais { get; set; }

        public ICollection<Ciudad> Ciudad { get; set; }
    }
}
