using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSLS.Domain.Entities
{
  
    public  class Estado
    {
        [Key]
        public int IdEstado { get; set; }
        public string Descripcion { get; set; } 
    }
}
