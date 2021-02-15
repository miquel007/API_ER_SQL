using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication1.Models
{
    public partial class Cientifico
    {
        public Cientifico()
        {
            Asignado_a = new HashSet<Asignado_a>();
        }
        public string DNI { get; set; }
        public string nomApels { get; set; }
        public virtual ICollection<Asignado_a> Asignado_a { get; set; }

    }
}
