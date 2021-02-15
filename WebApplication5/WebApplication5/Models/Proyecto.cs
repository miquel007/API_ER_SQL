using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication1.Models
{
    public class Proyecto
    {
        public Proyecto()
        {
            Asignado_a = new HashSet<Asignado_a>();
        }
        public string ID { get; set; }
        public string nombre { get; set; }
        public int horas { get; set; }
        public virtual ICollection<Asignado_a> Asignado_a { get; set; }
    }
}
