using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EvParcial2.Vistas
{
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'evParcial2DataSet2.vw_VentasConNombreLibro' table. You can move, or remove it, as needed.
            this.vw_VentasConNombreLibroTableAdapter.Fill(this.evParcial2DataSet2.vw_VentasConNombreLibro);
            this.reportViewer1.RefreshReport();
        }

        private void btbBuscar_Click(object sender, EventArgs e)
        {


        }
        }
}
