
namespace SistemaSLS.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Empresa")]
    public partial class Empresa
    {

        [Key]

        public int IdEmpresa { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("Pais")]
        public int IdPais { get; set; }

        public Pais Pais { get; set; }


    }
}
