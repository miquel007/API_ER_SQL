using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication1.Models
{
    public partial class Pieza
    {
        public Pieza()
        {
            Proveedores = new HashSet<Suministra>();
        }
        public int Codigo { get; set; }
        public string nombre { get; set; }
        public virtual ICollection<Suministra> Proveedores { get; set; }

    }
}
