using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EV4CristopherPeregrin.BLL;

namespace EV4CristopherPeregrin
{
    partial class Libro
    {
        public override string ToString()
        {
            return string.Format("{0} {1}", NumeroSerie, Titulo);
        }

        public string GetEstadistica { get { return string.Format("{0}", ObtenerCantidad(LibroID)); } }

        public int ObtenerCantidad(int libroID)
        {
            PrestamoBLL pbll = new PrestamoBLL();
            List<Prestamo> listaPrestamos = pbll.ObtenerPrestamos();

            int cantidad = 0;
            foreach (Prestamo prestamo in listaPrestamos)
            {
                if (prestamo.LibroID == libroID)
                {
                    cantidad = (cantidad + 1);
                }
            }

            return cantidad;
        }
    }
}
