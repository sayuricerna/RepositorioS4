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

namespace EvParcial2.Vistas.Proveedores
{
    public partial class ProveedoresForm : Form
    {
        public bool modoEdicion = false;
        public int id = 0;  // Para editar un proveedor específico

        public ProveedoresForm(string modo)
        {
            if (modo != "n")
            {
                this.modoEdicion = true;
                this.id = int.Parse(modo);  // Si no es nuevo, obtén el id del proveedor
            }
            InitializeComponent();
        }

        private void ProveedoresForm_Load(object sender, EventArgs e)
        {
            if (!this.modoEdicion)
            {
                lblFrm.Text = "Ingreso de Nuevo Proveedor";
            }
            else
            {
                lblFrm.Text = "Actualización de Proveedor";
                var proveedorController = new ProveedoresController();
                var proveedor = proveedorController.GetAll().Find(p => p.IdProveedor == this.id);  // Buscar proveedor por ID
                txtNombre.Text = proveedor.Nombre;
                txtContacto.Text = proveedor.Contacto;
                txtTelefono.Text = proveedor.Telefono;
                txtDireccion.Text = proveedor.Direccion;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validar los campos
            if (txtNombre.Text == "" || txtContacto.Text == "" || txtTelefono.Text == "" || txtDireccion.Text == "")
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            try
            {
                // Crear el objeto proveedor
                var proveedor = new ProveedoresModel()
                {
                    Nombre = txtNombre.Text,
                    Contacto = txtContacto.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text
                };

                var proveedorController = new ProveedoresController();

                if (!this.modoEdicion)  // Si no es edición, insertar nuevo proveedor
                {
                    var resultado = proveedorController.Insert(proveedor);
                    if (resultado == "OK")
                    {
                        MessageBox.Show("Proveedor guardado con éxito");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Error al guardar: {resultado}");
                    }
                }
                else  // Si es edición, actualizar proveedor
                {
                    proveedor.IdProveedor = this.id;  // Establecer el ID del proveedor
                    var resultado = proveedorController.Update(proveedor);
                    if (resultado == "OK")
                    {
                        MessageBox.Show("Proveedor actualizado con éxito");
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
    }
}
