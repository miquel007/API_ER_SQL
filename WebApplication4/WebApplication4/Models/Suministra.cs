using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication4.Models
{
    public partial class Suministra
    {
        public int? cod_pieza { get; set; }
        public string? id_proveedor { get; set; }
        public virtual Pieza piezas { get; set; }
        public virtual Proveedor proveedores { get; set; }
    }
}
