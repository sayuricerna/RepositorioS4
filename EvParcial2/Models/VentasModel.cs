using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvParcial2.Models
{
     class VentasModel
    {
        public int IdVenta { get; set; }
        public int IdLibro { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaVenta { get; set; }
    }
}
