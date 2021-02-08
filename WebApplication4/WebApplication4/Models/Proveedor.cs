using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication1.Models
{
    public class Proveedor
    {
        public Proveedor()
        {
            Proveedores = new HashSet<Suministra>();
        }
        public string ID { get; set; }
        public string nombre { get; set; }
        public virtual ICollection<Suministra> Proveedores { get; set; }
    }
}
