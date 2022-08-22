using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP04052015b.BLL
{
    class VentaBLL
    {
        private CP04052015bEntidades ent;

        public VentaBLL()
        {
            ent = new CP04052015bEntidades();
        }

        // obtener ventas
        public List<Venta> GetVentas()
        {
            return ent.Venta.ToList();
        }

        // agregar ventas

        public void Agregar(DateTime fecha, int pago, int vuelto, int itemId)
        {
            Venta nuevaVenta = new Venta()
            {
                Fecha = fecha,
                Pago = pago,
                Vuelto = vuelto,
                itemID = itemId
            };
            ent.Venta.AddObject(nuevaVenta);
            ent.SaveChanges();
        }

    }
}
