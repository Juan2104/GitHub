using System;

namespace SistemaSLS.Domain.DTOs
{
    public partial class TipoServicioDTO
    {
        public int IdTipoServicio { get; set; }

        public string Nombre { get; set; }
 
        public string Descripcion { get; set; }

        public Boolean Valida { get; set; }

    }
}
