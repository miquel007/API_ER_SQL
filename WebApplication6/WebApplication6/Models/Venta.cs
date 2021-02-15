using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication4.Models
{
    public partial class Venta
    {
        public int? Cajero { get; set; }
        public int? Maquina { get; set; }
        public int? Producto { get; set; }
        public virtual Cajero Cajeros { get; set; }
        public virtual Maquina Maquinas { get; set; }
        public virtual Producto Productos { get; set; }

    }
}
