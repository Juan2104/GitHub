
namespace SistemaSLS.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Ciudad")]
    public partial class Ciudad
    {
        [Key]
        public int IdCiudad { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("Provincia")]
        public int IdProvincia { get; set; }

        public Provincia Provincia { get; set; }
       
    }
}