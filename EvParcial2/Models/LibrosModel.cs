using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvParcial2.Models
{
    class LibrosModel
    {
        public int IdLibro { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int? IdProveedor { get; set; }
    }
}
