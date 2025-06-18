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

namespace EvParcial2.Vistas.Ventas
{
    public partial class CUVentas : UserControl
    {
        public CUVentas()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            VentasForm frm = new VentasForm("n");
            frm.Text = "Formulario de Ventas";
            frm.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(2);
        }

        private void CUVentas_Load(object sender, EventArgs e)
        {
            var controller = new VentasController();
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
                var idVenta = filaSeleccionada.Cells["IdVenta"].Value;
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditarVenta((int)idVenta);
                }
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    EliminarVenta((int)idVenta);
                }
            }
        }

        public void CargarGrilla(int numero)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            var controller = new VentasController();
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

            // Cargar los datos según la búsqueda o todo
            if (numero == 1)
            {
                dataGridView1.DataSource = controller.GetAll();
            }
            else
            {
                dataGridView1.DataSource = controller.Search(txtBuscar.Text.Trim());
            }

            // Asegúrate de que los nombres de las columnas coincidan con las propiedades del modelo
            dataGridView1.Columns["IdVenta"].Visible = false;
            dataGridView1.Columns["FechaVenta"].HeaderText = "Fecha de Venta";
            dataGridView1.Columns["IdLibro"].HeaderText = "Libro";  // Cambié "Libro" por "IdLibro"
            dataGridView1.Columns["Cantidad"].HeaderText = "Cantidad"; // Cambié "Monto Total" por "Cantidad"
            dataGridView1.Columns["Total"].HeaderText = "Monto Total";  // "Monto Total" está correcto

            // Añadir botones de editar y eliminar
            dataGridView1.Columns.Add(btnEditar);
            dataGridView1.Columns.Add(btnEliminar);
        }



        public void EditarVenta(int id)
        {
            VentasForm venta = new VentasForm(id.ToString());
            venta.ShowDialog();
            CargarGrilla(1); // Recargar la grilla después de editar
        }

        public void EliminarVenta(int id)
        {
            DialogResult cuadroDialogo = MessageBox.Show("¿Está seguro de que desea eliminar esta venta?",
                "Eliminar Venta", MessageBoxButtons.YesNo);
            if (cuadroDialogo == DialogResult.Yes)
            {
                var controller = new VentasController();
                if (controller.Delete(id) == "OK")
                {
                    MessageBox.Show("La venta se ha eliminado con éxito.");
                    CargarGrilla(1); // Recargar la grilla después de eliminar
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
