using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvParcial2.Config;
using EvParcial2.Models;

namespace EvParcial2.Controllers
{
    internal class LibrosController
    {
        private readonly conexion cn = new conexion();

        // Obtener todos los libros
        public List<LibrosModel> GetAll()
        {
            var libros = new List<LibrosModel>();
            using (var connection = cn.obtenerConexion())
            {
                connection.Open();
                string query = "SELECT * FROM libros";
                using (var command = new SqlCommand(query, connection))
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
                            IdProveedor = reader["idproveedor"] as int?  // Puede ser nulo, por eso el cast a int?
                        });
                    }
                }
            }
            return libros;
        }

        // Insertar un nuevo libro
        public string Insert(LibrosModel libro)
        {
            string query = "INSERT INTO libros (titulo, autor, editorial, precio, stock, idproveedor) VALUES (@Titulo, @Autor, @Editorial, @Precio, @Stock, @Proveedor)";
            using (var connection = cn.obtenerConexion())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Titulo", libro.Titulo);
                command.Parameters.AddWithValue("@Autor", libro.Autor);
                command.Parameters.AddWithValue("@Editorial", libro.Editorial);
                command.Parameters.AddWithValue("@Precio", libro.Precio);
                command.Parameters.AddWithValue("@Stock", libro.Stock);
                command.Parameters.AddWithValue("@Proveedor", libro.IdProveedor.HasValue ? (object)libro.IdProveedor.Value : DBNull.Value);
                connection.Open();
                return command.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }

        // Actualizar un libro existente
        public string Update(LibrosModel libro)
        {
            string query = "UPDATE libros SET titulo = @Titulo, autor = @Autor, editorial = @Editorial, precio = @Precio, stock = @Stock, idproveedor = @Proveedor WHERE idlibro = @LibroId";
            using (var connection = cn.obtenerConexion())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Titulo", libro.Titulo);
                command.Parameters.AddWithValue("@Autor", libro.Autor);
                command.Parameters.AddWithValue("@Editorial", libro.Editorial);
                command.Parameters.AddWithValue("@Precio", libro.Precio);
                command.Parameters.AddWithValue("@Stock", libro.Stock);
                command.Parameters.AddWithValue("@Proveedor", libro.IdProveedor.HasValue ? (object)libro.IdProveedor.Value : DBNull.Value);
                command.Parameters.AddWithValue("@LibroId", libro.IdLibro);
                connection.Open();
                return command.ExecuteNonQuery() > 0 ? "OK" : "Error";
            }
        }

        // Eliminar un libro
        public string Delete(int idLibro)
        {
            string query = "DELETE FROM libros WHERE idlibro = @LibroId";
            using (var connection = cn.obtenerConexion())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@LibroId", idLibro);
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
                string query = "SELECT * FROM libros WHERE titulo LIKE @SearchText OR autor LIKE @SearchText";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");  // Agrega el % para buscar coincidencias parciales
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
                                IdProveedor = reader["idproveedor"] as int?
                            });
                        }
                    }
                }
            }
            return libros;
        }

    }
}
