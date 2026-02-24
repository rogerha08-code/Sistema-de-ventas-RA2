using System;

namespace CapaEntidad
{
    public class Ventas
    {
        public int Id_ventas { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public int Id_cliente { get; set; }
        public decimal Total_general { get; set; }
        public bool Estado_venta { get; set; }
    }
}
