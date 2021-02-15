using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication1.Models
{
    public partial class Cajero
    {
        public Cajero()
        {
            Venta = new HashSet<Venta>();
        }
        public int Codigo { get; set; }
        public string nomApels { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }

    }
}