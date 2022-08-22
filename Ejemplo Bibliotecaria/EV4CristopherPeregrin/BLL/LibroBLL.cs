using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV4CristopherPeregrin.BLL
{
    class LibroBLL
    {
        private EV4CristopherPeregrinEntidades ent = new EV4CristopherPeregrinEntidades();

        public List<Libro> ObtenerLibros()
        {
            return ent.Libro.ToList();
        }

        public void AgregarLibro(string numSerie, string titulo, string autor, int edicion)
        {
            Libro nuevoLibro = new Libro()
            {
                NumeroSerie = numSerie,
                Titulo = titulo,
                Autor = autor,
                AñoEdicion = edicion
            };

            ent.Libro.AddObject(nuevoLibro);
            ent.SaveChanges();
        }

        public void BorrarLibro(int libroID)
        {
            Libro libroBorrar = ent.Libro.Where(l => l.LibroID == libroID).FirstOrDefault();

            ent.Libro.DeleteObject(libroBorrar);
            ent.SaveChanges();
        }

        public string VerificarPrestamoLibro(int libroID)
        {
            string msg = "El libro sigue prestado";

            // busco si el libro esta prestado
            Prestamo objPrestamo = ent.Prestamo.Where(p => p.LibroID == libroID && p.FechaDevolucion == null).FirstOrDefault();

            if (objPrestamo == null)
            {
                msg = "Libro Borrado";
                BorrarLibro(libroID);
            }
            return msg;
        }
    }
}
