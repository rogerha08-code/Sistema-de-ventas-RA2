using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class DetalleVentasDAL
    {
        public void Insertar(DetalleVenta d)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd =
                    new SqlCommand("sp_InsertarDetalleVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_ventas", d.Id_ventas);
                cmd.Parameters.AddWithValue("@Id_producto", d.Id_producto);
                cmd.Parameters.AddWithValue("@Cantidad", d.Cantidad);
                cmd.Parameters.AddWithValue("@Precio_unitario", d.Precio_unitario);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarPorVenta(int idVenta)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd =
                    new SqlCommand("sp_ListarDetalleVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id_ventas", idVenta);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            return dt;
        }
    }
}
