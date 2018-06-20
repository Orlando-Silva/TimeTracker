using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Entidades
{
    public class Periodo
    {
        public int ID { get; set; }
        public DateTime Inicio { get; protected set; }
        public DateTime Fim { get; protected set; }
    }
}
