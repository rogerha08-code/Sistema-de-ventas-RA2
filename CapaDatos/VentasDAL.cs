using System;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class VentasDAL
    {
        public int Insertar(Ventas v)
        {
            int idVenta;

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertarVenta", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Fecha", v.Fecha_Venta);
                cmd.Parameters.AddWithValue("@Id_cliente", v.Id_cliente);
                cmd.Parameters.AddWithValue("@Total", v.Total_general);

                cn.Open();
                idVenta = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return idVenta;
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlDataAdapter da =
                    new SqlDataAdapter("sp_ListarVentas", cn);

                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                da.Fill(dt);
            }

            return dt;
        }

        public void Anular(int idVenta)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd =
                    new SqlCommand("sp_AnularVenta", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_ventas", idVenta);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerVentasPorCliente(int idCliente)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd =
                    new SqlCommand("sp_ObtenerVentasPorCliente", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Idcliente", idCliente);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }

            return dt;
        }

        // ESTE ES EL NUEVO MÉTODO DEL REPORTE
        public DataTable ReporteFacturaCliente(int idCliente)
        {
            DataTable dt = new DataTable();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd =
                    new SqlCommand("sp_ReporteFacturaCliente", cn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id_cliente", idCliente);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);
            }

            return dt;
        }


        public DataTable ObtenerFactura(int idVenta)
        {
            SqlConnection con = new SqlConnection(Conexion.cadena);

            SqlCommand cmd = new SqlCommand("SP_FACTURA_VENTA", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdVenta", idVenta);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
    }
}
