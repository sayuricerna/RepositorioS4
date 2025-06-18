using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EvParcial2.Vistas.Libros;
using EvParcial2.Vistas.Proveedores;
using EvParcial2.Vistas.Ventas;

namespace EvParcial2.Vistas
{
    public partial class MenuGeneral : Form
    {
        public MenuGeneral()
        {
            InitializeComponent();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            CUVentas ventas = new CUVentas();
            pnlGeneral.Controls.Clear();
            ventas.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(ventas);
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            CUProveedores proveedores = new CUProveedores();
            pnlGeneral.Controls.Clear();
            proveedores.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(proveedores);
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            CULibros libros = new CULibros();
            pnlGeneral.Controls.Clear();
            libros.Dock = DockStyle.Fill;
            pnlGeneral.Controls.Add(libros);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reporte frm = new Reporte();
            frm.Text = "Reporte";
            frm.ShowDialog();
        }
    }
}
