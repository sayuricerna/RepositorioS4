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

namespace EvParcial2.Vistas.Libros
{
    public partial class CULibros : UserControl
    {
        public CULibros()
        {
            InitializeComponent();
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
                var idLibro = filaSeleccionada.Cells["IdLibro"].Value;
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Editar")
                {
                    EditarLibro((int)idLibro);
                }
                if (dataGridView1.Columns[e.ColumnIndex].HeaderText == "Eliminar")
                {
                    EliminarLibro((int)idLibro);
                }
            }
        }

        private void CULibros_Load(object sender, EventArgs e)
        {
            var controller = new LibrosController();
            dataGridView1.DataSource = "";
            dataGridView1.DataSource = controller.GetAll();
            CargarGrilla(1);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(2);

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            LibrosForm frm = new LibrosForm("n");
            frm.Text = "Formulario de Libros";
            frm.ShowDialog();
        }

        public void CargarGrilla(int numero)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            var controller = new LibrosController();
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
            dataGridView1.Columns["IdLibro"].Visible = false;
            dataGridView1.Columns["Titulo"].HeaderText = "Título del Libro";
            dataGridView1.Columns["Autor"].HeaderText = "Autor";
            dataGridView1.Columns["Editorial"].HeaderText = "Editorial";
            dataGridView1.Columns["Precio"].HeaderText = "Precio";
            dataGridView1.Columns["Stock"].HeaderText = "Stock";
            dataGridView1.Columns["IdProveedor"].Visible = false;

            dataGridView1.Columns.Add(btnEditar);
            dataGridView1.Columns.Add(btnEliminar);
        }
        // Editar libro
        public void EditarLibro(int id)
        {
            LibrosForm libro = new LibrosForm(id.ToString());
            libro.ShowDialog();
            CargarGrilla(1);
        }

        // Eliminar libro
        public void EliminarLibro(int id)
        {
            DialogResult cuadroDialogo = MessageBox.Show("¿Está seguro de que desea eliminar este libro?",
                "Eliminar Libro", MessageBoxButtons.YesNo);
            if (cuadroDialogo == DialogResult.Yes)
            {
                var controller = new LibrosController();
                if (controller.Delete(id) == "OK")
                {
                    MessageBox.Show("El libro se ha eliminado con éxito.");
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
