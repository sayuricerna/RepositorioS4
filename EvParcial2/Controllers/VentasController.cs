using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvParcial2.Config;
using EvParcial2.Models;

namespace EvParcial2.Controllers
{
    internal class VentasController
    {
        private readonly conexion cn = new conexion();

        public List<VentasModel> GetAll()
        {
            var ventas = new List<VentasModel>();
            using (var connection = cn.obtenerConexion())
            {
                connection.Open();
                string query = "SELECT * FROM ventas";
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        /*
                        ventas.Add(new VentasModel
                        {
                            IdVenta = (int)reader["idventa"],
                            IdLibro = (int)reader["idlibro"],
                            Cantidad = (int)reader["cantidad"],
                            Total = (decimal)reader["total"],  // Asumí que también deseas leer el campo 'total'
                            FechaVenta = (DateTime)reader["fechaventa"]
                        });*/
                        ventas.Add(new VentasModel
                        {
                            IdVenta = reader["idventa"] != DBNull.Value ? (int)reader["idventa"] : 0,
                            IdLibro = reader["idlibro"] != DBNull.Value ? (int)reader["idlibro"] : 0,
                            Cantidad = reader["cantidad"] != DBNull.Value ? (int)reader["cantidad"] : 0,
                            Total = reader["total"] != DBNull.Value ? (decimal)reader["total"] : 0m,  // Si el valor es NULL, asignar 0
                            FechaVenta = reader["fechaventa"] != DBNull.Value ? (DateTime)reader["fechaventa"] : DateTime.MinValue  // Si es NULL, asignar la fecha mínima
                        });

                    }
                }
            }
            return ventas;
        }

        public string Insert(VentasModel venta)
        {
            string query = "INSERT INTO ventas (idlibro, cantidad, fechaventa) VALUES (@Libro, @Cantidad, @Fecha)";
            using (var connection = cn.obtenerConexion())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Libro", venta.IdLibro);
                command.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                command.Parameters.AddWithValue("@Fecha", venta.FechaVenta);
                connection.Open();
                return command.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }

        public string Update(VentasModel venta)
        {
            string query = "UPDATE ventas SET idlibro = @Libro, cantidad = @Cantidad, fechaventa = @Fecha WHERE idventa = @VentaId";
            using (var connection = cn.obtenerConexion())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Libro", venta.IdLibro);
                command.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
                command.Parameters.AddWithValue("@Fecha", venta.FechaVenta);
                command.Parameters.AddWithValue("@VentaId", venta.IdVenta);
                connection.Open();
                return command.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }

        public string Delete(int idVenta)
        {
            string query = "DELETE FROM ventas WHERE idventa = @VentaId";
            using (var connection = cn.obtenerConexion())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@VentaId", idVenta);
                connection.Open();
                return command.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }
        // Buscar ventas por libro o fecha
        public List<VentasModel> Search(string searchText)
        {
            var ventas = new List<VentasModel>();
            using (var connection = cn.obtenerConexion())
            {
                connection.Open();
                string query = "SELECT * FROM ventas WHERE idlibro = @SearchText OR fechaventa LIKE @SearchText";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ventas.Add(new VentasModel
                            {
                                IdVenta = (int)reader["idventa"],
                                IdLibro = (int)reader["idlibro"],
                                Cantidad = (int)reader["cantidad"],
                                Total = (decimal)reader["total"],
                                FechaVenta = (DateTime)reader["fechaventa"]
                            });
                        }
                    }
                }
            }
            return ventas;
        }

    }
}