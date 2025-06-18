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
    internal class ProveedoresController
    {
        private readonly conexion cn = new conexion();

        // Obtener todos los proveedores
        public List<ProveedoresModel> GetAll()
        {
            var proveedores = new List<ProveedoresModel>();
            using (var connection = cn.obtenerConexion())
            {
                connection.Open();
                string query = "SELECT * FROM proveedores";
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proveedores.Add(new ProveedoresModel
                        {
                            IdProveedor = (int)reader["idproveedor"],
                            Nombre = reader["nombre"].ToString(),
                            Contacto = reader["contacto"].ToString(),
                            Telefono = reader["telefono"].ToString(),
                            Direccion = reader["direccion"].ToString()
                        });
                    }
                }
            }
            return proveedores;
        }

        // Insertar un nuevo proveedor
        public string Insert(ProveedoresModel proveedor)
        {
            string query = "INSERT INTO proveedores (nombre, contacto, telefono, direccion) VALUES (@Nombre, @Contacto, @Telefono, @Direccion)";
            using (var connection = cn.obtenerConexion())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                command.Parameters.AddWithValue("@Contacto", proveedor.Contacto);
                command.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                command.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                connection.Open();
                return command.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }

        // Actualizar un proveedor existente
        public string Update(ProveedoresModel proveedor)
        {
            string query = "UPDATE proveedores SET nombre = @Nombre, contacto = @Contacto, telefono = @Telefono, direccion = @Direccion WHERE idproveedor = @ProveedorId";
            using (var connection = cn.obtenerConexion())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Nombre", proveedor.Nombre);
                command.Parameters.AddWithValue("@Contacto", proveedor.Contacto);
                command.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                command.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                command.Parameters.AddWithValue("@ProveedorId", proveedor.IdProveedor);
                connection.Open();
                return command.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }

        // Eliminar un proveedor
        public string Delete(int idProveedor)
        {
            string query = "DELETE FROM proveedores WHERE idproveedor = @ProveedorId";
            using (var connection = cn.obtenerConexion())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProveedorId", idProveedor);
                connection.Open();
                return command.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }
        public List<LibrosModel> Search(string searchText)
        {
            var libros = new List<LibrosModel>();
            using (var connection = cn.obtenerConexion())
            {
                connection.Open();
                string query = "SELECT * FROM libros WHERE titulo LIKE @SearchText OR autor LIKE @SearchText OR editorial LIKE @SearchText";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");  // El % para coincidencias parciales
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            libros.Add(new LibrosModel
                            {
                                IdLibro = (int)reader["idlibro"],
                                Titulo = reader["titulo"].ToString(),
                                Autor = reader["autor"].ToString(),
                                Editorial = reader["editorial"].ToString(),
                                Precio = (decimal)reader["precio"],
                                Stock = (int)reader["stock"],
                                IdProveedor = reader["idproveedor"] as int?  // Si el proveedor es nulo
                            });
                        }
                    }
                }
            }
            return libros;
        }

    }
}

