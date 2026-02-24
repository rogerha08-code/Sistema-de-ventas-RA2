namespace CapaEntidad
{
    public class DetalleVenta
    {
        public int Id_detalle { get; set; }
        public int Id_ventas { get; set; }
        public int Id_producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio_unitario { get; set; }
    }
}
