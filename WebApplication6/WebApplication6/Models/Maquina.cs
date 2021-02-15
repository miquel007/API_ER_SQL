using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication1.Models
{
    public class Maquina
    {
        public Maquina()
        {
            Venta = new HashSet<Venta>();
        }
        public int Codigo { get; set; }
        public int piso { get; set; }
        public virtual ICollection<Venta> Venta { get; set; }
    }
}
