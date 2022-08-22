using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EV4CristopherPeregrin.BLL
{
    class ClienteBLL
    {
        private EV4CristopherPeregrinEntidades ent = new EV4CristopherPeregrinEntidades();

        public List<Cliente> ObtenerClientes()
        {
            return ent.Cliente.ToList();
        }

        public void AgregarCliente(string rut, string nombres, string apellidos)
        {
            Cliente nuevoCliente = new Cliente()
            {
                Rut = rut,
                Nombres = nombres,
                Apellidos = apellidos
            };

            ent.Cliente.AddObject(nuevoCliente);
            ent.SaveChanges();
        }

        public void BorrarCliente(int clienteID)
        {
            Cliente clienteBorrar = ent.Cliente.Where(c => c.ClienteID == clienteID).FirstOrDefault(); // referencia del objeto

            ent.Cliente.DeleteObject(clienteBorrar);
            ent.SaveChanges();
        }
        public string VerificarPrestamoLibro(int clienteID)
        {
            string msg = "El cliente aun tiene un libro prestado!";

            // busco si el libro esta prestado
            Prestamo objPrestamo = ent.Prestamo.Where(p => p.ClienteID == clienteID && p.FechaDevolucion == null).FirstOrDefault();

            if (objPrestamo == null)
            {
                msg = "Cliente Borrado";
                BorrarCliente(clienteID);
            }
            return msg;
        }
    }
}
