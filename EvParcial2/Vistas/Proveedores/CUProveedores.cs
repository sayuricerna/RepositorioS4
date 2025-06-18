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

namespace EvParcial2.Vistas.Proveedores
{
    public partial class CUProveedores : UserControl
    {
        public CUProveedores()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ProveedoresForm frm = new ProveedoresForm("n");
            frm.Text = "Formulario de Proveedores";
            frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(2);
        }

        private void CUProveedores_Load(object sender, EventArgs e)
        {
            var controller = new ProveedoresController();
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = controller.GetAll();
            CargarGrilla(1);
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                var filaSeleccionada = dataGridView1.Rows[e.RowIndex];
                var idProveedor = filaSeleccionada.Cells["IdProveedor"].Value;
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditarProveedor((int)idProveedor);
                }
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    EliminarProveedor((int)idProveedor);
                }
            }
        }
        public void CargarGrilla(int numero)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            var controller = new ProveedoresController();
            var autoIncremento = new DataGridViewTextBoxColumn
            {
                HeaderText = "N.-",
                ReadOnly = true
            };
            dataGridView1.Columns.Add(autoIncremento);

            var btnEditar = new DataGridViewButtonColumn
            {
                HeaderText = "Editar",
                Text = "Editar",
                UseColumnTextForButtonValue = true
            };

            var btnEliminar = new DataGridViewButtonColumn
            {
                HeaderText = "Eliminar",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true
            };

            if (numero == 1)
            {
                dataGridView1.DataSource = controller.GetAll();
            }
            else
            {
                dataGridView1.DataSource = controller.Search(txtBuscar.Text.Trim());
            }

            // Configurar columnas del DataGridView
            dataGridView1.Columns["IdProveedor"].Visible = false;
            dataGridView1.Columns["Nombre"].HeaderText = "Nombre del Proveedor";
            dataGridView1.Columns["Contacto"].HeaderText = "Contacto";
            dataGridView1.Columns["Telefono"].HeaderText = "Teléfono";
            dataGridView1.Columns["Direccion"].HeaderText = "Dirección";

            dataGridView1.Columns.Add(btnEditar);
            dataGridView1.Columns.Add(btnEliminar);
        }

        // Editar proveedor
        public void EditarProveedor(int id)
        {
            ProveedoresForm proveedor = new ProveedoresForm(id.ToString());
            proveedor.ShowDialog();
            CargarGrilla(1);
        }

        // Eliminar proveedor
        public void EliminarProveedor(int id)
        {
            DialogResult cuadroDialogo = MessageBox.Show("¿Está seguro de que desea eliminar este proveedor?",
                "Eliminar Proveedor", MessageBoxButtons.YesNo);
            if (cuadroDialogo == DialogResult.Yes)
            {
                var controller = new ProveedoresController();
                if (controller.Delete(id) == "OK")
                {
                    MessageBox.Show("El proveedor se ha eliminado con éxito.");
                    CargarGrilla(1);
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al eliminar.");
                }
            }
            else
            {
                MessageBox.Show("El usuario canceló la eliminación.");
            }
        }
    }
}
