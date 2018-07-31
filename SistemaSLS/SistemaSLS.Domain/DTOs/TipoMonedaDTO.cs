using System;
namespace SistemaSLS.Domain.DTOs
{
    public partial class TipoMonedaDTO
    {
        public int IdTipoMoneda { get; set; }
        public string Nombre { get; set; }
        public decimal Cambio { get; set; }
        public DateTime Fecha { get; set; }
    }
}
