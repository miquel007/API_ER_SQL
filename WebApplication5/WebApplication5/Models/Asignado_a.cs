using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication4.Models
{
    public partial class Asignado_a
    {
        public string? cientifico { get; set; }
        public string? proyecto { get; set; }
        public virtual Cientifico cientificos { get; set; }
        public virtual Proyecto proyectos { get; set; }
    }
}
