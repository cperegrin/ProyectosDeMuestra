﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP04052015b
{
    partial class Item
    {
        public override string ToString()
        {
            return string.Format("{0} [${1}]", Nombre, Precio);
        }
    }
}
