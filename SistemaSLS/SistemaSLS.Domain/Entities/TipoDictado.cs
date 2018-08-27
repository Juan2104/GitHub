
namespace SistemaSLS.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TipoDictado")]
    public partial class TipoDictado
    {

        [Key]

        public int IdTipoDictado { get; set; }


        public string Descripcion { get; set; }
    }
}
