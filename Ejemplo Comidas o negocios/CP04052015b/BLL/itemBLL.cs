using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CP04052015b.BLL
{
    class itemBLL
    {
        private CP04052015bEntidades ent;

        public itemBLL()
        {
            ent = new CP04052015bEntidades();
        }

        // obtener items
        public List<Item> GetItems()
        {
            return ent.Item.ToList();
        }

        // agregar items
        public void Agregar(string nombre, int precio)
        {
            Item nuevoItem = new Item() { Nombre = nombre, Precio = precio };
            ent.Item.AddObject(nuevoItem);
            ent.SaveChanges();
        }

    }
}
