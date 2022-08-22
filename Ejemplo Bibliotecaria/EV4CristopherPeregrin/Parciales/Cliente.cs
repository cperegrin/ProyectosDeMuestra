using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV4CristopherPeregrin
{
    partial class Cliente
    {
        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Rut, Nombres, Apellidos);
        }
    }
}
