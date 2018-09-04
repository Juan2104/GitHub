using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaSLS.Domain.Entities
{
  
    public  class Auditoria
    {
        public string UsuarioAdd { get; set; }
        public DateTime FechaAdd { get; set; }
        public string UsuarioEdit { get; set; } 
        public DateTime FechaEdit { get; set; }
    }
}
