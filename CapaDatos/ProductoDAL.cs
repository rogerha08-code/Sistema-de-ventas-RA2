using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Capaentidad.CapaEntidad;
using CapaEntidad;

namespace CapaDatos
{
    public class ProductoDAL
    {
       
        public void AgregarProducto(Producto p)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_AgregarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Nombre_producto", p.Nombre_producto);
                cmd.Parameters.AddWithValue("@Precio_producto", p.Precio_producto);
                cmd.Parameters.AddWithValue("@Stock", p.Stock);
                cmd.Parameters.AddWithValue("@ID_categoria", p.ID_categoria);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarProducto(int idProducto)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_producto", idProducto);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }




        public List<Producto> Listar()
        {
            List<Producto> lista = new List<Producto>();

            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ListarProductos", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Producto
                    {
                        ID_producto = Convert.ToInt32(dr["ID_producto"]),
                        Nombre_producto = dr["Nombre_producto"].ToString(),
                        Precio_producto = Convert.ToDecimal(dr["Precio_producto"]),
                        Stock = Convert.ToInt32(dr["Stock"]),
                        ID_categoria = Convert.ToInt32(dr["ID_categoria"])
                    });
                }
            }

            return lista;
        }




        public void ActualizarProducto(Producto p)
        {
            using (SqlConnection cn = Conexion.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_ActualizarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID_producto", p.ID_producto);
                cmd.Parameters.AddWithValue("@Nombre_producto", p.Nombre_producto);
                cmd.Parameters.AddWithValue("@Precio_producto", p.Precio_producto);
                cmd.Parameters.AddWithValue("@Stock", p.Stock);
                cmd.Parameters.AddWithValue("@ID_categoria", p.ID_categoria);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
