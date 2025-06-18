using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvParcial2.Controllers;
using EvParcial2.Models;

namespace EvParcial2.Vistas.Libros
{
    public partial class LibrosForm : Form
    {
        public bool modoEdicion = false;
        public int id = 0;  // Para editar un libro específico
        public LibrosForm(string modo)
        {
            if (modo != "n")
            {
                this.modoEdicion = true;
                this.id = int.Parse(modo);  // Si no es nuevo, obtén el id del libro
            }
            InitializeComponent();

        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Aceptar solo números para el stock
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Aceptar solo números y el punto decimal para el precio
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar los campos
            if (txtTitulo.Text == "" || txtAutor.Text == "" || txtEditorial.Text == "" || txtPrecio.Text == "" || txtStock.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                // Crear el objeto libro
                var libro = new LibrosModel()
                {
                    Titulo = txtTitulo.Text,
                    Autor = txtAutor.Text,
                    Editorial = txtEditorial.Text,
                    Precio = decimal.Parse(txtPrecio.Text),
                    Stock = int.Parse(txtStock.Text),
                    IdProveedor = string.IsNullOrEmpty(txtProveedor.Text) ? (int?)null : int.Parse(txtProveedor.Text)
                };

                var libroController = new LibrosController();

                if (!this.modoEdicion)  // Si no es edición, insertar nuevo libro
                {
                    var resultado = libroController.Insert(libro);
                    if (resultado == "OK")
                    {
                        MessageBox.Show("Libro guardado con éxito");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar: {resultado}");
                    }
                }
                else  // Si es edición, actualizar libro
                {
                    libro.IdLibro = this.id;  // Establecer el ID del libro
                    var resultado = libroController.Update(libro);
                    if (resultado == "OK")
                    {
                        MessageBox.Show("Libro actualizado con éxito");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al actualizar: {resultado}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error: {ex.Message}");
            }
        }

        private void btbCancelar_Click(object sender, EventArgs e)
        {
            this.Close();  // Cierra el formulario

        }

        private void LibrosForm_Load(object sender, EventArgs e)
        {
            if (!this.modoEdicion)
            {
                lblFrm.Text = "Ingreso de Nuevo Libro";
            }
            else
            {
                lblFrm.Text = "Actualización de Libro";
                var libroController = new LibrosController();
                var libro = libroController.GetAll().Find(l => l.IdLibro == this.id);  // Buscar libro por ID
                txtTitulo.Text = libro.Titulo;
                txtAutor.Text = libro.Autor;
                txtEditorial.Text = libro.Editorial;
                txtPrecio.Text = libro.Precio.ToString();
                txtStock.Text = libro.Stock.ToString();
                txtProveedor.Text = libro.IdProveedor.ToString();  // Asumiendo que Proveedor es un campo entero
            }
        }
    }
}
