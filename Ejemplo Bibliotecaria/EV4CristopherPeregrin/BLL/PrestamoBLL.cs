using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV4CristopherPeregrin.BLL
{
    class PrestamoBLL
    {
        private EV4CristopherPeregrinEntidades ent = new EV4CristopherPeregrinEntidades();

        public List<Prestamo> ObtenerPrestamos()
        {
            return ent.Prestamo.ToList();
        }

        public void AgregarPrestamo(DateTime fPrestamo, DateTime fLimite, int libroID, int clienteID)
        {
                Prestamo nuevoPrestamo = new Prestamo()
                {
                    FechaPrestamo = fPrestamo,
                    FechaLimite = fLimite,
                    LibroID = libroID,
                    ClienteID = clienteID,
                };

                ent.Prestamo.AddObject(nuevoPrestamo);
                ent.SaveChanges();
        }

        public string VerificarPrestamo(DateTime fPrestamo, DateTime fLimite, int libroID, int clienteID)
        {
            string msg = "El libro sigue prestado";

            // busco si el libro esta prestado
            Prestamo objPrestamo = ent.Prestamo.Where(p => p.LibroID == libroID && p.FechaDevolucion == null).FirstOrDefault();

            if (objPrestamo==null)
            {
                msg = "Prestamo Realizado!";
                AgregarPrestamo(fPrestamo,fLimite,libroID,clienteID);
            }
            return msg;
        }

        public string AgregarDevolucion(string numSerie, DateTime fDevolucion) 
        {
            Libro libroDev = ent.Libro.Where(l => l.NumeroSerie == numSerie).FirstOrDefault();

            string msg = "Coloque un numero de Serie Correcto"; // en caso de que no coloque numero de serie correcto

            if (libroDev != null) // si existe el objeto libro
            {
                int libroID = libroDev.LibroID;

                Prestamo prestamoDev = ent.Prestamo.Where(p => p.LibroID == libroID && p.FechaDevolucion == null).FirstOrDefault();
                DateTime fLimite = (DateTime)prestamoDev.FechaLimite;

                int dias = (fDevolucion - fLimite).Days; // tomar dias de atraso
                    if (dias >0)
                    { // en caso de que se atrase
                        msg = string.Format("Fecha Limite: {0:dd/MM/yyyy} \nDias de Atraso: {1}", fLimite, dias);
                    }
                    else
                    { // si no esta atrasado mensaje normal
                        msg = "Devolucion Realizada!";
                    }
                    prestamoDev.FechaDevolucion = fDevolucion;

                    //ent.AcceptAllChanges(); // no son cambios permanentes ?
                    //ent.DetectChanges(); //
                    ent.SaveChanges();
            }
            return msg;
        }
       
    }
}
