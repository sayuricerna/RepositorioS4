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

namespace EvParcial2.Vistas.Ventas
{
    public partial class VentasForm : Form
    {

        public bool modoEdicion = false;
        public int id = 0;


        public VentasForm(string modo)
        {
            if (modo != "n")
            {
                this.modoEdicion = true;
                this.id = int.Parse(modo);  // Si no es nuevo, obtén el id de la venta
            }
            InitializeComponent();
        }

        private void VentasForm_Load(object sender, EventArgs e)
        {
            if (!this.modoEdicion)
            {
                lblFrm.Text = "Ingreso de Nueva Venta";
            }
            else
            {
                lblFrm.Text = "Actualización de Venta";
                var ventaController = new VentasController();
                var venta = ventaController.GetAll().Find(v => v.IdVenta == this.id);  // Buscar venta por ID
                cboLibro.SelectedItem = venta.IdLibro;  // Asumiendo que se tiene un ComboBox con libros
                txtCantidad.Text = venta.Cantidad.ToString();
                txtTotal.Text = venta.Total.ToString();
            }

            // Cargar lista de libros al ComboBox
            CargarLibros();
        }
        private void CargarLibros()
        {
            var libroController = new LibrosController(); // Asumiendo que tienes un controlador para libros
            var libros = libroController.GetAll();  // Obtener todos los libros disponibles

            cboLibro.DataSource = libros;
            cboLibro.DisplayMember = "Titulo";  // Asume que cada libro tiene un 'NombreLibro'
            cboLibro.ValueMember = "IdLibro";  // Asume que cada libro tiene un 'IdLibro'
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar los campos
            if (cboLibro.SelectedIndex == -1 || txtCantidad.Text == "" || decimal.TryParse(txtCantidad.Text, out decimal cantidad) == false || cantidad <= 0)
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.");
                return;
            }

            try
            {
                // Obtener el libro seleccionado (IdLibro)
                int idLibro = (int)cboLibro.SelectedValue;  // Usamos el ValueMember para obtener el IdLibro seleccionado
                decimal precioLibro = ObtenerPrecioLibro(idLibro); // Obtener el precio del libro seleccionado

                // Calcular el total
                decimal total = precioLibro * cantidad;

                // Crear el objeto venta
                var venta = new VentasModel()
                {
                    IdLibro = idLibro,
                    Cantidad = (int)cantidad,
                    Total = total,
                    FechaVenta = DateTime.Now  // La fecha se genera automáticamente al guardar, pero puedes dejarla para mostrarla si es necesario.
                };

                var ventaController = new VentasController();

                if (!this.modoEdicion)  // Si no es edición, insertar nueva venta
                {
                    var resultado = ventaController.Insert(venta);
                    if (resultado == "OK")
                    {
                        MessageBox.Show("Venta guardada con éxito");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar: {resultado}");
                    }
                }
                else  // Si es edición, actualizar venta
                {
                    venta.IdVenta = this.id;  // Establecer el ID de la venta
                    var resultado = ventaController.Update(venta);
                    if (resultado == "OK")
                    {
                        MessageBox.Show("Venta actualizada con éxito");
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

        private decimal ObtenerPrecioLibro(int idLibro)
        {
            // Lógica para obtener el precio del libro
            // Aquí solo retornaré un valor de ejemplo:
            var libroController = new LibrosController();
            var libro = libroController.GetAll().FirstOrDefault(l => l.IdLibro == idLibro);
            return libro != null ? libro.Precio : 0m;  // Suponiendo que el libro tiene una propiedad 'Precio'
        }
        private void btbCancelar_Click(object sender, EventArgs e)
        {
            this.Close();  // Cierra el formulario

        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtCantidad.Text, out decimal cantidad) && cboLibro.SelectedIndex != -1)
            {
                int idLibro = (int)cboLibro.SelectedValue;
                decimal precioLibro = ObtenerPrecioLibro(idLibro);
                txtTotal.Text = (precioLibro * cantidad).ToString();
            }
        }
    }
}
