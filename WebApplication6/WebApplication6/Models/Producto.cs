using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication1.Models
{
    public partial class Producto
    {
        public Producto()
        {
            Venta = new HashSet<Venta>();
        }
        public int Codigo { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }

    }
}
